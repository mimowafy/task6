using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshLifie.Models
{
    public class User_Provider
    {
        public int UserId { get; set; }
        public User _user { get; set; }
        public int ProviderID { get; set; }
        public Provider _providers { get; set; }
    }
}
