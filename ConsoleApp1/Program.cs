using System;
using System.Globalization;

namespace ExtractDateTimeFromString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputString = {
                "Closing >> At close: May 24 3:29PM IST",
                "Opening >> As of  9:23AM IST. Market open.",
                "As of May 27 9:30AM IST. Market open.",
                "As of May 27 9:26AM IST. Market open.",
                "As of May 24 3:52PM IST. Market open."
            };
            foreach (string sin in inputString)
                Console.WriteLine(sin);
            var splits = inputString[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string sDate = string.Empty, sTime = string.Empty;
            for (int i = 0; i < splits.Length; i++)
            {
                if (Int32.TryParse(splits[i], out int value))
                {
                    sDate = $"{splits[i]} {splits[i - 1]}";
                    sTime = $"{splits[i+1]}".Insert($"{splits[i + 1]}".Length-2," ");
                }
            }
            DateTime dt = DateTime.ParseExact(sDate, "dd MMM", CultureInfo.InvariantCulture);
           // DateTime tm = DateTime.ParseExact(sTime, "h:mm tt", CultureInfo.InvariantCulture);
            DateTime tm = (DateTime)Convert.ChangeType(sTime, typeof(DateTime));
            var vReturn = dt.Date.Add(tm.TimeOfDay);

            Console.WriteLine(vReturn.ToString());
            Console.ReadKey();
        }
    }
}

//DateTime dt = DateTime.ParseExact(theDateTime.ToString().Trim(), "dd MMM", CultureInfo.InvariantCulture);
//DateTime tm = DateTime.ParseExact(theDateTime.ToString().Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);
//sp.ValueOn = dt.Date.Add(tm.TimeOfDay);

#region dummy
//string s = inputString[2];
//string subs = s.Substring(0,s.IndexOf("IST")-1);

//var stime = subs.Substring(subs.LastIndexOfAny(new char[] {' '}) + 1,
//    (subs.Length - subs.LastIndexOfAny(new char[] { ' ' }) -1)
//    );
//Console.WriteLine(stime);

//var sdt = subs.Remove(subs.IndexOf(stime), subs.Length - subs.IndexOf(stime)).Split(' ',StringSplitOptions.RemoveEmptyEntries);
//var temp = string.Empty;
//for (int i = 0; i< sdt.Length; i++)
//{
//    bool success = Int32.TryParse(sdt[i], out int value);
//    if (success)
//    {
//        temp = $"{sdt[i]} {sdt[i - 1]}";
//        //DateTime dd = DateTime.ParseExact(sdt[i], "dd", CultureInfo.InvariantCulture);
//        //DateTime mm = DateTime.ParseExact(sdt[i-1], "MMM", CultureInfo.InvariantCulture);
//        break;
//    }
//}
////subs = subs.Substring(subs.LastIndexOf(' ', subs.LastIndexOf(' ') + 1), 1); 
//DateTime dt = DateTime.ParseExact(temp.ToString().Trim(), "dd MMM", CultureInfo.InvariantCulture);
//DateTime tm = DateTime.ParseExact(stime.ToString().Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);
//var vReturn = dt.Date.Add(tm.TimeOfDay);
//Console.WriteLine(subs);
#endregion