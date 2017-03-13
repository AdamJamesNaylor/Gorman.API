

namespace Gorman.API.Core.Services {
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Repositories;

    public interface IActorService {
        Actor Add(Actor request);
        Actor Get(long id);
        List<Actor> List(long activityId);
        List<ActorSummary> ListSummaries(long activityId);
    }

    public class ActorService
        : IActorService {

        public ActorService(IActorRepository repository) {
            _repository = repository;
        }

        public Actor Add(Actor actor) {
            return _repository.Add(actor);
        }

        public Actor Get(long id) {
            return _repository.Get(id);
        }

        public List<Actor> List(long activityId) {
            return _repository.List(activityId);
        }

        public List<ActorSummary> ListSummaries(long activityId) {
            return _repository.ListSummaries(activityId);
        }

        private readonly IActorRepository _repository;
    }
}