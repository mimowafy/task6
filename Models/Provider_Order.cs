using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Models
{
    public class Provider_Order
    {
        public int ProviderID { get; set; }
        public Provider _provider { get; set; }
        public int OrderId { get; set; }
        public Order _Order { get; set; }
}
}
