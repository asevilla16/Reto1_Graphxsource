using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto1.Core.Entities
{
    public enum OrderStatus
    {
        RECEIVED,
        UNDER_REVIEW,
        APPROVED,
        IN_PRODUCTION,
        SHIPPED,
        DELIVERED
    }
}
