using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace UnitConverter.Logic
{
    public class Time: IConverterSpecial
    {
        public string name => "Czas";
        public int hour;
        public int minute;
        public string Convert(string time)
        {
            List<string> elementary = time.Split(':').ToList();
            string tim;
            hour = Int16.Parse(elementary[0]);
            minute = Int16.Parse(elementary[1]);
            if (hour > 12)
            {
                tim = "PM";
                elementary[0] = (hour-12).ToString();
            }
            else
                tim = "AM";
            elementary.Add(tim);
            time = elementary[0] + ":" + elementary[1] + " " + elementary[2];
            return time;
        }
    }
}
