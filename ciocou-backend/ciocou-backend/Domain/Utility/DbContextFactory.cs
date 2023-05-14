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
            var builder = new DbContextOptionsBuilder<CiocouPostgresDbContext>();
            var connectionString = ConfigurationUtils.GetDataLayerConfiguration().GetConnectionString("DefaultConnection");

            builder.UseNpgsql(connectionString);

            return new CiocouPostgresDbContext(builder.Options);
        }
    }
}
