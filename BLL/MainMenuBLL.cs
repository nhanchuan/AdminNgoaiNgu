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
    public class MainMenuBLL
    {
        DataServices DB = new DataServices();
        public List<MainMenu> ListMenuItems()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from MainMenu order by ItemIndex asc";
            DataTable tb = DB.DAtable(sql);
            List<MainMenu> lst = new List<MainMenu>();
            foreach(DataRow r in tb.Rows)
            {
                MainMenu menu = new MainMenu();
                menu.MenuID = (int)r[0];
                menu.ItemName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                menu.Permalink = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                menu.ItemIndex = (int)r[3];
                lst.Add(menu);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<MainMenu> ListMenuItemsWithMenuID(int MenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from MainMenu where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            DataTable tb = DB.DAtable(sql, pMenuID);
            List<MainMenu> lst = new List<MainMenu>();
            foreach (DataRow r in tb.Rows)
            {
                MainMenu menu = new MainMenu();
                menu.MenuID = (int)r[0];
                menu.ItemName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                menu.Permalink = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                menu.ItemIndex = (int)r[3];
                lst.Add(menu);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<MainMenu> ListMenuItemsWithIndex(int ItemIndex)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from MainMenu where ItemIndex=@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            DataTable tb = DB.DAtable(sql, pItemIndex);
            List<MainMenu> lst = new List<MainMenu>();
            foreach (DataRow r in tb.Rows)
            {
                MainMenu menu = new MainMenu();
                menu.MenuID = (int)r[0];
                menu.ItemName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                menu.Permalink = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                menu.ItemIndex = (int)r[3];
                lst.Add(menu);
            }
            this.DB.CloseConnection();
            return lst;
        }
        //Create
        public Boolean NewMainMenu(string ItemName, string Permalink, int ItemIndex)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into MainMenu(ItemName,Permalink,ItemIndex) values(@ItemName,@Permalink,@ItemIndex)";
            SqlParameter pItemName = (ItemName == "") ? new SqlParameter("@ItemName", DBNull.Value) : new SqlParameter("@ItemName", ItemName);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            SqlParameter pItemIndex = (ItemIndex == 0) ? new SqlParameter("@ItemIndex", DBNull.Value) : new SqlParameter("@ItemIndex", ItemIndex);
            this.DB.Updatedata(sql, pItemName, pPermalink, pItemIndex);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdateMainMenu(int MenuID, string ItemName, string Permalink)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update MainMenu set ItemName=@ItemName, Permalink=@Permalink where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            SqlParameter pItemName = (ItemName == "") ? new SqlParameter("@ItemName", DBNull.Value) : new SqlParameter("@ItemName", ItemName);
            SqlParameter pPermalink = (Permalink == "") ? new SqlParameter("@Permalink", DBNull.Value) : new SqlParameter("@Permalink", Permalink);
            this.DB.Updatedata(sql, pMenuID, pItemName, pPermalink);
            this.DB.CloseConnection();
            return true;
        }
        public int CounkItem()
        {
            int RC = 0;
            string sql = "select COUNT(*) from MainMenu";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        public int MaxItemindex()
        {
            int RC = 0;
            string sql = "select max(ItemIndex) from MainMenu";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        public int MinItemindex()
        {
            int RC = 0;
            string sql = "select min(ItemIndex) from MainMenu";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        public int MaxItemindexLK(int ItemIndex)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from MainMenu where ItemIndex<@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            RC = DB.GetValues(sql, pItemIndex);
            this.DB.CloseConnection();
            return RC;
        }
        public int MinItemindexLK(int ItemIndex)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select min(ItemIndex) from MainMenu where ItemIndex>@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            RC = DB.GetValues(sql, pItemIndex);
            this.DB.CloseConnection();
            return RC;
        }
        //============UPDATRE ITEM INDEX======================================================================================================================================================================
        public Boolean UpdateItemIndex(int ItemIndex, int MenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update MainMenu set ItemIndex=@ItemIndex where MenuID=@MenuID";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            this.DB.Updatedata(sql, pItemIndex, pMenuID);
            this.DB.CloseConnection();
            return true;
        }
        //DELETE MANIN MENU
        public Boolean DeleteMainMenuyMenuID(int MenuID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from MainMenu where MenuID=@MenuID";
            SqlParameter pMenuID = new SqlParameter("@MenuID", MenuID);
            this.DB.Updatedata(sql, pMenuID);
            this.DB.CloseConnection();
            return true;
        }

    }
}
