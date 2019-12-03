using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopThiso.Models
{
    public class UserViewModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
    }
}
