
namespace Gorman.API.Controllers {
    using Core.Services;
    using System.Web.Http;
    using Domain;

    [RoutePrefix("activities")]
    public class ActorController
        : ApiController {

        public ActorController(IActorService actorService) {
            _actorService = actorService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Actor request) {
            if (request == null)
                return BadRequest();

            _actorService.Add(request);

            return Ok();
        }

        private readonly IActorService _actorService;
    }
}