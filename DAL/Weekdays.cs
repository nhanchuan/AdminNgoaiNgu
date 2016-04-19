using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Weekdays
    {
        private int dayID;
        private string weekdaysNameEN;
        private string weekdaysNameVN;
        public int DayID
        {
            get
            {
                return dayID;
            }

            set
            {
                dayID = value;
            }
        }

        public string WeekdaysNameEN
        {
            get
            {
                return weekdaysNameEN;
            }

            set
            {
                weekdaysNameEN = value;
            }
        }

        public string WeekdaysNameVN
        {
            get
            {
                return weekdaysNameVN;
            }

            set
            {
                weekdaysNameVN = value;
            }
        }
    }
}
