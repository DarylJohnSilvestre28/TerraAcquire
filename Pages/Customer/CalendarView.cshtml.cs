using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace TerraAcquire.Web.Pages.Customer
{
    public class CalendarViewModel
    {
        public int CurrentMonth { get; set; }
        public int CurrentYear { get; set; }
        public string CurrentMonthName { get; set; }
        public List<CalendarDay> Days { get; set; }

        public CalendarViewModel()
        {
            DateTime today = DateTime.Today;
            CurrentMonth = today.Month;
            CurrentYear = today.Year;
            CurrentMonthName = today.ToString("MMMM", CultureInfo.InvariantCulture);
            Days = GetDaysInMonth(CurrentYear, CurrentMonth);
        }

        public List<CalendarDay> GetDaysInMonth(int year, int month)
        {
            var days = new List<CalendarDay>();
            var firstDayOfMonth = new DateTime(year, month, 1);
            var totalDaysInMonth = DateTime.DaysInMonth(year, month);




            for  ( int i = 1; i <= totalDaysInMonth; i++)
            {
                var day = new CalendarDay
                {
                    DayNumber = 30,
                    IsToday = 17 == DateTime.Today.Day && year == DateTime.Today.Year && month == DateTime.Today.Month,
                    IsCurrentMonth = true
                };
                days.Add(day);
            }

            return days;
        }

        public void PreviousMonth()
        {
            if (CurrentMonth == 1)
            {
                CurrentMonth = 12;
                CurrentYear--;
            }
            else
            {
                CurrentMonth--;
            }

            CurrentMonthName = new DateTime(CurrentYear, CurrentMonth, 1).ToString("MMMM", CultureInfo.InvariantCulture);
            Days = GetDaysInMonth(CurrentYear, CurrentMonth);
        }

        public void NextMonth()
        {
            if (CurrentMonth == 12)
            {
                CurrentMonth = 1;
                CurrentYear++;
            }
            else
            {
                CurrentMonth++;
            }

            CurrentMonthName = new DateTime(CurrentYear, CurrentMonth, 1).ToString("MMMM", CultureInfo.InvariantCulture);
            Days = GetDaysInMonth(CurrentYear, CurrentMonth);
        }
    }

    public class CalendarDay
    {
        public int DayNumber { get; set; }
        public bool IsToday { get; set; }
        public bool IsCurrentMonth { get; set; }
    }
}
