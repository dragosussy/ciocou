using Data.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service;

namespace Data.DbContext
{
    public class CiocouPostgresDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<CioccEvent> CioccEvents { get; set; }

        public CiocouPostgresDbContext(DbContextOptions<CiocouPostgresDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseNpgsql(ConfigurationUtils.GetDataLayerConfiguration().GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.ApplyUtcDateTimeConverter();
    }
}
