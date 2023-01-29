using System.Web.Mvc;

using CarouselAndWordCount.Models;
using CarouselAndWordCount.Repository;

namespace CarouselAndWordCount.Controllers
{
    public class TestAppController : Controller
    {
        private readonly ITestAppRepository _carouselRepository;

        public TestAppController(ITestAppRepository carouselRepository)
        {
            _carouselRepository = carouselRepository;
        }

        //[Route("carousel/{pageName}")]
        public ActionResult GetPageResult()
        {
            return View(new PageModel());
        }

        [HttpPost]
        public ActionResult GetPageResult(string pageUrl)
        {
            _ = new PageModel();
            PageModel viewModel;
            try
            {
                viewModel = _carouselRepository.GetPage(pageUrl);
            }
            catch (System.Exception)
            {
                throw;
            }
            return View(viewModel);
        }
    }
}