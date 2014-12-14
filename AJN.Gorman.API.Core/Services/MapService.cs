
namespace AJN.Gorman.API.Core.Services
{
    using AJN.Gorman.Domain;

    public class MapService : IMapService
    {
        public MapService(IEntitiesContext entitiesContext)
        {
            _entitiesContext = entitiesContext;
        }

        public void Add(Map map)
        {
            _entitiesContext.Maps.Add(map);
            _entitiesContext.SaveChanges();
        }

        private readonly IEntitiesContext _entitiesContext;
    }
}
