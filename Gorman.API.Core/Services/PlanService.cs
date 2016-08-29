
namespace Gorman.API.Core.Services
{
    using Domain;

    public class PlanService
        : IPlanService {


        public int Add(Plan plan) {


            return plan.Id;
        }

        public void Update(Plan plan) {
        }

    }
}