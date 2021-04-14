using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using YDM.ConfigurationsString;
using YDM.Models;

namespace YDM
{
    internal static class RequestManager
    {


        public static string DownloadWebSite(Results<AnalysisReport> url)
        {
            var responseFromServer = string.Empty;
            var Retryes = Configuration.MaxRetries;

            while (Retryes > 0)
            {
                try
                {
                    var request = WebRequest.Create(url.Result.Url);
                    request.Credentials = CredentialCache.DefaultCredentials;
                    using var response = request.GetResponse() as HttpWebResponse;
                    using var dataStream = response.GetResponseStream();
                    using var reader = new StreamReader(dataStream);

                    responseFromServer = reader.ReadToEnd();

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
    }
}
