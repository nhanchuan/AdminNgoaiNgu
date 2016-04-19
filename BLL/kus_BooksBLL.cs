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
    public class kus_BooksBLL
    {
        DataServices DB = new DataServices();
        DateTime DefaultDate = Convert.ToDateTime("12/12/1900");
        public List<kus_Books> getAllBooks()
        {
            string sql = "select * from kus_Books";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<kus_Books> lst = new List<kus_Books>();
            foreach(DataRow r in tb.Rows)
            {
                kus_Books bk = new kus_Books();
                bk.BookID = (int)r[0];
                bk.BookCode = (string)r[1];
                bk.BookName = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bk.Author= (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                bk.Publisher= (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                bk.NgayXB = (string.IsNullOrEmpty(r[5].ToString())) ? DefaultDate:(DateTime)r[5];
                bk.SoTrang= (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                bk.HinhThuc= (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                bk.Languages= (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                lst.Add(bk);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetTBBoook()
        {
            string sql = "select BookID, (BookName+ ' - Mã: '+ BookCode + N' - NXB: '+Publisher) as BookNames from kus_Books";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //Create
        public Boolean AddNew_Book(string name, string author, string publisher, DateTime nxb, int sotrang, string hinhthuc, string language)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int namxb = nxb.Year;
            string query = "insert into kus_Books(BookName,Author,Publisher,NgayXB,SoTrang,HinhThuc,Languages) values(@name, @author, @publisher, @nxb, @sotrang, @hinhthuc, @language)";
            SqlParameter pname = new SqlParameter("@name", name);
            SqlParameter pauthor = new SqlParameter("@author", author);
            SqlParameter ppublisher = new SqlParameter("@publisher", publisher);
            SqlParameter pnxb = (namxb <= 1900) ? new SqlParameter("@nxb", DBNull.Value) : new SqlParameter("@nxb", nxb);
            SqlParameter psotrang = (sotrang <= 0) ? new SqlParameter("@sotrang", DBNull.Value) : new SqlParameter("@sotrang", sotrang);
            SqlParameter phinhthuc = new SqlParameter("@hinhthuc", hinhthuc);
            SqlParameter planguage = new SqlParameter("@language", language);
            this.DB.Updatedata(query, pname, pauthor, ppublisher, pnxb, psotrang, phinhthuc, planguage);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean Update_Book(int id, string name, string author, string publisher, DateTime nxb, int sotrang, string hinhthuc, string language)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int namxb = nxb.Year;
            string query = "update kus_Books set BookName=@name, Author=@author, Publisher=@publisher, NgayXB=@nxb, SoTrang=@sotrang, HinhThuc=@hinhthuc, Languages=@language where BookID=@id";
            SqlParameter pid = new SqlParameter("@id", id);
            SqlParameter pname = new SqlParameter("@name", name);
            SqlParameter pauthor = new SqlParameter("@author", author);
            SqlParameter ppublisher = new SqlParameter("@publisher", publisher);
            SqlParameter pnxb = (namxb <= 1900) ? new SqlParameter("@nxb", DBNull.Value) : new SqlParameter("@nxb", nxb);
            SqlParameter psotrang = (sotrang <= 0) ? new SqlParameter("@sotrang", DBNull.Value) : new SqlParameter("@sotrang", sotrang);
            SqlParameter phinhthuc = new SqlParameter("@hinhthuc", hinhthuc);
            SqlParameter planguage = new SqlParameter("@language", language);
            this.DB.Updatedata(query, pid, pname, pauthor, ppublisher, pnxb, psotrang, phinhthuc, planguage);
            this.DB.CloseConnection();
            return true;
        }
        //Delete
        public Boolean Delete_Book(int id)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string query = "delete from kus_Books where BookID=@id";
            SqlParameter pid = new SqlParameter("@id", id);
            this.DB.Updatedata(query, pid);
            this.DB.CloseConnection();
            return true;
        }
    }
}
