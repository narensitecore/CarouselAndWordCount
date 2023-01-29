using CarouselAndWordCount.Models;

namespace CarouselAndWordCount.Repository
{
    public interface ITestAppRepository
    {
        PageModel GetPage(string pageUrl);
    }
}