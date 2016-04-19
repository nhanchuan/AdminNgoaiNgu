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
    public class VideosBLL
    {
        DataServices DB = new DataServices();
        public List<Videos> getallVideo()
        {
            string sql = "select * from Videos";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<Videos> lst = new List<Videos>();
            foreach (DataRow r in tb.Rows)
            {
                Videos vi = new Videos();
                vi.VideoID = (int)r[0];
                vi.VideoName =(string.IsNullOrEmpty(r[1].ToString()))?"": (string)r[1];
                vi.VideoUrl = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                vi.ContentType = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                vi.VideotypeID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                vi.ShortDecsription = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                vi.DateOfCreate = (DateTime)r[6];
                vi.UserUpload = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                lst.Add(vi);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Videos> getVideoWithId(int videoId)
        {
            string sql = "select * from Videos where VideoID=@videoId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pVideoId = new SqlParameter("videoId", videoId);
            DataTable tb = DB.DAtable(sql, pVideoId);
            List<Videos> lst = new List<Videos>();
            foreach (DataRow r in tb.Rows)
            {
                Videos vi = new Videos();
                vi.VideoID = (int)r[0];
                vi.VideoName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                vi.VideoUrl = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                vi.ContentType = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                vi.VideotypeID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                vi.ShortDecsription = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                vi.DateOfCreate = (DateTime)r[6];
                vi.UserUpload = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                lst.Add(vi);
            }
            this.DB.CloseConnection();
            return lst;
        }

        public Boolean UploadVideos(string name, string url, string contentype, int videptype, string shortDC, int uid)
        {
            string sql = "Exec UploadVideos @name,@url,@contentype,@videptype,@shortDC,@uid";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pname = new SqlParameter("name", name);
            SqlParameter purl = new SqlParameter("url", url);
            SqlParameter pcontentypel = new SqlParameter("contentype", contentype);
            SqlParameter pvideptype = new SqlParameter("videptype", videptype);
            SqlParameter pshortDC = new SqlParameter("shortDC", shortDC);
            SqlParameter puid = new SqlParameter("uid", uid);
            this.DB.Updatedata(sql, pname, purl, pcontentypel, pvideptype, pshortDC, puid);
            this.DB.CloseConnection();
            return true;
        }

        public int CountRecordVideo()
        {
            int count = 0;
            string sql = "select COUNT(*) from Videos";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            count = DB.GetValues(sql);
            this.DB.CloseConnection();
            return count;
        }
        public int CountRecordVideoType(int type)
        {
            int count = 0;
            string sql = "select COUNT(*) from Videos where VideotypeID=@type";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter ptype = new SqlParameter("type", type);
            count = DB.GetValues(sql, ptype);
            this.DB.CloseConnection();
            return count;
        }
        public int CountRecordVideoSearch(string keysearch)
        {
            int count = 0;
            string sql = "select Count(*) from Videos Where VideoName like '%'+@keysearch+'%' or ShortDecsription like '%'+@keysearch+'%'";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            count = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return count;
        }
        public DataTable GetVideoPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec GetVideoPageWise @PageIndex,@PageSize";
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
        public DataTable GetVideoTypePageWise(int PageIndex, int PageSize, int type)
        {
            string sql = "Exec GetVideoTypePageWise @PageIndex,@PageSize,@type";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter ptype = new SqlParameter("type", type);
            DataTable tb = DB.DAtable(sql, paramPageIndex, paramPageSize, ptype);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetVideoSearchPageWise(int PageIndex, int PageSize, string keysearch)
        {
            string sql = "Exec GetVideoSearchPageWise @PageIndex,@PageSize,@keysearch";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter paramPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter paramPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, paramPageIndex, paramPageSize, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public Boolean UpdateVideoInfo(int videoid, string videoname, int videoType, string shortDC)
        {
            string sql = "update Videos set VideoName=@videoname, VideotypeID=@videoType, ShortDecsription=@shortDC where VideoID=@videoid";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pvideoid = new SqlParameter("videoid", videoid);
            SqlParameter pvideoname = new SqlParameter("videoname", videoname);
            SqlParameter pvideoType = new SqlParameter("videoType", videoType);
            SqlParameter pshortDC = new SqlParameter("shortDC", shortDC);
            this.DB.Updatedata(sql, pvideoid, pvideoname, pvideoType, pshortDC);
            this.DB.CloseConnection();
            return true;
        }
    }
}
