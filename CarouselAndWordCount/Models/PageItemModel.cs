using CarouselAndWordCount.Models;
using System.Collections.Generic;

namespace TestAPI.Models
{
    public class PageItemModel
    {
        public PageItem Page { get; set; }
        public int WordsCount { get; set; }
        public List<Word> Words { get; set; }
    }
}
