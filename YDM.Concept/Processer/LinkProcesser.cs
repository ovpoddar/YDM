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
        public static List<FileInformationInternal> GetFormatsStream(JsonElement.ArrayEnumerator jsons)
        {
            var result = new List<FileInformationInternal>();

            foreach (var format in jsons)
            {
                var videoinfo = new FileInformationInternal()
                {
                    Uri = format.TryToParseProprity(Configuration.CaptureUri),
                    TypeOfContent = format.GetProperty("mimeType").GetString(),
                    IsSecure = ParseSecure(format),
                    Format = format.TryToParseProprity(Configuration.CaptureFormat),
                    Id = format.GetProperty("itag").GetInt32(),
                };
                result.Add(videoinfo);
            }
            return result;
        }

        public static List<FileInformationInternal> GetAdaptiveFormatsStream(JsonElement.ArrayEnumerator jsons)
        {
            var result = new List<FileInformationInternal>();

            foreach (var format in jsons)
            {
                var videoinfo = new FileInformationInternal()
                {
                    Uri = format.TryToParseProprity(Configuration.CaptureUri),
                    TypeOfContent = format.GetProperty("mimeType").GetString(),
                    IsSecure = ParseSecure(format),
                    Format = format.TryToParseProprity(Configuration.CaptureFormat),
                    Id = format.GetProperty("itag").GetInt32(),
                };
                result.Add(videoinfo);
            }
            return result;
        }

        public static List<FileInformation> FilterUrls(List<FileInformationInternal> information, string js)
        {
            var results = new List<FileInformation>();
            foreach (var info in information)
            {
                if (!info.IsSecure)
                {
                    var result = new FileInformation
                    {
                        Uri = info.Uri,
                        FileExtenction = info.TypeOfContent.Split('/')[1],
                        Format = info.Format,
                        FileType = (FileTypeEnum)Enum.Parse(typeof(FileTypeEnum), info.TypeOfContent.Split('/')[0], true),
                        Id = info.Id
                    };
                    results.Add(result);
                }
                else
                {
                    var result = new FileInformation
                    {
                        FileExtenction = info.TypeOfContent.Split('/')[1],
                        Uri = YouTubeVideo.Decrypt(info.Uri, js),
                        FileType = (FileTypeEnum)Enum.Parse(typeof(FileTypeEnum) ,info.TypeOfContent.Split('/')[0], true),
                        Id = info.Id,
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
