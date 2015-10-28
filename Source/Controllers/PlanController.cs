
using AJN.Gorman.API.Core.Services;
using AJN.Gorman.Domain;

namespace AJN.Gorman.API.Controllers
{
    using System.Web.Http;
    
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