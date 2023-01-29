using CarouselAndWordCount.Models;

namespace CarouselAndWordCount.Services
{
    public interface ITestApiService
    {
        PageModel GetPageModel(string pageUrl);
    }
}