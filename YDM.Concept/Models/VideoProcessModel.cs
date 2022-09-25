using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YDM.Concept.Models
{
    public class VideoProcessModel : VideoModel
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
    }
}
