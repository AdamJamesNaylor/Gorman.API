
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Builders;
    using Domain;

    public class HomeController
        : ApiController {

        [Route("")]
        public EndpointListResponse Get() {
            return new EndpointListResponse {
                MapsUrl = MapBuilder.MapsUrl,
                ActivitiesUrl = ActivityBuilder.ActivitiesUrl,
                ActorsUrl = ActorBuilder.ActorsUrl,
                ActionsUrl = ActionBuilder.ActionsUrl
            };
        }
    }

}