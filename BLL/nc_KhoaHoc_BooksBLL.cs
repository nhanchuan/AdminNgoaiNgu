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
    public class nc_KhoaHoc_BooksBLL
    {
        DataServices dt = new DataServices();
        public List<nc_KhoaHoc_Books> getLstnc_KhoaHoc_Books()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_KhoaHoc_Books";
            DataTable tb = dt.DAtable(sql);
            List<nc_KhoaHoc_Books> lst = new List<nc_KhoaHoc_Books>();
            foreach(DataRow r in tb.Rows)
            {
                nc_KhoaHoc_Books nc = new nc_KhoaHoc_Books();
                nc.KhoaHoc = (int)r["KhoaHoc"];
                nc.BookID = (int)r["BookID"];
                nc.DateOfCreate = (DateTime)r["DateOfCreate"];
                lst.Add(nc);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<nc_KhoaHoc_Books> ListAvailableBook(int KhoaHoc, int BookID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_KhoaHoc_Books where KhoaHoc=@KhoaHoc and BookID=@BookID";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            SqlParameter pBookID = new SqlParameter("@BookID", BookID);
            DataTable tb = dt.DAtable(sql, pKhoaHoc, pBookID);
            List<nc_KhoaHoc_Books> lst = new List<nc_KhoaHoc_Books>();
            foreach (DataRow r in tb.Rows)
            {
                nc_KhoaHoc_Books nc = new nc_KhoaHoc_Books();
                nc.KhoaHoc = (int)r["KhoaHoc"];
                nc.BookID = (int)r["BookID"];
                nc.DateOfCreate = (DateTime)r["DateOfCreate"];
                lst.Add(nc);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public DataTable getTBnc_KhoaHoc_Books(int KhoaHoc)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from nc_KhoaHoc_Books KB full outer join kus_Books b on KB.BookID=b.BookID where KB.KhoaHoc is not null and  KB.KhoaHoc=@KhoaHoc";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            DataTable tb = dt.DAtable(sql, pKhoaHoc);
            this.dt.CloseConnection();
            return tb;
        }
        //Create
        public Boolean InsertBook(int KhoaHoc, int bookID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into nc_KhoaHoc_Books(KhoaHoc,BookID) values(@KhoaHoc,@bookID)";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            SqlParameter pbookID = new SqlParameter("@bookID", bookID);
            this.dt.Updatedata(sql, pKhoaHoc, pbookID);
            this.dt.CloseConnection();
            return true;
        }
        //Delete
        public Boolean DeletetBook(int KhoaHoc, int bookID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "delete from nc_KhoaHoc_Books where KhoaHoc=@KhoaHoc and BookID=@bookID";
            SqlParameter pKhoaHoc = new SqlParameter("@KhoaHoc", KhoaHoc);
            SqlParameter pbookID = new SqlParameter("@bookID", bookID);
            this.dt.Updatedata(sql, pKhoaHoc, pbookID);
            this.dt.CloseConnection();
            return true;
        }
    }
}
