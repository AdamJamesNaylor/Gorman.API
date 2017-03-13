
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Services;
    using Domain;
    using Microsoft.Web.Http;

    public interface IActivityController {
        IHttpActionResult Add(Activity request);
        IHttpActionResult Get(long id);
    }

    [ApiVersion("0.1")]
    [RoutePrefix("v{version:apiVersion}/activities")]
    public class ActivityController
        : ApiController, IActivityController {

        public ActivityController(IActivityService activityService, IActionService actionService,
            IActorService actorService) {
            _activityService = activityService;
            _actionService = actionService;
            _actorService = actorService;
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Add(Activity request) {
            if (request == null)
                return BadRequest();

            var activity = _activityService.Add(request);

            return Ok(activity);
        }

        [Route("{activityId}")]
        [HttpGet]
        public IHttpActionResult Get(long activityId) {

            var result = _activityService.Get(activityId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route]
        [HttpGet]
        public IHttpActionResult List() {

            var result = _activityService.ListSummaries(0);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/activities")]
        [HttpGet]
        public IHttpActionResult List(long activityId) {

            var result = _activityService.ListSummaries(activityId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/actions")]
        [HttpPost]
        public IHttpActionResult AddAction(long activityId, Action request) {
            if (request == null)
                return BadRequest();

            request.ActivityId = activityId;
            var result = _actionService.Add(request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/actors/{id}")]
        [HttpGet]
        public IHttpActionResult GetActor(long activityId, long id) {
            var result = _actorService.Get(id); //AND activityId == @activityId  ??

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/actors")]
        [HttpPost]
        public IHttpActionResult AddActor(long activityId, Actor request) {
            if (request == null)
                return BadRequest();

            request.ActivityId = activityId;
            var actor = _actorService.Add(request);

            return Ok(actor);
        }

        [Route("{activityId}/actors")]
        [HttpGet]
        public IHttpActionResult ListActors(long activityId) {

            var result = _actorService.ListSummaries(activityId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/actions/{id}")]
        [HttpGet]
        public IHttpActionResult GetAction(long activityId, long id) {
            var result = _actionService.Get(id); //AND activityId == @activityId  ??

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{activityId}/actions")]
        [HttpGet]
        public IHttpActionResult ListActions(long activityId) {

            var result = _actionService.ListSummaries(activityId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        private readonly IActivityService _activityService;
        private readonly IActionService _actionService;
        private readonly IActorService _actorService;
    }
}