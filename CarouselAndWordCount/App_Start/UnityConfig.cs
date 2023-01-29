using CarouselAndWordCount.Repository;
using CarouselAndWordCount.Services;

using System.Web.Mvc;

using Unity;
using Unity.Mvc5;

namespace CarouselAndWordCount
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ITestAppRepository, TestAppRepository>();
            container.RegisterType<ITestApiService, TestApiService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}