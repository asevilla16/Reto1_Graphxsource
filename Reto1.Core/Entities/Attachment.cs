using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto1.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Url { get; set; } = string.Empty;
        public AttachmentType Type { get; set; }
    }
}
