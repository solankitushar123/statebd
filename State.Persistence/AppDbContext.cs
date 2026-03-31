using Microsoft.EntityFrameworkCore;

namespace State.Persistence
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<States> States { get; init; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type t = typeof(AppDbContext);
            modelBuilder.ApplyConfigurationsFromAssembly(t.Assembly); 

            base.OnModelCreating(modelBuilder);
        }
    }
}

