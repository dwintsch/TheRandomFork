using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheRandomFork.Data;
using TheRandomFork.Models.Domain;
using TheRandomFork.Models.ViewModels;
using TheRandomFork.Services;

namespace TheRandomFork.Pages
{
    public class RestaurantModel : PageModel
    {
        public List<RestaurantViewModel> restaurants = new();
        private readonly RandomForkDbContext dbContext;

        [BindProperty]
        public RestaurantViewModel newRestaurant { get; set; } = new();
        public RestaurantModel(RandomForkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            var restaurantsDb = dbContext.Restaurants.ToList();
            // Reset the list
            restaurants.Clear();
            foreach (var restaurant in restaurantsDb)
            { // Transform all to the view model
                restaurants.Add(restaurant.ToViewModel(null));
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            dbContext.Restaurants.Add(newRestaurant.ToDomainModel()); 
            dbContext.SaveChanges();
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(Guid id)
        {
            var existingRestaurant = dbContext.Restaurants.Find(id);
            if(existingRestaurant != null)
            {
                dbContext.Restaurants.Remove(existingRestaurant);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Get");
        }
    }
}
