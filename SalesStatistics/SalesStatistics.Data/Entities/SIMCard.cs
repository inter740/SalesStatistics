using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities.Abstract;
using SalesStatistics.Data.Enum;

namespace SalesStatistics.Data.Entities
{
    public class SimCard : BaseProduckt
    {
        public Operators Operator { get; set; }

        public SimCard()
        {
            Date = DateTime.Today;
        }

    }
}
