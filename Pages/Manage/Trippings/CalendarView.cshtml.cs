using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Manage.Trippings
{
    public class CalendarViewModel : PageModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int PreviousMonth { get; set; }
        public int NextMonth { get; set; }
        public List<List<DayCell>> CalendarDays { get; set; }

        public void OnGet(int? year, int? month)
        {

            var currentDate = DateTime.Now;
            Year = year ?? currentDate.Year;
            Month = month ?? currentDate.Month;
            MonthName = new DateTime(Year, Month, 1).ToString("MMMM yyyy");


            PreviousMonth = Month == 1 ? 12 : Month - 1;
            NextMonth = Month == 12 ? 1 : Month + 1;


            CalendarDays = GetCalendarDays(Year, Month);
        }

        private List<List<DayCell>> GetCalendarDays(int year, int month)
        {
            var days = new List<List<DayCell>>();
            var firstDayOfMonth = new DateTime(year, month, 1);
            var startDay = (int)firstDayOfMonth.DayOfWeek;
            var daysInMonth = DateTime.DaysInMonth(year, month);

            int dayCounter = 1;
            List<DayCell> week = new List<DayCell>();


            for (int i = 0; i < startDay; i++)
            {
                week.Add(new DayCell { DayNumber = 0 });
            }


            for (int day = startDay; day < 7; day++)
            {
                week.Add(new DayCell { DayNumber = dayCounter++ });
            }

            days.Add(week);
            week = new List<DayCell>();

            for (int day = dayCounter; day <= daysInMonth; day++)
            {
                if (week.Count == 7)
                {
                    days.Add(week);
                    week = new List<DayCell>();
                }
                week.Add(new DayCell { DayNumber = day });
            }

            if (week.Count > 0)
            {
                days.Add(week);
            }

            return days;
        }

        public class DayCell
        {
            public int DayNumber { get; set; }
            public bool IsInCurrentMonth => DayNumber != 0;
        }
    }
}