
namespace Gorman.API.Core.Services {
    using System.Collections.ObjectModel;
    using Domain;
    using Repositories;

    public interface IActivityService {
        Activity Add(Activity request);
        Activity Get(long id);
        ReadOnlyCollection<Activity> List(long mapId);
    }

    public class ActivityService
        : IActivityService {

        public ActivityService(IActivityRepository repository) {
            _repository = repository;
        }

        public Activity Add(Activity request) {
            return _repository.Add(request);
        }

        public Activity Get(long id) {
            return _repository.Get(id);
        }

        public ReadOnlyCollection<Activity> List(long mapId) {
            return _repository.List(mapId);
        }

        private readonly IActivityRepository _repository;
    }
}