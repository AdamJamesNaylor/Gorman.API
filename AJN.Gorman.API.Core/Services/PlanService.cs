
namespace AJN.Gorman.API.Core.Services
{
    using AJN.Gorman.Domain;

    public class PlanService : IPlanService
    {
        public void Add(Plan plan)
        {
            using (var ctx = new EntitiesContext())
            {
                ctx.Plans.Add(plan);
                ctx.SaveChanges();
            }
        }
        
    }
}