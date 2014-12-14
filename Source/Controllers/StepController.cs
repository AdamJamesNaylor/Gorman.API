
namespace AJN.Gorman.API.Controllers
{
    using AJN.Gorman.Domain;
    using System.Web.Http;
    using AJN.Gorman.API.Core.Services;

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