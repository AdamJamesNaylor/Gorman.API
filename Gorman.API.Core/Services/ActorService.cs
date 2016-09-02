

namespace Gorman.API.Core.Services {
    using System.Collections.ObjectModel;
    using Domain;
    using Repositories;

    public interface IActorService {
        Actor Add(Actor request);
        Actor Get(long id);
        ReadOnlyCollection<Actor> List(long id);
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

        public ReadOnlyCollection<Actor> List(long mapId) {
            return _repository.List(mapId);
        }

        private readonly IActorRepository _repository;
    }
}