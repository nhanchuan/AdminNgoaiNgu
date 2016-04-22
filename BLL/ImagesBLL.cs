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
    public class ImagesBLL
    {
        DataServices DB = new DataServices();
        public List<Images> getAllImages()
        {
            string sql = "select * from Images";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<Images> lst = new List<Images>();
            foreach (DataRow r in tb.Rows)
            {
                Images im = new Images();
                im.ImagesID = (int)r[0];
                im.ImagesName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                im.ImagesUrl = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                im.ImagesTypeID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                im.DateOfStart = (DateTime)r[4];
                im.UserUpload = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lst.Add(im);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Images> getAllImagesWithUserUpload(int UserUpload)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Images where UserUpload=@UserUpload";
            SqlParameter pUserUpload = new SqlParameter("@UserUpload", UserUpload);
            DataTable tb = DB.DAtable(sql, pUserUpload);
            List<Images> lst = new List<Images>();
            foreach (DataRow r in tb.Rows)
            {
                Images im = new Images();
                im.ImagesID = (int)r[0];
                im.ImagesName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                im.ImagesUrl = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                im.ImagesTypeID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                im.DateOfStart = (DateTime)r[4];
                im.UserUpload = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lst.Add(im);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Images> getImagesWithId(int imgid)
        {
            string sql = "select * from Images where ImagesID=@imgid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter paramimgid = new SqlParameter("imgid", imgid);
            DataTable tb = DB.DAtable(sql, paramimgid);
            List<Images> lst = new List<Images>();
            foreach (DataRow r in tb.Rows)
            {
                Images im = new Images();
                im.ImagesID = (int)r[0];
                im.ImagesName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                im.ImagesUrl = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                im.ImagesTypeID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                im.DateOfStart = (DateTime)r[4];
                im.UserUpload = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lst.Add(im);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getImagesWithType(int typeId)
        {
            string sql = "select img.ImagesID,img.ImagesName,img.ImagesUrl,img.ImagesTypeID,img.DateOfStart,img.UserUpload,ac.UserName from Images img full outer join UserAccounts ac on img.UserUpload=ac.UserID where ImagesTypeID=@typeId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ptypeId = new SqlParameter("@typeId", typeId);
            DataTable tb = DB.DAtable(sql, ptypeId);
            this.DB.CloseConnection();
            return tb;
        }
        public List<Images> getImagesWithUserUpload(int userid)
        {
            string sql = "select * from Images where UserUpload=@userid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter puserid = new SqlParameter("userid", userid);
            DataTable tb = DB.DAtable(sql, puserid);
            List<Images> lst = new List<Images>();
            foreach (DataRow r in tb.Rows)
            {
                Images im = new Images();
                im.ImagesID = (int)r[0];
                im.ImagesName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                im.ImagesUrl = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                im.ImagesTypeID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                im.DateOfStart = (DateTime)r[4];
                im.UserUpload = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                lst.Add(im);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetImagesTypeAndUserUpload(int typeId, int UserId)
        {
            string sql = "Exec GetImagesTypeAndUserUpload @typeId,@UserId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ptypeId = new SqlParameter("typeId", typeId);
            SqlParameter pUserId = new SqlParameter("UserId", UserId);
            DataTable tb = DB.DAtable(sql, ptypeId, pUserId);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetImagesTypeUpload(int typeId)
        {
            string sql = "Exec GetImagesTypeUpload @typeId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ptypeId = new SqlParameter("typeId", typeId);
            DataTable tb = DB.DAtable(sql, ptypeId);
            this.DB.CloseConnection();
            return tb;
        }
        public Boolean InsertImages(string imgName, string Imgurl, int imgtype, int uid)
        {
            string sql = "insert into Images(ImagesName,ImagesUrl,ImagesTypeID,UserUpload) values(@imgName,@Imgurl,@imgtype,@uid)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter paramimgName = new SqlParameter("imgName", imgName);
            SqlParameter pImgurl = new SqlParameter("Imgurl", Imgurl);
            SqlParameter pimgtype = new SqlParameter("imgtype", imgtype);
            SqlParameter puid = new SqlParameter("uid", uid);
            this.DB.Updatedata(sql, paramimgName, pImgurl, pimgtype, puid);
            this.DB.CloseConnection();
            return true;
        }
        public int ImagesID(string imgUrl)
        {
            int imid = 0;
            string sql = "select ImagesID from Images where ImagesUrl=@imgUrl";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pimgUrl = new SqlParameter("imgUrl", imgUrl);
            DataTable tb = DB.DAtable(sql, pimgUrl);
            foreach(DataRow r in tb.Rows)
            {
                imid = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
            }
            this.DB.CloseConnection();
            return imid;
        }
        public int ImagesIDUrl(string ImagesUrl)
        {
            int imid = 0;
            string sql = "select ImagesID from Images where ImagesUrl=@ImagesUrl";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pImagesUrl = new SqlParameter("ImagesUrl", ImagesUrl);
            DataTable tb = DB.DAtable(sql, pImagesUrl);
            foreach (DataRow r in tb.Rows)
            {
                imid = (string.IsNullOrEmpty(r[0].ToString())) ? 0 : (int)r[0];
            }
            this.DB.CloseConnection();
            return imid;
        }
        public string ImagesUrl(int imgId)
        {
            string url = "";
            string sql = "select ImagesUrl from Images where ImagesID=@imgId";
            if (!this.DB.OpenConnection())
            {
                return "";
            }
            SqlParameter pimgId = new SqlParameter("imgId", imgId);
            DataTable tb = DB.DAtable(sql, pimgId);
            foreach (DataRow r in tb.Rows)
            {
                url = (string.IsNullOrEmpty(r[0].ToString())) ? "" : (string)r[0];
            }
            this.DB.CloseConnection();
            return url;
        }
        public int RecordCountImages() //COUNT ROW IN TABLE IMAGES
        {
            int RC = 0;
            
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from Images";
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        public int RecordCountImagesType(int ImagesTypeID) //COUNT ROW IN TABLE IMAGES WITH TYPE ID
        {
            int RC = 0;
            string sql = "select COUNT(*) from Images where ImagesTypeID=@ImagesTypeID";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pImagesTypeID = new SqlParameter("ImagesTypeID", ImagesTypeID);
            RC = DB.GetValues(sql, pImagesTypeID);
            this.DB.CloseConnection();
            return RC;
        }
        public int RecordCountSearchImages(string keysearch) //COUNT ROW IN TABLE IMAGES WITH SEARCH  
        {
            int RC = 0;
            string sql = "select COUNT(*) from Images WHERE (ImagesName like '%'+@keysearch+'%' or ImagesUrl like '%'+@keysearch+'%')";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("@keysearch", keysearch);
            RC = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return RC;
        }
        // THU VIEN HINH ANH ==================================================================
        public DataTable GetImagesPageWise(int PageIndex, int PageSize)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetImagesPageWise @PageIndex,@PageSize";
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = DB.DAtable(sql, paramPageIndex, paramPageSize);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetImagesTypePageWise(int PageIndex, int PageSize, int ImagesTypeID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetImagesTypePageWise @PageIndex,@PageSize,@ImagesTypeID";
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter paramImagesTypeID = new SqlParameter("ImagesTypeID", ImagesTypeID);
            DataTable tb = DB.DAtable(sql, paramPageIndex, paramPageSize, paramImagesTypeID);
            this.DB.CloseConnection();
            return tb;
        }
        // THU VIEN HINH ANH ==================================================================
        public DataTable GetImagesSearchPageWise(int PageIndex, int PageSize, string keysearch)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetImagesSearchPageWise @PageIndex,@PageSize,@keysearch";
            SqlParameter paramPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("@PageSize", PageSize);
            SqlParameter paramkeysearch = new SqlParameter("@keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, paramPageIndex, paramPageSize, paramkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
    }
}
