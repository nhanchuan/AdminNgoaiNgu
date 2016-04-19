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
    public class BagAttachmentsBLL
    {
        DataServices DB = new DataServices();
        public Boolean UploadBagAttachments(string AtName, string AtURL, int bagproId, int userUpload)
        {
            string sql = "insert into BagAttachments(AttachmentName,AttachmentURL,BagProfileID,UserUpload) values(@AtName,@AtURL,@bagproId,@userUpload)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pAtName = new SqlParameter("AtName", AtName);
            SqlParameter pAtURL = new SqlParameter("AtURL", AtURL);
            SqlParameter pbagproId = new SqlParameter("bagproId", bagproId);
            SqlParameter puserUpload = new SqlParameter("userUpload", userUpload);
            this.DB.Updatedata(sql, pAtName, pAtURL, pbagproId, puserUpload);
            this.DB.CloseConnection();
            return true;
        }
        public List<BagAttachments> GetbagattWihAttId(int attid)
        {
            string sql = "select * from BagAttachments where AttachmentID=@attid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pattid = new SqlParameter("attid", attid);
            DataTable tb = DB.DAtable(sql, pattid);
            List<BagAttachments> lst = new List<BagAttachments>();
            foreach (DataRow r in tb.Rows)
            {
                BagAttachments bt = new BagAttachments();
                bt.AttachmentID = (int)r[0];
                bt.AttachmentName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                bt.AttachmentURL = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bt.BagProfileID = (int)r[3];
                bt.UserUpload = (int)r[4];
                bt.DateOfCreate = (DateTime)r[5];
                lst.Add(bt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<BagAttachments> GetbagattWihname(string name, int bagid)
        {
            string sql = "select * from BagAttachments where AttachmentName=@name and BagProfileID=@bagid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pnamee = new SqlParameter("name", name);
            SqlParameter pbagid = new SqlParameter("bagid", bagid);
            DataTable tb = DB.DAtable(sql, pnamee, pbagid);
            List<BagAttachments> lst = new List<BagAttachments>();
            foreach (DataRow r in tb.Rows)
            {
                BagAttachments bt = new BagAttachments();
                bt.AttachmentID = (int)r[0];
                bt.AttachmentName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                bt.AttachmentURL = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bt.BagProfileID = (int)r[3];
                bt.UserUpload = (int)r[4];
                bt.DateOfCreate = (DateTime)r[5];
                lst.Add(bt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetBagAttWihUidInfoId(int uid, int infoUId)
        {
            string sql = "select at.AttachmentID,at.AttachmentName,at.AttachmentURL,at.BagProfileID,at.UserUpload,at.DateOfCreate,bp.DocName from BagAttachments  at join BagProfile bp on at.BagProfileID=bp.BagProfileID where bp.InfoID=@infoUId and at.UserUpload=@uid";
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
        public Boolean DeleteBagAttachments(int attachId)
        {
            string sql = "delete from BagAttachments where AttachmentID=@attachId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pattachId = new SqlParameter("attachId", attachId);
            this.DB.Updatedata(sql, pattachId);
            this.DB.CloseConnection();
            return true;
        }
    }
}
