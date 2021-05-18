using System;
using System.Collections.Generic;
using YDM.Concept.ConfigurationsString;

namespace YDM.Concept.Helper
{
    public class UriAnalyzer
    {
        public UriAnalyzer(string uri)
        {
            IsProcessable = true;
            try
            {
                Url = new Uri(uri);
            }
            catch
            {
                try
                {
                    Url = new Uri(string.Concat(Configuration.Scheme, Configuration.Host, "/watch?v=", uri));
                }
                catch (Exception ex)
                {
                    Exception = ex;
                    IsProcessable = false;
                }
            }
            if (Url.Host == Configuration.Host)
                IsProcessable = true;
            else
                IsProcessable = false;

            if (Url.Query.Contains("List"))
                IsList = true;
            else
                IsList = false;

            var query = Url.Query.Substring(1);
            var queryes = query.Split("&");
            Queryes = new KeyValuePair<string, string>[queryes.Length];
            for (int i = 0; i < queryes.Length; i++)
            {
                var keyvalue = queryes[i].Split("=");
                Queryes[i] = new KeyValuePair<string, string>(keyvalue[0], keyvalue[1]);
            }

        }

        public bool IsList { get; set; }
        public Uri Url { get; set; }
        public Exception Exception { get; set; }
        public bool IsProcessable { get; set; }
        public KeyValuePair<string, string>[] Queryes { get; set; }
    }
}
