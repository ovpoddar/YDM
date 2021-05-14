using YDM.Concept.Models;

namespace YDM.Concept.ConfigurationsString
{
    internal static class Configuration
    {
        public static string Host { get => "www.youtube.com"; }
        public static string Scheme { get => "https://"; }
        public static int MaxRetries { get => 3; }
        public static string[] BaseJsToken { get => new string[] { "PLAYER_JS_URL", "jsUrl" }; }
        public static string[] CaptureUri { get => new string[] { "url", "cipher", "signatureCipher" }; }
        public static string[] CaptureFormat { get => new string[] { "audioQuality", "qualityLabel" }; }
        public static JSONPath Format = new JSONPath("streamingData,formats");
        public static JSONPath AdaptiveFormats = new JSONPath("streamingData,adaptiveFormats");
        public static JSONPath Title = new JSONPath("videoDetails,title");
        public static JSONPath Author = new JSONPath("videoDetails,author");
        public static JSONPath Status = new JSONPath("playabilityStatus,status");
        public static JSONPath LiveVideo = new JSONPath("videoDetails,isLive");
        public static HTMLElementModel VideoTitle = new HTMLElementModel("<title>", "</title>");
        public static HTMLElementModel ListScript = new HTMLElementModel("var ytInitialData =", ";</script><link rel=\"alternate\"");
        public static HTMLElementModel VideoScript = new HTMLElementModel("var ytInitialPlayerResponse =", ";</script><div id=\"player\" class=\"skeleton flexy\">");
    }
}
