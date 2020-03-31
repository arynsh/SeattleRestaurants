using Microsoft.EntityFrameworkCore;

namespace SeattleRestaurants.Models
{
    public class SeattleRestaurantsContext : DbContext
    {
        public SeattleRestaurantsContext(DbContextOptions<SeattleRestaurantsContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}