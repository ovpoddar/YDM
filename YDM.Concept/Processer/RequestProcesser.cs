using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.Helper;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    internal class RequestProcesser
    {
        private readonly Uri _uri;
        public RequestProcesser(Uri uri) =>
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));

        public async ValueTask<string> DownloadString(bool cache, CancellationToken cancelatontoken)
        {
            if (cache)
            {
                if (string.IsNullOrWhiteSpace(Caching.GetItem("SCRIPT")))
                {
                    var response = await Request.BaseDownloadString(_uri, cancelatontoken);
                    Caching.AddItem("SCRIPT", response);
                    return response;
                }
                else return Caching.GetItem("SCRIPT");
            }
            return await Request.BaseDownloadString(_uri, cancelatontoken);
        }

    }
}
