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
    public class Menu_CategoryBLL
    {
        DataServices DB = new DataServices();
        //Get Table ListSubMenuItem
        public DataTable ListSubMenuItem(int MenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec ListSubMenuItem @MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            DataTable tb=DB.DAtable(sql, pMenuID);
            this.DB.CloseConnection();
            return tb;
        }
        public List<Menu_Category> ListItemWithCID(int CMenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Menu_Category where CMenuID=@CMenuID";
            SqlParameter pCMenuIDD = new SqlParameter("@CMenuID", CMenuID);
            DataTable tb = DB.DAtable(sql, pCMenuIDD);
            List<Menu_Category> lst = new List<Menu_Category>();
            foreach (DataRow r in tb.Rows)
            {
                Menu_Category mc = new Menu_Category();
                mc.CMenuID = (int)r[0];
                mc.MenuID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                mc.CategoryID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                mc.ItemIndex = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(mc);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Menu_Category> ListItemWithIndex(int ItemIndex, int MenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Menu_Category where ItemIndex=@ItemIndex and MenuID=@MenuID";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            DataTable tb = DB.DAtable(sql, pItemIndex, pMenuID);
            List<Menu_Category> lst = new List<Menu_Category>();
            foreach (DataRow r in tb.Rows)
            {
                Menu_Category mc = new Menu_Category();
                mc.CMenuID = (int)r[0];
                mc.MenuID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                mc.CategoryID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                mc.ItemIndex = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(mc);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Menu_Category> ListItemWithMenuAndCT(int MenuID, int CategoryID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Menu_Category where MenuID=@MenuID and CategoryID=@CategoryID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            DataTable tb = DB.DAtable(sql, pMenuID, pCategoryID);
            List<Menu_Category> lst = new List<Menu_Category>();
            foreach(DataRow r in tb.Rows)
            {
                Menu_Category mc = new Menu_Category();
                mc.CMenuID = (int)r[0];
                mc.MenuID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                mc.CategoryID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                mc.ItemIndex = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(mc);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //Add New Menu Category Item
        public Boolean AddNewMenu_Category(int MenuID,int CategoryID, int ItemIndex)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into Menu_Category(MenuID,CategoryID,ItemIndex) values(@MenuID,@CategoryID,@ItemIndex)";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            this.DB.Updatedata(sql, pMenuID, pCategoryID, pItemIndex);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean DeleteMenu_CategoryMenuID(int MenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Menu_Category where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            this.DB.Updatedata(sql, pMenuID);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean DeleteMenu_CategoryCMenuID(int CMenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Menu_Category where CMenuID=@CMenuID";
            SqlParameter pCMenuID = new SqlParameter("@CMenuID", CMenuID);
            this.DB.Updatedata(sql, pCMenuID);
            this.DB.CloseConnection();
            return true;
        }
        //Update Index Item
        public Boolean UpdateIndexItem(int ItemIndex, int CMenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update Menu_Category set ItemIndex=@ItemIndex where CMenuID=@CMenuID";
            SqlParameter pCMenuID = new SqlParameter("@CMenuID", CMenuID);
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            this.DB.Updatedata(sql, pCMenuID, pItemIndex);
            this.DB.CloseConnection();
            return true;
        }

        public int CounkItemWithMenuID(int MenuID)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from Menu_Category where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            RC = DB.GetValues(sql, pMenuID);
            this.DB.CloseConnection();
            return RC;
        }
        //====================
        public int MaxItemindexWithMenuID(int MenuID)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from Menu_Category where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            RC = DB.GetValues(sql, pMenuID);
            this.DB.CloseConnection();
            return RC;
        }
        public int MaxItemindexLK(int ItemIndex, int MenuID)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from Menu_Category where MenuID=@MenuID and ItemIndex<@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            RC = DB.GetValues(sql, pItemIndex, pMenuID);
            this.DB.CloseConnection();
            return RC;
        }
        public int MinItemindexLK(int ItemIndex, int MenuID)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select min(ItemIndex) from Menu_Category where MenuID=@MenuID and ItemIndex>@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            RC = DB.GetValues(sql, pItemIndex, pMenuID);
            this.DB.CloseConnection();
            return RC;
        }
    }
}
