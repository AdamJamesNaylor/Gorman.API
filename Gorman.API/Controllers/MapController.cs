
namespace Gorman.API.Controllers {
    using Core.Services;
    using System.Web.Http;
    using Domain;

    [RoutePrefix("maps")]
    public class MapController
        : ApiController {

        public MapController(IMapService mapService, IActivityService activityService, IActorService actorService, IActionService actionService) {
            _mapService = mapService;
            _activityService = activityService;
            _actionService = actionService;
            _actorService = actorService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(Map request) {
            if (request == null)
                return BadRequest();

            var map = _mapService.Add(request);

            return Ok(map);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id) {

            var map = _mapService.Get(id);

            if (map == null)
                return NotFound();

            return Ok(map);
        }

        [Route("{id}/activities")]
        [HttpPost]
        public IHttpActionResult AddActivity(long id, Activity request) {
            if (request == null)
                return BadRequest();

            request.MapId = id;
            var activity = _activityService.Add(request);

            return Ok(activity);
        }

        [Route("{id}/activities/{parentId}")]
        [HttpPost]
        public IHttpActionResult AddActivity(long id, long parentId, Activity request) {
            if (request == null)
                return BadRequest();

            request.MapId = id;
            request.ParentId = parentId;
            var activity = _activityService.Add(request);

            return Ok(activity);
        }

        [Route("{id}/activities")]
        [HttpGet]
        public IHttpActionResult ListActivities(long id) {
            var activities = _activityService.List(id);

            return Ok(activities);
        }

        [Route("{id}/actors")]
        [HttpPost]
        public IHttpActionResult AddActor(long id, Actor request) {
            if (request == null)
                return BadRequest();

            request.MapId = id;
            var actor = _actorService.Add(request);

            return Ok(actor);
        }

        [Route("{id}/actors")]
        [HttpGet]
        public IHttpActionResult ListActors(long id) {
            var actors = _actorService.List(id);

            return Ok(actors);
        }

        [Route("{id}/activities/{activityId}/actions")]
        [HttpPost]
        public IHttpActionResult AddAction(long id, long activityId, Action request) {
            if (request == null)
                return BadRequest();

            request.ActivityId = activityId;
            var actor = _actionService.Add(request);

            return Ok(actor);
        }

        [Route("{id}/actors/{activityId}/actions")]
        [HttpGet]
        public IHttpActionResult ListActions(long id, long activityId) {
            var actors = _actionService.List(activityId);

            return Ok(actors);
        }


        private readonly IMapService _mapService;
        private readonly IActivityService _activityService;
        private readonly IActionService _actionService;
        private readonly IActorService _actorService;
    }
}