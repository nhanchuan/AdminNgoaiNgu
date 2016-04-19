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
    public class ListOfNationalitiesBLL
    {
        DataServices DB = new DataServices();
        public List<ListOfNationalities> getAllListOfNationalities()
        {
            string sql = "select * from ListOfNationalities";
            if (!DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<ListOfNationalities> lst = new List<ListOfNationalities>();
            foreach (DataRow r in tb.Rows)
            {
                ListOfNationalities lo = new ListOfNationalities();
                lo.NationalityID = (int)r[0];
                lo.NationalityName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(lo);
            }
            this.DB.CloseConnection();
            return lst;
        }

    }
}
