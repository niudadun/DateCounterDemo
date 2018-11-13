using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateCounterDemo.Domain
{
    public class BusinessDayCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            var days = (secondDate - firstDate).Days - 1;
            var total = (WeekdaysInFullWeeks(days) + WeekdaysInPartialWeek(firstDate.DayOfWeek, days));
            return total >= 0 ? total : 0;
        }

        private int WeekdaysInFullWeeks(int totalDays)
        {
            return (totalDays / 7) * 5;
        }

        private int WeekdaysInPartialWeek(DayOfWeek firstDay, int totalDays)
        {
            var remainingDays = totalDays % 7;
            //daysToSaturday are the days before the weekend
            var daysToSaturday = ((int)DayOfWeek.Saturday - (int)firstDay - 1) >= 0 ? ((int)DayOfWeek.Saturday - (int)firstDay - 1) : 0;
            if (remainingDays <= daysToSaturday)
                return remainingDays;

            // Range ends in a Saturday or in a Sunday
            if (remainingDays <= daysToSaturday + 2)
                return daysToSaturday;
            // Range ends after a Sunday
            else
                return remainingDays - 2;
        }


        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            var days = (secondDate - firstDate).Days - 1;

            var total = (WeekdaysInFullWeeks(days) + WeekdaysInPartialWeek(firstDate.DayOfWeek, days));

            foreach (DateTime publicHoliday in publicHolidays)
            {
                DateTime ph = publicHoliday.Date;
                if (firstDate < ph && ph < secondDate && ph.DayOfWeek != 0 && (int)ph.DayOfWeek != 6)
                    --total;
            }

            return total >= 0 ? total : 0;
        }
    }
}
