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
    public class YDM
    {
        public EventHandler<Exception> ErrorFound;
        public EventHandler StartHandler;
        public EventHandler EndHandler;

        public async ValueTask<IEnumerable<UriAnalyzer>> GetIDsAsync(string videoUri)
        {
            var uri = new UriAnalyzer(videoUri);
            if (uri.IsProcessable || uri.Exception == null)
            {
                if (uri.IsList)
                {
                    var process = new SorceProcesser();
                    var responseFromServer = await RequestProcesser.DownloadWebSite(uri.Url);
                    return process.ParseListCode(responseFromServer);
                }
                else
                {
                    return new List<UriAnalyzer>()
                    {
                        uri
                    }.AsEnumerable();
                }
            }
            else
            {
                ErrorFound.Raise(this, new Exception(uri.Exception.Message));
                return null;
            }
        }

        public async Task GetVideos(IEnumerable<UriAnalyzer> uris, IProgress<VideoModel> progress, CancellationToken token)
        {
            StartHandler.Raise(this, EventArgs.Empty);
            foreach (var uri in uris.Where(uri => uri.IsProcessable))
            {
                if (token.IsCancellationRequested)
                    break;
                var video = await GetVideoAsync(uri);
                progress.Report(video);
            }

            EndHandler.Raise(this, EventArgs.Empty);
        }

        private async Task<VideoModel> GetVideoAsync(UriAnalyzer videoUri)
        {
            var process = new SorceProcesser();

            var responseFromServer = await RequestProcesser.DownloadWebSite(videoUri.Url);

            var result = await process.ParseVideoCode(responseFromServer);
            if (result)
                return new VideoModel
                {
                    Detais = process.Details,
                    Lists = process.Streans
                };
            ErrorFound.Raise(this, process.Exception);
            return new VideoModel();
        }

    }
}
