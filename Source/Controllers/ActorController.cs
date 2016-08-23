
namespace AJN.Gorman.API.Controllers {
    using Core.Services;
    using System.Web.Http;
    using Domain;

    [RoutePrefix("activities")]
    public class ActorController
        : ApiController {

        public ActorController(IActorService actorService) {
            _activityService = actorService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Actor request) {
            if (request == null)
                return BadRequest();

            _activityService.Add(request);

            return Ok();
        }

        private readonly IActivityService _activityService;
    }
}