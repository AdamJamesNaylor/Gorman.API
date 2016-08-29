
namespace Gorman.API.Core {
    using System.Data.Entity;
    using Domain;

    public interface IEntitiesContext {

        DbSet<Map> Maps { get; set; }
        DbSet<Plan> Plans { get; set; }
        DbSet<Phase> Phases { get; set; }
        DbSet<Step> Steps { get; set; }

        int SaveChanges();

    }
}