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
        public EventHandler StartHandler;
        public EventHandler EndHandler;

        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly string _uri;
        private readonly EventHandler<Exception> _errorFound;
        private readonly EventHandler<VideoModel> _videoFound;

        public YDMVideoProcesser(string uri, EventHandler<VideoModel> videoHandler, EventHandler<Exception> exctptionHandler)
        {
            _uri = uri;
            _videoFound += videoHandler;
            _errorFound += exctptionHandler;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async ValueTask<IEnumerable<UriAnalyzer>> GetTaskAsync()
        {
            var token = _cancellationTokenSource.Token;
            var ids = await GetIDsAsync(token);
            GetVideos(ids, token);
            return ids;
        }

        public void CancelProcesse() =>
            _cancellationTokenSource.Cancel();

        private async Task<VideoModel> GetVideoAsync(UriAnalyzer videoUri, CancellationToken token)
        {
            var process = new SorceProcesser();
            var responseFromServer = await new RequestProcesser(videoUri.Url).DownloadString(false, token);

            var result = await process.ParseVideoCode(responseFromServer, token);
            if (result)
                return new VideoModel
                {
                    Detais = process.Details,
                    Lists = process.Streans,
                    Thumbnails = process.Thumbnails
                };
            _errorFound.Raise(this, process.Exception);
            return new VideoModel();
        }

        private async ValueTask<IEnumerable<UriAnalyzer>> GetIDsAsync(CancellationToken token)
        {
            var uri = new UriAnalyzer(_uri);
            if (uri.IsProcessable || uri.Exception == null)
            {
                if (!uri.IsList)
                    return new List<UriAnalyzer>()
                    {
                        uri
                    }.AsEnumerable();
                else
                {
                    try
                    {
                        var responseFromServer = await new RequestProcesser(uri.Url).DownloadString(false, token);
                        var process = new SorceProcesser();
                        return process.ParseListCode(responseFromServer);
                    }
                    catch (Exception ex)
                    {
                        _errorFound.Raise(this, new Exception(ex.Message));
                        return null;
                        throw new Exception();
                    }
                }
            }
            else
            {
                _errorFound.Raise(this, new Exception(uri.Exception.Message));
                return null;
            }
        }

        private void GetVideos(IEnumerable<UriAnalyzer> uris, CancellationToken token)
        {
            StartHandler.Raise(this, EventArgs.Empty);
            Task.Run(async () =>
            {
                foreach (var uri in uris.Where(uri => uri.IsProcessable))
                {
                    if (token.IsCancellationRequested)
                        break;
                    var video = await GetVideoAsync(uri, token);
                    if (video.Lists.Any())
                        _videoFound.Raise(this, video);
                }
            });
            EndHandler.Raise(this, EventArgs.Empty);
        }

    }
}
