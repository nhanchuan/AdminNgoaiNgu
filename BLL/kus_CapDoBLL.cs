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
    public class kus_CapDoBLL
    {
        DataServices DB = new DataServices();
        public List<kus_CapDo> getAllCapDo()
        {
            string sql = "select * from kus_CapDo";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<kus_CapDo> lst = new List<kus_CapDo>();
            foreach(DataRow r in tb.Rows)
            {
                kus_CapDo cd = new kus_CapDo();
                cd.CapDoID = (int)r[0];
                cd.TenCapDo = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cd.KhoiLopID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                cd.MoTaNgan = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(cd);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_CapDo> getCapDoWithID(int capdoID)
        {
            string sql = "select * from kus_CapDo where CapDoID=@capdoID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcapdoID = new SqlParameter("capdoID", capdoID);
            DataTable tb = DB.DAtable(sql, pcapdoID);
            List<kus_CapDo> lst = new List<kus_CapDo>();
            foreach (DataRow r in tb.Rows)
            {
                kus_CapDo cd = new kus_CapDo();
                cd.CapDoID = (int)r[0];
                cd.TenCapDo = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cd.KhoiLopID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                cd.MoTaNgan = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(cd);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_CapDo> getCapDoWithKhoiLopID(int khoilopID)
        {
            string sql = "select * from kus_CapDo where KhoiLopID=@khoilopID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pkhoilopID = new SqlParameter("khoilopID", khoilopID);
            DataTable tb = DB.DAtable(sql, pkhoilopID);
            List<kus_CapDo> lst = new List<kus_CapDo>();
            foreach (DataRow r in tb.Rows)
            {
                kus_CapDo cd = new kus_CapDo();
                cd.CapDoID = (int)r[0];
                cd.TenCapDo = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cd.KhoiLopID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                cd.MoTaNgan = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(cd);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_CapDo> getAllCapDoWithId(int capdoId)
        {
            string sql = "select * from kus_CapDo where CapDoID=@capdoId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcapdoId = new SqlParameter("@capdoId", capdoId);
            DataTable tb = DB.DAtable(sql, pcapdoId);
            List<kus_CapDo> lst = new List<kus_CapDo>();
            foreach (DataRow r in tb.Rows)
            {
                kus_CapDo cd = new kus_CapDo();
                cd.CapDoID = (int)r[0];
                cd.TenCapDo = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cd.KhoiLopID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                cd.MoTaNgan = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(cd);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getTBAllCapDo()
        {
            string sql = "select cd.CapDoID,cd.TenCapDo,cd.KhoiLopID,cd.MoTaNgan,kl.TenKhoiLop from kus_CapDo cd join kus_KhoiLop kl on cd.KhoiLopID=kl.KhoiLopID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //Create
        public Boolean AddNew_CapDo(string TenCapDo, int KhoiLopID, string MoTaNgan)
        {
            if (!DB.OpenConnection())
            {
                return false;
            }
            string query = "insert into kus_CapDo(TenCapDo,KhoiLopID,MoTaNgan) values(@TenCapDo,@KhoiLopID,@MoTaNgan)";
            SqlParameter pTenCapDo = new SqlParameter("@TenCapDo", TenCapDo);
            SqlParameter pKhoiLopID =(KhoiLopID==0)? new SqlParameter("@KhoiLopID", DBNull.Value): new SqlParameter("@KhoiLopID", KhoiLopID);
            SqlParameter pMoTaNgan = new SqlParameter("@MoTaNgan", MoTaNgan);
            this.DB.Updatedata(query, pTenCapDo, pKhoiLopID, pMoTaNgan);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean Update_CapDo(int CapdoId, string TenCapDo, int KhoiLopID, string MoTaNgan)
        {
            if (!DB.OpenConnection())
            {
                return false;
            }
            string query = "update kus_CapDo set TenCapDo=@TenCapDo,KhoiLopID=@KhoiLopID,MoTaNgan=@MoTaNgan where CapDoID=@CapdoId";
            SqlParameter pCapdoId = new SqlParameter("@CapdoId", CapdoId);
            SqlParameter pTenCapDo = new SqlParameter("@TenCapDo", TenCapDo);
            SqlParameter pKhoiLopID = new SqlParameter("@KhoiLopID", KhoiLopID);
            SqlParameter pMoTaNgan = new SqlParameter("@MoTaNgan", MoTaNgan);
            this.DB.Updatedata(query, pTenCapDo, pKhoiLopID, pMoTaNgan, pCapdoId);
            this.DB.CloseConnection();
            return true;
        }
        //Delete
        public Boolean Delete_CapDo(int CapdoId)
        {
            if (!DB.OpenConnection())
            {
                return false;
            }
            string query = "delete from kus_CapDo where CapDoID=@CapdoId";
            SqlParameter pCapdoId = new SqlParameter("@CapdoId", CapdoId);
            this.DB.Updatedata(query, pCapdoId);
            this.DB.CloseConnection();
            return true;
        }
    }
}
