using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Enum;

namespace SalesStatistics.Data.Entities
{
    public class Appliances : BaseEntity
    {
        public TypeAppliances Type { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public Appliances()
        {
            Date = DateTime.Today;
        }
    }
}
