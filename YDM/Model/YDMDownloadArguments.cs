using System;
using System.Collections.Generic;
using System.Text;
using YDM.Concept.Models;

namespace YDM.Model
{
    public class YDMDownloadArguments
    {
        public List<FileInformation> Files { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
