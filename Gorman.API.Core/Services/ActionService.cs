
namespace Gorman.API.Core.Services {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Domain;
    using Repositories;

    public interface IActionService {
        Action Add(Action request);
        Action Get(long id);
        List<Action> List(long activityId);
        List<ActionSummary> ListSummaries(long id);
    }

    public class ActionService
        : IActionService {

        public ActionService(IActionRepository repository, IActionParameterService actionParameterService) {
            _repository = repository;
            _actionParameterService = actionParameterService;
        }

        public Action Add(Action request) {
            var action = _repository.Add(request);
            foreach (var parameter in request.Parameters) {
                parameter.ActionId = action.Id;
                _actionParameterService.Add(parameter);
            }
            request.Id = action.Id;
            return request;
        }

        public Action Get(long id) {
            var action = _repository.Get(id);
            if (action == null)
                return null;
            action.Parameters = _actionParameterService.List(id);
            return action;
        }

        public List<Action> List(long activityId) {
            return _repository.List(activityId);
        }

        public List<ActionSummary> ListSummaries(long activityId) {
            return _repository.ListSummaries(activityId);
        }

        private readonly IActionRepository _repository;
        private readonly IActionParameterService _actionParameterService;
    }
}