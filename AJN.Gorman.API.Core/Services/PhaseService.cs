
namespace AJN.Gorman.API.Core.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using System.Data.Entity;
    
    public class PhaseService
        : IPhaseService
    {
        public void Add(Phase phase)
        {
            using (var ctx = new EntitiesContext())
            {
                ctx.Phases.Add(phase);
                ctx.SaveChanges();
            }

        }

        public IEnumerable<Phase> List(int planId) {
            return null;
        }
    }
}