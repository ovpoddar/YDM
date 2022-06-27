using System.IO;
using YDM.Concept.Models;

namespace YDM.Concept.Processer
{
    public class FileOutputProcesser
    {
        private readonly string _output;

        public FileOutputProcesser(string output) =>
            _output = output;

        internal FileStream GetStream() =>
            File.Exists(_output)
                ? new FileStream(_output, FileMode.Append, FileAccess.Write)
                : new FileStream(_output, FileMode.Create, FileAccess.ReadWrite);

        internal void Remove()
        {
            if (File.Exists(_output))
                File.Delete(_output);
        }
    }

}
