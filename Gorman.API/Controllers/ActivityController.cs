
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

        public ActivityController(IActivityService activityService, IActionService actionService) {
            _activityService = activityService;
            _actionService = actionService;
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

        private readonly IActivityService _activityService;
        private readonly IActionService _actionService;
    }
}