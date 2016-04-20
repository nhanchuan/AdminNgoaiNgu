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
    public class nc_KhoaHocBLL
    {
        DataServices dt = new DataServices();
        DateTime DefaultDate = Convert.ToDateTime("12/12/1900");
        public List<nc_KhoaHoc> getListKhoaHocWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_KhoaHoc where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DAtable(sql, pID);
            List<nc_KhoaHoc> lst = new List<nc_KhoaHoc>();
            foreach (DataRow r in tb.Rows)
            {
                nc_KhoaHoc kh = new nc_KhoaHoc();
                kh.ID = (int)r["ID"];
                kh.MaKhoaHoc = (string)r["MaKhoaHoc"];
                kh.TenKhoaHoc = (string.IsNullOrEmpty(r["TenKhoaHoc"].ToString())) ? "" : (string)r["TenKhoaHoc"];
                kh.SoLuong = (string.IsNullOrEmpty(r["SoLuong"].ToString())) ? 0 : (int)r["SoLuong"];
                kh.NgayKhaiGiang = (string.IsNullOrEmpty(r["NgayKhaiGiang"].ToString())) ? DefaultDate : (DateTime)r["NgayKhaiGiang"];
                kh.ThoiLuong = (string.IsNullOrEmpty(r["ThoiLuong"].ToString())) ? 0 : (int)r["ThoiLuong"];
                kh.NgayKetThuc = (string.IsNullOrEmpty(r["NgayKetThuc"].ToString())) ? DefaultDate : (DateTime)r["NgayKetThuc"];
                kh.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                kh.ChuongTrinh = (string.IsNullOrEmpty(r["ChuongTrinh"].ToString())) ? 0 : (int)r["ChuongTrinh"];
                kh.LopHoc = (string.IsNullOrEmpty(r["LopHoc"].ToString())) ? 0 : (int)r["LopHoc"];
                kh.CoSoID = (string.IsNullOrEmpty(r["CoSoID"].ToString())) ? 0 : (int)r["CoSoID"];
                kh.DateOfCreate = (DateTime)r["DateOfCreate"];
                lst.Add(kh);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_KhoaHoc> getListKhoaHocWithMaKhoaHoc(string MaKhoaHoc)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_KhoaHoc where MaKhoaHoc=@MaKhoaHoc";
            SqlParameter pMaKhoaHoc = new SqlParameter("@MaKhoaHoc", MaKhoaHoc);
            DataTable tb = dt.DAtable(sql, pMaKhoaHoc);
            List<nc_KhoaHoc> lst = new List<nc_KhoaHoc>();
            foreach (DataRow r in tb.Rows)
            {
                nc_KhoaHoc kh = new nc_KhoaHoc();
                kh.ID = (int)r["ID"];
                kh.MaKhoaHoc = (string)r["MaKhoaHoc"];
                kh.TenKhoaHoc = (string.IsNullOrEmpty(r["TenKhoaHoc"].ToString())) ? "" : (string)r["TenKhoaHoc"];
                kh.SoLuong = (string.IsNullOrEmpty(r["SoLuong"].ToString())) ? 0 : (int)r["SoLuong"];
                kh.NgayKhaiGiang = (string.IsNullOrEmpty(r["NgayKhaiGiang"].ToString())) ? DefaultDate : (DateTime)r["NgayKhaiGiang"];
                kh.ThoiLuong = (string.IsNullOrEmpty(r["ThoiLuong"].ToString())) ? 0 : (int)r["ThoiLuong"];
                kh.NgayKetThuc = (string.IsNullOrEmpty(r["NgayKetThuc"].ToString())) ? DefaultDate : (DateTime)r["NgayKetThuc"];
                kh.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                kh.ChuongTrinh = (string.IsNullOrEmpty(r["ChuongTrinh"].ToString())) ? 0 : (int)r["ChuongTrinh"];
                kh.LopHoc = (string.IsNullOrEmpty(r["LopHoc"].ToString())) ? 0 : (int)r["LopHoc"];
                kh.CoSoID = (string.IsNullOrEmpty(r["CoSoID"].ToString())) ? 0 : (int)r["CoSoID"];
                kh.DateOfCreate = (DateTime)r["DateOfCreate"];
                lst.Add(kh);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public DataTable get_Tabel_nc_KhoaHoc(int PageIndex, int PageSize)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec get_nc_KhoaHoc @PageIndex,@PageSize";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            DataTable tb = dt.DAtable(sql, pPageIndex, pPageSize);
            this.dt.CloseConnection();
            return tb;
        }
        
        public int Count_khoahoc()
        {
            int count = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from nc_KhoaHoc";
            count = dt.GetValues(sql);
            this.dt.CloseConnection();
            return count;
        }
        //Get Khoa Hoc With CoSoID
        public DataTable get_nc_KhoaHoc_CoSoID(int PageIndex, int PageSize, int CoSoID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec get_nc_KhoaHoc_CoSoID @PageIndex,@PageSize,@CoSoID";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            SqlParameter pCoSoID = new SqlParameter("@CoSoID", CoSoID);
            DataTable tb = dt.DAtable(sql, pPageIndex, pPageSize, pCoSoID);
            this.dt.CloseConnection();
            return tb;
        }

        public int Count_khoahocCS(int CoSoID)
        {
            int count = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from nc_KhoaHoc where CoSoID=@CoSoID";
            SqlParameter pCoSoID = new SqlParameter("@CoSoID", CoSoID);
            count = dt.GetValues(sql, pCoSoID);
            this.dt.CloseConnection();
            return count;
        }

        //NEW 
        public Boolean New_nc_KhoaHoc(string TenKhoaHoc, int SoLuong, DateTime NgayKhaiGiang, int ThoiLuong, DateTime NgayKetThuc, int LoaiChuongTrinh, int ChuongTrinh, int LopHoc, int CoSoID)
        {
            if(!this.dt.OpenConnection())
            {
                return false;
            }
            int YearNgayKG = NgayKhaiGiang.Year;
            int YearNgayKT = NgayKetThuc.Year;
            string sql = "Exec New_nc_KhoaHoc @TenKhoaHoc,@SoLuong,@NgayKhaiGiang,@ThoiLuong,@NgayKetThuc,@LoaiChuongTrinh,@ChuongTrinh,@LopHoc,@CoSoID";
            SqlParameter pTenKhoaHoc = new SqlParameter("TenKhoaHoc", TenKhoaHoc);
            SqlParameter pSoLuong = (SoLuong == 0) ? new SqlParameter("SoLuong", DBNull.Value) : new SqlParameter("SoLuong", SoLuong);
            SqlParameter pNgayKhaiGiang = (YearNgayKG <= 1900) ? new SqlParameter("NgayKhaiGiang", DBNull.Value) : new SqlParameter("NgayKhaiGiang", NgayKhaiGiang);
            SqlParameter pThoiLuong = (ThoiLuong == 0) ? new SqlParameter("ThoiLuong", DBNull.Value) : new SqlParameter("ThoiLuong", ThoiLuong);
            SqlParameter pNgayKetThuc = (YearNgayKT <= 1900) ? new SqlParameter("NgayKetThuc", DBNull.Value) : new SqlParameter("NgayKetThuc", NgayKetThuc);
            SqlParameter pLoaiChuongTrinh = (LoaiChuongTrinh == 0) ? new SqlParameter("LoaiChuongTrinh", DBNull.Value) : new SqlParameter("LoaiChuongTrinh", LoaiChuongTrinh);
            SqlParameter pChuongTrinh = (ChuongTrinh == 0) ? new SqlParameter("ChuongTrinh", DBNull.Value) : new SqlParameter("ChuongTrinh", ChuongTrinh);
            SqlParameter pLopHoc = (LopHoc == 0) ? new SqlParameter("LopHoc", DBNull.Value) : new SqlParameter("LopHoc", LopHoc);
            SqlParameter pCoSoID = (CoSoID == 0) ? new SqlParameter("CoSoID", DBNull.Value) : new SqlParameter("CoSoID", CoSoID);
            this.dt.Updatedata(sql, pTenKhoaHoc, pSoLuong, pNgayKhaiGiang, pThoiLuong, pNgayKetThuc, pLoaiChuongTrinh, pChuongTrinh, pLopHoc, pCoSoID);
            this.dt.CloseConnection();
            return true;
        }
        //UPDATE
        public Boolean Update_nc_KhoaHoc(int ID, string TenKhoaHoc, int SoLuong, DateTime NgayKhaiGiang, int ThoiLuong, DateTime NgayKetThuc, int LoaiChuongTrinh, int ChuongTrinh, int LopHoc, int CoSoID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            int YearNgayKG = NgayKhaiGiang.Year;
            int YearNgayKT = NgayKetThuc.Year;
            string sql = "Exec Update_nc_KhoaHoc @ID,@TenKhoaHoc,@SoLuong,@NgayKhaiGiang,@ThoiLuong,@NgayKetThuc,@LoaiChuongTrinh,@ChuongTrinh,@LopHoc,@CoSoID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pTenKhoaHoc = new SqlParameter("TenKhoaHoc", TenKhoaHoc);
            SqlParameter pSoLuong = (SoLuong == 0) ? new SqlParameter("SoLuong", DBNull.Value) : new SqlParameter("SoLuong", SoLuong);
            SqlParameter pNgayKhaiGiang = (YearNgayKG <= 1900) ? new SqlParameter("NgayKhaiGiang", DBNull.Value) : new SqlParameter("NgayKhaiGiang", NgayKhaiGiang);
            SqlParameter pThoiLuong = (ThoiLuong == 0) ? new SqlParameter("ThoiLuong", DBNull.Value) : new SqlParameter("ThoiLuong", ThoiLuong);
            SqlParameter pNgayKetThuc = (YearNgayKT <= 1900) ? new SqlParameter("NgayKetThuc", DBNull.Value) : new SqlParameter("NgayKetThuc", NgayKetThuc);
            SqlParameter pLoaiChuongTrinh = (LoaiChuongTrinh == 0) ? new SqlParameter("LoaiChuongTrinh", DBNull.Value) : new SqlParameter("LoaiChuongTrinh", LoaiChuongTrinh);
            SqlParameter pChuongTrinh = (ChuongTrinh == 0) ? new SqlParameter("ChuongTrinh", DBNull.Value) : new SqlParameter("ChuongTrinh", ChuongTrinh);
            SqlParameter pLopHoc = (LopHoc == 0) ? new SqlParameter("LopHoc", DBNull.Value) : new SqlParameter("LopHoc", LopHoc);
            SqlParameter pCoSoID = (CoSoID == 0) ? new SqlParameter("CoSoID", DBNull.Value) : new SqlParameter("CoSoID", CoSoID);
            this.dt.Updatedata(sql, pID, pTenKhoaHoc, pSoLuong, pNgayKhaiGiang, pThoiLuong, pNgayKetThuc, pLoaiChuongTrinh, pChuongTrinh, pLopHoc, pCoSoID);
            this.dt.CloseConnection();
            return true;
        }
        //SEARCH
        public DataTable Search_nc_KhoaHoc(int PageIndex, int PageSize, string keysearch)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "Exec Search_nc_KhoaHoc @PageIndex,@PageSize,@keysearch";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            SqlParameter pkeysearch = new SqlParameter("@keysearch", keysearch);
            DataTable tb = dt.DAtable(sql, pPageIndex, pPageSize, pkeysearch);
            this.dt.CloseConnection();
            return tb;
        }
        public int Count_search_khoahoc(string keysearch)
        {
            int count = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from nc_KhoaHoc where (MaKhoaHoc like '%'+@keysearch+'%' or TenKhoaHoc like '%'+@keysearch+'%')";
            SqlParameter pkeysearch = new SqlParameter("@keysearch", keysearch);
            count = dt.GetValues(sql, pkeysearch);
            this.dt.CloseConnection();
            return count;
        }
        //=================================
        public DataTable DropdownKhoaHocWithCS(int CoSoID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select ID, (MaKhoaHoc+' - '+TenKhoaHoc) as TenKhoaHoc from nc_KhoaHoc where CoSoID=@CoSoID and NgayKetThuc>=GETDATE()";
            SqlParameter pCoSoID = new SqlParameter("CoSoID", CoSoID);
            DataTable tb = dt.DAtable(sql, pCoSoID);
            this.dt.CloseConnection();
            return tb;
        }

    }
}
