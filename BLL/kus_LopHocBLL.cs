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
    public class kus_LopHocBLL
    {
        DataServices DB = new DataServices();
        DateTime DefaultDate = Convert.ToDateTime("12/12/1900");
        //View
        public List<kus_LopHoc> GetListLopHocWithCode(string code)
        {
            string sql = "select * from kus_LopHoc where LopHocCode=@code";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcode = new SqlParameter("code", code);
            DataTable tb = DB.DAtable(sql, pcode);
            List<kus_LopHoc> lst = new List<kus_LopHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_LopHoc lh = new kus_LopHoc();
                lh.LopHocID = (int)r[0];
                lh.LopHocCode = (string)r[1];
                lh.TenLopHoc = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lh.NgayKhaiGiang = (string.IsNullOrEmpty(r[3].ToString())) ? DefaultDate : (DateTime)r[3];
                lh.ThoiLuong = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lh.NgayKetThuc = (string.IsNullOrEmpty(r[5].ToString())) ? DefaultDate : (DateTime)r[5];
                lh.SiSoToiDa = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                lh.DateOfCreate = (DateTime)r[7];
                lh.CapDoID = (string.IsNullOrEmpty(r[8].ToString())) ? 0 : (int)r[8];
                lh.MucHocPhi = (string.IsNullOrEmpty(r[9].ToString())) ? 0 : (int)r[9];
                lh.TrangThai = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                lh.CoSoID = (string.IsNullOrEmpty(r[11].ToString())) ? 0 : (int)r[11];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_LopHoc> GetListLopHocWithID(int LopHocID)
        {
            string sql = "select * from kus_LopHoc where LopHocID=@LopHocID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            DataTable tb = DB.DAtable(sql, pLopHocID);
            List<kus_LopHoc> lst = new List<kus_LopHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_LopHoc lh = new kus_LopHoc();
                lh.LopHocID = (int)r[0];
                lh.LopHocCode = (string)r[1];
                lh.TenLopHoc = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lh.NgayKhaiGiang = (string.IsNullOrEmpty(r[3].ToString())) ? DefaultDate : (DateTime)r[3];
                lh.ThoiLuong = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lh.NgayKetThuc = (string.IsNullOrEmpty(r[5].ToString())) ? DefaultDate : (DateTime)r[5];
                lh.SiSoToiDa = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                lh.DateOfCreate = (DateTime)r[7];
                lh.CapDoID = (string.IsNullOrEmpty(r[8].ToString())) ? 0 : (int)r[8];
                lh.MucHocPhi = (string.IsNullOrEmpty(r[9].ToString())) ? 0 : (int)r[9];
                lh.TrangThai = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                lh.CoSoID = (string.IsNullOrEmpty(r[11].ToString())) ? 0 : (int)r[11];
                lst.Add(lh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable Getkus_KhoiLopPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec Getkus_KhoiLopPageWise @PageIndex,@PageSize";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize);
            this.DB.CloseConnection();
            return tb;
        }
        public int Counkus_KhoiLopPageWise()
        {
            int RC = 0;
            string sql = "select COUNT(*) from kus_LopHoc where TrangThai=1";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        //==============================================================
        public DataTable Getkus_KhoiLopWithCSPageWise(int PageIndex, int PageSize, int CoSoID)
        {
            string sql = "Exec Getkus_KhoiLopWithCSPageWise @PageIndex,@PageSize,@CoSoID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pCoSoID = new SqlParameter("CoSoID", CoSoID);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pCoSoID);
            this.DB.CloseConnection();
            return tb;
        }
        public int Counkus_KhoiLopWithCSPageWise(int CoSoID)
        {
            int RC = 0;
            string sql = "select COUNT(*) from kus_LopHoc where TrangThai=1 and CoSoID=@CoSoID and NgayKhaiGiang >= GETDATE()";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pCoSoID = new SqlParameter("CoSoID", CoSoID);
            RC = DB.GetValues(sql, pCoSoID);
            this.DB.CloseConnection();
            return RC;
        }

        

        //Create
        public Boolean NewLopHoc(string tenLH, DateTime ngayKG, int thoiluong, DateTime ngayKT, int siso, int capdoID, int mucHP, int trangthai, int cosoID)
        {
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            int YearNgayKG = ngayKG.Year;
            int YearNgayKT = ngayKT.Year;
            string sql = "Exec kus_NewLopHoc @tenLH,@ngayKG,@thoiluong,@ngayKT,@siso,@capdoID,@mucHP,@trangthai,@cosoID";
            SqlParameter ptenLH = new SqlParameter("tenLH", tenLH);
            SqlParameter pngayKG = (YearNgayKG <= 1900) ? new SqlParameter("ngayKG", DBNull.Value) : new SqlParameter("ngayKG", ngayKG);
            SqlParameter pthoiluong = (thoiluong <= 0) ? new SqlParameter("thoiluong", DBNull.Value) : new SqlParameter("thoiluong", thoiluong);
            SqlParameter pngayKT = (YearNgayKT <= 1900) ? new SqlParameter("ngayKT", DBNull.Value) : new SqlParameter("ngayKT", ngayKT);
            SqlParameter psiso = (siso <= 0) ? new SqlParameter("siso", DBNull.Value) : new SqlParameter("siso", siso);
            SqlParameter pcapdoID = (capdoID <= 0) ? new SqlParameter("capdoID", DBNull.Value) : new SqlParameter("capdoID", capdoID);
            SqlParameter pmucHP = (mucHP <= 0) ? new SqlParameter("mucHP", DBNull.Value) : new SqlParameter("mucHP", mucHP);
            SqlParameter ptrangthai = new SqlParameter("trangthai", trangthai);
            SqlParameter pcosiID = (cosoID <= 0) ? new SqlParameter("cosoID", DBNull.Value) : new SqlParameter("cosoID", cosoID);
            this.DB.Updatedata(sql, ptenLH, pngayKG, pthoiluong, pngayKT, psiso, pcapdoID, pmucHP, ptrangthai, pcosiID);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean kus_UpdateLopHoc(int lophocID, string tenLH, DateTime ngayKG, int thoiluong, DateTime ngayKT, int siso, int capdoID, int mucHP, int trangthai, int cosoID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int YearNgayKG = ngayKG.Year;
            int YearNgayKT = ngayKT.Year;
            string sql = "Exec kus_UpdateLopHoc @lophocID, @tenLH,@ngayKG,@thoiluong,@ngayKT,@siso,@capdoID,@mucHP,@trangthai,@cosoID";
            SqlParameter plophocID = new SqlParameter("lophocID", lophocID);
            SqlParameter ptenLH = new SqlParameter("tenLH", tenLH);
            SqlParameter pngayKG = (YearNgayKG <= 1900) ? new SqlParameter("ngayKG", DBNull.Value) : new SqlParameter("ngayKG", ngayKG);
            SqlParameter pthoiluong = (thoiluong <= 0) ? new SqlParameter("thoiluong", DBNull.Value) : new SqlParameter("thoiluong", thoiluong);
            SqlParameter pngayKT = (YearNgayKT <= 1900) ? new SqlParameter("ngayKT", DBNull.Value) : new SqlParameter("ngayKT", ngayKT);
            SqlParameter psiso = (siso <= 0) ? new SqlParameter("siso", DBNull.Value) : new SqlParameter("siso", siso);
            SqlParameter pcapdoID = (capdoID <= 0) ? new SqlParameter("capdoID", DBNull.Value) : new SqlParameter("capdoID", capdoID);
            SqlParameter pmucHP = (mucHP <= 0) ? new SqlParameter("mucHP", DBNull.Value) : new SqlParameter("mucHP", mucHP);
            SqlParameter ptrangthai = new SqlParameter("trangthai", trangthai);
            SqlParameter pcosiID = (cosoID <= 0) ? new SqlParameter("cosoID", DBNull.Value) : new SqlParameter("cosoID", cosoID);
            this.DB.Updatedata(sql, plophocID, ptenLH, pngayKG, pthoiluong, pngayKT, psiso, pcapdoID, pmucHP, ptrangthai, pcosiID);
            this.DB.CloseConnection();
            return true;
        }
        //Lấy thời gian học với mã Cơ Sở
        public DateTime minNgayKhaiGiangWithCoSoID(int CoSoID)
        {
            DateTime minngayKG;
            if(!this.DB.OpenConnection())
            {
                return new DateTime(1900,01,01);
            }
            string sql = "select min(NgayKhaiGiang) from kus_LopHoc where CoSoID=@CoSoID";
            SqlParameter pCoSoID = new SqlParameter("@CoSoID", CoSoID);
            minngayKG = this.DB.GetDateValues(sql,pCoSoID);
            this.DB.CloseConnection();
            return minngayKG;
        }
        public DateTime MaxNgayKetThucWithCoSoID(int CoSoID)
        {
            DateTime minngayKT;
            if (!this.DB.OpenConnection())
            {
                return new DateTime(1900, 01, 01);
            }
            string sql = "select max(NgayKetThuc) from kus_LopHoc where CoSoID=@CoSoID";
            SqlParameter pCoSoID = new SqlParameter("@CoSoID", CoSoID);
            minngayKT = this.DB.GetDateValues(sql, pCoSoID);
            this.DB.CloseConnection();
            return minngayKT;
        }
    }
}
