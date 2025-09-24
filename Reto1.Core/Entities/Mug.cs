using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto1.Core.Entities
{
    public class Mug : Product
    {
        public int? CapacityInMl { get; set; }

        [StringLength(100)]
        public string Color {  get; set; } = string.Empty;
    }
}
