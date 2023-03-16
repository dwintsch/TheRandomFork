using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;
using TheRandomFork.Data;
using TheRandomFork.Models.Domain;
using TheRandomFork.Models.ViewModels;

namespace TheRandomFork.Pages.Restaurants
{
    public class HistoryVisitModel : PageModel
    {
        public List<String> restaurantNames = new();
        public List<DateTime> restaurantVisits = new();
        public List<Guid> restaurantIds = new();

        private readonly RandomForkDbContext dbContext;
        public HistoryVisitModel(RandomForkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            // Get the restaurant history with Linq query
            var historyList = dbContext.RestaurantHistory.Select(x => new { Name = x.Restaurant.Name, VisitDate= x.VisitDateTime, VisitId = x.Id});

            historyList = historyList.OrderByDescending(x => x.VisitDate);

            foreach (var obj in historyList)
            {
                restaurantNames.Add(obj.Name);
                restaurantVisits.Add(obj.VisitDate);
                restaurantIds.Add(obj.VisitId);
            }
        }

        public IActionResult OnPostDelete(Guid id)
        {
            var historyEvent = dbContext.RestaurantHistory.Find(id);
            if (historyEvent != null)
            {
                dbContext.RestaurantHistory.Remove(historyEvent);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Get");
        }
    }
}
