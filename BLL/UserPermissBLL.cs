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
    public class UserPermissBLL
    {
        DataServices DB = new DataServices();
        public List<UserPermiss> lstPermissWithCode(int UserID, string FunctionCode)
        {
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec checkFuntion @UserID, @FunctionCode";
            SqlParameter pUserID = new SqlParameter("@UserID", UserID);
            SqlParameter pFunctionCode = new SqlParameter("@FunctionCode", FunctionCode);
            DataTable tb = DB.DAtable(sql, pUserID, pFunctionCode);
            List<UserPermiss> lst = new List<UserPermiss>();
            foreach(DataRow r in tb.Rows)
            {
                UserPermiss p = new UserPermiss();
                p.UserID = (int)r[0];
                p.PermissFuncID = (int)r[1];
                p.PermisstionNumber = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(p);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<UserPermiss> lstPermiss(int UserID, int PermissFuncID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from UserPermiss where UserID=@UserID and PermissFuncID=@PermissFuncID";
            SqlParameter pUserID = new SqlParameter("@UserID", UserID);
            SqlParameter pPermissFuncID = new SqlParameter("@PermissFuncID", PermissFuncID);
            DataTable tb = DB.DAtable(sql, pUserID, pPermissFuncID);
            List<UserPermiss> lst = new List<UserPermiss>();
            foreach (DataRow r in tb.Rows)
            {
                UserPermiss p = new UserPermiss();
                p.UserID = (int)r[0];
                p.PermissFuncID = (int)r[1];
                p.PermisstionNumber = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(p);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //New UserPermiss
        public Boolean NewUserPermiss(int UserID, int PermissFuncID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into UserPermiss(UserID,PermissFuncID) values(@UserID,@PermissFuncID)";
            SqlParameter pUserID = new SqlParameter("@UserID", UserID);
            SqlParameter pPermissFuncID = new SqlParameter("@PermissFuncID", PermissFuncID);
            this.DB.Updatedata(sql, pUserID, pPermissFuncID);
            this.DB.CloseConnection();
            return true;
        }
        //Delete With UserID
        public Boolean DeleteWithUserID(int UserID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from UserPermiss where UserID=@UserID";
            SqlParameter pUserID = new SqlParameter("@UserID", UserID);
            this.DB.Updatedata(sql, pUserID);
            this.DB.CloseConnection();
            return true;
        }
        //Get Userpermiss With UserID
        public DataTable getUserPermissWithUID(int UserID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec getUserPermissWithUID @UserID";
            SqlParameter pUserID = new SqlParameter("@UserID", UserID);
            DataTable tb = DB.DAtable(sql, pUserID);
            this.DB.CloseConnection();
            return tb;
        }
        //
        public Boolean setpermission(int UserID, int PermissFuncID, int PermisstionNumber)
        {
            string sql = "update UserPermiss set PermisstionNumber=@PermisstionNumber where UserID=@UserID and PermissFuncID=@PermissFuncID";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pUserID = new SqlParameter("@UserID", UserID);
            SqlParameter pPermissFuncID = new SqlParameter("@PermissFuncID", PermissFuncID);
            SqlParameter pPermisstionNumber = new SqlParameter("@PermisstionNumber", PermisstionNumber);
            this.DB.Updatedata(sql, pUserID, pPermissFuncID, pPermisstionNumber);
            this.DB.CloseConnection();
            return true;
        }
    }
}
