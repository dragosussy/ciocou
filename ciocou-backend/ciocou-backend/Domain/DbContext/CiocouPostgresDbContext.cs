using Microsoft.EntityFrameworkCore;
using Service;

namespace Data.DbContext
{
    public class CiocouPostgresDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<CioccEvent> CioccEvents { get; set; }

        public CiocouPostgresDbContext()
        {
        }

        public CiocouPostgresDbContext(DbContextOptions<CiocouPostgresDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder
                .UseSnakeCaseNamingConvention();
    }
}
