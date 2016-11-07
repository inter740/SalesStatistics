using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public Role(string role)
        {
            RoleName = role;
        }

        public virtual ICollection<User> Users { get; set; }
    }
}
