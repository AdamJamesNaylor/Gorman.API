
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Services;
    using Domain;

    [RoutePrefix("actors")]
    public class ActorController
        : ApiController {

        public ActorController(IActorService actorService) {
            _actorService = actorService;
        }

        //[Route("{id}")]
        //[HttpGet]
        //public IHttpActionResult Get(long id) {
        //    var result = _actorService.Get(id);

        //    if (result == null)
        //        return NotFound();

        //    return Ok(result);
        //}

        //[Route("")]
        //[HttpPost]
        //public IHttpActionResult Add(Actor request)
        //{
        //    if (request == null)
        //        return BadRequest();

        //    var actor = _actorService.Add(request);

        //    return Ok(actor);
        //}


        private readonly IActorService _actorService;
    }
}