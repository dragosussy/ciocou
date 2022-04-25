using Domain;
using Microsoft.EntityFrameworkCore;

namespace ciocou_backend.DbContext
{
    public class Repository : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Link> Links { get; set; }

        public Repository(DbContextOptions<Repository> options) : base(options)
        {
        }
    }
}
