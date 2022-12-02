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
    // TODO: Better Libary approtch with Interface and settings object
    public class YDMVideoProcesser
    {
        public EventHandler StartProcess;
        public EventHandler EndProcess;
        public EventHandler<Exception> ErrorOccered;
        public EventHandler<VideoModel> VideoFound;

        private readonly string _uri;
        private object _isProcessHasStart;

        public YDMVideoProcesser(string uri) =>
            _uri = uri;

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
            try
            {
                var responseFromServer = await new RequestProcesser(ref videoUri).DownloadString(false, token);
                var result = await process.ParseVideoCode(responseFromServer, token, true);
                if (result.Success)
                    return new VideoModel
                    {
                        Details = result.Details,
                        Streans = result.Streans,
                        Thumbnails = result.Thumbnails
                    };
                ErrorOccered.Raise(this, process.Exception);
                return new VideoModel();
            }
            catch
            {
                ErrorOccered.Raise(this, process.Exception);
                return new VideoModel();
            }
        }

        /// <summary>
        /// it will process the link and return a process version of the link 
        /// </summary>
        /// <param name="token">Cancellation token to stop the operation in any moment</param>
        /// <returns>ValueTask<IEnumerable<UriAnalyzer>> which include every thing the ydm need to process the link</returns>
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
                        ErrorOccered.Raise(this, new Exception(ex.Message));
                        return new List<UriAnalyzer>().AsQueryable();
                        throw new Exception();
                    }
                }
            }
            else
            {
                ErrorOccered.Raise(this, new Exception(uri.Exception.Message));
                return null;
            }
        }

        /// <summary>
        /// this method will process the links and raised the VideoFound Event
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
                    if (video.Streans.Any())
                        VideoFound.Raise(this, video);
                }

                EndProcess.Raise(this, EventArgs.Empty);
            });
        }

    }
}
