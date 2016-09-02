
namespace Gorman.API {
    using System.Net.Http.Formatting;
    using System.Web.Http;

    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {

            var jsonFormatter = new JsonMediaTypeFormatter {
                SerializerSettings = {Formatting = Newtonsoft.Json.Formatting.Indented}
            };

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(jsonFormatter);

            //jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}