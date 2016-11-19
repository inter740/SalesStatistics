using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.Data.Entities.Abstract
{
    public abstract class BaseProduckt : BaseEntity
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
