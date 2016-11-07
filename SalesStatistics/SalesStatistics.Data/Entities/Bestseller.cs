using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.Data.Entities
{
    public class Bestseller : BaseEntity
    {
        public int Price { get; set; }
        public int Count { get; set; }

        public Bestseller()
        {
            Date = DateTime.Today;
        }
    }
}
