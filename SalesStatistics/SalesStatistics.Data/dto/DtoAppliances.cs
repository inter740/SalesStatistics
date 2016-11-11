using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;

namespace SalesStatistics.Data.dto
{
    public class DtoAppliances
    {
        public int Price { get; set; }
        public int Count { get; set; }
        public string Date { get; set; }

        public int Month { get; set; }
        public int StartMonth { get; set; }
        public int EndMonth { get; set; }

        public DtoAppliances(Appliances appliances)
        {
            Count = appliances.Count;
            Price = appliances.Price;
            Date = appliances.Date.Day.ToString() + "." + appliances.Date.Month.ToString() + "." + appliances.Date.Year.ToString();
        }

        public DtoAppliances() { }
    }
}
