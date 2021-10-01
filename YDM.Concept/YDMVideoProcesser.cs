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
    // TODO: what happend when link expire

    // TODO: need a better processing pipeline
    public class YDMVideoProcesser
    {
        public EventHandler StartProcess;
        public EventHandler EndProcess;

        private readonly string _uri;
        private readonly EventHandler<Exception> _errorFound;
        private readonly EventHandler<VideoModel> _videoFound;
        private object _isProcessHasStart;
        public YDMVideoProcesser(string uri, EventHandler<VideoModel> videoHandler, EventHandler<Exception> exctptionHandler)
        {
            _uri = uri;
            _videoFound += videoHandler;
            _errorFound += exctptionHandler;
        }

        /// <summary>
        /// Start the processing to raised videofound event
        /// </summary>
        /// <param name="token">calcenation token to stop the opration in any moment</param>
        public async ValueTask StartTaskAsync(CancellationToken token)
        {
            _isProcessHasStart = StartProcess.Raise(this, EventArgs.Empty);
            var ids = await GetIDsAsync(token);
            GetVideos(ids, token);
        }

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

        /// <summary>
        /// it will return all the ids of the link or playlist
        /// </summary>
        /// <param name="token">calcenation token to stop the opration in any moment</param>
        /// <returns>ValueTask<IEnumerable<UriAnalyzer>> which inclue every thing the ydm need to process the link</returns>
        public async ValueTask<IEnumerable<UriAnalyzer>> GetIDsAsync(CancellationToken token)
        {
            if (_isProcessHasStart is null)
                _isProcessHasStart = StartProcess.Raise(this, EventArgs.Empty);
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
                        return new List<UriAnalyzer>().AsQueryable();
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

        /// <summary>
        /// this method will raised on every time when the video link will be processed
        /// </summary>
        /// <param name="uris">details about uri which you want to download</param>
        /// <param name="token">calcenation token to stop the opration in any moment</param>
        public void GetVideos(IEnumerable<UriAnalyzer> uris, CancellationToken token)
        {
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

                EndProcess.Raise(this, EventArgs.Empty);
            });
        }

    }
}
