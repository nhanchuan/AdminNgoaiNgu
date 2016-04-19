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
    public class AuthenticationGroupsBLL
    {
        DataServices DB = new DataServices();
        public List<AuthenticationGroups> getListpIDanddepID(int PermissFuncID, int DepartmentsID)
        {
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from AuthenticationGroups where PermissFuncID=@PermissFuncID and DepartmentsID=@DepartmentsID";
            SqlParameter pPermissFuncID = new SqlParameter("@PermissFuncID", PermissFuncID);
            SqlParameter pDepartmentsID = new SqlParameter("@DepartmentsID", DepartmentsID);
            DataTable tb = DB.DAtable(sql, pPermissFuncID, pDepartmentsID);
            List<AuthenticationGroups> lst = new List<AuthenticationGroups>();
            foreach(DataRow r in tb.Rows)
            {
                AuthenticationGroups au = new AuthenticationGroups();
                au.AuthenticationGroupsID = (int)r[0];
                au.DepartmentsID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                au.PermissFuncID= (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(au);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<AuthenticationGroups> getListWithdpID(int DepartmentsID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from AuthenticationGroups where DepartmentsID=@DepartmentsID";
            SqlParameter pDepartmentsID = new SqlParameter("@DepartmentsID", DepartmentsID);
            DataTable tb = DB.DAtable(sql, pDepartmentsID);
            List<AuthenticationGroups> lst = new List<AuthenticationGroups>();
            foreach (DataRow r in tb.Rows)
            {
                AuthenticationGroups au = new AuthenticationGroups();
                au.AuthenticationGroupsID = (int)r[0];
                au.DepartmentsID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                au.PermissFuncID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(au);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //New AuthenticationGroups
        public Boolean NewAuthenticationGroups(int DepartmentsID, int PermissFuncID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into AuthenticationGroups(DepartmentsID,PermissFuncID) values(@DepartmentsID,@PermissFuncID)";
            SqlParameter pDepartmentsID = new SqlParameter("@DepartmentsID", DepartmentsID);
            SqlParameter pPermissFuncID = new SqlParameter("@PermissFuncID", PermissFuncID);
            this.DB.Updatedata(sql, pDepartmentsID, pPermissFuncID);
            this.DB.CloseConnection();
            return true;
        }
        //Delete With DepartmentsID
        public Boolean DeleteWithDepartmentsID(int DepartmentsID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from AuthenticationGroups where DepartmentsID=@DepartmentsID";
            SqlParameter pDepartmentsID = new SqlParameter("@DepartmentsID", DepartmentsID);
            this.DB.Updatedata(sql, pDepartmentsID);
            this.DB.CloseConnection();
            return true;
        }
        
    }
}
