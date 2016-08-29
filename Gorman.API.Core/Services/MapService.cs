
namespace Gorman.API.Core.Services {
    using System.Linq;
    using Domain;

    public class MapService
        : IMapService {

        public MapService(IEntitiesContext entitiesContext) {
            _entitiesContext = entitiesContext;
        }

        public void Add(Map map) {
            _entitiesContext.Maps.Add(map);
            _entitiesContext.SaveChanges();
        }

        private readonly IEntitiesContext _entitiesContext;

        public Map Get(int id) {
            return _entitiesContext.Maps.FirstOrDefault(m => m.Id == id);
        }
    }
}
