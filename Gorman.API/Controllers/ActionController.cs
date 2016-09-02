
namespace Gorman.API.Controllers {
    using System.Web.Http;
    using Core.Services;
    using Domain;

    [RoutePrefix("actions")]
    public class ActionController
        : ApiController {

        public ActionController(IActionService actionService) {
            _actionService = actionService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(Action request) {
            if (request == null)
                return BadRequest();

            var activity = _actionService.Add(request);

            return Ok(activity);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(long id) {

            var result = _actionService.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        private readonly IActionService _actionService;
    }

}