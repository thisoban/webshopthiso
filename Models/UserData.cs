using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class UserData
    {
        public int IdUser { get; set; }
        public string uid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public string Adres { get; set; }
        public string Housenumber { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
        public bool Admin { get; set; }
    }
}
