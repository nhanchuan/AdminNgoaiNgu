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
    public class BagFileTranslateBLL
    {
        DataServices DB = new DataServices();
        public List<BagFileTranslate> getListWithBagProfileID(int BagProfileID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from BagFileTranslate where BagProfileID=@BagProfileID";
            SqlParameter pBagProfileID = new SqlParameter("@BagProfileID", BagProfileID);
            DataTable tb = DB.DAtable(sql, pBagProfileID);
            List<BagFileTranslate> lst = new List<BagFileTranslate>();
            foreach (DataRow r in tb.Rows)
            {
                BagFileTranslate bt = new BagFileTranslate();
                bt.FileTranslateID = (int)r["FileTranslateID"];
                bt.FileTranslateName = (string.IsNullOrEmpty(r["FileTranslateName"].ToString())) ? "" : (string)r["FileTranslateName"];
                bt.FileTranslateURL = (string.IsNullOrEmpty(r["FileTranslateURL"].ToString())) ? "" : (string)r["FileTranslateURL"];
                bt.BagProfileID = (string.IsNullOrEmpty(r["BagProfileID"].ToString())) ? 0 : (int)r["BagProfileID"];
                bt.UserUpload = (string.IsNullOrEmpty(r["UserUpload"].ToString())) ? 0 : (int)r["UserUpload"];
                bt.DateOfCreate = (DateTime)r["DateOfCreate"];
                lst.Add(bt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean UploadBagFileTranslate(string filename, string fileUrl, int bagproId, int UserID)
        {
            string sql = "insert into BagFileTranslate(FileTranslateName,FileTranslateURL,BagProfileID,UserUpload) values(@filename,@fileUrl,@bagproId,@UserID)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pfilenamee = new SqlParameter("filename", filename);
            SqlParameter pfileUrl = new SqlParameter("fileUrl", fileUrl);
            SqlParameter pbagproId = new SqlParameter("bagproId", bagproId);
            SqlParameter pUserID = new SqlParameter("UserID", UserID);
            this.DB.Updatedata(sql, pfilenamee, pfileUrl, pbagproId, pUserID);
            this.DB.CloseConnection();
            return true;
        }
        public List<BagFileTranslate> GetBagFileTranslateName(string name, int bagid)
        {
            string sql = "select * from BagFileTranslate where FileTranslateName=@name and BagProfileID=@bagid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pnamee = new SqlParameter("name", name);
            SqlParameter pbagid = new SqlParameter("bagid", bagid);
            DataTable tb = DB.DAtable(sql, pnamee, pbagid);
            List<BagFileTranslate> lst = new List<BagFileTranslate>();
            foreach (DataRow r in tb.Rows)
            {
                BagFileTranslate bt = new BagFileTranslate();
                bt.FileTranslateID = (int)r[0];
                bt.FileTranslateName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                bt.FileTranslateURL = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bt.BagProfileID = (int)r[3];
                bt.UserUpload = (int)r[4];
                bt.DateOfCreate = (DateTime)r[5];
                lst.Add(bt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<BagFileTranslate> GetBagFileTranslateId(int TranId)
        {
            string sql = "select * from BagFileTranslate where FileTranslateID=@TranId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pTranId = new SqlParameter("TranId", TranId);
            DataTable tb = DB.DAtable(sql, pTranId);
            List<BagFileTranslate> lst = new List<BagFileTranslate>();
            foreach (DataRow r in tb.Rows)
            {
                BagFileTranslate bt = new BagFileTranslate();
                bt.FileTranslateID = (int)r[0];
                bt.FileTranslateName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                bt.FileTranslateURL = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bt.BagProfileID = (int)r[3];
                bt.UserUpload = (int)r[4];
                bt.DateOfCreate = (DateTime)r[5];
                lst.Add(bt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetFileTranslatWihUidInfoId(int uid, int infoUId)
        {
            string sql = "select bt.FileTranslateID,bt.FileTranslateName,bt.FileTranslateURL,bt.BagProfileID,bt.UserUpload,bt.DateOfCreate,bp.DocName from BagFileTranslate bt join BagProfile bp on bt.BagProfileID=bp.BagProfileID where bp.InfoID=@infoUId and bt.UserUpload=@uid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter puid = new SqlParameter("uid", uid);
            SqlParameter pinfoUId = new SqlParameter("infoUId", infoUId);
            DataTable tb = DB.DAtable(sql, puid, pinfoUId);

            this.DB.CloseConnection();
            return tb;
        }
        //DELETE
        public Boolean DeleteBagFileTranslate(int transId)
        {
            string sql = "delete from BagFileTranslate where FileTranslateID=@transId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptransId = new SqlParameter("transId", transId);
            this.DB.Updatedata(sql, ptransId);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean DeleteBagProfileID(int BagProfileID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from BagFileTranslate where BagProfileID=@BagProfileID";
            SqlParameter pBagProfileID = new SqlParameter("@BagProfileID", BagProfileID);
            this.DB.Updatedata(sql, pBagProfileID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
