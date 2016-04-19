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
    public class kus_HTChiNhanhBLL
    {
        DataServices DB = new DataServices();
        public DataTable getlAllHTChiNHanh()
        {
            string sql = "select * from kus_HTChiNhanh";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<kus_HTChiNhanh> lst = new List<kus_HTChiNhanh>();
            foreach (DataRow r in tb.Rows)
            {
                kus_HTChiNhanh cn = new kus_HTChiNhanh();
                cn.HTChiNhanhID = (int)r[0];
                cn.TenHTChiNhanh = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cn.GhiChu = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                cn.GDChiNHanh = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(cn);
            }
            this.DB.CloseConnection();
            return tb;
        }
        public List<kus_HTChiNhanh> getlistHTChiNHanhWithID(int chinhanhid)
        {
            string sql = "select * from kus_HTChiNhanh where HTChiNhanhID=@chinhanhid";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pchinhanhid = new SqlParameter("chinhanhid", chinhanhid);
            DataTable tb = DB.DAtable(sql, pchinhanhid);
            List<kus_HTChiNhanh> lst = new List<kus_HTChiNhanh>();
            foreach (DataRow r in tb.Rows)
            {
                kus_HTChiNhanh cn = new kus_HTChiNhanh();
                cn.HTChiNhanhID = (int)r[0];
                cn.TenHTChiNhanh = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cn.GhiChu = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                cn.GDChiNHanh = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(cn);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getAllTBChiNhanh()
        {
            string sql = "select cn.HTChiNhanhID, cn.TenHTChiNhanh, cn.GhiChu, cn.GDChiNHanh, emp.EmployeesCode, emp.ProfileID, pro.FirstName, pro.LastName from kus_HTChiNhanh cn full outer join Employees emp on cn.GDChiNHanh=emp.EmployeesID full outer join UserProfile pro on emp.ProfileID=pro.ProfileID where cn.HTChiNhanhID is not null";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //Create
        public Boolean AddNew_HTChiNhanh(string chinhanh, string ghichu, int giamdoc)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string query = "insert into kus_HTChiNhanh(TenHTChiNhanh,GhiChu,GDChiNHanh) values(@chinhanh, @ghichu, @giamdoc)";
            SqlParameter pchinhanh= new SqlParameter("@chinhanh", chinhanh);
            SqlParameter pghichu= new SqlParameter("@ghichu", ghichu);
            SqlParameter pgiamdoc=(giamdoc==0)? new SqlParameter("@giamdoc", DBNull.Value): new SqlParameter("@giamdoc", giamdoc);
            this.DB.Updatedata(query, pchinhanh, pghichu, pgiamdoc);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean Update_HTChiNhanh(int id, string chinhanh, string ghichu, int giamdoc)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string query = "update kus_HTChiNhanh set TenHTChiNhanh=@chinhanh, GhiChu=@ghichu, GDChiNHanh=@giamdoc where HTChiNhanhID=@id";
            SqlParameter pid = new SqlParameter("@id", id);
            SqlParameter pchinhanh = new SqlParameter("@chinhanh", chinhanh);
            SqlParameter pghichu = new SqlParameter("@ghichu", ghichu);
            SqlParameter pgiamdoc = (giamdoc == 0) ? new SqlParameter("@giamdoc", DBNull.Value) : new SqlParameter("@giamdoc", giamdoc);
            this.DB.Updatedata(query, pid, pchinhanh, pghichu, pgiamdoc);
            this.DB.CloseConnection();
            return true;
        }
        //Delete
        public Boolean Delete_HTChiNhanh(int id)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string query = "delete from kus_HTChiNhanh where HTChiNhanhID=@id";
            SqlParameter pid = new SqlParameter("@id", id);
            this.DB.Updatedata(query, pid);
            this.DB.CloseConnection();
            return true;
        }
    }
}
