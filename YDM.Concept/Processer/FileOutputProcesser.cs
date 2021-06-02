using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    public class FileOutputProcesser
    {
        internal readonly bool candownload;
        internal readonly long Downloaded;
        private readonly string _output;

        //private readonly FileStream _information;

        //public FileStream Information => _information;

        //public FileOutputProcesser(string path)
        //{
        //    if (!File.Exists(path))
        //        _information = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
        //    else
        //        _information = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite);

        //    _information.Dispose();
        //}
        public FileOutputProcesser(string output, long filesize, FileInformation file)
        {
            _output = string.Concat(output, ".", file.FileExtenction.Remove(3));
            try
            {
                Downloaded = new FileInfo(_output).Length;
            }
            catch
            {
                Downloaded = 0;
            }
            candownload = filesize >= Downloaded;
        }


        internal FileStream GetStream() =>
            File.Exists(_output)
                ? new FileStream(_output, FileMode.Append, FileAccess.Write)
                : new FileStream(_output, FileMode.Create, FileAccess.ReadWrite);

        internal void Remove() =>
            File.Delete(_output);
    }

}
