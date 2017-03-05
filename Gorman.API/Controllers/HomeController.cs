
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Builders;
    using Domain;

    public class HomeController
        : ApiController {

        [Route("")]
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