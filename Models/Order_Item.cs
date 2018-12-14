using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Models
{
    public class Order_Item
    {
        public int OrderId { get; set; }
        public Order _Order { get; set; }
        public int ItemId { get; set; }
        public item _Item { get; set; }
    }
}
