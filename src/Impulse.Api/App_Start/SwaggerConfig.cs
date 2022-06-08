using System;
using System.Web.Http;
using WebActivatorEx;
using Impulse.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Impulse.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Impulse.Api");
                    c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\Impulse.Api.xml");
                })
                .EnableSwaggerUi(c => { c.InjectJavaScript(thisAssembly, "SwaggerDemoApi.SwaggerExtensions.fixOAuthScopeSeparator.js"); });
        }
    }
}
