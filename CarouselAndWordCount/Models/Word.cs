using Newtonsoft.Json;

namespace CarouselAndWordCount.Models
{
    public class Word
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}