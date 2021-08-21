using System.Text.Json.Serialization;

namespace YDM.Concept.Models
{
    public class Thumbnail
    {
        [JsonPropertyName("url")]
        public string Uri { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
    }
}
