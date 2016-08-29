
namespace Gorman.API.Core.Services {
    using Domain;
    using Repositories;

    public interface IMapService {
        void Add(Map map);
        Map Get(int id);
    }

    public class MapService
        : IMapService {

        public MapService(IMapRepository repository) {
            _repository = repository;
        }

        public void Add(Map map) {
            //validate
            _repository.Add(map);
        }

        public Map Get(int id) {
            //add url etc.
            return _repository.Get(id);
        }

        private readonly IMapRepository _repository;
    }
}