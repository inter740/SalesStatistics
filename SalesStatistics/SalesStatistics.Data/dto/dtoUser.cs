using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data.dto
{
    public class DtoUser
    {
        public int Id { get; set; }
        public DateTime RegDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Cookies { get; set; }

        public int Month { get; set; }
        public int StartMonth { get; set; }
        public int EndMonth { get; set; }

        public DtoUser(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Role = user.Role;
            Cookies = user.Cookies;
        }
    }
}
