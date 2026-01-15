using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) // Calls DbContext's constructor
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}