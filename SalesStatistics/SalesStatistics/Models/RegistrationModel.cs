using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SalesStatistics.Data;

namespace SalesStatistics.Models
{
    public class RegistrationModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = " *")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " *")]
        public string LastName { get; set; }

        [Required(ErrorMessage = " *")]
        public string Password { get; set; }

        [Required(ErrorMessage = " *")]
        [Compare("Password", ErrorMessage = " Incorrect password")]
        public string DPassword { get; set; }

        public Role Role { get; set; }
    }
}