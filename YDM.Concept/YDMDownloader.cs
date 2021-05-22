using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YDM.Concept.Helper;
using YDM.Concept.Models;
using YDM.Concept.Processer;

namespace YDM.Concept
{
    public class YDMDownloader
    {
        private readonly FileOutputProcesser _outputPath;

        public YDMDownloader(FileInformation video, FileInformation audio, string output, string title)
        {
            _outputPath = new FileOutputProcesser(Path.Combine(output, title));
        }

        public YDMDownloader(FileInformation audio, string output, string title)
        {
            _outputPath = new FileOutputProcesser(Path.Combine(output, title));
        }

        public void Start()
        {

        }
        public void PauseOrResume()
        {

        }
        public void Stop()
        {

        }
    }
}
