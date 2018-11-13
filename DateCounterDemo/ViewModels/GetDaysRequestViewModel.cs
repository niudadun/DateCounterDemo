using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateCounterDemo.ViewModels
{
    public class GetDaysRequestViewModel
    {
        public string FirstDate { get; set; }

        public string SecondDate { get; set; }
    }

    public class GetDaysWithHolidayListRequestViewModel
    {
        public string FirstDate { get; set; }

        public string SecondDate { get; set; }

        public List<string> PublicHolidays { get; set; }
    }
}
