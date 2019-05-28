using System;
using System.Linq;

namespace ExtractDateTimeFromString
{
    internal static class InternalExtensions
    {
        internal static bool IsDateType(this string o)
        {
            return DateTime.TryParse(o, out DateTime dummy);
        }
        internal static bool IsNumericType(this string o)
        {
            return double.TryParse(o, out double dummy);
        }
        internal static bool IsWeekend(this DateTime date)
        {
            return new[] { DayOfWeek.Sunday, DayOfWeek.Saturday }.Contains(date.DayOfWeek);
        }
        internal static DateTime PreviousWorkDay(this DateTime date)
        {
            do
            {
                date = date.AddDays(-1);
            }
            while (IsWeekend(date));

            return date;
        }
    }
}
