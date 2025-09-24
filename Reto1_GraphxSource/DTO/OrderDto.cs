using Reto1.API.Entities;

namespace Reto1.API.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Client { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? TShirtId { get; set; }
        public int? MugId { get; set; }
        public int? PosterId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
