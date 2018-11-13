﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateCounterDemo.Domain.Entites
{
    public class BusinessDaysModel
    {
        public DateTime FirstDate { get; set; }

        public DateTime SecondDate { get; set; }

        public IList<DateTime> PublicHolidays { get; set; }
    }
}
