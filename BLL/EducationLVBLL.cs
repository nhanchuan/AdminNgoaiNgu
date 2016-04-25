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
    public class EducationLVBLL
    {
        DataServices DB = new DataServices();
        public List<EducationLV> getallEducationLV()
        {
            string sql = "select * from EducationLV";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<EducationLV> lst = new List<EducationLV>();
            foreach (DataRow r in tb.Rows)
            {
                EducationLV ed = new EducationLV();
                ed.ID = (int)r["ID"];
                ed.NAME = (string.IsNullOrEmpty(r["NAME"].ToString())) ? "" : (string)r["NAME"];
                lst.Add(ed);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<EducationLV> getallEducationLVWithId(int EID)
        {
            string sql = "select * from EducationLV where ID=@EID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pEID = new SqlParameter("EID", EID);
            DataTable tb = DB.DAtable(sql, pEID);
            List<EducationLV> lst = new List<EducationLV>();
            foreach (DataRow r in tb.Rows)
            {
                EducationLV ed = new EducationLV();
                ed.ID = (int)r["ID"];
                ed.NAME = (string.IsNullOrEmpty(r["NAME"].ToString())) ? "" : (string)r["NAME"];
                lst.Add(ed);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
