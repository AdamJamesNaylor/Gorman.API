
namespace Gorman.API.Controllers
{
    using System.Web.Http;
    using Core.Services;
    using Domain;

    [RoutePrefix("steps")]
    public class StepController
        : ApiController {

        public StepController(IStepService stepService)
        {
            _stepService = stepService;
        }

        [Route("")]
        [HttpPost]
        public void Post(Step request) {

            _stepService.Add(request);
        }

        private readonly IStepService _stepService;
    }
}