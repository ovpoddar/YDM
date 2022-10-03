using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.Models;

namespace YDM.Concept.Helper
{
    static class Request
    {
        public static HttpWebRequest CreateHttpRequest(Uri url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.18362";
            request.AllowAutoRedirect = true;
            request.Method = "GET";
            request.Timeout = 10000;
            request.ReadWriteTimeout = 5000;
            request.KeepAlive = false;
            return request;
        }

        public static HttpWebRequest CreateHttpRequest(Uri url, long start)
        {
            if (start < 0)
                start = 0;

            var request = CreateHttpRequest(url);
            request.AddRange(start);

            return request;
        }

        public static DownloadingFileDetails GetFileDetails(List<FileInformation> files)
        {
            var result = new DownloadingFileDetails()
            {
                FileSizes = new List<long>()
            };

            foreach (var file in files)
            {
                var request = CreateHttpRequest(file.Uri);
                using (var responce = request.GetResponse())
                {
                    result.FileSize += responce.ContentLength;
                    result.FileSizes.Add(responce.ContentLength);
                }
            }

            return result;
        }

        public static DownloadingFileDetails GetLocalFileDetails(List<string> paths)
        {
            var result = new DownloadingFileDetails()
            {
                FileSizes = new List<long>()
            };

            foreach (var path in paths)
            {
                try
                {
                    result.FileSize += new FileInfo(path).Length;
                    result.FileSizes.Add(new FileInfo(path).Length);
                }
                catch
                {
                    result.FileSizes.Add(0);
                }
            }

            return result;
        }

        public static async Task<string> BaseDownloadString(Uri url, CancellationToken cancelatontoken)
        {
            var responseFromServer = string.Empty;
            var retries = Configuration.MaxRetries;

            while (retries > 0)
            {
                try
                {
                    var request = CreateHttpRequest(url);
                    using var response = await request.GetResponseAsync() as HttpWebResponse;
                    if (cancelatontoken.IsCancellationRequested)
                        cancelatontoken.ThrowIfCancellationRequested();
                    using var dataStream = response.GetResponseStream();
                    if (cancelatontoken.IsCancellationRequested)
                        cancelatontoken.ThrowIfCancellationRequested();
                    using var reader = new StreamReader(dataStream);

                    responseFromServer = await reader.ReadToEndAsync();

                    if (response.StatusCode == HttpStatusCode.OK)
                        break;
                    throw new HttpRequestException();

                }
                catch (Exception ex)
                {
                    if (ex.GetType().Name == "HttpRequestException")
                    {
                        retries--;
                        await Task.Delay(2000);
                        if (retries == 0)
                            throw;
                    }
                    else
                    {
                        if (ex?.InnerException.Message == "No such host is known.")
                            throw new Exception("no Internet");
                        throw ex;
                    }
                }
            }
            return responseFromServer;
        }
    }
}
