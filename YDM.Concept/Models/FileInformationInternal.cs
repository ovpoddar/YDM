namespace YDM.Concept.Models
{
    public struct FileInformationInternal
    {
        public int Id { get; set; }
        public string TypeOfContent { get; set; }
        public string Uri { get; set; }
        public bool IsSecure { get; set; }
        public string Format { get; set; }
        public string[] Thumbnail { get; set; }
    }
}
