using System.Globalization;

namespace SPA.Utils
{
    public class DateUtils
    {
        public static int GetWeekNumber(DateTime date)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            return ci.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(DateTime date)
        {
            DateTime sunday = date.AddDays(-(int)DateTime.Today.DayOfWeek);
            return sunday;
        }

        public static DateTime GetAssociatedSunday(DateTime inputDate)
        {
            return inputDate.AddDays(-(int)inputDate.DayOfWeek);

        }

    }

}
