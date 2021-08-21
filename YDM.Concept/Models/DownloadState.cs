namespace YDM.Concept.Models
{
    public enum DownloadState
    {
        Initialized,
        GettingHeaders,
        GettingResponse,
        Downloading,
        Paused,
        Completed,
        Stopped
    }
}
