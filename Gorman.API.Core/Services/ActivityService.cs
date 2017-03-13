
namespace Gorman.API.Core.Services {
    using System.Collections.Generic;
    using Domain;
    using Repositories;

    public interface IActivityService {
        Activity Add(Activity request);
        Activity Get(long id);
        List<Activity> List(long parentActivityId);
        List<ActivitySummary> ListSummaries(long activityId);
    }

    public class ActivityService
        : IActivityService {

        public ActivityService(IActivityRepository repository, IActorService actorService, IActionService actionService) {
            _repository = repository;
            _actorService = actorService;
            _actionService = actionService;
        }

        public Activity Add(Activity request) {
            return _repository.Add(request);
        }

        public Activity Get(long id) {
            var activity = _repository.Get(id);
            activity.Activities = ListSummaries(activity.Id);
            activity.Actors = _actorService.ListSummaries(activity.Id);
            activity.Actions = _actionService.ListSummaries(activity.Id);
            return activity;
        }

        public List<ActivitySummary> ListSummaries(long activityId) {
            return _repository.ListSummaries(activityId);
        }

        public List<Activity> List(long parentActivityId) {
            return _repository.List(parentActivityId);
        }

        private readonly IActivityRepository _repository;
        private readonly IActorService _actorService;
        private readonly IActionService _actionService;
    }
}