using System.ComponentModel.DataAnnotations.Schema;

namespace TheRandomFork.Models.Domain
{
    public class RestaurantClosedDay
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
        public Guid RestaurantId { get; set; }
        public DayOfWeek ClosedDay { get; set; }    
    }
}
