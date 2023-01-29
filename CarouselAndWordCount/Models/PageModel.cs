using Newtonsoft.Json;

using System.Collections.Generic;

namespace CarouselAndWordCount.Models
{
    public class JsonContext
    {
        public List<PageItem> PageItems { get; set; } = new List<PageItem>();

        public List<CarouselItem> CarouselItems { get; set; } = new List<CarouselItem>();
    }

    public class PageModel
    {
        [JsonProperty("page")]
        public PageItem Page { get; set; }

        [JsonProperty("wordsCount")]
        public int WordsCount { get; set; }

        [JsonProperty("words")]
        public List<Word> Words { get; set; }
        public bool Success { get; set; }
        public string FailureMessage { get; set; }
    }
}