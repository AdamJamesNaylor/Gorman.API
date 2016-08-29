
namespace Gorman.API.Core.Services
{
    using Domain;

    public class PlanService
        : IPlanService {

        public PlanService(IEntitiesContext entitiesContext) {
            _entitiesContext = entitiesContext;
        }

        public int Add(Plan plan) {

            _entitiesContext.Plans.Add(plan);
            _entitiesContext.SaveChanges();

            return plan.Id;
        }

        public void Update(Plan plan) {
            //_entitiesContext.TrackGraph(plan, node => node.Entry.State = EntityState.Added);
            _entitiesContext.SaveChanges();
        }

        private readonly IEntitiesContext _entitiesContext;
    }
}