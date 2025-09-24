using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto1.API.Entities
{
    [Table("Posters")]
    public class Poster : Product
    {
        public decimal HeightCm { get; set; }
        public decimal WidthCm { get; set; }

        [StringLength(50)]
        public string PaperType { get; set; } = string.Empty;
    }
}
