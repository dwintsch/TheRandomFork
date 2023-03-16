using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheRandomFork.Data;
using TheRandomFork.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace TheRandomFork.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly RandomForkDbContext dbContext;
        [BindProperty]
        public RestaurantViewModel updateRestaurant { get; set; }
        public EditModel(RandomForkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var restaurant = dbContext.Restaurants.Find(id);

            // Query to get all closed days of this restaurant
            var closedDayQuery = dbContext.ClosedDays.Where(x => x.RestaurantId == id);

            if (restaurant != null)
            {
                var closedDays = closedDayQuery.ToList();
                updateRestaurant = restaurant.ToViewModel(closedDays);
            }
        }

        public IActionResult OnPost(Guid id) 
        {
            if (updateRestaurant != null)
            {
                var existingRestaurant = dbContext.Restaurants.Find(id);
                if (existingRestaurant != null)
                {
                    // First delete all entries with the restaurant id. To be sure no others are left
                    dbContext.ClosedDays.RemoveRange(dbContext.ClosedDays.Where(x => x.RestaurantId == id));
 
                    // No update the entry and model
                    existingRestaurant.FromViewModel(updateRestaurant);
                    dbContext.SaveChanges();
                }
             }
            return Redirect("/Restaurants/Restaurants");
        }
    }
}
