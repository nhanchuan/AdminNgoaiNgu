using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BagProfileBLL
    {
        DataServices DB = new DataServices();
        public List<BagProfile> GetBagProfileWithInfoID(int InfoID)
        {
            string sql = "select * from BagProfile where InfoID=@InfoID";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pInfoID= new SqlParameter("InfoID", InfoID);
            DataTable tb = DB.DAtable(sql, pInfoID);
            List<BagProfile> lst = new List<BagProfile>();
            foreach(DataRow r in tb.Rows)
            {
                BagProfile bg = new BagProfile();
                bg.BagProfileID = (int)r[0];
                bg.InfoID = (int)r[1];
                bg.DocName = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bg.DocNote = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                bg.DateOfCreate = (DateTime)r[4];
                bg.DocStatucs =(string.IsNullOrEmpty(r[5].ToString()))?0: (int)r[5];
                lst.Add(bg);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean NewDocProfile(int InfoID, string DocName, string DocNote, int DocStatus)
        {
            string sql = "Exec NewDocProfile @InfoID,@DocName,@DocNote,@DocStatus";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            SqlParameter pDocName = new SqlParameter("DocName", DocName);
            SqlParameter pDocNote = new SqlParameter("DocNote", DocNote);
            SqlParameter pDocStatus = new SqlParameter("DocStatus", DocStatus);
            this.DB.Updatedata(sql, pInfoID, pDocName, pDocNote, pDocStatus);
            this.DB.CloseConnection();
            return true;
        }
        //=====GetBagProfilePageWise===========================================================================================================
        public DataTable GetBagProfilePageWise(int pageindex, int pagesize, int InfoID)
        {
            string sql = "Exec GetBagProfilePageWise @pageindex,@pagesize,@InfoID";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ppageindex = new SqlParameter("pageindex", pageindex);
            SqlParameter ppagesize = new SqlParameter("pagesize", pagesize);
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            DataTable tb = DB.DAtable(sql, ppageindex, ppagesize, pInfoID);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountGetBagProfilePageWise(int InfoID)
        {
            int rc = 0;
            string sql = "select COUNT(*) from BagProfile where InfoID=@InfoID";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            rc = DB.GetValues(sql, pInfoID);
            this.DB.CloseConnection();
            return rc;
        }
        //=====GetKeySearchBagProfilePageWise===========================================================================================================
        public DataTable GetKeySearchBagProfilePageWise(int pageindex, int pagesize, int InfoID, string keysearch)
        {
            string sql = "Exec GetKeySearchBagProfilePageWise @pageindex,@pagesize,@InfoID,@keysearch";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ppageindex = new SqlParameter("pageindex", pageindex);
            SqlParameter ppagesize = new SqlParameter("pagesize", pagesize);
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, ppageindex, ppagesize, pInfoID, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountKeySearchBagProfilePageWise(int InfoID, string keysearch)
        {
            int rc = 0;
            string sql = "select COUNT(*) from BagProfile where InfoID=@InfoID and DocName like '%'+@keysearch+'%'";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            rc = DB.GetValues(sql, pInfoID, pkeysearch);
            this.DB.CloseConnection();
            return rc;
        }
        //=====GetOrderByNameBagProfilePageWise===========================================================================================================
        public DataTable GetOrderByNameBagProfilePageWise(int pageindex, int pagesize, int InfoID, int orderby)
        {
            string sql = "Exec GetOrderByNameBagProfilePageWise @pageindex,@pagesize,@InfoID,@orderby";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ppageindex = new SqlParameter("pageindex", pageindex);
            SqlParameter ppagesize = new SqlParameter("pagesize", pagesize);
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            SqlParameter porderby = new SqlParameter("orderby", orderby);
            DataTable tb = DB.DAtable(sql, ppageindex, ppagesize, pInfoID, porderby);
            this.DB.CloseConnection();
            return tb;
        }
        //Delete 
        public Boolean DeleteBagProfile(int BagProfileID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from BagProfile where BagProfileID=@BagProfileID";
            SqlParameter pBagProfileID = new SqlParameter("@BagProfileID", BagProfileID);
            this.DB.Updatedata(sql, pBagProfileID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
