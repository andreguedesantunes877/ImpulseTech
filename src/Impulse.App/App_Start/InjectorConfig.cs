using System.Reflection;
using System.Web.Mvc;
using Impulse.Infra.CrossCuting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Impulse.App
{
    public class InjectorConfig
    {
        public static Container Container { get; internal set; }
        
        public static void RegisterServices()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            BootStrapper.RegisterServices(Container);

            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            Container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }
    }
}