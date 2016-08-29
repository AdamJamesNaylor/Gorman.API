
namespace Gorman.API.Core.Services
{
    using System.Collections.Generic;
    using Domain;
    
    public interface IPhaseService
    {
        void Add(Phase phase);

        IEnumerable<Phase> List(int planId);
    }
}