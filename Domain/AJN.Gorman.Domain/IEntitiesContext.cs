using System.Data.Entity;

namespace AJN.Gorman.Domain
{
    public interface IEntitiesContext
    {
        Microsoft.Data.Entity.DbSet<Map> Maps { get; set; }
        Microsoft.Data.Entity.DbSet<Plan> Plans { get; set; }
        Microsoft.Data.Entity.DbSet<Phase> Phases { get; set; }
        Microsoft.Data.Entity.DbSet<Step> Steps { get; set; }
        int SaveChanges();
    }
}