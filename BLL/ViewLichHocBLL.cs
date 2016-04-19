using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class ViewLichHocBLL
    {
        DataServices DB = new DataServices();
        public DataTable tbtb(DateTime start, DateTime end)
        {
            kus_GioHocBLL kus_giohoc = new kus_GioHocBLL();
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_LichHocEvent 5,'01/01/1900','01/01/2200'";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        TimeSpan DefaultTime = TimeSpan.Parse("00:00:00.0000000");
        public List<kus_GioHoc> getkus_GioHocWithTietHoc(int TietHoc)
        {
            string str = "select * from kus_GioHoc where TietHoc=@TietHoc";
            if (!DB.OpenConnection())
            {
                return null;
            }
            DateTime dt = new DateTime(DefaultTime.Ticks);
            SqlParameter pTietHoc = new SqlParameter("@TietHoc", TietHoc);
            DataTable tb = DB.DAtable(str, pTietHoc);
            List<kus_GioHoc> lst = new List<kus_GioHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_GioHoc gh = new kus_GioHoc();
                gh.GioHocID = (int)r[0];
                gh.TietHoc = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                gh.StartTime = (string.IsNullOrEmpty(r[2].ToString())) ? dt : new DateTime(TimeSpan.Parse(r[2].ToString()).Ticks);
                gh.EndTime = (string.IsNullOrEmpty(r[3].ToString())) ? dt : new DateTime(TimeSpan.Parse(r[3].ToString()).Ticks);
                gh.BuoiHocID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lst.Add(gh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //== LICH HOC CAC LOP THUOC CO SO
        public List<LichHocEvent> getLichHocEvents(DateTime start, DateTime end, int CoSoID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_LichHocEvent @CoSoID,@start,@end";
            SqlParameter pstart = new SqlParameter("@start", start);
            SqlParameter pend = new SqlParameter("@end", end);
            SqlParameter pCoSoID = new SqlParameter("@CoSoID", CoSoID);
            //SqlParameter pCoSoID = new SqlParameter("@CoSoID", 5);
            DataTable tb = DB.DAtable(sql, pstart, pend, pCoSoID);
            List<LichHocEvent> lvents = new List<LichHocEvent>();

            foreach (DataRow r in tb.Rows)
            {
                DateTime tostart = Convert.ToDateTime(r[8]);
                DateTime toend = Convert.ToDateTime(r[9]);

                List<kus_GioHoc> lststart = getkus_GioHocWithTietHoc((int)r[19]);
                kus_GioHoc giostart = lststart.FirstOrDefault();
                List<kus_GioHoc> lstend = getkus_GioHocWithTietHoc((int)r[19] + (int)r[5] - 1);
                kus_GioHoc gioend = lstend.FirstOrDefault();
                while (tostart <= toend)
                {
                    if (tostart.DayOfWeek.ToString() == "Monday" && (int)r[2] == 1)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Tuesday" && (int)r[2] == 2)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Wednesday" && (int)r[2] == 3)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Thursday" && (int)r[2] == 4)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Friday" && (int)r[2] == 5)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Saturday" && (int)r[2] == 6)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Sunday" && (int)r[2] == 7)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    tostart = tostart.AddDays(1);
                }
            }
            this.DB.CloseConnection();
            return lvents;
        }

        //== LICH GIANG DAY CUA GIAO VIEN
        public List<LichHocEvent> LichDayGvEvent(int GVTT, int GVHD)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_LichDayGvEvent @GVTT,@GVHD";
            SqlParameter pGVTT = new SqlParameter("@GVTT", GVTT);
            SqlParameter pGVHD = new SqlParameter("@GVHD", GVHD);
            //SqlParameter pCoSoID = new SqlParameter("@CoSoID", 5);
            DataTable tb = DB.DAtable(sql, pGVTT, pGVHD);
            List<LichHocEvent> lvents = new List<LichHocEvent>();

            foreach (DataRow r in tb.Rows)
            {
                DateTime tostart = Convert.ToDateTime(r[8]);
                DateTime toend = Convert.ToDateTime(r[9]);

                List<kus_GioHoc> lststart = getkus_GioHocWithTietHoc((int)r[19]);
                kus_GioHoc giostart = lststart.FirstOrDefault();
                List<kus_GioHoc> lstend = getkus_GioHocWithTietHoc((int)r[19] + (int)r[5] - 1);
                kus_GioHoc gioend = lstend.FirstOrDefault();
                while (tostart <= toend)
                {
                    if (tostart.DayOfWeek.ToString() == "Monday" && (int)r[2] == 1)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Tuesday" && (int)r[2] == 2)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Wednesday" && (int)r[2] == 3)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Thursday" && (int)r[2] == 4)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Friday" && (int)r[2] == 5)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Saturday" && (int)r[2] == 6)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    if (tostart.DayOfWeek.ToString() == "Sunday" && (int)r[2] == 7)
                    {
                        LichHocEvent lv = new LichHocEvent();
                        //lv.id = (int)r[0];
                        lv.title = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1);
                        lv.description = " Tiết " + r[19].ToString() + " - " + Convert.ToString(Convert.ToInt32(r[19]) + Convert.ToInt32(r[5]) - 1) + " | Room: " + Convert.ToString(r[23]) + Convert.ToString(r[24]) + "." + Convert.ToString(r[25]) + " | Class: " + Convert.ToString(r[6]) + "-" + Convert.ToString(r[7]) + " | " + (string.IsNullOrEmpty(r[26].ToString()) ? "" : "gv." + (string)r[30] + " " + (string)r[31]) + " | " + (string.IsNullOrEmpty(r[27].ToString()) ? "" : "gv." + (string)r[32] + " " + (string)r[33]);
                        lv.start = new DateTime(tostart.Year, tostart.Month, tostart.Day, giostart.StartTime.Hour, giostart.StartTime.Minute, giostart.StartTime.Second);
                        lv.end = new DateTime(tostart.Year, tostart.Month, tostart.Day, gioend.EndTime.Hour, gioend.EndTime.Minute, gioend.EndTime.Second);
                        lvents.Add(lv);
                    }
                    tostart = tostart.AddDays(1);
                }
            }
            this.DB.CloseConnection();
            return lvents;
        }
        public int CountSoTieted(int khoahoc)
        {
            int dem = 0;

            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "Exec kus_LichHocWithKhoaHocEvent @khoahoc";
            SqlParameter pkhoahoc = new SqlParameter("@khoahoc", khoahoc);
            DataTable tb = DB.DAtable(sql, pkhoahoc);

            foreach (DataRow r in tb.Rows)
            {
                DateTime tostart = Convert.ToDateTime(r["NgayKhaiGiang"]);
                DateTime toend = Convert.ToDateTime(r["NgayKetThuc"]);
                while (tostart <= toend)
                {
                    if (tostart.DayOfWeek.ToString() == "Monday" && (int)r["DayID"] == 1)
                    {
                        dem = dem + Convert.ToInt32(r["SoTiet"]);
                    }
                    if (tostart.DayOfWeek.ToString() == "Tuesday" && (int)r["DayID"] == 2)
                    {
                        dem = dem + Convert.ToInt32(r["SoTiet"]);
                    }
                    if (tostart.DayOfWeek.ToString() == "Wednesday" && (int)r["DayID"] == 3)
                    {
                        dem = dem + Convert.ToInt32(r["SoTiet"]);
                    }
                    if (tostart.DayOfWeek.ToString() == "Thursday" && (int)r["DayID"] == 4)
                    {
                        dem = dem + Convert.ToInt32(r["SoTiet"]);
                    }
                    if (tostart.DayOfWeek.ToString() == "Friday" && (int)r["DayID"] == 5)
                    {
                        dem = dem + Convert.ToInt32(r["SoTiet"]);
                    }
                    if (tostart.DayOfWeek.ToString() == "Saturday" && (int)r["DayID"] == 6)
                    {
                        dem = dem + Convert.ToInt32(r["SoTiet"]);
                    }
                    if (tostart.DayOfWeek.ToString() == "Sunday" && (int)r["DayID"] == 7)
                    {
                        dem = dem + Convert.ToInt32(r["SoTiet"]);
                    }
                    tostart = tostart.AddDays(1);
                }
            }
            this.DB.CloseConnection();
            return dem;
        }

        public int CountSoTietPhatSinh(int ID, string dayofweek, int sotiet)
        {
            int phatsinh = 0;
            
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select * from nc_KhoaHoc where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = DB.DAtable(sql, pID);
            foreach (DataRow r in tb.Rows)
            {
                DateTime tostart = Convert.ToDateTime(r["NgayKhaiGiang"]);
                DateTime toend = Convert.ToDateTime(r["NgayKetThuc"]);
                while (tostart <= toend)
                {
                    if (dayofweek == tostart.DayOfWeek.ToString())
                    {
                        phatsinh = phatsinh + sotiet;
                    }
                    tostart = tostart.AddDays(1);
                }
            }
            this.DB.CloseConnection();
            return phatsinh;
        }
    }
}
