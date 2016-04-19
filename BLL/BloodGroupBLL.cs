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
    public class BloodGroupBLL
    {
        DataServices DB = new DataServices();
        public List<BloodGroup> GetAllBloodGroup()
        {
            string sql = "select * from BloodGroup";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<BloodGroup> lst = new List<BloodGroup>();
            foreach (DataRow r in tb.Rows)
            {
                BloodGroup lg = new BloodGroup();
                lg.BloodID = (int)r[0];
                lg.BloodName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(lg);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
