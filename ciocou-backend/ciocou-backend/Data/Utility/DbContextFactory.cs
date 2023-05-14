using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Utility
{
    /// <summary>
    /// Used to enable migrations from the `Data` layer
    /// </summary>
    public class DbContextFactory : IDesignTimeDbContextFactory<CiocouPostgresDbContext>
    {
        public DbContextFactory()
        {
        }

        public CiocouPostgresDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CiocouPostgresDbContext>();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            return new CiocouPostgresDbContext(builder.Options);
        }
    }
}
