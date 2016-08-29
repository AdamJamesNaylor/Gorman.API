
namespace Gorman.API.Core.Services
{
    using Domain;

    public class StepService : IStepService
    {
        public void Add(Step step)
        {
            using (var ctx = new EntitiesContext())
            {
                ctx.Steps.Add(step);
                ctx.SaveChanges();
            }
        }
    }
}