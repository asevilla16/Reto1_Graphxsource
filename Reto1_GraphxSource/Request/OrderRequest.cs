using Reto1.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Reto1.API.Request
{
    public class OrderRequest
    {
        [Required]
        [StringLength(100)]
        public string Client { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public int? TShirtId { get; set; }
        public int? MugId { get; set; }
        public int? PosterId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.RECEIVED;
    }
}
