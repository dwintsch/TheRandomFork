using Microsoft.EntityFrameworkCore;
using TheRandomFork.Models.Domain;

namespace TheRandomFork.Data
{
    // Vererbung von DbContext Class
    public class RandomForkDbContext : DbContext
    {
        public RandomForkDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantHistoryEntry> RestaurantHistory { get; set; }
        public DbSet<RestaurantClosedDay> ClosedDays { get; set; }
    }
}
