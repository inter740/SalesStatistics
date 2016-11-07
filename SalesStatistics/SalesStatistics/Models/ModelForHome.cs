using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Models
{
    public class ModelForHome
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }

        public ModelForHome(User user)
        {
            if (user != null)
            {
                UserName = user.FirstName + " " + user.LastName;
                LastName = user.LastName;
                UserId = user.Id;
            }
            else
            {
                UserName = "Гость";
                LastName = "Гость";
            }

        }
    }
}