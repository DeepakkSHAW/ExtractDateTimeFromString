using System;

namespace ExtractDateTimeFromString
{
    class Program
    {
        static void Main(string[] args)
        {
            //**initialize IST**//
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime tm = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            DateTime dt = DateTime.Today;
            string sDate = string.Empty, sTime = string.Empty;

            //** dummy data for test**//
            string[] inputString = {
                "At close: May 25 3:29PM IST",
                "At close: May 27 3:30PM IST",
                "At close: 3:30PM IST",
                "As of  9:23AM IST. Market open.",
                "As of May 27 9:30AM IST. Market open.",
                "As of May 27 9:26AM IST. Market open.",
                "As of May 24 3:52PM IST. Market open."
            };
            foreach (string sin in inputString) Console.WriteLine(sin);
            var inputValue = inputString[0].Trim();
            //** ---------------------**//

            var splits = inputValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var index = Array.FindIndex(splits, x => x.ToUpper() == "IST");
            if (index > -1)
            {
                if (index - 1 > -1) sTime = $"{splits[index - 1]}";
                if (index - 3 > -1) sDate = $"{splits[index - 2]} {splits[index - 3]}";
            }

            //** precaution in case missing date & time**//
            if (sDate.IsDateType())
                dt = (DateTime)Convert.ChangeType(sDate, typeof(DateTime));
            if(sTime.IsDateType())
                tm = (DateTime)Convert.ChangeType(sTime, typeof(DateTime));

            //** adjust the date if date in missing in the downloaded time stamp**//
            var vReturn = dt.Date.Add(tm.TimeOfDay);
            vReturn = vReturn > TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE) ?
                vReturn.AddDays(-1) : vReturn;

            //** Convert the downloaded time into last business day**//
            if (vReturn.IsWeekend())
                vReturn = vReturn.PreviousWorkDay();

            Console.WriteLine(vReturn.ToString());
            Console.ReadKey();
        }
    }
}