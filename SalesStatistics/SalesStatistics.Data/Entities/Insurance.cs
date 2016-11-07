using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.Data.Entities
{
    public class Insurance : BaseEntity
    {
        public int Price { get; set; }
        public TypeInsurance Type { get; set; }

        public Insurance()
        {
            Date = DateTime.Today;
        }

        public enum TypeInsurance
        {
            Portable, Stationary
        }
    }
}
