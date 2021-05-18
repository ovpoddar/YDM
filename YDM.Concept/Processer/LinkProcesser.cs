using System;
using System.Collections.Generic;
using System.Text.Json;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.ExtendClasses;
using YDM.Concept.Helper;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    internal static class LinkProcesser
    {
        public static List<VideoInformationInternal> GetFormatsStream(JsonElement.ArrayEnumerator jsons)
        {
            var result = new List<VideoInformationInternal>();

            foreach (var format in jsons)
            {
                var videoinfo = new VideoInformationInternal()
                {
                    Uri = format.TryToParseProprity(Configuration.CaptureUri),
                    TypeOfContent = format.GetProperty("mimeType").GetString(),
                    IsSecure = ParseSecure(format),
                    Format = format.TryToParseProprity(Configuration.CaptureFormat)
                };
                result.Add(videoinfo);
            }
            return result;
        }

        public static List<VideoInformationInternal> GetAdaptiveFormatsStream(JsonElement.ArrayEnumerator jsons)
        {
            var result = new List<VideoInformationInternal>();

            foreach (var format in jsons)
            {
                var videoinfo = new VideoInformationInternal()
                {
                    Uri = format.TryToParseProprity(Configuration.CaptureUri),
                    TypeOfContent = format.GetProperty("mimeType").GetString(),
                    IsSecure = ParseSecure(format),
                    Format = format.TryToParseProprity(Configuration.CaptureFormat)
                };
                result.Add(videoinfo);
            }
            return result;
        }

        public static List<VideoInformation> FilterUrls(List<VideoInformationInternal> information, string js)
        {
            var results = new List<VideoInformation>();
            foreach (var info in information)
            {
                if (!info.IsSecure)
                {
                    var result = new VideoInformation
                    {
                        Uri = info.Uri,
                        FileExtenction = info.TypeOfContent.Split('/')[1],
                        Format = info.Format,
                        FileType = (FileTypeEnum)Enum.Parse(typeof(FileTypeEnum), info.TypeOfContent.Split('/')[0], true)
                    };
                    results.Add(result);
                }
                else
                {
                    var result = new VideoInformation
                    {
                        FileExtenction = info.TypeOfContent.Split('/')[1],
                        Uri = YouTubeVideo.Decrypt(info.Uri, js),
                        FileType = (FileTypeEnum)Enum.Parse(typeof(FileTypeEnum) ,info.TypeOfContent.Split('/')[0], true),
                        Format = info.Format
                    };
                    results.Add(result);
                }
            }
            return results;
        }

        public static bool ParseSecure(JsonElement element) =>
            element.TryGetProperty("cipher", out var result) || element.TryGetProperty("signatureCipher", out result);

    }
}
