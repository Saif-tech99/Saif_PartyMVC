using System;
using System.ComponentModel.DataAnnotations;

namespace Saif_PartyMVC.Models
{
    public class Visitor
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Second Name")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [EmailAddress(ErrorMessage = "Email format is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Tel Number")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Please enter your Age")]
        [Range(18, 60, ErrorMessage = "Age must be between  18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        public string Addtess { get; set; }

        [Required(ErrorMessage = "Please enter your Postal Code")]
        [Range(1000, 1500, ErrorMessage = "Postal code is not valid")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }

        public bool IsFamily { get; set; }
    }
}
