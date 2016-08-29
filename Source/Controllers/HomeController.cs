
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Domain;

    public class HomeController
        : ApiController {

        public EndpointListResponse Get() {
            return new EndpointListResponse {
                MapUrl = "/maps"
            };
        }
    }

}