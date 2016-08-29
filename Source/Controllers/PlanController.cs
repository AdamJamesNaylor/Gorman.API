
namespace Gorman.API.Controllers
{
    using System.Web.Http;
    using Core.Services;
    using Domain;

    [RoutePrefix("plans")]
    public class PlanController
        : ApiController
    {
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Plan request) {
            _planService.Add(request);

            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Put(Plan request)
        {
            _planService.Update(request);

            return Ok();
        }

        private readonly IPlanService _planService;
    }
}