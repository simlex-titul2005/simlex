using simlex.Models;
using System.Data.Entity;

namespace simlex.Infrastructure
{
    public sealed class DbContext : SX.WebCore.SxDbContext
    {
        public DbContext() : base("DbContext") { }

        public new DbSet<Article> Articles { get; set; }
    }
}