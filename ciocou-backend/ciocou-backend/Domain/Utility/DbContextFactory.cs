using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Utility
{
    /// <summary>
    /// Used to enable migrations from the `Data` layer
    /// </summary>
    internal class DbContextFactory : IDesignTimeDbContextFactory<CiocouPostgresDbContext>
    {
        public DbContextFactory()
        {
        }

        public CiocouPostgresDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CiocouPostgresDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(connectionString);

            return new CiocouPostgresDbContext(builder.Options);
        }
    }
}
