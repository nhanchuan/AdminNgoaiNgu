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
    public class CategoryBLL
    {
        DataServices DB = new DataServices();
        public List<Category> getAllCategory()
        {
            string sql = "select * from Category";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<Category> lst = new List<Category>();
            foreach(DataRow r in tb.Rows)
            {
                Category ct = new Category();
                ct.CategoryID = (int)r[0];
                ct.CategoryName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                ct.Descriptions = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                ct.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                ct.Parent = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                ct.CateogryImage = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                ct.ItemIndex = (string.IsNullOrEmpty(r["ItemIndex"].ToString())) ? 0 : (int)r["ItemIndex"];
                lst.Add(ct);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Category> getCategoryWithID(int CategoryID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Category where CategoryID=@CategoryID";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            DataTable tb = DB.DAtable(sql, pCategoryID);
            List<Category> lst = new List<Category>();
            foreach (DataRow r in tb.Rows)
            {
                Category ct = new Category();
                ct.CategoryID = (int)r[0];
                ct.CategoryName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                ct.Descriptions = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                ct.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                ct.Parent = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                ct.CateogryImage = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                ct.ItemIndex = (string.IsNullOrEmpty(r["ItemIndex"].ToString())) ? 0 : (int)r["ItemIndex"];
                lst.Add(ct);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Category> getCategoryWithIndex(int ItemIndex, int Parent)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Category where ItemIndex=@ItemIndex and Parent=@Parent";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pParent = new SqlParameter("@Parent", Parent);
            DataTable tb = DB.DAtable(sql, pItemIndex, pParent);
            List<Category> lst = new List<Category>();
            foreach (DataRow r in tb.Rows)
            {
                Category ct = new Category();
                ct.CategoryID = (int)r[0];
                ct.CategoryName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                ct.Descriptions = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                ct.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                ct.Parent = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                ct.CateogryImage = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                ct.ItemIndex = (string.IsNullOrEmpty(r["ItemIndex"].ToString())) ? 0 : (int)r["ItemIndex"];
                lst.Add(ct);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getTBCategoryWithParent(int Parent)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Category ct full outer join Images im on ct.CateogryImage=im.ImagesID where ct.CategoryID is not null and ct.Parent=@Parent order by ct.ItemIndex asc";
            SqlParameter pParent = new SqlParameter("@Parent", Parent);
            DataTable tb = DB.DAtable(sql, pParent);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable getTBAllCategory()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select ct.CategoryID, ct.CategoryName, case when ct.Parent is null then ct.CategoryName when ct.Parent is not null then (ct.CategoryName + N'  -  thuộc danh mục:  » '+ pct.CategoryName + N' « ') end as ParentNameCategory from Category ct full outer join Category pct on ct.Parent=pct.CategoryID where ct.CategoryID is not null";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable getTBCategoryForDL()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select CategoryID, (CategoryName +' ('+ CONVERT(varchar(5),[dbo].[CountPostInCategory](CategoryID))+')') as CTName  from Category";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        public List<Category> getCategorWithId(int ctId)
        {
            string sql = "select * from Category where CategoryID=@ctId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pctId = new SqlParameter("ctId", ctId);
            DataTable tb = DB.DAtable(sql, pctId);
            List<Category> lst = new List<Category>();
            foreach (DataRow r in tb.Rows)
            {
                Category ct = new Category();
                ct.CategoryID = (int)r[0];
                ct.CategoryName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                ct.Descriptions = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                ct.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                ct.Parent = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                ct.CateogryImage = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                ct.ItemIndex = (string.IsNullOrEmpty(r["ItemIndex"].ToString())) ? 0 : (int)r["ItemIndex"];
                lst.Add(ct);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetCategoryPageWise(int pageindex, int pagesize)
        {
            string sql = "Exec GetCategoryPageWise @pageindex,@pagesize";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ppageindex = new SqlParameter("pageindex", pageindex);
            SqlParameter ppagesize = new SqlParameter("pagesize", pagesize);
            DataTable tb = DB.DAtable(sql, ppageindex, ppagesize);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountRecordPostCategory()
        {
            int rc = 0;
            string sql = "select COUNT(*) from Category";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            rc = DB.GetValues(sql);
            this.DB.CloseConnection();
            return rc;
        }
        // ======GetCategorySearchPageWise===============================
        public DataTable GetCategorySearchPageWise(int pageindex, int pagesize, string keysearch)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetCategorySearchPageWise @pageindex,@pagesize,@keysearch";
            SqlParameter ppageindex = new SqlParameter("@pageindex", pageindex);
            SqlParameter ppagesize = new SqlParameter("@pagesize", pagesize);
            SqlParameter pkeysearch = new SqlParameter("@keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, ppageindex, ppagesize, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountSearchCategory(string keysearch)
        {
            int rc = 0;
            string sql = "select COUNT(*) from Category where CategoryName like '%'+@keysearch+'%'";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("@keysearch", keysearch);
            rc = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return rc;
        }

        // ======GetCategorySearchPageWise===============================
        public DataTable getCategoryWithParent(int parentId)
        {
            string sql = "select *,(Select COUNT(*) from Category where Parent=po.CategoryID)as childnodecount from Category po where Parent=@parentId order by po.ItemIndex asc";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pparentId = new SqlParameter("parentId", parentId);
            DataTable tb = DB.DAtable(sql, pparentId);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable getCategoryWithParentNull()
        {
            string sql = "select *,(Select COUNT(*) from Category where Parent=po.CategoryID)as childnodecount  from Category po where Parent is null";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Boolean QuickInserCategory(string name, string description)
        {
            string sql = "insert into Category(CategoryName,Descriptions) values (@name,@description)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pname = new SqlParameter("name", name);
            SqlParameter pdescription = new SqlParameter("description", description);
            this.DB.Updatedata(sql, pname, pdescription);
            this.DB.CloseConnection();
            return true;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Boolean newCategory(string name, string description, string permalink, int parent, int pcimage, int ItemIndex)
        {
            string sql = "insert into Category(CategoryName,Descriptions,Permalink,Parent,CateogryImage,ItemIndex) values (@name,@description,@permalink,@parent,@pcimage,@ItemIndex)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pname = new SqlParameter("@name", name);
            SqlParameter pdescription = new SqlParameter("@description", description);
            SqlParameter ppermalink = new SqlParameter("@permalink", permalink);
            SqlParameter pParent = (parent == 0) ? new SqlParameter("@parent", DBNull.Value) : new SqlParameter("parent", parent);
            SqlParameter ppcimage = (pcimage == 0) ? new SqlParameter("@pcimage", DBNull.Value) : new SqlParameter("pcimage", pcimage);
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            this.DB.Updatedata(sql, pname, pdescription, ppermalink, pParent, ppcimage, pItemIndex);
            this.DB.CloseConnection();
            return true;
        }
        //public Boolean newCategoryparentNull(string name, string description, string permalink, int pcimage)
        //{
        //    string sql = "insert into Category(CategoryName,Descriptions,Permalink,Parent,CateogryImage) values (@name,@description,@permalink,null,@pcimage)";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return false;
        //    }
        //    SqlParameter pname = new SqlParameter("name", name);
        //    SqlParameter pdescription = new SqlParameter("description", description);
        //    SqlParameter ppermalink = new SqlParameter("permalink", permalink);
        //    SqlParameter ppcimage = new SqlParameter("pcimage", pcimage);
        //    this.DB.Updatedata(sql, pname, pdescription, ppermalink, ppcimage);
        //    this.DB.CloseConnection();
        //    return true;
        //}
        //public Boolean newCategoryImgNull(string name, string description, string permalink, int parent)
        //{
        //    string sql = "insert into Category(CategoryName,Descriptions,Permalink,Parent,CateogryImage) values (@name,@description,@permalink,@parent,null)";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return false;
        //    }
        //    SqlParameter pname = new SqlParameter("name", name);
        //    SqlParameter pdescription = new SqlParameter("description", description);
        //    SqlParameter ppermalink = new SqlParameter("permalink", permalink);
        //    SqlParameter pParent = new SqlParameter("parent", parent);
        //    this.DB.Updatedata(sql, pname, pdescription, ppermalink, pParent);
        //    this.DB.CloseConnection();
        //    return true;
        //}
        //public Boolean newCategoryParentandImgNull(string name, string description, string permalink)
        //{
        //    string sql = "insert into Category(CategoryName,Descriptions,Permalink,Parent,CateogryImage) values (@name,@description,@permalink,null,null)";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return false;
        //    }
        //    SqlParameter pname = new SqlParameter("name", name);
        //    SqlParameter pdescription = new SqlParameter("description", description);
        //    SqlParameter ppermalink = new SqlParameter("permalink", permalink);
        //    this.DB.Updatedata(sql, pname, pdescription, ppermalink);
        //    this.DB.CloseConnection();
        //    return true;
        //}
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Boolean UpdatePostCategory(int ctID, string ctName, string descriptions, string permalink, int parent, int pcimage)
        {
            string sql = "Exec UpdatePostCategory @ctID,@ctName,@descriptions,@permalink,@parent,@pcimage";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pctID = new SqlParameter("ctID", ctID);
            SqlParameter pctName = new SqlParameter("ctName", ctName);
            SqlParameter pdescriptions = new SqlParameter("descriptions", descriptions);
            SqlParameter ppermalink = new SqlParameter("permalink", permalink);
            SqlParameter pparent = new SqlParameter("parent", parent);
            SqlParameter ppcimage = new SqlParameter("pcimage", pcimage);
            this.DB.Updatedata(sql, pctID, pctName, pdescriptions, ppermalink, pparent, ppcimage);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdatePostCategoryparentNull(int ctID, string ctName, string descriptions, string permalink, int pcimage)
        {
            string sql = "Exec UpdatePostCategory @ctID,@ctName,@descriptions,@permalink,null,@pcimage";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pctID = new SqlParameter("ctID", ctID);
            SqlParameter pctName = new SqlParameter("ctName", ctName);
            SqlParameter pdescriptions = new SqlParameter("descriptions", descriptions);
            SqlParameter ppermalink = new SqlParameter("permalink", permalink);
            SqlParameter ppcimage = new SqlParameter("pcimage", pcimage);
            this.DB.Updatedata(sql, pctID, pctName, pdescriptions, ppermalink, ppcimage);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdatePostCategoryImgNull(int ctID, string ctName, string descriptions, string permalink, int parent)
        {
            string sql = "Exec UpdatePostCategory @ctID,@ctName,@descriptions,@permalink,@parent,null";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pctID = new SqlParameter("ctID", ctID);
            SqlParameter pctName = new SqlParameter("ctName", ctName);
            SqlParameter pdescriptions = new SqlParameter("descriptions", descriptions);
            SqlParameter ppermalink = new SqlParameter("permalink", permalink);
            SqlParameter pparent = new SqlParameter("parent", parent);
            this.DB.Updatedata(sql, pctID, pctName, pdescriptions, ppermalink, pparent);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdatePostCategoryParentAndImgNull(int ctID, string ctName, string descriptions, string permalink)
        {
            string sql = "Exec UpdatePostCategory @ctID,@ctName,@descriptions,@permalink,null,null";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pctID = new SqlParameter("ctID", ctID);
            SqlParameter pctName = new SqlParameter("ctName", ctName);
            SqlParameter pdescriptions = new SqlParameter("descriptions", descriptions);
            SqlParameter ppermalink = new SqlParameter("permalink", permalink);
            this.DB.Updatedata(sql, pctID, pctName, pdescriptions, ppermalink);
            this.DB.CloseConnection();
            return true;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<Category> getSubtractCategory(int ctID)
        {
            string sql = "Exec getSubtractCategory @ctID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pctID = new SqlParameter("ctID", ctID);
            DataTable tb = DB.DAtable(sql, pctID);
            List<Category> lst = new List<Category>();
            foreach (DataRow r in tb.Rows)
            {
                Category po = new Category();
                po.CategoryID = (int)r[0];
                po.CategoryName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                po.Descriptions = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                po.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                po.Parent = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                po.CateogryImage = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lst.Add(po);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getTBSubtractCategory(int ctID)
        {
            string sql = "Exec getSubtractCategory @ctID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pctID = new SqlParameter("ctID", ctID);
            DataTable tb = DB.DAtable(sql, pctID);
            this.DB.CloseConnection();
            return tb;
        }
        //Delete from Category
        public Boolean DeleteCategory(int CategoryID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Category where CategoryID=@CategoryID";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            this.DB.Updatedata(sql, pCategoryID);
            this.DB.CloseConnection();
            return true;
        }
        // Sort
        public int MaxItemindexWithParent(int Parent)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from Category where Parent=@Parent";
            SqlParameter pParent = new SqlParameter("@Parent", Parent);
            RC = DB.GetValues(sql, pParent);
            this.DB.CloseConnection();
            return RC;
        }
        public int MaxItemindexWithParentNull()
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from Category where Parent is null";
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        public int MaxItemindexLK(int ItemIndex, int Parent)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select max(ItemIndex) from Category where Parent=@Parent and ItemIndex<@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pParent = new SqlParameter("@Parent", Parent);
            RC = DB.GetValues(sql, pItemIndex, pParent);
            this.DB.CloseConnection();
            return RC;
        }
        public int MinItemindexLK(int ItemIndex, int Parent)
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select min(ItemIndex) from Category where Parent=@Parent and ItemIndex>@ItemIndex";
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            SqlParameter pParent = new SqlParameter("@Parent", Parent);
            RC = DB.GetValues(sql, pItemIndex, pParent);
            this.DB.CloseConnection();
            return RC;
        }
        //Update Index Item
        public Boolean UpdateIndexItem(int ItemIndex, int CategoryID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update Category set ItemIndex=@ItemIndex where CategoryID=@CategoryID";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            SqlParameter pItemIndex = new SqlParameter("@ItemIndex", ItemIndex);
            this.DB.Updatedata(sql, pCategoryID, pItemIndex);
            this.DB.CloseConnection();
            return true;
        }
    }
}
