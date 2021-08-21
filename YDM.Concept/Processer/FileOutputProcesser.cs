using System.IO;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    public class FileOutputProcesser
    {
        internal readonly bool _isDownload;
        internal readonly long _downloaded;
        private readonly string _output;

        public FileOutputProcesser(string output, long filesize, FileInformation file)
        {
            _output = string.Concat(output, ".", file.FileExtenction.Remove(3));
            try
            {
                _downloaded = new FileInfo(_output).Length;
            }
            catch
            {
                _downloaded = 0;
            }
            _isDownload = filesize >= _downloaded;
        }


        internal FileStream GetStream() =>
            File.Exists(_output)
                ? new FileStream(_output, FileMode.Append, FileAccess.Write)
                : new FileStream(_output, FileMode.Create, FileAccess.ReadWrite);

        internal void Remove() =>
            File.Delete(_output);
    }

}
