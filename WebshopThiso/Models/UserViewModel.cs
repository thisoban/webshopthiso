using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataModel;

namespace WebshopThiso.Models
{
    public class UserViewModel
    {
        public string  uid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string housenumber { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
        public string password { get; set; }

        public UserViewModel(UserData data)
        {
            uid = data.uid;
            Firstname = data.Firstname;
            Surname = data.Surname;
            Email = data.Email;
            Adres = data.Adres;
            housenumber = data.Housenumber;
            Postalcode = data.Postalcode;
            City = data.City;
            password = data.Passsword;
        }

        public UserViewModel()
        {

        }
    }
}
