using Newtonsoft.Json;

namespace CarouselAndWordCount.Models
{
    public class CarouselItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pageRefId")]
        public string PageRefId { get; set; }
    }
}