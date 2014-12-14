


namespace AJN.Gorman.API.Controllers
{
    using System.Web.Http;
    using System.Collections.Generic;
    using Domain;
    using Core.Services;

    [RoutePrefix("phases")]
    public class PhaseController
        : ApiController {

        public PhaseController(IPhaseService phaseService) {
            
            _phaseService = phaseService;
        }

        [Route("")]
        [HttpPost]
        public void Post(Phase request) {

            _phaseService.Add(request);
        }

        [Route("~/plans/{id}/phases")]
        [HttpGet]
        public IEnumerable<Phase> List(int id) {

            return _phaseService.List(id);
        }

        private readonly IPhaseService _phaseService;

    }
}