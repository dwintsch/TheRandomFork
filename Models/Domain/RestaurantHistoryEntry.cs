using System.ComponentModel.DataAnnotations.Schema;

namespace TheRandomFork.Models.Domain
{
    public class RestaurantHistoryEntry
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime VisitDateTime { get; set; }
    }
}
