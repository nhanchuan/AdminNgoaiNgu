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
    public class nc_LopHocBLL
    {
        DataServices dt = new DataServices();
        public List<nc_LopHoc> getListLopHocWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LopHoc where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DAtable(sql, pID);
            List<nc_LopHoc> lst = new List<nc_LopHoc>();
            foreach(DataRow r in tb.Rows)
            {
                nc_LopHoc lh = new nc_LopHoc();
                lh.ID = (int)r["ID"];
                lh.LopHocCode = (string.IsNullOrEmpty(r["LopHocCode"].ToString())) ? "" : (string)r["LopHocCode"];
                lh.TenLopHoc = (string.IsNullOrEmpty(r["TenLopHoc"].ToString())) ? "" : (string)r["TenLopHoc"];
                lh.ThoiLuong = (string.IsNullOrEmpty(r["ThoiLuong"].ToString())) ? 0 : (int)r["ThoiLuong"];
                lh.BangCap = (string.IsNullOrEmpty(r["BangCap"].ToString())) ? "" : (string)r["BangCap"];
                lh.MucHocPhi = (string.IsNullOrEmpty(r["MucHocPhi"].ToString())) ? 0 : (int)r["MucHocPhi"];
                lh.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                lh.ChuongTrinh = (string.IsNullOrEmpty(r["ChuongTrinh"].ToString())) ? 0 : (int)r["ChuongTrinh"];
                lh.MoTa = (string.IsNullOrEmpty(r["MoTa"].ToString())) ? "" : (string)r["MoTa"];
                lh.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(lh);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_LopHoc> getListLopHocWithChuongTrinh(int ChuongTrinh)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LopHoc where ChuongTrinh=@ChuongTrinh";
            SqlParameter pChuongTrinh = new SqlParameter("@ChuongTrinh", ChuongTrinh);
            DataTable tb = dt.DAtable(sql, pChuongTrinh);
            List<nc_LopHoc> lst = new List<nc_LopHoc>();
            foreach (DataRow r in tb.Rows)
            {
                nc_LopHoc lh = new nc_LopHoc();
                lh.ID = (int)r["ID"];
                lh.LopHocCode = (string.IsNullOrEmpty(r["LopHocCode"].ToString())) ? "" : (string)r["LopHocCode"];
                lh.TenLopHoc = (string.IsNullOrEmpty(r["TenLopHoc"].ToString())) ? "" : (string)r["TenLopHoc"];
                lh.ThoiLuong = (string.IsNullOrEmpty(r["ThoiLuong"].ToString())) ? 0 : (int)r["ThoiLuong"];
                lh.BangCap = (string.IsNullOrEmpty(r["BangCap"].ToString())) ? "" : (string)r["BangCap"];
                lh.MucHocPhi = (string.IsNullOrEmpty(r["MucHocPhi"].ToString())) ? 0 : (int)r["MucHocPhi"];
                lh.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                lh.ChuongTrinh = (string.IsNullOrEmpty(r["ChuongTrinh"].ToString())) ? 0 : (int)r["ChuongTrinh"];
                lh.MoTa = (string.IsNullOrEmpty(r["MoTa"].ToString())) ? "" : (string)r["MoTa"];
                lh.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(lh);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_LopHoc> getListLopHocWithIndex(int index)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LopHoc where SapXep=@SapXep";
            SqlParameter pSapXep = new SqlParameter("@SapXep", index);
            DataTable tb = dt.DAtable(sql, pSapXep);
            List<nc_LopHoc> lst = new List<nc_LopHoc>();
            foreach (DataRow r in tb.Rows)
            {
                nc_LopHoc lh = new nc_LopHoc();
                lh.ID = (int)r["ID"];
                lh.LopHocCode = (string.IsNullOrEmpty(r["LopHocCode"].ToString())) ? "" : (string)r["LopHocCode"];
                lh.TenLopHoc = (string.IsNullOrEmpty(r["TenLopHoc"].ToString())) ? "" : (string)r["TenLopHoc"];
                lh.ThoiLuong = (string.IsNullOrEmpty(r["ThoiLuong"].ToString())) ? 0 : (int)r["ThoiLuong"];
                lh.BangCap = (string.IsNullOrEmpty(r["BangCap"].ToString())) ? "" : (string)r["BangCap"];
                lh.MucHocPhi = (string.IsNullOrEmpty(r["MucHocPhi"].ToString())) ? 0 : (int)r["MucHocPhi"];
                lh.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                lh.ChuongTrinh = (string.IsNullOrEmpty(r["ChuongTrinh"].ToString())) ? 0 : (int)r["ChuongTrinh"];
                lh.MoTa = (string.IsNullOrEmpty(r["MoTa"].ToString())) ? "" : (string)r["MoTa"];
                lh.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(lh);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public DataTable getTBLopHoc()
        {
            if(!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select lop.ID, lop.LopHocCode, lop.TenLopHoc, lop.ThoiLuong, lop.BangCap, lop.MucHocPhi, lop.LoaiChuongTrinh, lop.ChuongTrinh, lop.MoTa, lop.SapXep,";
            sql += " ";
            sql += "loai.TenChuongTrinh as TenLoaiChuongTrinh, ct.TenChuongTrinh";
            sql += " ";
            sql += "from nc_LopHoc lop full outer join nc_LoaiCTDaoTao loai on lop.LoaiChuongTrinh=loai.ID";
            sql += " ";
            sql += "full outer join nc_ChuongTrinhDaoTao ct on lop.ChuongTrinh=ct.ID";
            sql += " ";
            sql += "where lop.ID is not null order by lop.SapXep asc";
            DataTable tb = dt.DAtable(sql);
            this.dt.CloseConnection();
            return tb;
        }
        //New 
        public Boolean New_nc_LopHoc(string TenLopHoc, int ThoiLuong, string BangCap, int MucHocPhi, int LoaiChuongTrinh, int ChuongTrinh, string MoTa, int SapXep)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "Exec New_nc_LopHoc @TenLopHoc,@ThoiLuong,@BangCap,@MucHocPhi,@LoaiChuongTrinh,@ChuongTrinh,@MoTa,@SapXep";
            SqlParameter pTenLopHoc = new SqlParameter("@TenLopHoc", TenLopHoc);
            SqlParameter pThoiLuong = (ThoiLuong == 0) ? new SqlParameter("@ThoiLuong", DBNull.Value) : new SqlParameter("@ThoiLuong", ThoiLuong);
            SqlParameter pBangCap = new SqlParameter("@BangCap", BangCap);
            SqlParameter pMucHocPhi = (MucHocPhi == 0) ? new SqlParameter("@MucHocPhi", DBNull.Value) : new SqlParameter("@MucHocPhi", MucHocPhi);
            SqlParameter pLoaiChuongTrinh = (LoaiChuongTrinh == 0) ? new SqlParameter("@LoaiChuongTrinh", DBNull.Value) : new SqlParameter("@LoaiChuongTrinh", LoaiChuongTrinh);
            SqlParameter pChuongTrinh = (ChuongTrinh == 0) ? new SqlParameter("@ChuongTrinh", DBNull.Value) : new SqlParameter("@ChuongTrinh", ChuongTrinh);
            SqlParameter pMoTa = new SqlParameter("@MoTa", MoTa);
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            this.dt.Updatedata(sql, pTenLopHoc, pThoiLuong, pBangCap, pMucHocPhi, pLoaiChuongTrinh, pChuongTrinh, pMoTa, pSapXep);
            this.dt.CloseConnection();
            return true;
        }
        //============UPDATRE ITEM INDEX======================================================================================================================================================================
        public Boolean UpdateSapXep(int SapXep, int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update nc_LopHoc set SapXep=@SapXep where ID=@ID";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sql, pSapXep, pID);
            this.dt.CloseConnection();
            return true;
        }
        public int MaxItemindex()
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(SapXep) from nc_LopHoc";
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public int MaxItemindexLK(int SapXep)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(SapXep) from nc_LopHoc where SapXep<@SapXep";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            RC = dt.GetValues(sql, pSapXep);
            this.dt.CloseConnection();
            return RC;
        }
        public int MinItemindexLK(int SapXep)
        {
            int RC = 0;
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            string sql = "select min(SapXep) from nc_LopHoc where SapXep>@SapXep";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            RC = dt.GetValues(sql, pSapXep);
            this.dt.CloseConnection();
            return RC;
        }
        //UPDATE
        public Boolean Update_nc_LopHoc(int ID, string TenLopHoc, int ThoiLuong, string BangCap, int MucHocPhi, int LoaiChuongTrinh, int ChuongTrinh, string MoTa)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "Exec Update_nc_LopHoc @ID,@TenLopHoc,@ThoiLuong,@BangCap,@MucHocPhi,@LoaiChuongTrinh,@ChuongTrinh,@MoTa";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pTenLopHoc = new SqlParameter("@TenLopHoc", TenLopHoc);
            SqlParameter pThoiLuong = (ThoiLuong == 0) ? new SqlParameter("@ThoiLuong", DBNull.Value) : new SqlParameter("@ThoiLuong", ThoiLuong);
            SqlParameter pBangCap = new SqlParameter("@BangCap", BangCap);
            SqlParameter pMucHocPhi = (MucHocPhi == 0) ? new SqlParameter("@MucHocPhi", DBNull.Value) : new SqlParameter("@MucHocPhi", MucHocPhi);
            SqlParameter pLoaiChuongTrinh = (LoaiChuongTrinh == 0) ? new SqlParameter("@LoaiChuongTrinh", DBNull.Value) : new SqlParameter("@LoaiChuongTrinh", LoaiChuongTrinh);
            SqlParameter pChuongTrinh = (ChuongTrinh == 0) ? new SqlParameter("@ChuongTrinh", DBNull.Value) : new SqlParameter("@ChuongTrinh", ChuongTrinh);
            SqlParameter pMoTa = new SqlParameter("@MoTa", MoTa);
            this.dt.Updatedata(sql, pID, pTenLopHoc, pThoiLuong, pBangCap, pMucHocPhi, pLoaiChuongTrinh, pChuongTrinh, pMoTa);
            this.dt.CloseConnection();
            return true;
        }
    }
}
