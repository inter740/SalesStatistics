using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data
{
    public class StatisticsContext : DbContext
    {
        DbSet<Bestseller> Bestsellers { get; set; }
        DbSet<Insurance> Insurances { get; set; }
        DbSet<Appliances> Applianceses { get; set; }
        DbSet<SimCard> SimCards { get; set; }
        public DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        static StatisticsContext()
        {
            Database.SetInitializer<StatisticsContext>(new InitializerDb());
        }

        public StatisticsContext() : base("StatisticsSalesDb")
        { }
    }
}
