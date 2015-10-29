

namespace AJN.Gorman.API.Core
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Domain;

    public class EntitiesContext
        : DbContext, IEntitiesContext
    {
        public DbSet<Map> Maps { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Step> Steps { get; set; }

        public EntitiesContext() {
            Database.SetInitializer<EntitiesContext>(null);
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
