using DateCounterDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateCounterDemo.Domain
{
    public class CalculateDaysRepository : ICalculateDaysRepository
    {
        private readonly BusinessDayCounter _dayscounter;
        public CalculateDaysRepository(BusinessDayCounter dayscounter)
        {
            _dayscounter = dayscounter;
        }
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {

            var days = _dayscounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);
            return days;
        }

        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            var days = _dayscounter.WeekdaysBetweenTwoDates(firstDate, secondDate);
            return days;
        }
    }

}
