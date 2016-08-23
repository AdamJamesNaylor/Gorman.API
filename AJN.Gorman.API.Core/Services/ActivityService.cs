
namespace AJN.Gorman.API.Core.Services {
    using Domain;

    public class ActivityService
        : IActivityService {

        public ActivityService(IEntitiesContext entitiesContext) {
            _entitiesContext = entitiesContext;
        }

        public void Add(Activity request) {
            //_entitiesContext.Activities.Add(request);
            _entitiesContext.SaveChanges();
        }

        private readonly IEntitiesContext _entitiesContext;
    }
}