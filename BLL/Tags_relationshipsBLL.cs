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
    public class Tags_relationshipsBLL
    {
        DataServices DB = new DataServices();
        public List<Tags_relationships> getTagsWithPostID(int postID)
        {
            string sql = "select * from Tags_relationships where PostID=@postID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ppostID = new SqlParameter("postID", postID);
            DataTable tb = DB.DAtable(sql, ppostID);
            List<Tags_relationships> lst = new List<Tags_relationships>();
            foreach (DataRow r in tb.Rows)
            {
                Tags_relationships tr = new Tags_relationships();
                tr.PostID = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
                tr.TagsID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                lst.Add(tr);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean New_Tags_relationships(int psotid, int tagsId)
        {
            string sql = "Exec New_Tags_relationships @psotid,@tagsId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ppsotid = new SqlParameter("psotid", psotid);
            SqlParameter ptagsId = new SqlParameter("tagsId", tagsId);
            this.DB.Updatedata(sql, ppsotid, ptagsId);
            this.DB.CloseConnection();
            return true;
        }
        //=====================================================================================
        public Boolean DeleteWithPostId(int postId)
        {
            string sql = "delete from Tags_relationships where PostID=@postId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ppostId = new SqlParameter("postId", postId);
            this.DB.Updatedata(sql, ppostId);
            this.DB.CloseConnection();
            return true;
        }
        //Detele With TagID
        public Boolean DeleteWithTagsID(int TagsID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Tags_relationships where TagsID=@TagsID";
            SqlParameter pTagsID = new SqlParameter("@TagsID", TagsID);
            this.DB.Updatedata(sql, pTagsID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
