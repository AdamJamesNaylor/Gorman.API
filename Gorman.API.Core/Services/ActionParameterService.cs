namespace Gorman.API.Core.Services {
    using System.Collections.Generic;
    using Domain;
    using Repositories;

    public interface IActionParameterService {
        ActionParameter Add(ActionParameter request);
        ActionParameter Get(long id);
        List<ActionParameter> List(long actionId);
        List<ActionParameterSummary> ListSummaries(long actionId);
    }

    public class ActionParameterService : IActionParameterService {
        public ActionParameterService(IActionParameterRepository repository)
        {
            _repository = repository;
        }

        public ActionParameter Add(ActionParameter request)
        {
            return _repository.Add(request);
        }

        public ActionParameter Get(long id)
        {
            return _repository.Get(id);
        }

        public List<ActionParameter> List(long actionId)
        {
            return _repository.List(actionId);
        }

        public List<ActionParameterSummary> ListSummaries(long actionId)
        {
            return _repository.ListSummaries(actionId);
        }

        private readonly IActionParameterRepository _repository;
    }
}