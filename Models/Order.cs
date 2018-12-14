using FreshLifie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Models
{
    public class Order
    {
    public int OrderId { get; set; }
        [Required(ErrorMessage = "You must Enter Order Price")]
        [Display(Name = "Prder Price")]
        [Column(TypeName ="decimal(18,3)")]
        public decimal Order_price { get; set; }
        public int UserId { get; set; }
        public User _User { get; set; }
        public List<Provider_Order> prvoderslist { get; set; }
    public List<Order_Item> ItemList { get; set; }

    }
}
