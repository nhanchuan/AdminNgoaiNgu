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
    public class ProfileProcessTypeBLL
    {
        DataServices dt = new DataServices();
        public List<ProfileProcessType> getList()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from ProfileProcessType";
            DataTable tb = dt.DAtable(sql);
            List<ProfileProcessType> lst = new List<ProfileProcessType>();
            foreach (DataRow r in tb.Rows)
            {
                ProfileProcessType pt = new ProfileProcessType();
                pt.ProcessID = (int)r["ProcessID"];
                pt.ProcessCode = (string.IsNullOrEmpty(r["ProcessCode"].ToString())) ? "" : (string)r["ProcessCode"];
                pt.ProcessName= (string.IsNullOrEmpty(r["ProcessName"].ToString())) ? "" : (string)r["ProcessName"];
                lst.Add(pt);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //New
        public Boolean NewProfileProcessType(string ProcessCode, string ProcessName)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into  ProfileProcessType(ProcessCode,ProcessName) values (@ProcessCode,@ProcessName)";
            SqlParameter pProcessCode = (ProcessCode == "") ? new SqlParameter("@ProcessCode", DBNull.Value) : new SqlParameter("@ProcessCode", ProcessCode);
            SqlParameter pProcessName = (ProcessName == "") ? new SqlParameter("@ProcessName", DBNull.Value) : new SqlParameter("@ProcessName", ProcessName);
            this.dt.Updatedata(sql, pProcessCode, pProcessName);
            this.dt.CloseConnection();
            return true;
        }
        //Delete 
        public Boolean DeleteProfileProcessType(int ProcessID)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "delete from ProfileProcessType where ProcessID=@ProcessID";
            SqlParameter pProcessID = new SqlParameter("@ProcessID", ProcessID);
            this.dt.Updatedata(sql, pProcessID);
            this.dt.CloseConnection();
            return true;
        }
    }
}
