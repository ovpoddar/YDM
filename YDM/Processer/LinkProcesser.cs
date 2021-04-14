using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using YDM.Models;

namespace YDM.Processer
{
    internal static class LinkProcesser
    {
        public static List<VideoInformation> GetFormatsStream(JsonElement.ArrayEnumerator jsons)
        {
            var result = new List<VideoInformation>();

            foreach (var format in jsons)
            {
                var videoinfo = new VideoInformation()
                {
                    Uri = format.GetProperty("signatureCipher").GetString(),
                    TypeOfContent = format.GetProperty("mimeType").GetString()
                };
                result.Add(videoinfo);
            }
            return result;
        }

        public static List<VideoInformation> GetAdaptiveStream(JsonElement.ArrayEnumerator jsons)
        {
            var result = new List<VideoInformation>();

            foreach (var format in jsons)
            {
                var videoinfo = new VideoInformation()
                {
                    Uri = format.GetProperty("signatureCipher").GetString(),
                    TypeOfContent = format.GetProperty("mimeType").GetString()
                };
                result.Add(videoinfo);
            }
            return result;
        }
    }
}
