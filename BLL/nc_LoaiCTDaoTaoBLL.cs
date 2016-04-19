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
    public class nc_LoaiCTDaoTaoBLL
    {
        DataServices dt = new DataServices();
        public List<nc_LoaiCTDaoTao> getListLoaiCTDaoTao()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LoaiCTDaoTao";
            DataTable tb = dt.DAtable(sql);
            List<nc_LoaiCTDaoTao> lst = new List<nc_LoaiCTDaoTao>();
            foreach(DataRow r in tb.Rows)
            {
                nc_LoaiCTDaoTao lc = new nc_LoaiCTDaoTao();
                lc.ID = (int)r["ID"];
                lc.MaChuongTrinh = (string.IsNullOrEmpty(r["MaChuongTrinh"].ToString())) ? "" : (string)r["MaChuongTrinh"];
                lc.TenChuongTrinh = (string.IsNullOrEmpty(r["TenChuongTrinh"].ToString())) ? "" : (string)r["TenChuongTrinh"];
                lc.LHDT = (string.IsNullOrEmpty(r["LHDT"].ToString())) ? 0 : (int)r["LHDT"];
                lc.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(lc);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_LoaiCTDaoTao> getLoaiCTDaoTaoWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LoaiCTDaoTao where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DAtable(sql, pID);
            List<nc_LoaiCTDaoTao> lst = new List<nc_LoaiCTDaoTao>();
            foreach (DataRow r in tb.Rows)
            {
                nc_LoaiCTDaoTao lc = new nc_LoaiCTDaoTao();
                lc.ID = (int)r["ID"];
                lc.MaChuongTrinh = (string.IsNullOrEmpty(r["MaChuongTrinh"].ToString())) ? "" : (string)r["MaChuongTrinh"];
                lc.TenChuongTrinh = (string.IsNullOrEmpty(r["TenChuongTrinh"].ToString())) ? "" : (string)r["TenChuongTrinh"];
                lc.LHDT = (string.IsNullOrEmpty(r["LHDT"].ToString())) ? 0 : (int)r["LHDT"];
                lc.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(lc);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_LoaiCTDaoTao> getLoaiCTDaoTaoWithIndex(int SapXep)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LoaiCTDaoTao where SapXep=@SapXep";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            DataTable tb = dt.DAtable(sql, pSapXep);
            List<nc_LoaiCTDaoTao> lst = new List<nc_LoaiCTDaoTao>();
            foreach (DataRow r in tb.Rows)
            {
                nc_LoaiCTDaoTao lc = new nc_LoaiCTDaoTao();
                lc.ID = (int)r["ID"];
                lc.MaChuongTrinh = (string.IsNullOrEmpty(r["MaChuongTrinh"].ToString())) ? "" : (string)r["MaChuongTrinh"];
                lc.TenChuongTrinh = (string.IsNullOrEmpty(r["TenChuongTrinh"].ToString())) ? "" : (string)r["TenChuongTrinh"];
                lc.LHDT = (string.IsNullOrEmpty(r["LHDT"].ToString())) ? 0 : (int)r["LHDT"];
                lc.SapXep = (string.IsNullOrEmpty(r["SapXep"].ToString())) ? 0 : (int)r["SapXep"];
                lst.Add(lc);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public DataTable getTableLoaiCTDaoTao()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select lt.ID, lt.MaChuongTrinh, lt.TenChuongTrinh, lt.LHDT, lt.SapXep, lh.TenLoaiHinh from nc_LoaiCTDaoTao lt full outer join nc_LoaiHinhDaoTao lh on lt.LHDT=lh.ID WHERE lt.ID is not null order by lt.SapXep asc";
            DataTable tb = dt.DAtable(sql);
            this.dt.CloseConnection();
            return tb;
        }
        //New
        public Boolean NewLoaiCTDaoTao(string MaChuongTrinh, string TenChuongTrinh, int LHDT, int SapXep)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into nc_LoaiCTDaoTao(MaChuongTrinh,TenChuongTrinh,LHDT,SapXep) values(@MaChuongTrinh,@TenChuongTrinh,@LHDT,@SapXep)";
            SqlParameter pMaChuongTrinh = new SqlParameter("@MaChuongTrinh", MaChuongTrinh);
            SqlParameter pTenChuongTrinh = new SqlParameter("@TenChuongTrinh", TenChuongTrinh);
            SqlParameter pLHDT = (LHDT == 0) ? new SqlParameter("@LHDT", DBNull.Value) : new SqlParameter("@LHDT", LHDT);
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            this.dt.Updatedata(sql, pMaChuongTrinh, pTenChuongTrinh, pLHDT, pSapXep);
            this.dt.CloseConnection();
            return true;
        }
        //Sum LoaiCTDaoTao
        public int CounkItem()
        {
            int RC = 0;
            string sql = "select COUNT(*) from nc_LoaiCTDaoTao";
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public int MaxItemindex()
        {
            int RC = 0;
            string sql = "select max(SapXep) from nc_LoaiCTDaoTao";
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
            RC = dt.GetValues(sql);
            this.dt.CloseConnection();
            return RC;
        }
        public int MinItemindex()
        {
            int RC = 0;
            string sql = "select min(SapXep) from nc_LoaiCTDaoTao";
            if (!this.dt.OpenConnection())
            {
                return 0;
            }
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
            string sql = "select max(SapXep) from nc_LoaiCTDaoTao where SapXep<@SapXep";
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
            string sql = "select min(SapXep) from nc_LoaiCTDaoTao where SapXep>@SapXep";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            RC = dt.GetValues(sql, pSapXep);
            this.dt.CloseConnection();
            return RC;
        }
        //============UPDATRE ITEM INDEX======================================================================================================================================================================
        public Boolean UpdateSapXep(int SapXep, int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update nc_LoaiCTDaoTao set SapXep=@SapXep where ID=@ID";
            SqlParameter pSapXep = new SqlParameter("@SapXep", SapXep);
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sql, pSapXep, pID);
            this.dt.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdateLoaiCTDaoTao(string MaChuongTrinh, string TenChuongTrinh, int LHDT, int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update nc_LoaiCTDaoTao set MaChuongTrinh=@MaChuongTrinh, TenChuongTrinh=@TenChuongTrinh, LHDT=@LHDT where ID=@ID";
            SqlParameter pMaChuongTrinh = new SqlParameter("@MaChuongTrinh", MaChuongTrinh);
            SqlParameter pTenChuongTrinh = new SqlParameter("@TenChuongTrinh", TenChuongTrinh);
            SqlParameter pLHDT = (LHDT == 0) ? new SqlParameter("@LHDT", DBNull.Value) : new SqlParameter("@LHDT", LHDT);
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sql, pMaChuongTrinh, pTenChuongTrinh, pLHDT, pID);
            this.dt.CloseConnection();
            return true;
        }
    }
}
