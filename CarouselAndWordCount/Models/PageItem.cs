using Newtonsoft.Json;

using System.Collections.Generic;

namespace CarouselAndWordCount.Models
{
    public class PageItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("pageName")]
        public string PageName { get; set; }

        [JsonProperty("pageUrl")]
        public string PageUrl { get; set; }

        [JsonProperty("carouselItems")]
        public List<CarouselItem> CarouselItems { get; set; }
    }
}