using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto1.API.Entities
{
    [Table("TShirts")]
    public class TShirt : Product
    {
        [StringLength(10)]
        public string? Size { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Color { get; set; } = string.Empty;
    }
}
