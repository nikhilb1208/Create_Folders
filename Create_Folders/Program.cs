using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Folders
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartDate = new DateTime(2020, 1, 1);
            DateTime EndDate = new DateTime(2020, 12, 31);

            for (var day = StartDate.Date; day.Date <= EndDate.Date; day = day.AddDays(1))
            {
                bool monthExists = Directory.Exists(ConfigurationManager.AppSettings["DocumentsPath"] + "/" + day.ToString("MMMM"));
                if (!monthExists)
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["DocumentsPath"] + "/" + day.ToString("MMMM"));

                    var first = new DateTime(day.Year, day.Month, 1);
                    var last = first.AddMonths(1).AddDays(-1);
                    for (var day1 = first.Date; day1.Date <= last.Date; day1 = day1.AddDays(7))
                    {

                        DayOfWeek weekend = DayOfWeek.Sunday;
                        DayOfWeek weekStart = DayOfWeek.Monday;
                        while (day1.DayOfWeek != weekStart)
                            day1 = day1.AddDays(1);

                        DateTime findEndDate = day1;
                        while (findEndDate.DayOfWeek != weekend)
                            findEndDate = findEndDate.AddDays(1);

                        //Console.WriteLine(day1.Date.Day + "_" + findEndDate.Date.Day);

                        bool weekExists = Directory.Exists(ConfigurationManager.AppSettings["DocumentsPath"] + "/" + day.ToString("MMMM") + "/" + day1.Date.Day + "_" + findEndDate.Date.Day);

                        if (!weekExists)
                        {
                            Directory.CreateDirectory(ConfigurationManager.AppSettings["DocumentsPath"] + "/" + day.ToString("MMMM") + "/" + day1.Date.Day + "_" + findEndDate.Date.Day);
                        }
                    }
                }
            }
        }
    }
}
