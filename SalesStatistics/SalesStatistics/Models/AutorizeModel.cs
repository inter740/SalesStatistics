using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class AutorizeModel
    {
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}