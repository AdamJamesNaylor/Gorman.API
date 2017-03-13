
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Builders;
    using Domain;
    using Microsoft.Web.Http;

    [ApiVersion("0.1")]
    [RoutePrefix("v{version:apiVersion}")]
    public class HomeController
        : ApiController {

        [Route]
        [HttpGet]
        public EndpointList Get() {
            return new EndpointList {
                    MapsUrl = MapBuilder.MapsUrl,
                    ActivitiesUrl = ActivityBuilder.ActivitiesUrl,
                    ActorsUrl = ActorBuilder.ActorsUrl,
                    ActionsUrl = ActionBuilder.ActionsUrl
                    //todo do I need to add the remaining endpoints
                };
        }
    }
}