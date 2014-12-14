
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
        public void Post(Plan request)
        {
            _planService.Add(request);
        }

        private readonly IPlanService _planService;
    }
}