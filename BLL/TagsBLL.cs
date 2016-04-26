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
    public class TagsBLL
    {
        DataServices DB = new DataServices();
        public List<Tags> getAllTagsTagsNameASC()
        {
            string sql = "select * from Tags order by TagsName ASC";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<Tags> lst = new List<Tags>();
            foreach (DataRow r in tb.Rows)
            {
                Tags t = new Tags();
                t.TagsID = (int)r[0];
                t.TagsName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                t.Descritption = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                t.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                t.DateOfCreate = (DateTime)r[4];
                lst.Add(t);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Tags> getTagsWithID(int tagsId)
        {
            string sql = "select * from Tags where TagsID=@tagsId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ptagsId = new SqlParameter("tagsId", tagsId);
            DataTable tb = DB.DAtable(sql, ptagsId);
            List<Tags> lst = new List<Tags>();
            foreach (DataRow r in tb.Rows)
            {
                Tags t = new Tags();
                t.TagsID = (int)r[0];
                t.TagsName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                t.Descritption = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                t.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                t.DateOfCreate = (DateTime)r[4];
                lst.Add(t);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Tags> getTagsWithName(string name)
        {
            string sql = "select * from Tags where TagsName=@name";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ptagname = new SqlParameter("name", name);
            DataTable tb = DB.DAtable(sql, ptagname);
            List<Tags> lst = new List<Tags>();
            foreach (DataRow r in tb.Rows)
            {
                Tags t = new Tags();
                t.TagsID = (int)r[0];
                t.TagsName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                t.Descritption = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                t.Permalink = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                t.DateOfCreate = (DateTime)r[4];
                lst.Add(t);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public int CountRecordTagsTB()
        {
            int rc = 0;
            string sql = "select COUNT(*) from Tags";
            if (!this.DB.OpenConnection())
            {
                rc = 0;
            }
            rc = DB.GetValues(sql);
            this.DB.CloseConnection();
            return rc;
        }
        public DataTable GetTagsPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec GetTagsPageWise @PageIndex,@PageSize";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize);
            this.DB.CloseConnection();
            return tb;
        }
        public Boolean newTags(string tagsname, string description, string permalink)
        {
            string sql = "insert into Tags(TagsName,Descritption,Permalink) values(@tagsname,@description,@permalink)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptagsname = new SqlParameter("tagsname", tagsname);
            SqlParameter pdescription = new SqlParameter("description", description);
            SqlParameter ppermalink = new SqlParameter("permalink", permalink);
            this.DB.Updatedata(sql, ptagsname, pdescription, ppermalink);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean newTagsName(string tagsname)
        {
            string sql = "insert into Tags(TagsName) values(@tagsname)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptagsname = new SqlParameter("tagsname", tagsname);
            this.DB.Updatedata(sql, ptagsname);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdateTags(int tagsid, string tagsname, string description, string permalink)
        {
            string sql = "Exec Update_Tags @tagsid,@tagsname,@description,@permalink";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptagsid = new SqlParameter("tagsid", tagsid);
            SqlParameter ptagsname = new SqlParameter("tagsname", tagsname);
            SqlParameter pdescription = new SqlParameter("description", description);
            SqlParameter ppermalink = new SqlParameter("permalink", permalink);
            this.DB.Updatedata(sql, ptagsid, ptagsname, pdescription, ppermalink);
            this.DB.CloseConnection();
            return true;
        }
        //Delete Tag
        public Boolean DeleteTagID(int TagsID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Tags where TagsID=@TagsID";
            SqlParameter pTagsID = new SqlParameter("@TagsID", TagsID);
            this.DB.Updatedata(sql, pTagsID);
            this.DB.CloseConnection();
            return true;
        }
        
    }
}
