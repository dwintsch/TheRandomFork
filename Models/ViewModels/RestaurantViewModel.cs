using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TheRandomFork.Models.Domain;

namespace TheRandomFork.Models.ViewModels
{
    // Pass the information from the view to the class behind in the DB
    public class RestaurantViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Road { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public RestaurantType Type { get; set; }
        public string Homepage { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }

        public Restaurant ToDomainModel()
        {
            var restaurantDomainModle = new Restaurant();
            restaurantDomainModle.Id = Id;
            restaurantDomainModle.Name = Name;
            restaurantDomainModle.Road = Road;
            restaurantDomainModle.City = City;
            restaurantDomainModle.PhoneNumber = PhoneNumber;
            restaurantDomainModle.Type = Type;
            restaurantDomainModle.Homepage = Homepage;
            return restaurantDomainModle;
        }

        public void FromDomainModel(Restaurant restaurant)
        {
            Id = restaurant.Id;
            Name = restaurant.Name;
            Road = restaurant.Road;
            City = restaurant.City;
            PhoneNumber = restaurant.PhoneNumber;
            Type = restaurant.Type;
            Homepage = restaurant.Homepage;
        }
    }
}
