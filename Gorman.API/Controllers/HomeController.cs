
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Builders;
    using Domain;

    public class HomeController
        : ApiController {

        [Route("")]
        public Response<EndpointListResponse> Get() {
            return new Response<EndpointListResponse> {
                Data = new EndpointListResponse {
                    MapsUrl = MapBuilder.MapsUrl,
                    ActivitiesUrl = ActivityBuilder.ActivitiesUrl,
                    ActorsUrl = ActorBuilder.ActorsUrl,
                    ActionsUrl = ActionBuilder.ActionsUrl
                }
            };
        }
    }
}