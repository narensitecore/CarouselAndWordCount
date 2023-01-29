using System.Web.Mvc;
using System.Web.Routing;

namespace CarouselAndWordCount
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{pageName}",
                defaults: new { controller = "TestApp", action = "GetPageResult", pageName = UrlParameter.Optional }
            );
        }
    }
}
