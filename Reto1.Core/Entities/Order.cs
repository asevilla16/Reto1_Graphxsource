using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto1.Core.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Client { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public OrderStatus Status { get; set; } = OrderStatus.RECEIVED;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
