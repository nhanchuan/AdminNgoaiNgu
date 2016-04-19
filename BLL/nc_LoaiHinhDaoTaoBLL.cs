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
    public class nc_LoaiHinhDaoTaoBLL
    {
        DataServices dt = new DataServices();

        public List<nc_LoaiHinhDaoTao> getListLoaiHinhDaoTao()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LoaiHinhDaoTao";
            DataTable tb = dt.DAtable(sql);
            List<nc_LoaiHinhDaoTao> lst = new List<nc_LoaiHinhDaoTao>();
            foreach(DataRow r in tb.Rows)
            {
                nc_LoaiHinhDaoTao lh = new nc_LoaiHinhDaoTao();
                lh.ID = (int)r["ID"];
                lh.MaLoaiHinh = (string.IsNullOrEmpty(r["MaLoaiHinh"].ToString())) ? "" : (string)r["MaLoaiHinh"];
                lh.TenLoaiHinh = (string.IsNullOrEmpty(r["TenLoaiHinh"].ToString())) ? "" : (string)r["TenLoaiHinh"];
                lst.Add(lh);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_LoaiHinhDaoTao> getListLoaiHinhDaoTaoWithID(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_LoaiHinhDaoTao where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            DataTable tb = dt.DAtable(sql, pID);
            List<nc_LoaiHinhDaoTao> lst = new List<nc_LoaiHinhDaoTao>();
            foreach (DataRow r in tb.Rows)
            {
                nc_LoaiHinhDaoTao lh = new nc_LoaiHinhDaoTao();
                lh.ID = (int)r["ID"];
                lh.MaLoaiHinh = (string.IsNullOrEmpty(r["MaLoaiHinh"].ToString())) ? "" : (string)r["MaLoaiHinh"];
                lh.TenLoaiHinh = (string.IsNullOrEmpty(r["TenLoaiHinh"].ToString())) ? "" : (string)r["TenLoaiHinh"];
                lst.Add(lh);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public Boolean NewLoaiHinhDaoTao(string MaLoaiHinh, string TenLoaiHinh)
        {
            if(!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into nc_LoaiHinhDaoTao(MaLoaiHinh,TenLoaiHinh) values(@MaLoaiHinh,@TenLoaiHinh)";
            SqlParameter pMaLoaiHinh = new SqlParameter("@MaLoaiHinh", MaLoaiHinh);
            SqlParameter pTenLoaiHinh = new SqlParameter("@TenLoaiHinh", TenLoaiHinh);
            this.dt.Updatedata(sql, pMaLoaiHinh, pTenLoaiHinh);
            this.dt.CloseConnection();
            return true;
        }
        //Delete Loai Hinh Dao Tao
        public Boolean DeleteLoaiHinhDaoTao(int ID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "delete from nc_LoaiHinhDaoTao where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            this.dt.Updatedata(sql, pID);
            this.dt.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdateLoaiHinhDaoTao(int ID, string MaLoaiHinh, string TenLoaiHinh)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update nc_LoaiHinhDaoTao set MaLoaiHinh=@MaLoaiHinh, TenLoaiHinh=@TenLoaiHinh where ID=@ID";
            SqlParameter pID = new SqlParameter("@ID", ID);
            SqlParameter pMaLoaiHinh = new SqlParameter("@MaLoaiHinh", MaLoaiHinh);
            SqlParameter pTenLoaiHinh = new SqlParameter("@TenLoaiHinh", TenLoaiHinh);
            this.dt.Updatedata(sql, pID, pMaLoaiHinh, pTenLoaiHinh);
            this.dt.CloseConnection();
            return true;
        }
    }
}
