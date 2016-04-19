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
    public class PostBLL
    {
        DataServices DB = new DataServices();
        public string defaultdate = "12/12/1900";
        public List<POST> getallPostWithPID(int postid)
        {
            string sql = "select * from POST where PostID=@postid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pId = new SqlParameter("postid", postid);
            DataTable tb = DB.DAtable(sql, pId);
            List<POST> lst = new List<POST>();

            foreach (DataRow r in tb.Rows)
            {
                POST p = new POST();
                p.PostID = (int)r[0];
                p.PostTitle = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                p.MetaKeywords= (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                p.MetaDescription= (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                p.PostContentVN = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                p.PostContentEN= (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                p.PostModified = (string.IsNullOrEmpty(r[6].ToString())) ? Convert.ToDateTime(defaultdate) : (DateTime)r[6];
                p.DateOfCreate = (DateTime)r[7];
                p.PostAuthor = (string.IsNullOrEmpty(r[8].ToString())) ? 0 : (int)r[8];
                p.PostStatus = (string.IsNullOrEmpty(r[9].ToString())) ? 0 : (int)r[9];
                p.ViewCount = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                p.PostImage = (string.IsNullOrEmpty(r[11].ToString())) ? 0 : (int)r[11];
                p.PostCode = (string.IsNullOrEmpty(r[12].ToString())) ? "" : (string)r[12];
                lst.Add(p);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public int PostIdWithPostCode(string postcode)
        {
            int code = 0;
            string sql = "select PostID from POST where PostCode=@postcode";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter ppostcode = new SqlParameter("postcode", postcode);
            DataTable tb = DB.DAtable(sql, ppostcode);
            foreach (DataRow r in tb.Rows)
            {
                code = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
            }
            this.DB.CloseConnection();
            return code;
        }
        //===================================================
        public int CountPost() //COUNT ROW IN TABLE Post
        {
            int RC = 0;
            string sql = "select COUNT(*) from POST";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        public DataTable GetAllPostPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec GetAllPostPageWise @PageIndex,@PageSize";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = DB.DAtable(sql, paramPageIndex, paramPageSize);
            this.DB.CloseConnection();
            return tb;
        }
        //===================================================
        //===================================================
        public int CountPostCategory(int CategoryID) //COUNT ROW IN TABLE Post
        {
            int RC = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from Post_Category_relationships where CategoryID=@CategoryID";
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            RC = DB.GetValues(sql, pCategoryID);
            this.DB.CloseConnection();
            return RC;
        }
        public DataTable GetPostWithCategoryPageWise(int PageIndex, int PageSize, int CategoryID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetPostWithCategoryPageWise @PageIndex,@PageSize,@CategoryID";
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pCategoryID = new SqlParameter("@CategoryID", CategoryID);
            DataTable tb = DB.DAtable(sql, paramPageIndex, paramPageSize, pCategoryID);
            this.DB.CloseConnection();
            return tb;
        }
        //===================================================
        //======================================================================================================
        public Boolean NewPost(string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, int author, int status, int img, string postcode)
        {
            string sql = "Exec NewPost @title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@author,@status,@img,@postcode";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            SqlParameter pimg = new SqlParameter("img", img);
            SqlParameter ppostcode = new SqlParameter("postcode", postcode);
            this.DB.Updatedata(sql, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pauthor, pstatus, pimg, ppostcode);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean NewPostWithoutImg(string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, int author, int status, string postcode)
        {
            string sql = "Exec NewPostWithoutImg @title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@author,@status,@postcode";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            SqlParameter ppostcode = new SqlParameter("postcode", postcode);
            this.DB.Updatedata(sql, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pauthor, pstatus, ppostcode);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean NewPostWithPostModified(string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, DateTime modified, int author, int status, int img, string postcode)
        {
            string sql = "Exec NewPostWithPostModified @title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@modified,@author,@status,@img,@postcode";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pmodified = new SqlParameter("modified", modified);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            SqlParameter pimg = new SqlParameter("img", img);
            SqlParameter ppostcode = new SqlParameter("postcode", postcode);
            this.DB.Updatedata(sql, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pmodified, pauthor, pstatus, pimg, ppostcode);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean NewPostWithPostModifiedWithoutImg(string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, DateTime modified, int author, int status, string postcode)
        {
            string sql = "Exec NewPostWithPostModifiedWithoutImg @title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@modified,@author,@status,@postcode";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pmodified = new SqlParameter("modified", modified);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            SqlParameter ppostcode = new SqlParameter("postcode", postcode);
            this.DB.Updatedata(sql, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pmodified, pauthor, pstatus, ppostcode);
            this.DB.CloseConnection();
            return true;
        }

        //=======================================================================================================

        public Boolean UpdatePost(int postId, string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, int author, int status, int img)
        {
            string sql = "Exec UpdatePost @postId,@title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@author,@status,@img";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ppostId = new SqlParameter("postId", postId);
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            SqlParameter pimg = new SqlParameter("img", img);
            this.DB.Updatedata(sql, ppostId, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pauthor, pstatus, pimg);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdatePostWithoutImg(int postId, string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, int author, int status)
        {
            string sql = "Exec UpdatePostWithoutImg @postId,@title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@author,@status";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ppostId = new SqlParameter("postId", postId);
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            this.DB.Updatedata(sql, ppostId, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pauthor, pstatus);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdatePostWithPostModified(int postId, string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, DateTime modified, int author, int status, int img)
        {
            string sql = "Exec UpdatePostWithPostModified @postId,@title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@modified,@author,@status,@img";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ppostId = new SqlParameter("postId", postId);
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pmodified = new SqlParameter("modified", modified);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            SqlParameter pimg = new SqlParameter("img", img);
            this.DB.Updatedata(sql, ppostId, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pmodified, pauthor, pstatus, pimg);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdatePostWithPostModifiedWithoutImg(int postId, string title, string metaKeywords, string metaDescription, string contentVn, string contentEn, DateTime modified, int author, int status)
        {
            string sql = "Exec NewPostWithPostModifiedWithoutImg @title,@metaKeywords,@metaDescription,@contentVn,@contentEn,@modified,@author,@status";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ppostId = new SqlParameter("postId", postId);
            SqlParameter ptitle = new SqlParameter("title", title);
            SqlParameter pmetaKeywords = new SqlParameter("metaKeywords", metaKeywords);
            SqlParameter pmetaDescription = new SqlParameter("metaDescription", metaDescription);
            SqlParameter pcontentVn = new SqlParameter("contentVn", contentVn);
            SqlParameter pcontentEn = new SqlParameter("contentEn", contentEn);
            SqlParameter pmodified = new SqlParameter("modified", modified);
            SqlParameter pauthor = new SqlParameter("author", author);
            SqlParameter pstatus = new SqlParameter("status", status);
            this.DB.Updatedata(sql, ppostId, ptitle, pmetaKeywords, pmetaDescription,pcontentVn, pcontentEn, pmodified, pauthor, pstatus);
            this.DB.CloseConnection();
            return true;
        }
        //Delete POst With ID
        public Boolean DeleteWithPostID(int PostID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from POST where PostID=@PostID";
            SqlParameter pPostID = new SqlParameter("@PostID", PostID);
            this.DB.Updatedata(sql, pPostID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
