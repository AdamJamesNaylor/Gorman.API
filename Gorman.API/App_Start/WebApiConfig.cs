
namespace Gorman.API {
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using Microsoft.Web.Http.Routing;

    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {

            var jsonFormatter = new JsonMediaTypeFormatter {
                SerializerSettings = {Formatting = Newtonsoft.Json.Formatting.Indented}
            };

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(jsonFormatter);

            var constraintResolver = new DefaultInlineConstraintResolver { ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) } };

            config.AddApiVersioning(o => o.ReportApiVersions = true);
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}