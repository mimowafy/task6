using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="User Name is required")]
        [Display(Name ="User Name")]
        [StringLength(100,ErrorMessage ="User Name is too large")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "User Phone")]
        public string UserPhone { get; set; }
        [Required]
        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please Enter a valid Email Address")]
        public string UserEmail { get; set; }
        [Required]
        [Display(Name = "User Address")]
        public string UserAddress { get; set; }
        [Required]
        [Display(Name = "User Length")]
        [Column(TypeName = "decimal(3,2)")]
        public decimal UserLength { get; set; }
        [Required]
        [Display(Name = "User Weight")]
        [Column(TypeName = "decimal(3,2)")]
        public decimal UserWeight { get; set; }
        [Required]
        [Display(Name = "User Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required]
        public List<User_Provider> ProvidersList { get; set; }
        [Required]
        public List<Order> OrdersList { get; set; }
    }
}
