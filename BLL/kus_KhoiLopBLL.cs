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
    public class kus_KhoiLopBLL
    {
        DataServices DB = new DataServices();
        public List<kus_KhoiLop> getAllKhoiLop()
        {
            string sql = "select * from kus_KhoiLop";
            if(!DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<kus_KhoiLop> lst = new List<kus_KhoiLop>();
            foreach (DataRow r in tb.Rows)
            {
                kus_KhoiLop kl = new kus_KhoiLop();
                kl.KhoiLopID = (int)r[0];
                kl.TenKhoiLop = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                kl.MoTaNgan = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lst.Add(kl);
            }
            DB.CloseConnection();
            return lst;
        }
        public List<kus_KhoiLop> getKhoiLopWithID(int khoilopid)
        {
            string sql = "select * from kus_KhoiLop where KhoiLopID=@khoilopid";
            if (!DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pkhoilopid = new SqlParameter("khoilopid", khoilopid);
            DataTable tb = DB.DAtable(sql, pkhoilopid);
            List<kus_KhoiLop> lst = new List<kus_KhoiLop>();
            foreach (DataRow r in tb.Rows)
            {
                kus_KhoiLop kl = new kus_KhoiLop();
                kl.KhoiLopID = (int)r[0];
                kl.TenKhoiLop = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                kl.MoTaNgan = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lst.Add(kl);
            }
            DB.CloseConnection();
            return lst;
        }
        //Create
        public Boolean AddNew_KhoiLop(string tenkhoi, string mota)
        {
            if (!DB.OpenConnection())
            {
                return false;
            }
            string query = "insert into kus_KhoiLop(TenKhoiLop,MoTaNgan) values(@tenkhoi, @mota)";
            SqlParameter ptenkhoi = new SqlParameter("@tenkhoi", tenkhoi);
            SqlParameter pmotai = new SqlParameter("@mota", mota);
            this.DB.Updatedata(query, ptenkhoi, pmotai);
            this.DB.CloseConnection();
            return true;
        }

        //Update
        public Boolean Update_KhoiLop(string id, string tenkhoi, string mota)
        {
            if (!DB.OpenConnection())
            {
                return false;
            }
            string query = "update kus_KhoiLop set TenKhoiLop=@tenkhoi, MoTaNgan=@mota where KhoiLopID=@id";
            SqlParameter ptenkhoi = new SqlParameter("@tenkhoi", tenkhoi);
            SqlParameter pmotai = new SqlParameter("@mota", mota);
            SqlParameter pid = new SqlParameter("@id", id);
            this.DB.Updatedata(query, ptenkhoi, pmotai, pid);
            this.DB.CloseConnection();
            return true;
        }
        //Delete
        public Boolean Delete_KhoiLop(string id)
        {
            if (!DB.OpenConnection())
            {
                return false;
            }
            string query = "delete from kus_KhoiLop where KhoiLopID=@id";
            SqlParameter pid = new SqlParameter("@id", id);
            this.DB.Updatedata(query, pid);
            this.DB.CloseConnection();
            return true;
        }
    }
}
