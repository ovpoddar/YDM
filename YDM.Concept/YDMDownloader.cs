using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime;
using System.Text;
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
        public string FinalFile { get; set; }
        public string FinalFileName { get; set; }
        public DownloadingFileDetails RemoteFile { get; set; }
        public DownloadingFileDetails LocalFile { get; set; }

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

        public EventHandler<DownloadingFileDetails> PerProcessing;
        public EventHandler<ProcessingModel> processing;
        public EventHandler<DownloadState> DownloadstateChange;

        private readonly List<FileInformation> _files = new List<FileInformation>();
        private readonly List<string> _fileOutputDirectory = new List<string>();
        private readonly CancellationTokenSource _cancellationTokenSorce;
        private readonly CancellationToken _cancellationToken;
        private Thread _downloadThrade;
        private volatile bool _canDownload;


        //TODO: fine a better way to store the final file
        // because after adding the path in the _fileOutputDirectory that can be gone
        public YDMDownloader(FileInformation audio, string output, string title)
        {
            if (!Directory.Exists(output))
                throw new ArgumentException(null, nameof(output));

            title = FixFileNameIfRequired(title);
            FinalFileName = title + "." + audio.FileExtenction.Split(";")[0];
            var path = Path.Combine(output, FinalFileName);

            _fileOutputDirectory.Add(path);

            FinalFile = path;

            _cancellationTokenSorce = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSorce.Token;
            _files.Add(audio);
            DownloadState = DownloadState.Initialized;

            LocalFile = Request.GetLocalFileDetails(_fileOutputDirectory);


            try
            {
                RemoteFile = Request.GetFileDetails(_files);
            }
            catch
            {

            }

        }

        public YDMDownloader(FileInformation video, FileInformation audio, string output, string title)
        {
            if (!Directory.Exists(output))
                throw new ArgumentException(null, nameof(output));

            title = FixFileNameIfRequired(title);

            var path = Path.Combine(output, title + "." + video.FileExtenction.Split(";")[0]);
            var tempPath = Path.Combine(Path.GetTempPath(), title + "." + audio.FileExtenction.Split(";")[0]);

            _fileOutputDirectory.Add(path);
            _fileOutputDirectory.Add(tempPath);

            FinalFile = path;

            _cancellationTokenSorce = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSorce.Token;
            _files.Add(video);
            _files.Add(audio);

            DownloadState = DownloadState.Initialized;

            LocalFile = Request.GetLocalFileDetails(_fileOutputDirectory);

            try
            {
                RemoteFile = Request.GetFileDetails(_files);
            }
            catch
            {
            }

        }

        private string FixFileNameIfRequired(string name)
        {
            var invalidChars = new StringBuilder();
            invalidChars.Append(Path.GetInvalidFileNameChars());
            invalidChars.Append(Path.GetInvalidPathChars());
            foreach (var c in invalidChars.ToString())
            {
                name = name.Replace(c.ToString(), "");
            }
            return name;
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

        private async Task Processing()
        {
            DownloadState = DownloadState.GettingHeaders;

            if (RemoteFile == null)
                RemoteFile = Request.GetFileDetails(_files);

            PerProcessing.Raise(this, RemoteFile);



            for (var i = 0; i < _files.Count; i++)
            {
                var file = new FileOutputProcesser(_fileOutputDirectory[i]);
                if (RemoteFile.FileSizes[i] <= LocalFile.FileSizes[i])
                    file.Remove();
                else if (RemoteFile.FileSizes[i] == LocalFile.FileSizes[i])
                    continue;

                try
                {
                    var filesize = LocalFile.FileSizes[i];
                    var request = Request.CreateHttpRequest(_files[i].Uri, filesize);
                    var bytesRead = 0;
                    var buffer = new byte[4 * 1024];
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
                            processing.Raise(this, new ProcessingModel(filesize, RemoteFile.FileSizes[i]));
                            DownloadState = DownloadState.Downloading;
                        }
                    }

                    if (!_canDownload && RemoteFile.FileSizes[i] > filesize)
                        DownloadState = DownloadState.Paused;
                }
                catch
                {
                    DownloadState = DownloadState.Stopped;
                }
            }
            if (DownloadState == DownloadState.Downloading && _canDownload)
                DownloadState = DownloadState.Completed;

        }
    }
}
