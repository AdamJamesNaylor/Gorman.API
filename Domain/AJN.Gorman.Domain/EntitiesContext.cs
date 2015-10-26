
using System;
using System.IO;
using System.Reflection;

namespace AJN.Gorman.Domain
{
    using System.Data.Entity;
    using Microsoft.Data.Entity;
    using Microsoft.Data.Sqlite;

    public class EntitiesContext
        : Microsoft.Data.Entity.DbContext, IEntitiesContext
    {
        public Microsoft.Data.Entity.DbSet<Map> Maps { get; set; }
        public Microsoft.Data.Entity.DbSet<Plan> Plans { get; set; }
        public Microsoft.Data.Entity.DbSet<Phase> Phases { get; set; }
        public Microsoft.Data.Entity.DbSet<Step> Steps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = Path.GetDirectoryName(path) + "\\data.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
