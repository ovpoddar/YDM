using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.ExtendClasses;
using YDM.Concept.Helper;
using YDM.Concept.Models;
using YDM.Concept.Processer;

namespace YDM.Concept
{
    public class YDM
    {
        public EventHandler<IQueryable<VideoModel>> VideoFound;
        public EventHandler<Exception> ErrorFound;

        public async Task ParseVideoAsync(string videoUri)
        {
            var url = UrlAnalyzer.Check(videoUri);
            if (url.Success || url.Exception == null)
            {
                if (!url.Result.IsList)
                {
                    var tasks = new List<Task<VideoModel>>
                    {
                        Task.Run(() => GetVideoAsync(url))
                    };

                    var result = await Task.WhenAll(tasks);
                    VideoFound.Raise(this, new List<VideoModel>(result).AsQueryable());
                }
                else
                {
                    await GetVideoIDsAsync(url);
                }
            }
            else
            {
                ErrorFound.Raise(this, new Exception(url.Exception));
                return;
            }
        }

        private async Task<VideoModel> GetVideoAsync(Results<AnalysisReport> videoUri)
        {
            var process = new SorceProcesser();
            var responseFromServer = await RequestProcesser.DownloadWebSite(videoUri);

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

        private async Task GetVideoIDsAsync(Results<AnalysisReport> videoUri)
        {
            var process = new SorceProcesser();
            var responseFromServer = await RequestProcesser.DownloadWebSite(videoUri);
            var lists =  process.ParseListCode(responseFromServer);
            foreach (var link in lists)
            {
                var url = $"{Configuration.Scheme}{Configuration.Host}/watch?v={link}";
                var analiser = UrlAnalyzer.Check(url);
                var result = await GetVideoAsync(analiser);
                var model = new List<VideoModel>();
                model.Add(result);
                VideoFound.Raise(this, model.AsQueryable());
            }
        }
    }
}
