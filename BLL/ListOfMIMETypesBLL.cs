using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;

namespace BLL
{
    public class ListOfMIMETypesBLL
    {
        DataServices DB = new DataServices();
        public List<ListOfMIMETypes> getMIMETypeWithEx(string extension)
        {
            string sql = "select * from ListOfMIMETypes where Extension=@extension";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pextension = new SqlParameter("extension", extension);
            DataTable tb = DB.DAtable(sql, pextension);
            List<ListOfMIMETypes> lst = new List<ListOfMIMETypes>();
            foreach(DataRow r in tb.Rows)
            {
                ListOfMIMETypes lo = new ListOfMIMETypes();
                lo.TypesID = (int)r[0];
                lo.Name = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lo.MIMEType= (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lo.Extension= (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(lo);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
