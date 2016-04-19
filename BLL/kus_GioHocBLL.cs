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
    public class kus_GioHocBLL
    {
        DataServices DB = new DataServices();
        TimeSpan DefaultTime = TimeSpan.Parse("00:00:00.0000000");
        public List<kus_GioHoc> getAllkus_GioHoc()
        {
            string str = "select * from kus_GioHoc";
            if(!DB.OpenConnection())
            {
                return null;
            }
            DateTime dt = new DateTime(DefaultTime.Ticks);
            DataTable tb = DB.DAtable(str);
            List<kus_GioHoc> lst = new List<kus_GioHoc>();
            foreach(DataRow r in tb.Rows)
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
        public List<kus_GioHoc> getAllkus_GioHocWithID(int giohocID)
        {
            string str = "select * from kus_GioHoc where GioHocID=@giohocID";
            if (!DB.OpenConnection())
            {
                return null;
            }
            DateTime dt = new DateTime(DefaultTime.Ticks);
            SqlParameter pgiohocID = new SqlParameter("@giohocID", giohocID);
            DataTable tb = DB.DAtable(str, pgiohocID);
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
        public int LastTietHoc()
        {
            int last = 0;
            if(!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(TietHoc) from kus_GioHoc ";
            last = DB.GetValues(sql);
            this.DB.CloseConnection();
            return last;
        }
        public DataTable getTBForDropdown()
        {
            if (!DB.OpenConnection())
            {
                return null;
            }
            string sql = "select GioHocID,(N'Tiết '+ CONVERT(varchar(2),TietHoc) + ' - '+ CONVERT(nvarchar(5),StartTime) + N' đến ' + CONVERT(nvarchar(5),EndTime)) as TietHoc from kus_GioHoc";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //Create
        public Boolean GioHoc_AddNew(string TietHoc, string StartTime, string EndTime, int BuoiHocID)
        {
            string query = "insert into kus_GioHoc(TietHoc,StartTime,EndTime,BuoiHocID) values(@tiethoc, @StartTime, @EndTime, @BuoiHocID)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pTietHoc = new SqlParameter("@tiethoc", TietHoc);
            SqlParameter pStartTime = (StartTime == "") ? new SqlParameter("@StartTime", DBNull.Value) : new SqlParameter("@StartTime", StartTime);
            SqlParameter pEndTime = (EndTime == "") ? new SqlParameter("@EndTime", DBNull.Value) : new SqlParameter("@EndTime", EndTime);
            SqlParameter pBuoiHocID = (BuoiHocID == 0) ? new SqlParameter("@BuoiHocID", DBNull.Value) : new SqlParameter("BuoiHocID", BuoiHocID);
            this.DB.Updatedata(query, pTietHoc, pStartTime, pEndTime, pBuoiHocID);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean GioHoc_Update(string GioHoc_ID, string TietHoc, string StartTime, string EndTime)
        {
            string query = "update kus_GioHoc set TietHoc = @tiethoc, StartTime = @StartTime, EndTime=@EndTime where GioHocID=@giohoc_id";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pgiohoc_id = new SqlParameter("@giohoc_id", GioHoc_ID);
            SqlParameter pTietHoc = new SqlParameter("@tiethoc", TietHoc);
            SqlParameter pStartTime = new SqlParameter("@StartTime", StartTime);
            SqlParameter pEndTime = new SqlParameter("@EndTime", EndTime);
            this.DB.Updatedata(query, pgiohoc_id, pTietHoc, pStartTime, pEndTime);
            this.DB.CloseConnection();
            return true;
        }

        //Delete
        public Boolean GioHoc_Delete(string GioHoc_ID)
        {
            string query = "delete from kus_GioHoc where GioHocID=@giohoc_id";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pgiohoc_id = new SqlParameter("@giohoc_id", GioHoc_ID);
            this.DB.Updatedata(query, pgiohoc_id);
            this.DB.CloseConnection();
            return true;
        }
        
    }
}
