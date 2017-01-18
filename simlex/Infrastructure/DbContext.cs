using simlex.Models;
using System.Data.Entity;

namespace simlex.Infrastructure
{
    public sealed class DbContext : SX.WebCore.SxDbContext
    {
        public DbContext() : base("DbContext") { }

        public new DbSet<Article> Articles { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Project>().HasRequired(x => x.Material).WithMany().HasForeignKey(x => new { x.Id, x.ModelCoreType });
        }

        
    }
}