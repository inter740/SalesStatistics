using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data.dto
{
    public class DtoBestseller
    {
        public int Price { get; set; }
        public int Count { get; set; }
        public string Date { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public int StartMonth { get; set; }
        public int EndMonth { get; set; }

        public DtoBestseller(Bestseller best)
        {
            Count = best.Count;
            Price = best.Price;
            Date = best.Date.Day.ToString()+"."+ best.Date.Month.ToString()+"."+ best.Date.Year.ToString();
        }

        public DtoBestseller() { }

    }
}
