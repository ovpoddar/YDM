using System.Collections;
using System.Collections.Generic;

namespace YDM.Concept.Models
{
    public class VideoModel
    {
        /// <summary>
        /// the details tab has title, author, live video and status
        /// </summary>
        public Hashtable Detais { get; set; }
        /// <summary>
        /// Links of the video
        /// </summary>
        public List<FileInformation> Lists { get; set; }
        /// <summary>
        /// Thumbnails of the video of different resulation
        /// </summary>
        public List<Thumbnail> Thumbnails { get; set; }
    }
}
