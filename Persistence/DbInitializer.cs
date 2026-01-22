using Domain;

namespace Persistence
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Activities.Any())
            {
                var activity = new Activity
                {
                    ActivityId = "gfdfgdfgd",
                    Title = "Sample Activity",
                    Date = DateTime.UtcNow,
                    Description = "This is a sample activity.",
                    Category = "General",
                    IsCancelled = false,
                    City = "Sample City",
                    Place = "Sample Venue",
                    Latitude = 0.0,
                    Longitude = 0.0,
                    CreatedByUserId = "admin_user"
                };

                context.Activities.Add(activity);
                context.SaveChanges();
            }
        }
    }
}