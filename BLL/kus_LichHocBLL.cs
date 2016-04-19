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
                lh.KhoaHoc = (string.IsNullOrEmpty(r["KhoaHoc"].ToString())) ? 0 : (int)r["KhoaHoc"];
                lh.DayID= (string.IsNullOrEmpty(r["DayID"].ToString())) ? 0 : (int)r["DayID"];
                lh.GioHocID= (string.IsNullOrEmpty(r["GioHocID"].ToString())) ? 0 : (int)r["GioHocID"];
                lh.PhongHocID= (string.IsNullOrEmpty(r["PhongHocID"].ToString())) ? 0 : (int)r["PhongHocID"];
                lh.SoTiet = (string.IsNullOrEmpty(r["SoTiet"].ToString())) ? 0 : (int)r["SoTiet"];
                lh.GVTT = (string.IsNullOrEmpty(r["GVTT"].ToString())) ? 0 : (int)r["GVTT"];
                lh.GVHD = (string.IsNullOrEmpty(r["GVHD"].ToString())) ? 0 : (int)r["GVHD"];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_LichHoc> getListLichHocWithKhoaHoc(int KhoaHoc)
        {
            string sql = "select * from kus_LichHoc where KhoaHoc=@KhoaHoc";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            DataTable tb = DB.DAtable(sql, pKhoaHoc);
            List<kus_LichHoc> lst = new List<kus_LichHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_LichHoc lh = new kus_LichHoc();
                lh.LichHocID = (int)r[0];
                lh.KhoaHoc = (string.IsNullOrEmpty(r["KhoaHoc"].ToString())) ? 0 : (int)r["KhoaHoc"];
                lh.DayID = (string.IsNullOrEmpty(r["DayID"].ToString())) ? 0 : (int)r["DayID"];
                lh.GioHocID = (string.IsNullOrEmpty(r["GioHocID"].ToString())) ? 0 : (int)r["GioHocID"];
                lh.PhongHocID = (string.IsNullOrEmpty(r["PhongHocID"].ToString())) ? 0 : (int)r["PhongHocID"];
                lh.SoTiet = (string.IsNullOrEmpty(r["SoTiet"].ToString())) ? 0 : (int)r["SoTiet"];
                lh.GVTT = (string.IsNullOrEmpty(r["GVTT"].ToString())) ? 0 : (int)r["GVTT"];
                lh.GVHD = (string.IsNullOrEmpty(r["GVHD"].ToString())) ? 0 : (int)r["GVHD"];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }

        public DataTable getkus_LichHocWith_KhoaHoc_Day_Buoi(int KhoaHoc, int daysID, int buoihocID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec getkus_LichHocWith_KhoaHoc_Day_Buoi @KhoaHoc,@daysID,@buoihocID";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            SqlParameter pdaysID = new SqlParameter("@daysID", daysID);
            SqlParameter pbuoihocID = new SqlParameter("@buoihocID", buoihocID);
            DataTable tb = DB.DAtable(sql, pKhoaHoc, pdaysID, pbuoihocID);
            this.DB.CloseConnection();
            return tb;
        }
       
        //Create Lich Hoc
        public Boolean kus_AddNewLichHoc(int KhoaHoc, int DayID, int GioHocID, int PhongHocID, int SoTiet)
        {
            string sql = "Exec kus_AddNewLichHoc @KhoaHoc,@DayID,@GioHocID,@PhongHocID,@SoTiet";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            SqlParameter pDayID = new SqlParameter("@DayID", DayID);
            SqlParameter pGioHocID = new SqlParameter("@GioHocID", GioHocID);
            SqlParameter pPhongHocID = new SqlParameter("@PhongHocID", PhongHocID);
            SqlParameter pSoTiet = new SqlParameter("@SoTiet", SoTiet);
            this.DB.Updatedata(sql, pKhoaHoc, pDayID, pGioHocID, pPhongHocID, pSoTiet);
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
                lh.KhoaHoc = (string.IsNullOrEmpty(r["KhoaHoc"].ToString())) ? 0 : (int)r["KhoaHoc"];
                lh.DayID = (string.IsNullOrEmpty(r["DayID"].ToString())) ? 0 : (int)r["DayID"];
                lh.GioHocID = (string.IsNullOrEmpty(r["GioHocID"].ToString())) ? 0 : (int)r["GioHocID"];
                lh.PhongHocID = (string.IsNullOrEmpty(r["PhongHocID"].ToString())) ? 0 : (int)r["PhongHocID"];
                lh.SoTiet = (string.IsNullOrEmpty(r["SoTiet"].ToString())) ? 0 : (int)r["SoTiet"];
                lh.GVTT = (string.IsNullOrEmpty(r["GVTT"].ToString())) ? 0 : (int)r["GVTT"];
                lh.GVHD = (string.IsNullOrEmpty(r["GVHD"].ToString())) ? 0 : (int)r["GVHD"];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //list check Add Lich hoc with @KhoaHoc
        public List<kus_LichHoc> kus_CheckAddLichHocWithKhoaHoc(int DayID, int KhoaHoc, int TietHoc, int SoTiet)
        {
            string sql = "Exec kus_CheckAddLichHocWithKhoaHoc @DayID,@KhoaHoc,@TietHoc,@SoTiet";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pDayID = new SqlParameter("@DayID", DayID);
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            SqlParameter pTietHoc = new SqlParameter("@TietHoc", TietHoc);
            SqlParameter pSoTiet = new SqlParameter("@SoTiet", SoTiet);
            DataTable tb = DB.DAtable(sql, pDayID, pKhoaHoc, pTietHoc, pSoTiet);
            List<kus_LichHoc> lst = new List<kus_LichHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_LichHoc lh = new kus_LichHoc();
                lh.LichHocID = (int)r[0];
                lh.KhoaHoc = (string.IsNullOrEmpty(r["KhoaHoc"].ToString())) ? 0 : (int)r["KhoaHoc"];
                lh.DayID = (string.IsNullOrEmpty(r["DayID"].ToString())) ? 0 : (int)r["DayID"];
                lh.GioHocID = (string.IsNullOrEmpty(r["GioHocID"].ToString())) ? 0 : (int)r["GioHocID"];
                lh.PhongHocID = (string.IsNullOrEmpty(r["PhongHocID"].ToString())) ? 0 : (int)r["PhongHocID"];
                lh.SoTiet = (string.IsNullOrEmpty(r["SoTiet"].ToString())) ? 0 : (int)r["SoTiet"];
                lh.GVTT = (string.IsNullOrEmpty(r["GVTT"].ToString())) ? 0 : (int)r["GVTT"];
                lh.GVHD = (string.IsNullOrEmpty(r["GVHD"].ToString())) ? 0 : (int)r["GVHD"];
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
        //Delete lich hoc with @KhoaHoc
        public Boolean DeleteLichHocWithKhoaHoc(int KhoaHoc)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from kus_LichHoc where KhoaHoc=@KhoaHoc";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            this.DB.Updatedata(sql, pKhoaHoc);
            this.DB.CloseConnection();
            return true;
        }
        //Add Lich Hoc
        public Boolean AddNewLichHoc(int KhoaHoc, int DayID, int GioHocID, int PhongHocID, int SoTiet, int GVTT, int GVHD)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into kus_LichHoc(KhoaHoc,DayID,GioHocID,PhongHocID,SoTiet,GVTT,GVHD) values (@KhoaHoc,@DayID,@GioHocID,@PhongHocID,@SoTiet,@GVTT,@GVHD)";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            SqlParameter pDayID = new SqlParameter("@DayID", DayID);
            SqlParameter pGioHocID = new SqlParameter("@GioHocID", GioHocID);
            SqlParameter pPhongHocID = new SqlParameter("@PhongHocID", PhongHocID);
            SqlParameter pSoTiet = new SqlParameter("@SoTiet", SoTiet);
            SqlParameter pGVTT = (GVTT == 0) ? new SqlParameter("@GVTT", DBNull.Value) : new SqlParameter("@GVTT", GVTT);
            SqlParameter pGVHD = (GVHD == 0) ? new SqlParameter("@GVHD", DBNull.Value) : new SqlParameter("@GVHD", GVHD);
            this.DB.Updatedata(sql, pKhoaHoc, pDayID, pGioHocID, pPhongHocID, pSoTiet, pGVTT, pGVHD);
            this.DB.CloseConnection();
            return true;
        }

        public int SumSoTietWithKhoaHoc(int KhoaHoc)
        {
            int sum = 0;
            if(!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select SUM(SoTiet) from kus_LichHoc where KhoaHoc=@KhoaHoc";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            sum = DB.GetValues(sql, pKhoaHoc);
            this.DB.CloseConnection();
            return sum;
        }
    }
}
