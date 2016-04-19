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
    public class ListOfReligionBLL
    {
        DataServices DB = new DataServices();
        public List<ListOfReligion> getAllListOfReligion()
        {
            string sql = "select * from ListOfReligion ";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<ListOfReligion> lst = new List<ListOfReligion>();
            foreach(DataRow r in tb.Rows)
            {
                ListOfReligion lr = new ListOfReligion();
                lr.ReligionID = (int)r[0];
                lr.ReligionName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(lr);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
