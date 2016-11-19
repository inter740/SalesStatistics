using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities.Abstract;

namespace SalesStatistics.Data.Entities
{
    public class Bestseller : BaseProduckt
    {
        public int Price { get; set; }
        public int Count { get; set; }

        public Bestseller()
        {
            Date = DateTime.Today;
        }
    }
}
