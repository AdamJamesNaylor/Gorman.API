
namespace AJN.Gorman.API.Core.Services
{
    using AJN.Gorman.Domain;

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
            
        }

        private readonly IEntitiesContext _entitiesContext;
    }
}