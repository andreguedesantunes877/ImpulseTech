using System.Web.Http;
using Impulse.Infra.CrossCuting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Impulse.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class InjectionConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Configure()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            BootStrapper.RegisterServices(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}