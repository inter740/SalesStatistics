using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public DateTime RegDate { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Cookies { get; set; }

        public User()
        {
            RegDate = DateTime.Now;
            
        }
    }
}
