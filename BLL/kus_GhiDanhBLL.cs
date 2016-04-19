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
    public class kus_GhiDanhBLL
    {
        DataServices DB = new DataServices();
        //public List<kus_GhiDanh> getListGDWithHocVienandLopHoc(int HocVienID, int LopHocID)
        //{
        //    if (!this.DB.OpenConnection())
        //    {
        //        return null;
        //    }
        //    string sql = "select * from kus_GhiDanh where HocVienID=@HocVienID and LopHocID=@LopHocID";
        //    SqlParameter pHocVienID = new SqlParameter("HocVienID", HocVienID);
        //    SqlParameter pLopHocID = new SqlParameter("LopHocID", LopHocID);
        //    DataTable tb = DB.DAtable(sql, pHocVienID, pLopHocID);
        //    List<kus_GhiDanh> lst = new List<kus_GhiDanh>();
        //    foreach (DataRow r in tb.Rows)
        //    {
        //        kus_GhiDanh gd = new kus_GhiDanh();
        //        gd.GhiDanhID = (int)r[0];
        //        gd.HocVienID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
        //        gd.LopHocID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
        //        gd.NhanVienTuID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
        //        gd.GhiChu = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
        //        gd.NgayDangKy = (DateTime)r[5];
        //        gd.DatCoc = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
        //        gd.GhiDanhCode = (string)r[7];
        //        lst.Add(gd);
        //    }
        //    this.DB.CloseConnection();
        //    return lst;
        //}
        public List<kus_GhiDanh> getListGDWithHocVien(int HocVienID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_GhiDanh where HocVienID=@HocVienID";
            SqlParameter pHocVienID = new SqlParameter("HocVienID", HocVienID);
            DataTable tb = DB.DAtable(sql, pHocVienID);
            List<kus_GhiDanh> lst = new List<kus_GhiDanh>();
            foreach (DataRow r in tb.Rows)
            {
                kus_GhiDanh gd = new kus_GhiDanh();
                gd.GhiDanhID = (int)r["GhiDanhID"];
                gd.HocVienID = (string.IsNullOrEmpty(r["HocVienID"].ToString())) ? 0 : (int)r["HocVienID"];
                gd.KhoaHoc = (string.IsNullOrEmpty(r["KhoaHoc"].ToString())) ? 0 : (int)r["KhoaHoc"];
                gd.NVGhiDanh = (string.IsNullOrEmpty(r["NVGhiDanh"].ToString())) ? 0 : (int)r["NVGhiDanh"];
                gd.GhiChu = (string.IsNullOrEmpty(r["GhiChu"].ToString())) ? "" : (string)r["GhiChu"];
                gd.NgayDangKy = (DateTime)r["NgayDangKy"];
                gd.DatCoc = (string.IsNullOrEmpty(r["DatCoc"].ToString())) ? 0 : (int)r["DatCoc"];
                gd.GhiDanhCode = (string)r["GhiDanhCode"];
                lst.Add(gd);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_GhiDanh> getListGDCode(string GhiDanhCode)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_GhiDanh where GhiDanhCode=@GhiDanhCode";
            SqlParameter pGhiDanhCode = new SqlParameter("@GhiDanhCode", GhiDanhCode);
            DataTable tb = DB.DAtable(sql, pGhiDanhCode);
            List<kus_GhiDanh> lst = new List<kus_GhiDanh>();
            foreach (DataRow r in tb.Rows)
            {
                kus_GhiDanh gd = new kus_GhiDanh();
                gd.GhiDanhID = (int)r["GhiDanhID"];
                gd.HocVienID = (string.IsNullOrEmpty(r["HocVienID"].ToString())) ? 0 : (int)r["HocVienID"];
                gd.KhoaHoc = (string.IsNullOrEmpty(r["KhoaHoc"].ToString())) ? 0 : (int)r["KhoaHoc"];
                gd.NVGhiDanh = (string.IsNullOrEmpty(r["NVGhiDanh"].ToString())) ? 0 : (int)r["NVGhiDanh"];
                gd.GhiChu = (string.IsNullOrEmpty(r["GhiChu"].ToString())) ? "" : (string)r["GhiChu"];
                gd.NgayDangKy = (DateTime)r["NgayDangKy"];
                gd.DatCoc = (string.IsNullOrEmpty(r["DatCoc"].ToString())) ? 0 : (int)r["DatCoc"];
                gd.GhiDanhCode = (string)r["GhiDanhCode"];
                lst.Add(gd);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean GhiDanhMoi(int HocVienID, int LopHocID, int NVTuVanID, string GhiChu, int DatCoc)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Exec kus_GhiDanhMoi @HocVienID,@LopHocID,@NVTuVanID,@GhiChu,@DatCoc";
            SqlParameter pHocVienID = (HocVienID == 0) ? new SqlParameter("HocVienID", DBNull.Value) : new SqlParameter("HocVienID", HocVienID);
            SqlParameter pLopHocID = (LopHocID == 0) ? new SqlParameter("LaopHocID", DBNull.Value) : new SqlParameter("LopHocID", LopHocID);
            SqlParameter pNVTuVanID = (NVTuVanID == 0) ? new SqlParameter("NVTuVanID", DBNull.Value) : new SqlParameter("NVTuVanID", NVTuVanID);
            SqlParameter pGhiChu = new SqlParameter("GhiChu", GhiChu);
            SqlParameter pDatCoc = (DatCoc == 0) ? new SqlParameter("DatCoc", DBNull.Value) : new SqlParameter("DatCoc", DatCoc);
            this.DB.Updatedata(sql, pHocVienID, pLopHocID, pNVTuVanID, pGhiChu, pDatCoc);
            this.DB.CloseConnection();
            return true;
        }
        //===================================================================================================================
        public DataTable kus_getHVGhiDanh(int PageIndex, int PageSize, DateTime Startdate, DateTime Enddate)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_getHVGhiDanh @PageIndex,@PageSize,@Startdate,@Enddate";
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pStartdate = new SqlParameter("Startdate", Startdate);
            SqlParameter pEnddate = new SqlParameter("Enddate", Enddate);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pStartdate, pEnddate);
            this.DB.CloseConnection();
            return tb;
        }
        public int Countkus_getHVGhiDanh(DateTime Startdate, DateTime Enddate)
        {
            int dem = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(hocvien.HocVienID) from kus_HocVien hocvien full outer join kus_GhiDanh ghidanh on hocvien.HocVienID=ghidanh.HocVienID where hocvien.HocVienID is not null and ghidanh.NgayDangKy between @Startdate and @Enddate";
            SqlParameter pStartdate = new SqlParameter("Startdate", Startdate);
            SqlParameter pEnddate = new SqlParameter("Enddate", Enddate);
            dem = DB.GetValues(sql, pStartdate, pEnddate);
            this.DB.CloseConnection();
            return dem;
        }
        //==================================================================================================================
        public DataTable kus_getHVGhiDanhInCoSo(int PageIndex, int PageSize, DateTime Startdate, DateTime Enddate, int CoSoID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_getHVGhiDanhInCoSo @PageIndex,@PageSize,@Startdate,@Enddate,@CoSoID";
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pStartdate = new SqlParameter("Startdate", Startdate);
            SqlParameter pEnddate = new SqlParameter("Enddate", Enddate);
            SqlParameter pCoSoID = new SqlParameter("CoSoID", CoSoID);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pStartdate, pEnddate, pCoSoID);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountgetHVGhiDanhInCoSo(DateTime Startdate, DateTime Enddate, int CoSoID)
        {
            int dem = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(hocvien.HocVienID) from kus_HocVien hocvien full outer join kus_GhiDanh ghidanh on hocvien.HocVienID=ghidanh.HocVienID full outer join kus_LopHoc lophoc on ghidanh.LopHocID=lophoc.LopHocID full outer join kus_CoSo coso on lophoc.CoSoID=coso.CoSoID where hocvien.HocVienID is not null and ghidanh.NgayDangKy between @Startdate and @Enddate and coso.CoSoID=@CoSoID";
            SqlParameter pStartdate = new SqlParameter("Startdate", Startdate);
            SqlParameter pEnddate = new SqlParameter("Enddate", Enddate);
            SqlParameter pCoSoID = new SqlParameter("CoSoID", CoSoID);
            dem = DB.GetValues(sql, pStartdate, pEnddate, pCoSoID);
            this.DB.CloseConnection();
            return dem;
        }
        //=====================================================================================================================
        //====================kus_getHVGhiDanhInLopHoc==============================================================================================
        public DataTable kus_getHVGhiDanhInLopHoc(int PageIndex, int PageSize, int LopHocID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_getHVGhiDanhInLopHoc @PageIndex,@PageSize,@LopHocID";
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pLopHocID = new SqlParameter("LopHocID", LopHocID);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pLopHocID);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountgetHVGhiDanhInLopHoc(int LopHocID)
        {
            int dem = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(hocvien.HocVienID) from kus_HocVien hocvien full outer join kus_GhiDanh ghidanh on hocvien.HocVienID=ghidanh.HocVienID full outer join kus_LopHoc lophoc on ghidanh.LopHocID=lophoc.LopHocID full outer join kus_CoSo coso on lophoc.CoSoID=coso.CoSoID where hocvien.HocVienID is not null and lophoc.LopHocID=@LopHocID";
            SqlParameter pLopHocID = new SqlParameter("LopHocID", LopHocID);
            dem = DB.GetValues(sql, pLopHocID);
            this.DB.CloseConnection();
            return dem;
        }
        //=====================================================================================================================
        public DataTable kus_getTTPhieuGhiDanh(string GDCode)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_getTTPhieuGhiDanh @GDCode";
            SqlParameter pGDCode = new SqlParameter("GDCode", GDCode);
            DataTable tb = DB.DAtable(sql, pGDCode);
            this.DB.CloseConnection();
            return tb;
        }
        //=======Reset So Tien Dat Coc============================================================================================================
        public Boolean ResetDatcoc(int GhiDanhID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update kus_GhiDanh set DatCoc=@DatCoc where GhiDanhID=@GhiDanhID";
            SqlParameter pDatCoc = new SqlParameter("@DatCoc", DBNull.Value);
            SqlParameter pGhiDanhID = new SqlParameter("@GhiDanhID", GhiDanhID);
            this.DB.Updatedata(sql, pDatCoc, pGhiDanhID);
            this.DB.CloseConnection();
            return true;
        }
        //===========Update ghi chu=======================================
        public Boolean UpdateGhichu(int HocVienID, string GhiChu)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update kus_GhiDanh set GhiChu=@GhiChu where HocVienID=@HocVienID";
            SqlParameter pHocVienID = new SqlParameter("@HocVienID", HocVienID);
            SqlParameter pGhiChu = (GhiChu == "") ? new SqlParameter("@GhiChu", DBNull.Value) : new SqlParameter("@GhiChu", GhiChu);
            this.DB.Updatedata(sql, pHocVienID, pGhiChu);
            this.DB.CloseConnection();
            return true;
        }
    }
}
