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
    public class Post_Category_relationshipsBLL
    {
        DataServices DB = new DataServices();
        public List<Post_Category_relationships> getCategoryWithPostId(int postid)
        {
            string sql = "select * from Post_Category_relationships where PostID=@postid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ppostid = new SqlParameter("postid", postid);
            DataTable tb = DB.DAtable(sql, ppostid);
            List<Post_Category_relationships> lst = new List<Post_Category_relationships>();
            foreach (DataRow r in tb.Rows)
            {
                Post_Category_relationships pr = new Post_Category_relationships();
                pr.PostID = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
                pr.CategoryID = (string.IsNullOrEmpty(r[1].ToString())) ? 0 : (int)r[1];
                lst.Add(pr);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean New_Post_Category_relationships(int postID, int CategoryID)
        {
            string sql = "New_Post_Category_relationships @postID,@CategoryID";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ppostid = new SqlParameter("postID", postID);
            SqlParameter pCategoryID = new SqlParameter("CategoryID", CategoryID);
            this.DB.Updatedata(sql, ppostid, pCategoryID);
            this.DB.CloseConnection();
            return true;
        }
        //=========================================================================
        //Delete With PostID
        public Boolean DeleteWithPostId(int postId)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Post_Category_relationships where PostID=@postId";
            SqlParameter ppostId = new SqlParameter("@postId", postId);
            this.DB.Updatedata(sql, ppostId);
            this.DB.CloseConnection();
            return true;
        }
        //Delete With CategoryID
        public Boolean DeleteWithCategoryID(int CategoryID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from Post_Category_relationships where CategoryID=@CategoryID";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            this.DB.Updatedata(sql, pCategoryID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
