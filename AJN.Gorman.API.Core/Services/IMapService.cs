using AJN.Gorman.Domain;

namespace AJN.Gorman.API.Core.Services {
    public interface IMapService {
        void Add(Map map);
        Map Get(int id);
    }
}