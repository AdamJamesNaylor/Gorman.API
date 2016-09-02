
namespace Gorman.API.Core.Services {
    using Domain;
    using Repositories;

    public interface IMapService {
        Map Add(Map map);
        Map Get(long id);
    }

    public class MapService
        : IMapService {

        public MapService(IMapRepository repository) {
            _repository = repository;
        }

        public Map Add(Map map) {
            //validate
            return _repository.Add(map);
        }

        public Map Get(long id) {
            //add url etc.
            return _repository.Get(id);
        }

        private readonly IMapRepository _repository;
    }
}