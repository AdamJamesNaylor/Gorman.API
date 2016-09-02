
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Services;

    [RoutePrefix("actors")]
    public class ActorController
        : ApiController {

        public ActorController(IActorService actorService) {
            _actorService = actorService;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id) {
            var result = _actorService.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        private readonly IActorService _actorService;
    }
}