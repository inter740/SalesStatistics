using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesStatistics.Data.dto;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Models
{
    public class ModelForHome
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public DtoUser Dto { get; set; }

        public ModelForHome(User user)
        {
            if (user != null)
            {
                UserName = user.FirstName + " " + user.LastName;
                LastName = user.LastName;
                Dto = new DtoUser(user);
            }
            else
            {
                UserName = "";
            }
            
        }
    }
}