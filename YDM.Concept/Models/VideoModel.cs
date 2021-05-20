using System.Collections;
using System.Collections.Generic;

namespace YDM.Concept.Models
{
    public class VideoModel
    {
        public Hashtable Detais { get; set; }
        public List<FileInformation> Lists { get; set; }
        public List<Thumbnail> Thumbnails { get; set; }
    }
}
