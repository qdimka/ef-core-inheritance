using EfCore.Example.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Example.Dal
{
    public class ExampleAppDbContext : DbContext
    {
        public DbSet<Connection> Connections { get; set; }
        public DbSet<MssqlConnectionInfo> MssqlConnectionInfos { get; set; }
        public DbSet<PostgresConnectionInfo> PostgresConnectionInfos { get; set; }
        public DbSet<ServerConnectionInfo> ServerConnectionInfos { get; set; }
        
        public ExampleAppDbContext(
            DbContextOptions<ExampleAppDbContext> options) : base(options)

        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectionInfo>()
                .HasDiscriminator(x => x.Type);

            base.OnModelCreating(modelBuilder);
        }
    }
}