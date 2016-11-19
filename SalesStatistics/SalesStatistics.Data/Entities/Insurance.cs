﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Entities.Abstract;
using SalesStatistics.Data.Enum;

namespace SalesStatistics.Data.Entities
{
    public class Insurance : BaseProduckt
    {
        public int Price { get; set; }
        public TypeInsurance Type { get; set; }

        public Insurance()
        {
            Date = DateTime.Today;
        }
    }
}
