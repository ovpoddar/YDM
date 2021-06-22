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
        public EventHandler<RemoteFIleInformation> PerProcessing;
        public EventHandler<double> processing;
        public EventHandler<DownloadState> DownloadstateChange;

        private DownloadState _downloadState;

        public DownloadState DownloadState
        {
            get => _downloadState;
            private set
            {
                DownloadstateChange.Raise(this, value);
                _downloadState = value;
            }
        }

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
            DownloadState = DownloadState.Initialized;
        }

        public YDMDownloader(FileInformation audio, string output, string title)
        {
            _files.Add(audio);
            _outputFolder = Path.Combine(output, title);
            _cancellationTokenSorce = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSorce.Token;
            DownloadState = DownloadState.Initialized;
        }

        private async Task Processing()
        {
            DownloadState = DownloadState.GettingHeaders;
            var fIleInformation = Request.GetFileDetails(_files);
            PerProcessing.Raise(this, fIleInformation);

            for (int i = 0; i < _files.Count; i++)
            {
                var file = new FileOutputProcesser(_outputFolder, fIleInformation.FileSizes[i], _files[i]);

                if (!file._isDownload)
                    continue;

                try
                {
                    var request = Request.CreateHttpRequest(_files[i].Uri, file._downloaded);
                    var filesize = file._downloaded;
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
                                fileStream.Dispose();
                                responceStream.Dispose();
                                responce.Dispose();

                                file.Remove();

                                _cancellationToken.ThrowIfCancellationRequested();
                            }

                            await fileStream.WriteAsync(buffer, 0, bytesRead, _cancellationToken);
                            filesize += bytesRead;
                            processing.Raise(this, filesize);
                            DownloadState = DownloadState.Downloading;
                        }
                    }

                    if (!_canDownload && fIleInformation.FileSizes[i] > filesize)
                        DownloadState = DownloadState.Paused;
                }
                catch (Exception)
                {
                    DownloadState = DownloadState.Stopped;
                }
            }
            if (!(DownloadState == DownloadState.Paused || _canDownload))
                DownloadState = DownloadState.Completed;
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
            if (_downloadState == DownloadState.Stopped || _downloadState == DownloadState.Paused)
                throw new Exception("Can't perform this method");
            else
                _canDownload = false;
        }

        public void Resume()
        {
            if (_downloadState == DownloadState.Paused && _canDownload == false && _downloadState != DownloadState.Stopped)
            {
                _canDownload = true;
                Start();
            }
            else
                throw new Exception("Can't perform this method");
        }

        public void Stop() =>
            _cancellationTokenSorce.Cancel();

        public void Restart()
        {
            Stop();
            Start();
        }
    }
}
