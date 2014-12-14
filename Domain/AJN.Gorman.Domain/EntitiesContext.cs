
namespace AJN.Gorman.Domain
{
    using System.Data.Entity;

    public class EntitiesContext
        : DbContext, IEntitiesContext
    {
        public IDbSet<Map> Maps { get; set; }
        public IDbSet<Plan> Plans { get; set; }
        public IDbSet<Phase> Phases { get; set; }
        public IDbSet<Step> Steps { get; set; }
    }
}
