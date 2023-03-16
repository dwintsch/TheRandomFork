using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheRandomFork.Data;
using TheRandomFork.Models.Domain;
using TheRandomFork.Models.ViewModels;

namespace TheRandomFork.Pages.Restaurants
{
    public class SelectModel : PageModel
    {
        private const int RESTAURANTS_TO_IGNORE_FROM_HISTORY = 5;

        private readonly RandomForkDbContext dbContext;
        public RestaurantViewModel Restaurant{ get; set; } = new RestaurantViewModel();
        public SelectModel(RandomForkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    
        public void OnGet(Guid? id)
        {
            if (id != null)
            {
                var existingRestaurant = dbContext.Restaurants.Find(id);
                if (existingRestaurant != null)
                {
                    Restaurant.FromDomainModel(existingRestaurant);
                }
            }
        }
        public IActionResult OnPostSaveRestaurant(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var restaurantHistory = new RestaurantHistoryEntry();
            restaurantHistory.RestaurantId = id;
            restaurantHistory.VisitDateTime = DateTime.Now;
            dbContext.RestaurantHistory.Add(restaurantHistory);
            dbContext.SaveChanges();

            ViewData["Message"] = "History updated, enjoy the meal!!!";
            return Page();
        }

        public IActionResult OnPostSelectRestaurant()
        {
            return OnPost();
        }

        public IActionResult OnPost()
        {
            // Query to order and just take the first fife, they needs to be ignored afterwards from the restaurant list
            var historyQuery = dbContext.RestaurantHistory
                .OrderByDescending(x => x.VisitDateTime)
                .Select(x => x.RestaurantId)
                .Take(RESTAURANTS_TO_IGNORE_FROM_HISTORY);

            DayOfWeek wk = DateTime.Today.DayOfWeek;

            // Query to select all restaurants which are closed today
            var closedDaysQuery = dbContext.ClosedDays
                .Where(x => x.ClosedDay == wk)
                .Select(x => x.RestaurantId);
                
            // Query to use just restaurants which are not in the query from above
            var randomRestaurants = dbContext.Restaurants
                .Where(x => !historyQuery.Contains(x.Id) && !closedDaysQuery.Contains(x.Id));

            var cnt = randomRestaurants.Count();

            if (cnt > 0)
            {
                var restaurant = randomRestaurants.Skip(Random.Shared.Next(cnt)).FirstOrDefault();
                if (restaurant != null)
                {
                    return Redirect($"/Restaurants/Select/{restaurant.Id}");
                }
            }else
            {
                ViewData["Message"] = "No restaurant available";
            }
            return Page();
        }
    }
}
