﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesStatistics.Data.Enum;

namespace SalesStatistics.Data.Entities
{
    public class SimCard : BaseEntity
    {
        public Operators Operator { get; set; }

        public SimCard()
        {
            Date = DateTime.Today;
        }

    }
}