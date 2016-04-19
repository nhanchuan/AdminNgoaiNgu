using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;

namespace BLL
{
    public class WeekdaysBLL
    {
        DataServices DB = new DataServices();
        public List<Weekdays> ListWeekdays()
        {
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Weekdays";
            DataTable tb = DB.DAtable(sql);
            List<Weekdays> lst = new List<Weekdays>();
            foreach(DataRow r in tb.Rows)
            {
                Weekdays wd = new Weekdays();
                wd.DayID = (int)r[0];
                wd.WeekdaysNameEN = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                wd.WeekdaysNameVN= (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lst.Add(wd);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
