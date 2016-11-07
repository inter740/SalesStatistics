using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data
{
    class InitializerDb : CreateDatabaseIfNotExists<StatisticsContext>
    {
        StatisticsContext _context = new StatisticsContext();

        protected override void Seed(StatisticsContext context)
        {
            ServiceToWorkWithUsers.AddRole("Admin");
            ServiceToWorkWithUsers.AddRole("User");

            User user = new User() { FirstName = "admin", LastName = "admin", Password = "123", RoleId = 1};
            ServiceToWorkWithUsers.AddUser(user);

            base.Seed(context);
        }
    }

    
}
