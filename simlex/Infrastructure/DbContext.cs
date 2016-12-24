namespace simlex.Infrastructure
{
    public sealed class DbContext : SX.WebCore.SxDbContext
    {
        public DbContext() : base("DbContext") { }
    }
}