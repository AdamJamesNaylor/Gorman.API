
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Services;
    using Domain;

    public interface IActivityController {
        IHttpActionResult Add(Activity request);
        IHttpActionResult Get(long id);
    }

    [RoutePrefix("activities")]
    public class ActivityController
        : ApiController, IActivityController {

        public ActivityController(IActivityService activityService, IActionService actionService, IActorService actorService) {
            _activityService = activityService;
            _actionService = actionService;
            _actorService = actorService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(Activity request) {
            if (request == null)
                return BadRequest();

            var activity = _activityService.Add(request);

            return Ok(activity);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id) {

            var result = _activityService.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{id}/actions")]
        [HttpPost]
        public IHttpActionResult AddAction(long id, Action request) {
            if (request == null)
                return BadRequest();

            request.ActivityId = id;
            var result = _actionService.Add(request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/actors/{id}")]
        [HttpGet]
        public IHttpActionResult GetActor(long activityId, long id)
        {
            var result = _actorService.Get(id); //AND activityId == @activityId  ??

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/actors")]
        [HttpPost]
        public IHttpActionResult AddActor(long activityId, Actor request)
        {
            if (request == null)
                return BadRequest();

            request.ActivityId = activityId;
            var actor = _actorService.Add(request);

            return Ok(actor);
        }


        private readonly IActivityService _activityService;
        private readonly IActionService _actionService;
        private readonly IActorService _actorService;
    }
}