using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Models
{
    public class Provider
    {
        public int ProviderID { get; set; }
        [Required(ErrorMessage ="You must Enter Provider Name")]
        [Display(Name ="Provider Name")]
        public string ProviderName { get; set; }
        [Required(ErrorMessage ="You must enter a provider URL")]
        [DataType(DataType.Url,ErrorMessage ="Please enter a valid URL")]
        [Display(Name ="Provider URL")]
        public string ProviderURL { get; set; }
        
        // Foreign Key of Service Type Model
        public int ProductTypeID { get; set; }
        public Product_Type _Product_Type { get; set; }
        public List<Provider_Order> orderList { get; set; }
        public List<User_Provider> UserList { get; set; }


    }
}
