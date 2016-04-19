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
    public class kus_LichHocBLL
    {
        DataServices DB = new DataServices();
        public List<kus_LichHoc> getListLichHoc()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_LichHoc";
            DataTable tb = DB.DAtable(sql);
            List<kus_LichHoc> lst = new List<kus_LichHoc>();
            foreach(DataRow r in tb.Rows)
            {
                kus_LichHoc lh = new kus_LichHoc();
                lh.LichHocID = (int)r[0];
                lh.LopHocID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                lh.DayID= (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lh.GioHocID= (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lh.PhongHocID= (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lh.SoTiet = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lh.GVTT = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                lh.GVHD = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_LichHoc> getListLichHocWithLophocID(int LopHocID)
        {
            string sql = "select * from kus_LichHoc where LopHocID=@LopHocID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            DataTable tb = DB.DAtable(sql, pLopHocID);
            List<kus_LichHoc> lst = new List<kus_LichHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_LichHoc lh = new kus_LichHoc();
                lh.LichHocID = (int)r[0];
                lh.LopHocID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                lh.DayID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lh.GioHocID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lh.PhongHocID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lh.SoTiet = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lh.GVTT = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                lh.GVHD = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }

        public DataTable getkus_LichHocWithLopHocandDayandBuoi(int lophocID, int daysID, int buoihocID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec getkus_LichHocWithLopHocandDayandBuoi @lophocID,@daysID,@buoihocID";
            SqlParameter plophocID = new SqlParameter("@lophocID", lophocID);
            SqlParameter pdaysID = new SqlParameter("@daysID", daysID);
            SqlParameter pbuoihocID = new SqlParameter("@buoihocID", buoihocID);
            DataTable tb = DB.DAtable(sql, plophocID, pdaysID, pbuoihocID);
            this.DB.CloseConnection();
            return tb;
        }
       
        //Create Lich Hoc
        public Boolean kus_AddNewLichHoc(int LopHocID, int DayID, int GioHocID, int PhongHocID, int SoTiet)
        {
            string sql = "Exec kus_AddNewLichHoc @LopHocID,@DayID,@GioHocID,@PhongHocID,@SoTiet";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            SqlParameter pDayID = new SqlParameter("DayID", DayID);
            SqlParameter pGioHocID = new SqlParameter("GioHocID", GioHocID);
            SqlParameter pPhongHocID = new SqlParameter("PhongHocID", PhongHocID);
            SqlParameter pSoTiet = new SqlParameter("SoTiet", SoTiet);
            this.DB.Updatedata(sql, pLopHocID, pDayID, pGioHocID, pPhongHocID, pSoTiet);
            this.DB.CloseConnection();
            return true;
        }
        //List check add lich hoc
        public List<kus_LichHoc> kus_CheckAddLichHoc(int DayID, int PhongHocID, int TietHoc, int SoTiet)
        {
            string sql = "Exec kus_CheckAddLichHoc @DayID,@PhongHocID,@TietHoc,@SoTiet";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pDayID = new SqlParameter("@DayID", DayID);
            SqlParameter pPhongHocID = new SqlParameter("@PhongHocID", PhongHocID);
            SqlParameter pTietHoc = new SqlParameter("@TietHoc", TietHoc);
            SqlParameter pSoTiet = new SqlParameter("@SoTiet", SoTiet);
            DataTable tb = DB.DAtable(sql, pDayID, pPhongHocID, pTietHoc, pSoTiet);
            List<kus_LichHoc> lst = new List<kus_LichHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_LichHoc lh = new kus_LichHoc();
                lh.LichHocID = (int)r[0];
                lh.LopHocID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                lh.DayID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lh.GioHocID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lh.PhongHocID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lh.SoTiet = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //list check Add Lich hoc with LopHoc
        public List<kus_LichHoc> kus_CheckAddLichHocWithLopHoc(int DayID, int LopHocID, int TietHoc, int SoTiet)
        {
            string sql = "Exec kus_CheckAddLichHocWithLopHoc @DayID,@LopHocID,@TietHoc,@SoTiet";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pDayID = new SqlParameter("@DayID", DayID);
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            SqlParameter pTietHoc = new SqlParameter("@TietHoc", TietHoc);
            SqlParameter pSoTiet = new SqlParameter("@SoTiet", SoTiet);
            DataTable tb = DB.DAtable(sql, pDayID, pLopHocID, pTietHoc, pSoTiet);
            List<kus_LichHoc> lst = new List<kus_LichHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_LichHoc lh = new kus_LichHoc();
                lh.LichHocID = (int)r[0];
                lh.LopHocID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                lh.DayID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lh.GioHocID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lh.PhongHocID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lh.SoTiet = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lh.GVTT = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                lh.GVHD = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //Delete lich hoc with LichHocID
        public Boolean DeleteLichHoc(int LichHocID)
        {
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from kus_LichHoc where LichHocID=@LichHocID";
            SqlParameter pLichHocID = new SqlParameter("LichHocID", LichHocID);
            this.DB.Updatedata(sql, pLichHocID);
            this.DB.CloseConnection();
            return true;
        }
        //Delete lich hoc with LichHocID
        public Boolean DeleteLichHocWithLopHoc(int LopHocID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from kus_LichHoc where LopHocID=@LopHocID";
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            this.DB.Updatedata(sql, pLopHocID);
            this.DB.CloseConnection();
            return true;
        }
        //Add Lich Hoc
        public Boolean AddNewLichHoc(int LopHocID, int DayID, int GioHocID, int PhongHocID, int SoTiet, int GVTT, int GVHD)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into kus_LichHoc(LopHocID,DayID,GioHocID,PhongHocID,SoTiet,GVTT,GVHD) values (@LopHocID,@DayID,@GioHocID,@PhongHocID,@SoTiet,@GVTT,@GVHD)";
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            SqlParameter pDayID = new SqlParameter("@DayID", DayID);
            SqlParameter pGioHocID = new SqlParameter("@GioHocID", GioHocID);
            SqlParameter pPhongHocID = new SqlParameter("@PhongHocID", PhongHocID);
            SqlParameter pSoTiet = new SqlParameter("@SoTiet", SoTiet);
            SqlParameter pGVTT = (GVTT == 0) ? new SqlParameter("@GVTT", DBNull.Value) : new SqlParameter("@GVTT", GVTT);
            SqlParameter pGVHD = (GVHD == 0) ? new SqlParameter("@GVHD", DBNull.Value) : new SqlParameter("@GVHD", GVHD);
            this.DB.Updatedata(sql,pLopHocID, pDayID, pGioHocID, pPhongHocID, pSoTiet, pGVTT, pGVHD);
            this.DB.CloseConnection();
            return true;
        }

        public int SumSoTietWithLopHocID(int LopHocID)
        {
            int sum = 0;
            if(!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select SUM(SoTiet) from kus_LichHoc where LopHocID=@LopHocID";
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            sum = DB.GetValues(sql, pLopHocID);
            this.DB.CloseConnection();
            return sum;
        }
    }
}
