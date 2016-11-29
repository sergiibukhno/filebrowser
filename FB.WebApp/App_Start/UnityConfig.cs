using FB.Models;
using FB.WebApp.Bll;
using FB.WebApp.Dal;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace FB.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IDirInfo, DirInfo>();
            container.RegisterType<IBrowserService, BrowserService>();
            container.RegisterType<IFileRepository, FileRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}