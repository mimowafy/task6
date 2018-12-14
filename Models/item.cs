using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Models
{
    public class item
    {
         public int itemId { get; set; }
        [Required(ErrorMessage = "You must Enter Item Title")]
        [Display(Name = "Item Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must Enter Item Title")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        [Required(ErrorMessage =" You must enter the price")]
        [Display(Name ="Item Price")]
        public decimal Price { get; set; }
        public List<Order_Item> OrderList { get; set; }

    }
}
