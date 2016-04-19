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
    public class UserAccountsBLL
    {
        DataServices DB = new DataServices();
        
        public List<UserAccounts> getAllUseraccount()
        {
            string sql = "select * from UserAccounts";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<UserAccounts> lst = new List<UserAccounts>();
            foreach (DataRow r in tb.Rows)
            {
                UserAccounts us = new UserAccounts();
                us.UserID = (int)r[0];
                us.UserName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                us.Email = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                us.Passwords = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(us);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<UserAccounts> getUseraccountUID(int UserID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from UserAccounts where UserID=@UserID";
            SqlParameter pUserID = new SqlParameter("@UserID", UserID);
            DataTable tb = DB.DAtable(sql, pUserID);
            List<UserAccounts> lst = new List<UserAccounts>();
            foreach (DataRow r in tb.Rows)
            {
                UserAccounts us = new UserAccounts();
                us.UserID = (int)r[0];
                us.UserName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                us.Email = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                us.Passwords = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(us);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<UserAccounts> getAllUserAccountUsername(string UserName)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from UserAccounts where UserName=@UserName";
            SqlParameter pUserName = new SqlParameter("@UserName", UserName);
            DataTable tb = DB.DAtable(sql, pUserName);
            List<UserAccounts> lst = new List<UserAccounts>();
            foreach (DataRow r in tb.Rows)
            {
                UserAccounts us = new UserAccounts();
                us.UserID = (int)r[0];
                us.UserName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                us.Email = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                us.Passwords = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(us);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<UserAccounts> getAllUserAccountEmail(string Email)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from UserAccounts where Email=@Email";
            SqlParameter pEmail = new SqlParameter("@Email", Email);
            DataTable tb = DB.DAtable(sql, pEmail);
            List<UserAccounts> lst = new List<UserAccounts>();
            foreach (DataRow r in tb.Rows)
            {
                UserAccounts us = new UserAccounts();
                us.UserID = (int)r[0];
                us.UserName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                us.Email = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                us.Passwords = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(us);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<UserAccounts> getLoginUser(string key, string passwords)
        {
            string sql = "Exec login_formAdmin @key,@passwords";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pkey = new SqlParameter("key", key);
            SqlParameter ppasswords = new SqlParameter("passwords", passwords);
            DataTable tb = DB.DAtable(sql, pkey, ppasswords);
            List<UserAccounts> lst = new List<UserAccounts>();
            foreach(DataRow r in tb.Rows)
            {
                UserAccounts us = new UserAccounts();
                us.UserID = (int)r[0];
                us.UserName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                us.Email = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                us.Passwords = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                lst.Add(us);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public int GetUIDWithName(string UserName)
        {
            int uid = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select * from UserAccounts where UserName=@UserName";
            SqlParameter pUserName = new SqlParameter("@UserName", UserName);
            DataTable tb = DB.DAtable(sql, pUserName);
            foreach (DataRow r in tb.Rows)
            {
                uid = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
            }
            this.DB.CloseConnection();
            return uid;
        }
        public string GetEmailWithID(int userId)
        {
            string email = "";
            string sql = "select Email from UserAccounts where UserID=@userId";
            if (!this.DB.OpenConnection())
            {
                return "";
            }
            SqlParameter puid = new SqlParameter("userId", userId);
            DataTable tb = DB.DAtable(sql, puid);
            foreach(DataRow r in tb.Rows)
            {
                email = (string.IsNullOrEmpty(r[0].ToString())) ? "" : (string)r[0];
            }
            this.DB.CloseConnection();
            return email;
        }
        public string GetPasswordWithID(int userId)
        {
            string Passwords = "";
            string sql = "select Passwords from UserAccounts where UserID=@userId";
            if (!this.DB.OpenConnection())
            {
                return "";
            }
            SqlParameter puid = new SqlParameter("userId", userId);
            DataTable tb = DB.DAtable(sql, puid);
            foreach (DataRow r in tb.Rows)
            {
                Passwords = (string.IsNullOrEmpty(r[0].ToString())) ? "" : (string)r[0];
            }
            this.DB.CloseConnection();
            return Passwords;
        }
        public Boolean UpdateEmail(int userId, string email)
        {
            string sql = "Update UserAccounts set Email=@email where UserID=@userId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter puid = new SqlParameter("userId", userId);
            SqlParameter pemail = new SqlParameter("email", email);
            this.DB.Updatedata(sql, puid, pemail);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpadatePassword(int userId, string password)
        {
            string sql = "Update UserAccounts set Passwords=@password where UserID=@userId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter puserId = new SqlParameter("userId", userId);
            SqlParameter ppassword = new SqlParameter("password", password);
            this.DB.Updatedata(sql, puserId, ppassword);
            this.DB.CloseConnection();
            return true;
        }
        //New Account
        public Boolean NewAccount(string UserName, string Email, string Passwords)
        {
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into UserAccounts(UserName,Email,Passwords) values(@UserName,@Email,@Passwords)";
            SqlParameter pUserName = new SqlParameter("@UserName", UserName);
            SqlParameter pEmail = new SqlParameter("@Email", Email);
            SqlParameter pPasswords = new SqlParameter("@Passwords", Passwords);
            this.DB.Updatedata(sql, pUserName, pEmail, pPasswords);
            this.DB.CloseConnection();
            return true;
        }
        //List All User
        public DataTable kus_listAllUser(int PageIndex, int PageSize)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_listAllUser @PageIndex,@PageSize";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountListAllUser()
        {
            int sum = 0;
            if(!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from UserAccounts";
            sum = DB.GetValues(sql);
            this.DB.CloseConnection();
            return sum;
        }
    }
}
