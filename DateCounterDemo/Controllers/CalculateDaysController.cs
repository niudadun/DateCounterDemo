using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateCounterDemo.Domain.Entites;
using DateCounterDemo.Services;
using DateCounterDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DateCounterDemo.Controllers
{
    public class CalculateDaysController : Controller
    {
        private readonly ICalculateDaysRepository _calculateDaysRepository;
        private readonly ValueObject _valueobjectFormatter;


        public CalculateDaysController(ICalculateDaysRepository calculateDaysRepository, ValueObject valueobjectFormatter)
        {
            _calculateDaysRepository = calculateDaysRepository;
            _valueobjectFormatter = valueobjectFormatter;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetWeekDays([FromForm]GetDaysRequestViewModel date)
        {
            if (date.FirstDate == null || date.SecondDate == null)
            {
                return Json("input date is null.");
            }
            else
            {
                var dateObj = _valueobjectFormatter.FormatDateObject(date.FirstDate, date.SecondDate);
                var days = _calculateDaysRepository.WeekdaysBetweenTwoDates(dateObj.FirstDate, dateObj.SecondDate);
                return Json(days);
            }         
        }

        public IActionResult GetBusinessDays([FromForm]GetDaysWithHolidayListRequestViewModel date)
        {
            if (date.FirstDate == null || date.SecondDate == null || date.PublicHolidays.Count == 0)
            {
                return Json("input date is null or input holidays is invalid");
            }
            else
            {
                var dateObj = _valueobjectFormatter.FormatDateObject(date.FirstDate, date.SecondDate);
                var holidayList = _valueobjectFormatter.FormatHolidays(date.PublicHolidays);
                var days = _calculateDaysRepository.BusinessDaysBetweenTwoDates(dateObj.FirstDate, dateObj.SecondDate, holidayList);

                return Json(days);
            }
            
        }

        
    }
}