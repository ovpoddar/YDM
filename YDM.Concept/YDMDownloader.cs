using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using YDM.Concept.ExtendClasses;
using YDM.Concept.Helper;
using YDM.Concept.Models;
using YDM.Concept.Processer;

namespace YDM.Concept
{
    public class YDMDownloader
    {
        public EventHandler PerProcessingStart;
        public EventHandler<RemoteFIleInformation> PerProcessingEnd;
        public EventHandler ProcessingStart;
        public EventHandler<double> processing;
        public EventHandler ProcessingEnd;
        public DownloadState DownloadState;

        private List<FileInformation> _files = new List<FileInformation>();
        private readonly string _outputFolder;
        private volatile bool _canDownload;
        private Thread _downloadThrade;
        private readonly CancellationTokenSource _cancellationTokenSorce;
        private readonly CancellationToken _cancellationToken;

        public YDMDownloader(FileInformation video, FileInformation audio, string output, string title)
        {
            _files.Add(video);
            _files.Add(audio);
            _outputFolder = Path.Combine(output, title);
            _cancellationTokenSorce = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSorce.Token;
        }

        public YDMDownloader(FileInformation audio, string output, string title)
        {
            _files.Add(audio);
            _outputFolder = Path.Combine(output, title);
            _cancellationTokenSorce = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSorce.Token;
        }

        private async Task Processing()
        {

            PerProcessingStart.Raise(this, EventArgs.Empty);
            DownloadState = DownloadState.GettingHeaders;
            var fIleInformation = Request.GetFileDetails(_files);
            PerProcessingEnd.Raise(this, fIleInformation);
            ProcessingStart.Raise(this, EventArgs.Empty);

            for (int i = 0; i < _files.Count; i++)
            {
                var file = new FileOutputProcesser(_outputFolder, fIleInformation.FileSizes[i], _files[i]);

                if (!file.candownload)
                    continue;

                try
                {
                    var request = Request.CreateHttpRequest(_files[i].Uri, file.Downloaded);
                    var filesize = file.Downloaded;
                    var bytesRead = 0;
                    var buffer = new byte[8];
                    using var responce = await request.GetResponseAsync();
                    using var responceStream = responce.GetResponseStream();
                    DownloadState = DownloadState.GettingResponse;
                    using (var fileStream = file.GetStream())
                    {
                        while (_canDownload && (bytesRead = responceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            if (_cancellationToken.IsCancellationRequested)
                            {
                                responce.Dispose();
                                responceStream.Dispose();
                                fileStream.Dispose();

                                file.Remove();

                                _cancellationToken.ThrowIfCancellationRequested();
                            }

                            await fileStream.WriteAsync(buffer, 0, bytesRead, _cancellationToken);
                            filesize += bytesRead;
                            processing.Raise(this, filesize);
                            DownloadState = DownloadState.Downloading;

                        }
                    }
                    DownloadState = DownloadState.Completed;
                }
                catch (Exception)
                {
                    DownloadState = DownloadState.Stopped;
                }
            }
            ProcessingEnd.Raise(this, EventArgs.Empty);
        }

        public void Start()
        {
            _downloadThrade = new Thread(async () =>
            {
                _canDownload = true;
                await Processing();
            });
            _downloadThrade.Start();
        }

        public void Pause()
        {
            if (DownloadState != DownloadState.Downloading || DownloadState != DownloadState.Completed && _canDownload == false)
            {
                throw new Exception("Can't perform this operation");
            }
            else
            {
                _canDownload = false;
            }
        }

        public void Resume()
        {
            if (DownloadState != DownloadState.Downloading || DownloadState != DownloadState.Completed && _canDownload == false)
            {
                _canDownload = true;
                Start();
            }
            else
            {
                throw new Exception("Can't perform this operation");
            }
        }

        public void Stop() =>
            _cancellationTokenSorce.Cancel();
    }
}
