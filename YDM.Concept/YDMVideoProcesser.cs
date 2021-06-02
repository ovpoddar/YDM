using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YDM.Concept.ExtendClasses;
using YDM.Concept.Helper;
using YDM.Concept.Models;
using YDM.Concept.Processer;

namespace YDM.Concept
{
    public class YDMVideoProcesser
    {
        public EventHandler<Exception> ErrorFound;
        public EventHandler StartHandler;
        public EventHandler EndHandler;

        private CancellationTokenSource _cancellationTokenSource;

        //// TODO: make it better way to flow the application thread
        public async ValueTask<IEnumerable<UriAnalyzer>> GetIDsAsync(string videoUri)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var uri = new UriAnalyzer(videoUri);
            if (uri.IsProcessable || uri.Exception == null)
            {
                if (!uri.IsList)
                {
                    return new List<UriAnalyzer>()
                    {
                        uri
                    }.AsEnumerable();
                }
                else
                {
                    try
                    {
                        var responseFromServer = await new RequestProcesser(uri.Url).DownloadString(false, _cancellationTokenSource.Token);
                        var process = new SorceProcesser();
                        return process.ParseListCode(responseFromServer);
                    }
                    catch (Exception ex)
                    {
                        ErrorFound.Raise(this, new Exception(ex.Message));
                        return null;
                        throw new Exception();
                    }
                }
            }
            else
            {
                ErrorFound.Raise(this, new Exception(uri.Exception.Message));
                return null;
            }
        }

        public void GetVideos(IEnumerable<UriAnalyzer> uris, IProgress<VideoModel> progress)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;
            StartHandler.Raise(this, EventArgs.Empty);
            Task.Run(async () =>
            {
                foreach (var uri in uris.Where(uri => uri.IsProcessable))
                {
                    if (token.IsCancellationRequested)
                        break;
                    var video = await GetVideoAsync(uri, token);
                    if (video.Lists.Any())
                        progress.Report(video);
                }
            });
            EndHandler.Raise(this, EventArgs.Empty);
        }

        public void CancelProcesse() => _cancellationTokenSource.Cancel();

        //// TODO: make it better way to flow the application thread
        private async Task<VideoModel> GetVideoAsync(UriAnalyzer videoUri, CancellationToken token)
        {
            var process = new SorceProcesser();
            try
            {
                var responseFromServer = await new RequestProcesser(videoUri.Url).DownloadString(false, token);

                var result = await process.ParseVideoCode(responseFromServer, token);
                if (result)
                    return new VideoModel
                    {
                        Detais = process.Details,
                        Lists = process.Streans,
                        Thumbnails = process.Thumbnails
                    };
                ErrorFound.Raise(this, process.Exception);
                return new VideoModel();
            }
            catch (Exception ex)
            {
                ErrorFound.Raise(this, ex.Message);
                return new VideoModel();
                throw new Exception();
            }
        }

    }
}
