using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateCounterDemo.Services
{
    public interface ICalculateDaysRepository
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);

        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
    }
}
