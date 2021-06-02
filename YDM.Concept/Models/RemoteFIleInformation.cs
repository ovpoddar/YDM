using System;
using System.Collections.Generic;
using System.Text;

namespace YDM.Concept.Models
{
    public class RemoteFIleInformation
    {
        public long FileSize { get; set; }
        public List<long> FileSizes { get; set; }
    }
}
