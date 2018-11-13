using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateCounterDemo.Domain.Entites
{
    public class ValueObject
    {
        public WeekdaysModel FormatDateObject(string firstDate, string secondDate)
        {
            var firstday = firstDate.Split("-");
            var startDay = new DateTime(int.Parse(firstday[2]), int.Parse(firstday[1]), int.Parse(firstday[0]));
            var secondday = secondDate.Split("-");
            var endDay = new DateTime(int.Parse(secondday[2]), int.Parse(secondday[1]), int.Parse(secondday[0]));

            var result = new WeekdaysModel() { FirstDate = startDay, SecondDate = endDay };

            return result;
        }

        public List<DateTime> FormatHolidays(List<string> holidays)
        {
            var result = new List<DateTime>();

            try
            {
                foreach (var holiday in holidays)
                {
                    var day = holiday.Split("-");
                    var dayobj = new DateTime(int.Parse(day[2]), int.Parse(day[1]), int.Parse(day[0]));
                    result.Add(dayobj);
                }
            }
            catch (Exception ex)
            {
                
            }
           
            return result;
        }

    }
}
