using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class kus_LopHoc_BooksBLL
    {
        DataServices DB = new DataServices();
        public List<kus_LopHoc_Books> getListLopHocBookWithLHID(int lophocID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_LopHoc_Books where LopHocID=@lophocID";
            SqlParameter plophocID = new SqlParameter("lophocID", lophocID);
            DataTable tb = DB.DAtable(sql, plophocID);
            List<kus_LopHoc_Books> lst = new List<kus_LopHoc_Books>();
            foreach(DataRow r in tb.Rows)
            {
                kus_LopHoc_Books lb = new kus_LopHoc_Books();
                lb.LopHocID = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
                lb.BookID= (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                lb.DateOfCreate = (DateTime)r[2];
                lst.Add(lb);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getTBkus_LopHoc_BooksWithLopID(int lophocID)
        {
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select LB.LopHocID,LB.BookID,LB.DateOfCreate, b.BookName, b.BookCode ,b.Author, b.Publisher, b.HinhThuc, b.Languages, b.NgayXB, b.SoTrang from kus_LopHoc_Books LB full outer join kus_Books b on LB.BookID=b.BookID where LB.LopHocID is not null and LB.LopHocID=@lophocID";
            SqlParameter plophocID = new SqlParameter("lophocID", lophocID);
            DataTable tb = DB.DAtable(sql, plophocID);
            this.DB.CloseConnection();
            return tb;
        }
        //Create
        public Boolean InsertBook(int lophocID, int bookID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into kus_LopHoc_Books(LopHocID,BookID) values(@lophocID,@bookID)";
            SqlParameter plophocID = new SqlParameter("lophocID", lophocID);
            SqlParameter pbookID = new SqlParameter("bookID", bookID);
            this.DB.Updatedata(sql, plophocID, pbookID);
            this.DB.CloseConnection();
            return true;
        }
        //Delete
        public Boolean DeletetBook(int lophocID, int bookID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from kus_LopHoc_Books where LopHocID=@lophocID and BookID=@bookID";
            SqlParameter plophocID = new SqlParameter("lophocID", lophocID);
            SqlParameter pbookID = new SqlParameter("bookID", bookID);
            this.DB.Updatedata(sql, plophocID, pbookID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
