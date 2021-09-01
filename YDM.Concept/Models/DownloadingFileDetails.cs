using System.Collections.Generic;
using YDM.Concept.ExtendClasses;

namespace YDM.Concept.Models
{
    public class DownloadingFileDetails
    {
        private double _fileSize;

        public double FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value;
                ReadableFileSize = _fileSize.ToString().HumanReadAbleLong();
            }
        }

        public string ReadableFileSize { get; private set; }
        public List<long> FileSizes { get; set; }
    }
}
