
namespace Gorman.API.Core.Services {
    using Domain;

    public interface IMapService {
        void Add(Map map);
        Map Get(int id);
    }
}