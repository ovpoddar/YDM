using System;
using System.Collections.Generic;
using System.Text;
using YDM.Models;

namespace YDM
{
    public class UrlAnalyzer
    {
        internal Results<Uri> Check(string url)
        {
            try
            {
                var path = new Uri(url);
            }
            catch(Exception exception)
            {
                return new Results<Uri>()
                {
                    Exception = exception.Message,
                    Success = false
                };
            }
        }
    }
}
