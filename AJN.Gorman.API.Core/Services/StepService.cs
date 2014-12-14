using AJN.Gorman.Domain;

namespace AJN.Gorman.API.Core.Services
{
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