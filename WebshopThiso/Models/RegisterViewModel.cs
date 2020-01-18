using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopThiso.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string password2 { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Housenumber { get; set; }
        [MaxLength(6)]
        public string Postalcode { get; set; }
        [Required]
        public string City { get; set; }
        public bool admin { get; set; } = false;
    }
}
