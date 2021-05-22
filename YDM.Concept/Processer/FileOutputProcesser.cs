using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YDM.Concept.Processer
{
    public class FileOutputProcesser
    {
        private readonly bool _isNewStart;
        private readonly FileStream _information;

        public bool IsNewStart => _isNewStart;
        public long ChunkSize => Information.Length;
        public FileStream Information => _information;

        public FileOutputProcesser(string path)
        {
            _isNewStart = !File.Exists(path);
            if (IsNewStart)
                _information = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
            else
                _information = new FileStream(path, FileMode.Append, FileAccess.ReadWrite);
        }

    }
}
