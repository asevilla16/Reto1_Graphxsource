using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto1.Core.Entities
{
    public class Poster : Product
    {
        public decimal HeightCm { get; set; }
        public decimal WidthCm { get; set; }

        [StringLength(50)]
        public string PaperType { get; set; } = string.Empty;
    }
}
