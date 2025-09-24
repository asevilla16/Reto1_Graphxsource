namespace Reto1.API.DTO
{
    public class MugDto
    {
        public int Id { get; set; }
        public int? CapacityInMl { get; set; }

        public string Color { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
