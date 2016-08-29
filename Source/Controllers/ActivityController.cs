
namespace Gorman.API.Controllers {
    using Core.Services;
    using System.Web.Http;
    using Domain;

    [RoutePrefix("activities")]
    public class ActivityController
        : ApiController {

        public ActivityController(IActivityService activityService) {
            _activityService = activityService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Activity request) {
            if (request == null)
                return BadRequest();

            _activityService.Add(request);

            return Ok();
        }

        private readonly IActivityService _activityService;
    }
}