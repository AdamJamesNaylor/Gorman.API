using System.Data.Entity;

namespace AJN.Gorman.Domain
{
    public interface IEntitiesContext
    {
        IDbSet<Map> Maps { get; set; }
        IDbSet<Plan> Plans { get; set; }
        IDbSet<Phase> Phases { get; set; }
        IDbSet<Step> Steps { get; set; }
        int SaveChanges();
    }
}