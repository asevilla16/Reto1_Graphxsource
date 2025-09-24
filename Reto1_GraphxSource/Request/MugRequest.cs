using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reto1.API.Request
{
    public class MugRequest
    {
        public int? CapacityInMl { get; set; }

        public string Color { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
