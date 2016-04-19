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
    public class PermissFuncBLL
    {
        DataServices DB = new DataServices();
        public List<PermissFunc> getListPermissFunc()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from PermissFunc";
            DataTable tb = DB.DAtable(sql);
            List<PermissFunc> lst = new List<PermissFunc>();
            foreach (DataRow r in tb.Rows)
            {
                PermissFunc p = new PermissFunc();
                p.PermissFuncID = (int)r[0];
                p.FunctionName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                p.FunctionCode = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                p.PFGroupID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(p);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getTBListPermissFunc()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from PermissFunc";
            DataTable tb = DB.DAtable(sql);
            return tb;
        }
        public List<PermissFunc> getListFGPermissFunc(int FGroupID)
        {
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from PermissFunc where FGroupID=@FGroupID";
            SqlParameter pFGroupID = new SqlParameter("@FGroupID", FGroupID);
            DataTable tb = DB.DAtable(sql, pFGroupID);
            List<PermissFunc> lst = new List<PermissFunc>();
            foreach(DataRow r in tb.Rows)
            {
                PermissFunc p = new PermissFunc();
                p.PermissFuncID = (int)r[0];
                p.FunctionName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                p.FunctionCode = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                p.PFGroupID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(p);
            }
            this.DB.CloseConnection();
            return lst;
        }
        
    }
}
