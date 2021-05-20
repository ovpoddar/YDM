namespace YDM.Concept.Models
{
    public class JSONPath
    {
        public string Path { get; private set; }
        public string[] PathDirectory { get; private set; }
        public string DeclearedPath { get; private set; }

        /// <summary>
        /// constrictor to reduce spelling mistakes and make declaring process easy 
        /// </summary>
        /// <param name="path">Json path coma separated</param>
        public JSONPath(string path)
        {
            var elements = path.Split(",");
            Path = elements[^1];
            PathDirectory = elements;
            for (int i = 0; i < elements.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(DeclearedPath))
                    DeclearedPath += elements[i];
                else
                    DeclearedPath += string.Concat(".", elements[i]);
            }
            //DeclearedPath = string.Concat("$..", Path);
        }
    }
}
