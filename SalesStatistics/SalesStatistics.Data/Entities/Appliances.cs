using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities.Abstract;
using SalesStatistics.Data.Enum;

namespace SalesStatistics.Data.Entities
{
    public class Appliances : BaseProduckt
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
