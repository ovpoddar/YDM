using System;
using System.Threading;
using System.Threading.Tasks;
using YDM.Concept.Helper;

namespace YDM.Concept.Processer
{
    public class RequestProcesser
    {
        private readonly Uri _uri;
        public RequestProcesser(ref UriAnalyzer uri) =>
            _uri = uri.Url ?? throw new ArgumentNullException(nameof(uri));

        public RequestProcesser(in Uri uri) =>
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
