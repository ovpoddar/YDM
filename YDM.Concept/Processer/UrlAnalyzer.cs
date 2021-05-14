using System;
using YDM.Concept.ConfigurationsString;
using YDM.Concept.Models;

namespace YDM.Concept.Helper
{
    internal static class UrlAnalyzer
    {
        internal static Results<AnalysisReport> Check(string url)
        {
            try
            {
                var path = new Uri(url);
                var result = new Results<AnalysisReport>
                {
                    Result = new AnalysisReport
                    {
                        IsList = url.Contains("list"),
                        Url = path
                    },
                    Success = true
                };

                if (path.Host == Configuration.Host)
                    return result;
                throw new Exception("Invalid Url");

            }
            catch (Exception exception)
            {
                return new Results<AnalysisReport>
                {
                    Exception = exception.Message,
                    Success = false
                };
            }
        }
    }
}
