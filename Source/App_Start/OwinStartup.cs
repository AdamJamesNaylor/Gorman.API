
[assembly: Microsoft.Owin.OwinStartup(typeof(AJN.Gorman.API.OwinStartup))]
namespace AJN.Gorman.API
{
    using System.Web.Http;
    using Owin;

    public class OwinStartup
    {
        public void Configuration(IAppBuilder app) {
        
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            AutoMapperConfig.RegisterMappings();
            AutofacConfig.RegisterDependencies();
        }
    }
}