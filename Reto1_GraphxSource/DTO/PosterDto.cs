namespace Reto1.API.DTO
{
    public class PosterDto
    {
        public int Id { get; set; }
        public decimal HeightCm { get; set; }
        public decimal WidthCm { get; set; }
        public string PaperType { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
