using System;
using System.Collections.Generic;
using System.Text;

namespace YDM.Concept.Models
{
    public enum DownloadState
    {
        Downloading,
        Completed,
        GettingHeaders,
        GettingResponse,
        Stopped
    }
}
