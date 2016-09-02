
namespace Gorman.API.Core.Services {
    using System.Collections.ObjectModel;
    using Domain;
    using Repositories;

    public interface IActionService {
        Action Add(Action request);
        Action Get(long id);
        ReadOnlyCollection<Action> List(long activityId);
    }

    public class ActionService
        : IActionService {

        public ActionService(IActionRepository repository) {
            _repository = repository;
        }

        public Action Add(Action request) {
            return _repository.Add(request);
        }

        public Action Get(long id) {
            return _repository.Get(id);
        }

        public ReadOnlyCollection<Action> List(long activityId) {
            return _repository.List(activityId);
        }

        private readonly IActionRepository _repository;
    }
}