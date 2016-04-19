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
   public  class kus_GioThiBLL
    {
        DataServices DB = new DataServices();
        public List<kus_GioThi> getAllkus_GioThi()
        {
            string str = "select * from kus_GioThi";
            if (!DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(str);
            List<kus_GioThi> lst = new List<kus_GioThi>();
            foreach (DataRow r in tb.Rows)
            {
                kus_GioThi gh = new kus_GioThi();
                gh.GioThiID = (int)r[0];
                gh.Tiet = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                gh.Gio = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lst.Add(gh);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //Create
        public Boolean GioThi_AddNew(string TietThi, string GioThi)
        {
           
            string query = "insert into kus_GioThi(Tiet,Gio) values(@tietthi, @giothi)";
            if (!DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pTietThi = new SqlParameter("@tietthi", TietThi);
            SqlParameter pGioThi = new SqlParameter("@giothi", GioThi);
            this.DB.Updatedata(query, pTietThi, pGioThi);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean GioThi_Update(string GioThi_ID, string TietThi, string GioThi)
        {
            string query = "update kus_GioThi set Tiet = @tietthi, Gio = @giothi where GioThiID=@giothi_id";
            if (!DB.OpenConnection())
            {
                return false;
            }

            SqlParameter pGioThi_ID = new SqlParameter("@giothi_id", GioThi_ID);
            SqlParameter pTietThi = new SqlParameter("@tietthi", TietThi);
            SqlParameter pGioThi = new SqlParameter("@giothi", GioThi);
            this.DB.Updatedata(query, pGioThi_ID, pTietThi, pGioThi);
            this.DB.CloseConnection();
            return true;
        }

        //Delete
        public Boolean GioThi_Delete(string GioThi_ID)
        {
            string query = "delete from kus_GioThi where GioThiID=@giothi_id";
            if (!DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pGioThi_ID = new SqlParameter("@giothi_id", GioThi_ID);
            this.DB.Updatedata(query, pGioThi_ID);
            this.DB.CloseConnection();
            return true;
        }

    }
}
