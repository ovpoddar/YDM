using System.Collections;
using System.Collections.Generic;

namespace YDM.Concept.Models
{
    public class VideoModel
    {
        /// <summary>
        /// the details tab has title, author, live video and status
        /// </summary>
        public Hashtable Details { get; private set; } = new Hashtable();
        /// <summary>
        /// Links of the video
        /// </summary>
        public List<FileInformation> Streans { get; set; }
        /// <summary>
        /// Thumbnails of the video of different resulation
        /// </summary>
        public List<Thumbnail> Thumbnails { get; set; }
    }
}
