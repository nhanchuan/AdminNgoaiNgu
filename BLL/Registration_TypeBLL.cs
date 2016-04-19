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
    public class Registration_TypeBLL
    {
        DataServices DB = new DataServices();
        public List<Registration_Type> getAllRegistration_Type()
        {
            string sql = "select * from Registration_Type";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<Registration_Type> lst = new List<Registration_Type>();
            foreach(DataRow r in tb.Rows)
            {
                Registration_Type rt = new Registration_Type();
                rt.TypeID = (int)r[0];
                rt.TypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(rt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Registration_Type> getAllRegistration_TypeWithId(int typeId)
        {
            string sql = "select * from Registration_Type where TypeID=@typeId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ptypeId = new SqlParameter("typeId", typeId);
            DataTable tb = DB.DAtable(sql, ptypeId);
            List<Registration_Type> lst = new List<Registration_Type>();
            foreach (DataRow r in tb.Rows)
            {
                Registration_Type rt = new Registration_Type();
                rt.TypeID = (int)r[0];
                rt.TypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(rt);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
