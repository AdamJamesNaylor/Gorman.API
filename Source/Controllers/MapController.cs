
namespace AJN.Gorman.API.Controllers
{
    using Core.Services;
    using System.Web.Http;
    using Domain;

    [RoutePrefix("maps")]
    public class MapController
        : ApiController {

        public MapController(IMapService mapService) {
            _mapService = mapService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Map request) {
            if (request == null)
                return BadRequest();

            _mapService.Add(request);

            return Ok();
        }

        public IHttpActionResult Get(int id) {

            var map = _mapService.Get(id);

            if (map == null)
                return NotFound();

            return Ok(map);
        }

        private readonly IMapService _mapService;
    }
}