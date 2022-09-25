using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.ExtendClasses;
using YDM.Concept.Helper;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    public class SorceProcesser
    {
        public event EventHandler<VideoProcessModel> ProcessedVideo;
        public Exception Exception { get; set; }

        public async ValueTask ParseVideoCode(string sorce, CancellationToken cancellationToken)
        {
            var result = new VideoProcessModel();
            try
            {
                var playerResponse = GetPlayerResponse(sorce, Configuration.VideoScript);
                var js = GetBaseJS(sorce);

                result = GetVideoDetails(sorce, playerResponse, Configuration.VideoTitle, result);
                result = GetThumbnails(playerResponse, result);

                if (!string.IsNullOrWhiteSpace(result.Details[Configuration.LiveVideo.Path] as string) || result.Details[Configuration.LiveVideo.Path] as string == "true")
                {
                    result.Exception = new Exception("Video is not valid or it's live");
                    result.Success = false;
                }

                var format = playerResponse.RootElement.FindElement(Configuration.Format.Path);
                var adaptiveFormats = playerResponse.RootElement.FindElement(Configuration.AdaptiveFormats.Path);

                if (format.ValueKind == JsonValueKind.Undefined || adaptiveFormats.ValueKind == JsonValueKind.Undefined)
                {
                    format = playerResponse.RootElement.GetProperty(Configuration.Format);
                    adaptiveFormats = playerResponse.RootElement.GetProperty(Configuration.AdaptiveFormats);
                }

                var Lists = LinkProcesser.GetFormatsStream(format.EnumerateArray()).Aggregate(LinkProcesser.GetAdaptiveFormatsStream(adaptiveFormats.EnumerateArray()), (list, item) =>
                {
                    list.Append(item);
                    return list;
                });

                var requestProcesser = new RequestProcesser(js);

                var baseJs = await requestProcesser.DownloadString(true, cancellationToken);

                result.Streans = LinkProcesser.FilterUrls(Lists, baseJs);
                result.Success = true;
                ProcessedVideo.Raise(this, result);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
                ProcessedVideo.Raise(this, result);
            }
        }

        private VideoProcessModel GetThumbnails(JsonDocument playerResponse, VideoProcessModel result)
        {
            var value = playerResponse.RootElement.GetProperty(Configuration.Thumbnails).ToString();
            result.Thumbnails = JsonSerializer.Deserialize<List<Thumbnail>>(value);
            return result;
        }

        public IEnumerable<UriAnalyzer> ParseListCode(string sorce)
        {
            var playerResponce = GetPlayerResponse(sorce, Configuration.ListScript);
            var result = playerResponce.RootElement.SelectElement("$..playlistVideoListRenderer.contents");

            var arrey = result.Value.EnumerateArray();
            foreach (var item in arrey)
            {
                var tokens = item.SelectElements("$..videoId").ToList()?.FirstOrDefault();
                yield return new UriAnalyzer(tokens.Value.ToString());
            }

        }

        private JsonDocument GetPlayerResponse(ReadOnlySpan<char> source, HTMLElementModel script)
        {
            var beginIndex = source.IndexOf(script.Begin) + script.Begin.Length;
            if (beginIndex == -1)
                throw new Exception($"{script.Begin} is not Updated");

            var responce = source.Slice(beginIndex);
            var endIndex = responce.IndexOf(script.End) + beginIndex;
            if (endIndex < beginIndex)
                throw new Exception($"{script.End} is not Updated");

            responce = source[beginIndex..endIndex];

            return JsonDocument.Parse(responce.ToString(), new JsonDocumentOptions
            {
                MaxDepth = 64,
                AllowTrailingCommas = false
            });
        }

        private Uri GetBaseJS(string source)
        {
            if (!source.ParseJSONKey(Configuration.BaseJsToken[0], out var js) || !source.ParseJSONKey(Configuration.BaseJsToken[1], out js))
            {
                Match match = Regex.Match(source, "<script src=\"((?:[^\"]|\\\\')*/base.js)\" nonce=\"(?:[^\"]|\\')*\"></script>");
                if (match.Success)
                    js = match.Groups[1].Value.Replace(@"\/", "/");
                else
                    throw new Exception($"{ Configuration.BaseJsToken } is not Updated");
            }
            return new Uri(string.Concat(Configuration.Scheme, Configuration.Host, js));
        }

        private VideoProcessModel GetVideoDetails(ReadOnlySpan<char> source, JsonDocument playerResponse, HTMLElementModel titleElement, VideoProcessModel result)
        {
            var beginIndex = source.IndexOf(titleElement.Begin) + titleElement.Begin.Length;
            var endIndex = source.IndexOf(titleElement.End);

            result.Details.Add(Configuration.Title.Path, beginIndex == -1 || endIndex == -1
                ? playerResponse.RootElement.GetProperty(Configuration.Title).GetString()
                : source.Slice(beginIndex, endIndex - beginIndex).ToString());
            result.Details.Add(Configuration.Author.Path, playerResponse.RootElement.GetProperty(Configuration.Author).ToString());
            result.Details.Add(Configuration.Status.Path, playerResponse.RootElement.GetProperty(Configuration.Status).ToString());
            result.Details.Add(Configuration.LiveVideo.Path, playerResponse.RootElement.GetProperty(Configuration.LiveVideo).ToString());
            return result;
        }
    }
}