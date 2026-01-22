using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) // Calls DbContext's constructor
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User-Activity one-to-many relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedActivities)
                .WithOne(a => a.CreatedBy)
                .HasForeignKey(a => a.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull); // When user is deleted, set CreatedByUserId to null

            // Configure primary keys (optional but explicit)
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Activity>()
                .HasKey(a => a.ActivityId);

            //Seed Admin user
            modelBuilder.Entity<User>().HasData(
                new User
                    {
                        UserId = "admin_user",
                        Name = "Batman",
                        Email = "admin@example.com",
                        Role = "Admin"
                }
             );
        }
    }
}