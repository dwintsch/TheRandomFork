using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TheRandomFork.Models.ViewModels;

namespace TheRandomFork.Models.Domain
{
    public class Restaurant
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Road { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public RestaurantType Type { get; set; }
        public string Homepage { get; set; }
        public virtual ICollection<RestaurantClosedDay> ClosedDays { get; set; }
        public virtual ICollection<RestaurantHistoryEntry> History { get; set; }
        public RestaurantViewModel ToViewModel(List<RestaurantClosedDay> ClosedDays)
        {
            var restaurantViewModle = new RestaurantViewModel();

            restaurantViewModle.Name = Name;
            restaurantViewModle.Road = Road;
            restaurantViewModle.City = City;
            restaurantViewModle.PhoneNumber = PhoneNumber;
            restaurantViewModle.Type = Type;
            restaurantViewModle.Homepage = Homepage;
            restaurantViewModle.Id = Id;

            if(ClosedDays != null)
            {
                if (ClosedDays.Any(x => x.ClosedDay == DayOfWeek.Monday)) restaurantViewModle.Monday = true;
                if (ClosedDays.Any(x => x.ClosedDay == DayOfWeek.Tuesday)) restaurantViewModle.Tuesday = true;
                if (ClosedDays.Any(x => x.ClosedDay == DayOfWeek.Wednesday)) restaurantViewModle.Wednesday = true;
                if (ClosedDays.Any(x => x.ClosedDay == DayOfWeek.Thursday)) restaurantViewModle.Thursday = true;
                if (ClosedDays.Any(x => x.ClosedDay == DayOfWeek.Friday)) restaurantViewModle.Friday = true;
            }
            return restaurantViewModle;
        }

        public void FromViewModel(RestaurantViewModel viewModel)
        {
            Name = viewModel.Name;
            Road = viewModel.Road;
            City = viewModel.City;
            PhoneNumber = viewModel.PhoneNumber;
            Type = viewModel.Type;
            Homepage = viewModel.Homepage;

            // Generate new collection of the new days. 
            // Interate afterwards thow every checkbox, not that nice... :-(
            ClosedDays = new Collection<RestaurantClosedDay>();
            if (viewModel.Monday)
            {
                var closedDay = new RestaurantClosedDay();
                closedDay.RestaurantId = Id;
                closedDay.ClosedDay = DayOfWeek.Monday;
                ClosedDays.Add(closedDay);
            }
            if (viewModel.Tuesday)
            {
                var closedDay = new RestaurantClosedDay();
                closedDay.RestaurantId = Id;
                closedDay.ClosedDay = DayOfWeek.Tuesday;
                ClosedDays.Add(closedDay);
            }
            if (viewModel.Wednesday)
            {
                var closedDay = new RestaurantClosedDay();
                closedDay.RestaurantId = Id;
                closedDay.ClosedDay = DayOfWeek.Wednesday;
                ClosedDays.Add(closedDay);
            }
            if (viewModel.Thursday)
            {
                var closedDay = new RestaurantClosedDay();
                closedDay.RestaurantId = Id;
                closedDay.ClosedDay = DayOfWeek.Thursday;
                ClosedDays.Add(closedDay);
            }
            if (viewModel.Friday)
            {
                var closedDay = new RestaurantClosedDay();
                closedDay.RestaurantId = Id;
                closedDay.ClosedDay = DayOfWeek.Friday;
                ClosedDays.Add(closedDay);
            }
        }
    }

    public enum RestaurantType { FastFood, Italian, Asia, Swiss, Indian, MiddleClass, Others }
}
