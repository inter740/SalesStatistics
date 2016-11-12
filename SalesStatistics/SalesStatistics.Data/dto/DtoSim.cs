using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities;
using SalesStatistics.Data.Enum;

namespace SalesStatistics.Data.dto
{
    public class DtoSim
    {
        public string Operator { get; set; }
        public string Date { get; set; }

        public int Month { get; set; }
        public int StartMonth { get; set; }
        public int EndMonth { get; set; }

        public DtoSim(SimCard sim)
        {
            Operator = sim.Operator.ToString();
            Date = sim.Date.Day.ToString() + "." + sim.Date.Month.ToString() + "." + sim.Date.Year.ToString();
        }

        public DtoSim() { }
    }
}
