using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.Helper;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    internal static class RequestProcesser
    {
        public static async Task<string> DownloadWebSite(Uri url)
        {
            var responseFromServer = string.Empty;
            var Retryes = Configuration.MaxRetries;

            while (Retryes > 0)
            {
                try
                {
                    var request = WebRequest.Create(url);
                    request.Credentials = CredentialCache.DefaultCredentials;
                    using var response = await request.GetResponseAsync() as HttpWebResponse;
                    using var dataStream = response.GetResponseStream();
                    using var reader = new StreamReader(dataStream);

                    responseFromServer = await reader.ReadToEndAsync();

                    if (response.StatusCode == HttpStatusCode.OK)
                        break;
                    throw new HttpRequestException();

                }
                catch
                {
                    Retryes--;
                    if (Retryes == 0)
                        throw;
                }
            }
            return responseFromServer;
        }


        public static async ValueTask<string> DownloadBaseJs(Uri url)
        {
            var responseFromServer = string.Empty;

            if (string.IsNullOrWhiteSpace(Caching.GetItem("SCRIPT")))
            {
                var Retryes = Configuration.MaxRetries;

                while (Retryes > 0)
                {
                    try
                    {
                        var request = WebRequest.Create(url);
                        request.Credentials = CredentialCache.DefaultCredentials;
                        using var response = await request.GetResponseAsync() as HttpWebResponse;
                        using var dataStream = response.GetResponseStream();
                        using var reader = new StreamReader(dataStream);

                        responseFromServer = await reader.ReadToEndAsync();

                        if (response.StatusCode == HttpStatusCode.OK)
                            break;
                        throw new HttpRequestException();

                    }
                    catch
                    {
                        Retryes--;
                        if (Retryes == 0)
                            throw;
                    }
                }
                Caching.AddItem("SCRIPT", responseFromServer);
                return responseFromServer;
            }
            return Caching.GetItem("SCRIPT");
        }
    }
}
