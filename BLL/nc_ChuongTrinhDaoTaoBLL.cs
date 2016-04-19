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
    public class nc_ChuongTrinhDaoTaoBLL
    {
        DataServices dt = new DataServices();
        public List<nc_ChuongTrinhDaoTao> GetChuongTrinhDaoTao()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_ChuongTrinhDaoTao";
            DataTable tb = dt.DAtable(sql);
            List<nc_ChuongTrinhDaoTao> lst = new List<nc_ChuongTrinhDaoTao>(); ;
            foreach (DataRow r in tb.Rows)
            {
                nc_ChuongTrinhDaoTao ct = new nc_ChuongTrinhDaoTao();
                ct.ID = (int)r["ID"];
                ct.MaChuongTrinh = (string.IsNullOrEmpty(r["MaChuongTrinh"].ToString())) ? "" : (string)r["MaChuongTrinh"];
                ct.TenChuongTrinh = (string.IsNullOrEmpty(r["TenChuongTrinh"].ToString())) ? "" : (string)r["TenChuongTrinh"];
                ct.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                ct.MoTa = (string.IsNullOrEmpty(r["MoTa"].ToString())) ? "" : (string)r["MoTa"];
                ct.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(ct);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_ChuongTrinhDaoTao> GetChuongTrinhDaoTaoWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_ChuongTrinhDaoTao where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DAtable(sql, pID);
            List<nc_ChuongTrinhDaoTao> lst = new List<nc_ChuongTrinhDaoTao>(); ;
            foreach (DataRow r in tb.Rows)
            {
                nc_ChuongTrinhDaoTao ct = new nc_ChuongTrinhDaoTao();
                ct.ID = (int)r["ID"];
                ct.MaChuongTrinh = (string.IsNullOrEmpty(r["MaChuongTrinh"].ToString())) ? "" : (string)r["MaChuongTrinh"];
                ct.TenChuongTrinh = (string.IsNullOrEmpty(r["TenChuongTrinh"].ToString())) ? "" : (string)r["TenChuongTrinh"];
                ct.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                ct.MoTa = (string.IsNullOrEmpty(r["MoTa"].ToString())) ? "" : (string)r["MoTa"];
                ct.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(ct);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_ChuongTrinhDaoTao> GetChuongTrinhDaoTaoWithLoai(int LoaiChuongTrinh)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_ChuongTrinhDaoTao where LoaiChuongTrinh=@LoaiChuongTrinh";
            SqlParameter pLoaiChuongTrinh = new SqlParameter("@LoaiChuongTrinh", LoaiChuongTrinh);
            DataTable tb = dt.DAtable(sql, pLoaiChuongTrinh);
            List<nc_ChuongTrinhDaoTao> lst = new List<nc_ChuongTrinhDaoTao>(); ;
            foreach (DataRow r in tb.Rows)
            {
                nc_ChuongTrinhDaoTao ct = new nc_ChuongTrinhDaoTao();
                ct.ID = (int)r["ID"];
                ct.MaChuongTrinh = (string.IsNullOrEmpty(r["MaChuongTrinh"].ToString())) ? "" : (string)r["MaChuongTrinh"];
                ct.TenChuongTrinh = (string.IsNullOrEmpty(r["TenChuongTrinh"].ToString())) ? "" : (string)r["TenChuongTrinh"];
                ct.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                ct.MoTa = (string.IsNullOrEmpty(r["MoTa"].ToString())) ? "" : (string)r["MoTa"];
                ct.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(ct);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_ChuongTrinhDaoTao> getChuongTrinhDaoTaoWithIndex(int SapXep)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_ChuongTrinhDaoTao where SapXep=@SapXep";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            DataTable tb = dt.DAtable(sql, pSapXep);
            List<nc_ChuongTrinhDaoTao> lst = new List<nc_ChuongTrinhDaoTao>();
            foreach (DataRow r in tb.Rows)
            {
                nc_ChuongTrinhDaoTao ct = new nc_ChuongTrinhDaoTao();
                ct.ID = (int)r["ID"];
                ct.MaChuongTrinh = (string.IsNullOrEmpty(r["MaChuongTrinh"].ToString())) ? "" : (string)r["MaChuongTrinh"];
                ct.TenChuongTrinh = (string.IsNullOrEmpty(r["TenChuongTrinh"].ToString())) ? "" : (string)r["TenChuongTrinh"];
                ct.LoaiChuongTrinh = (string.IsNullOrEmpty(r["LoaiChuongTrinh"].ToString())) ? 0 : (int)r["LoaiChuongTrinh"];
                ct.MoTa = (string.IsNullOrEmpty(r["MoTa"].ToString())) ? "" : (string)r["MoTa"];
                ct.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(ct);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public DataTable TableChuongTrinhDaoTao()
        {
            if(!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select ct.ID,ct.MaChuongTrinh,ct.TenChuongTrinh,ct.LoaiChuongTrinh,ct.MoTa,ct.SapXep,lct.TenChuongTrinh as TenLoaiChuongTrinh";
            sql += " ";
            sql += "from nc_ChuongTrinhDaoTao ct full outer join nc_LoaiCTDaoTao lct on ct.LoaiChuongTrinh=lct.ID where ct.ID is not null order by ct.SapXep asc";
            DataTable tb = dt.DAtable(sql);
            this.dt.CloseConnection();
            return tb;
        }
        //New
        public Boolean NewChuongTrinhDaoTao(string MaChuongTrinh, string TenChuongTrinh, int LoaiChuongTrinh, string MoTa, int SapXep)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into nc_ChuongTrinhDaoTao(MaChuongTrinh,TenChuongTrinh,LoaiChuongTrinh,MoTa,SapXep) values(@MaChuongTrinh,@TenChuongTrinh,@LoaiChuongTrinh,@MoTa,@SapXep)";
            SqlParameter pMaChuongTrinh = new SqlParameter("@MaChuongTrinh", MaChuongTrinh);
            SqlParameter pTenChuongTrinh = new SqlParameter("@TenChuongTrinh", TenChuongTrinh);
            SqlParameter pLoaiChuongTrinh = (LoaiChuongTrinh == 0) ? new SqlParameter("@LoaiChuongTrinh", DBNull.Value) : new SqlParameter("@LoaiChuongTrinh", LoaiChuongTrinh);
            SqlParameter pMoTa = new SqlParameter("@MoTa", MoTa);
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            this.dt.Updatedata(sql, pMaChuongTrinh, pTenChuongTrinh, pLoaiChuongTrinh, pMoTa, pSapXep);
            this.dt.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdateChuongTrinhDaoTao(int ID, string MaChuongTrinh, string TenChuongTrinh, int LoaiChuongTrinh, string MoTa)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update nc_ChuongTrinhDaoTao set MaChuongTrinh=@MaChuongTrinh,TenChuongTrinh=@TenChuongTrinh,LoaiChuongTrinh=@LoaiChuongTrinh,MoTa=@MoTa where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pMaChuongTrinh = new SqlParameter("@MaChuongTrinh", MaChuongTrinh);
            SqlParameter pTenChuongTrinh = new SqlParameter("@TenChuongTrinh", TenChuongTrinh);
            SqlParameter pLoaiChuongTrinh = (LoaiChuongTrinh == 0) ? new SqlParameter("@LoaiChuongTrinh", DBNull.Value) : new SqlParameter("@LoaiChuongTrinh", LoaiChuongTrinh);
            SqlParameter pMoTa = new SqlParameter("@MoTa", MoTa);
            this.dt.Updatedata(sql, pID, pMaChuongTrinh, pTenChuongTrinh, pLoaiChuongTrinh, pMoTa);
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
            string sql = "update nc_ChuongTrinhDaoTao set SapXep=@SapXep where ID=@ID";
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
            string sql = "select max(SapXep) from nc_ChuongTrinhDaoTao";
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
            string sql = "select max(SapXep) from nc_ChuongTrinhDaoTao where SapXep<@SapXep";
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
            string sql = "select min(SapXep) from nc_ChuongTrinhDaoTao where SapXep>@SapXep";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            RC = dt.GetValues(sql, pSapXep);
            this.dt.CloseConnection();
            return RC;
        }
    }
}
