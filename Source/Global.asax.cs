﻿
namespace AJN.Gorman.API
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperConfig.RegisterMappings();
            AutofacConfig.RegisterDependencies();
        }
    }
}
