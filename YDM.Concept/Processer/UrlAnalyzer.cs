using System;
using System.Collections.Generic;
using YDM.Concept.ConfigurationsString;

namespace YDM.Concept.Helper
{
    public struct UriAnalyzer
    {
        public UriAnalyzer(string uri)
        {
            try
            {
                Url = new Uri(uri);
            }
            catch (UriFormatException e)
            {
                if (!string.Equals(e.Message, "Invalid URI: The URI is empty.", StringComparison.OrdinalIgnoreCase))
                    Url = new Uri(string.Concat(Configuration.Scheme, Configuration.Host, "/watch?v=", uri));
                else
                {
                    Exception = e;
                    IsProcessable = false;
                }
            }

            if (IsProcessable == true && Url.Host == Configuration.Host)
                IsProcessable = true;
            else
            {
                IsProcessable = false;
                return;
            }

            var query = Url.Query.Substring(1);
            var queryes = query.Split("&");
            Queryes = new KeyValuePair<string, string>[queryes.Length];
            for (int i = 0; i < queryes.Length; i++)
            {
                var keyvalue = queryes[i].Split("=");
                Queryes[i] = new KeyValuePair<string, string>(keyvalue[0], keyvalue[1]);
            }

            if (Queryes[0].Key.ToLower() == "list")
                IsList = true;
            else
                IsList = false;
        }

        public bool IsList { get; set; } = false;
        public Uri Url { get; set; } = null;
        public Exception Exception { get; set; } = new Exception();
        public bool IsProcessable { get; set; } = true;
        public KeyValuePair<string, string>[] Queryes { get; set; } = new KeyValuePair<string, string>[0];
    }
}
