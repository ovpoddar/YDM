using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.ExtendClasses;
using YDM.Concept.Helper;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    public class SorceProcesser
    {
        public Hashtable Details { get; private set; } = new Hashtable();
        public List<FileInformation> Streans { get; set; }
        public List<Thumbnail> Thumbnails { get; set; }
        public Exception Exception { get; set; }

        public async ValueTask<bool> ParseVideoCode(string sorce)
        {
            try
            {
                var playerResponse = GetPlayerResponse(sorce, Configuration.VideoScript);
                var js = GetBaseJS(sorce);

                GetVideoDetails(sorce, playerResponse, Configuration.VideoTitle);
                GetThumbnails(playerResponse);

                if (!string.IsNullOrWhiteSpace(Details[Configuration.LiveVideo.Path] as string) || Details[Configuration.LiveVideo.Path] as string == "true")
                {
                    Exception = new Exception("Video is not valid or it's live");
                    return false;
                }

                await ProcessPlayerResponseAsync(playerResponse, js);
                return true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                return false;
            }
        }

        private void GetThumbnails(JsonDocument playerResponse)
        {
            var value = playerResponse.RootElement.GetProperty(Configuration.Thumbnails).ToString();
            Thumbnails = JsonSerializer.Deserialize<List<Thumbnail>>(value);
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

        private async Task ProcessPlayerResponseAsync(JsonDocument playerResponse, Uri js)
        {
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

            var baseJs = await RequestProcesser.DownloadBaseJs(js);

            Streans = LinkProcesser.FilterUrls(Lists, baseJs);
        }

        private JsonDocument GetPlayerResponse(ReadOnlySpan<char> source, HTMLElementModel script)
        {
            var beginIndex = source.IndexOf(script.Begin) + script.Begin.Length;
            if (beginIndex == -1)
                throw new Exception($"{script.Begin} is not Updated");

            var endIndex = source.IndexOf(script.End);
            if (endIndex == -1)
                throw new Exception($"{script.End} is not Updated");

            var responce = source[beginIndex..endIndex];

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

        private void GetVideoDetails(ReadOnlySpan<char> source, JsonDocument playerResponse, HTMLElementModel titleElement)
        {
            var beginIndex = source.IndexOf(titleElement.Begin) + titleElement.Begin.Length;
            var endIndex = source.IndexOf(titleElement.End);

            Details.Add(Configuration.Title.Path, beginIndex == -1 || endIndex == -1
                ? playerResponse.RootElement.GetProperty(Configuration.Title).GetString()
                : source.Slice(beginIndex, endIndex - beginIndex).ToString());
            Details.Add(Configuration.Author.Path, playerResponse.RootElement.GetProperty(Configuration.Author).ToString());
            Details.Add(Configuration.Status.Path, playerResponse.RootElement.GetProperty(Configuration.Status).ToString());
            Details.Add(Configuration.LiveVideo.Path, playerResponse.RootElement.GetProperty(Configuration.LiveVideo).ToString());
        }
    }
}