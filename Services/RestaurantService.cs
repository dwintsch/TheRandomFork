using System.Xml.Linq;
using TheRandomFork.Models.Domain;

// No longer used, was used without the DB connntion

namespace TheRandomFork.Services
{
    public static class RestaurantService
    {
        static List<Restaurant> Restaurants { get; }
        static RestaurantService()
        {
            Restaurants = new List<Restaurant>();
        }

        public static List<Restaurant> GetAll() => Restaurants;

        public static Restaurant? Get(Guid id) => Restaurants.FirstOrDefault(p => p.Id == id);

        public static void Add(Restaurant restaurant)
        {
           // restaurant.Id = nextId++;
            Restaurants.Add(restaurant);
        }

        public static void Delete(Guid id)
        {
            var restaurant = Get(id);
            if (restaurant is null)
                return;

            Restaurants.Remove(restaurant);
        }

        public static void Update(Restaurant restaurant)
        {
            var index = Restaurants.FindIndex(p => p.Id == restaurant.Id);
            if (index == -1)
                return;

            Restaurants[index] = restaurant;
        }
    }
}
