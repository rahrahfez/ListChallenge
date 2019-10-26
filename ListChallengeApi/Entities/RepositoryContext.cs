using Microsoft.EntityFrameworkCore;

namespace Entities
{
  public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) {}
        public DbSet<RootTreeModel> Root { get; set; }
        public DbSet<FactoryModel> Factory { get; set; }
        public DbSet<ChildModel> Child { get; set; }
    }
}