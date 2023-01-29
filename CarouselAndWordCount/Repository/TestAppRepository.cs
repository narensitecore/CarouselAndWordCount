using System;

using CarouselAndWordCount.Models;
using CarouselAndWordCount.Services;

namespace CarouselAndWordCount.Repository
{
    public class TestAppRepository : ITestAppRepository
    {
        private readonly ITestApiService _testApiService;

        public TestAppRepository(ITestApiService testApiService)
        {
            _testApiService = testApiService;
        }

        public PageModel GetPage(string pageUrl)
        {
            try
            {
                return _testApiService.GetPageModel(pageUrl);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}