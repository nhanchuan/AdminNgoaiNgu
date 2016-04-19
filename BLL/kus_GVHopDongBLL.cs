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
    public class kus_GVHopDongBLL
    {
        DataServices DB = new DataServices();
        public List<kus_GVHopDong> getGVHopDongWithID(int GVID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_GVHopDong where GVID=@GVID";
            SqlParameter pGVID = new SqlParameter("@GVID", GVID);
            DataTable tb = DB.DAtable(sql, pGVID);
            List<kus_GVHopDong> lst = new List<kus_GVHopDong>();
            foreach(DataRow r in tb.Rows)
            {
                kus_GVHopDong gv = new kus_GVHopDong();
                gv.GVID = (int)r[0];
                gv.FirstName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                gv.LastName = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                gv.Birthday = (string.IsNullOrEmpty(r[3].ToString())) ? Convert.ToDateTime("01/01/1900") : (DateTime)r[3];
                gv.Sex = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                gv.CMND = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                gv.GVAddress = (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];
                gv.Email = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                gv.Phone = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                gv.GhiChu = (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                gv.MoTaGV= (string.IsNullOrEmpty(r[10].ToString())) ? "" : (string)r[10];
                lst.Add(gv);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable kus_GetGVHopDongPageWise(int PageIndex, int PageSize)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_GetGVHopDongPageWise @PageIndex,@PageSize";
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize);
            this.DB.CloseConnection();
            return tb;
        }
        public int Countkus_GetGVHopDong()
        {
            int dem = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from kus_GVHopDong";
            dem = DB.GetValues(sql);
            this.DB.CloseConnection();
            return dem;
        }
        public DataTable kus_GetGVHopDongDL()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select GVID, (LastName + ' ' + FirstName) as GVname from kus_GVHopDong";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        public Boolean kus_AddNewGVHopDong(string FirstName, string LastName, DateTime Birthday, int Sex, string CMND, string GVAddress, string Email, string Phone, string GhiChu, string MoTaGV)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Exec kus_AddNewGVHopDong @FirstName,@LastName,@Birthday,@Sex,@CMND,@GVAddress,@Email,@Phone,@GhiChu,@MoTaGV";
            SqlParameter p1 = (FirstName == "") ? new SqlParameter("FirstName", DBNull.Value) : new SqlParameter("FirstName", FirstName);
            SqlParameter p2 = (LastName == "") ? new SqlParameter("LastName", DBNull.Value) : new SqlParameter("LastName", LastName);
            SqlParameter p3 = (Birthday.Year <= 1900) ? new SqlParameter("Birthday", DBNull.Value) : new SqlParameter("Birthday", Birthday);
            SqlParameter p4 = (Sex == 0) ? new SqlParameter("Sex", DBNull.Value) : new SqlParameter("Sex", Sex);
            SqlParameter p5 = (CMND == "") ? new SqlParameter("CMND", DBNull.Value) : new SqlParameter("CMND", CMND);
            SqlParameter p6 = (GVAddress == "") ? new SqlParameter("GVAddress", DBNull.Value) : new SqlParameter("GVAddress", GVAddress);
            SqlParameter p7 = (Email == "") ? new SqlParameter("Email", DBNull.Value) : new SqlParameter("Email", Email);
            SqlParameter p8 = (Phone == "") ? new SqlParameter("Phone", DBNull.Value) : new SqlParameter("Phone", Phone);
            SqlParameter p9 = (GhiChu == "") ? new SqlParameter("GhiChu", DBNull.Value) : new SqlParameter("GhiChu", GhiChu);
            SqlParameter p10 = (MoTaGV == "") ? new SqlParameter("@MoTaGV", DBNull.Value) : new SqlParameter("@MoTaGV", MoTaGV);
            this.DB.Updatedata(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            this.DB.CloseConnection();
            return true;
        }
        //UPDATE
        public Boolean kus_UpdateGVHopDong(int GVID, string FirstName, string LastName, DateTime Birthday, int Sex, string CMND, string GVAddress, string Email, string Phone, string GhiChu, string MoTaGV)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Exec kus_UpdateGVHopDong @GVID,@FirstName,@LastName,@Birthday,@Sex,@CMND,@GVAddress,@Email,@Phone,@GhiChu,@MoTaGV";
            SqlParameter p0 = new SqlParameter("@GVID", GVID);
            SqlParameter p1 = (FirstName == "") ? new SqlParameter("@FirstName", DBNull.Value) : new SqlParameter("@FirstName", FirstName);
            SqlParameter p2 = (LastName == "") ? new SqlParameter("@LastName", DBNull.Value) : new SqlParameter("@LastName", LastName);
            SqlParameter p3 = (Birthday.Year <= 1900) ? new SqlParameter("@Birthday", DBNull.Value) : new SqlParameter("@Birthday", Birthday);
            SqlParameter p4 = (Sex == 0) ? new SqlParameter("@Sex", DBNull.Value) : new SqlParameter("@Sex", Sex);
            SqlParameter p5 = (CMND == "") ? new SqlParameter("@CMND", DBNull.Value) : new SqlParameter("@CMND", CMND);
            SqlParameter p6 = (GVAddress == "") ? new SqlParameter("@GVAddress", DBNull.Value) : new SqlParameter("@GVAddress", GVAddress);
            SqlParameter p7 = (Email == "") ? new SqlParameter("@Email", DBNull.Value) : new SqlParameter("@Email", Email);
            SqlParameter p8 = (Phone == "") ? new SqlParameter("@Phone", DBNull.Value) : new SqlParameter("@Phone", Phone);
            SqlParameter p9 = (GhiChu == "") ? new SqlParameter("@GhiChu", DBNull.Value) : new SqlParameter("@GhiChu", GhiChu);
            SqlParameter p10 = (MoTaGV == "") ? new SqlParameter("@MoTaGV", DBNull.Value) : new SqlParameter("@MoTaGV", MoTaGV);
            this.DB.Updatedata(sql, p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            this.DB.CloseConnection();
            return true;
        }
        //Delete 
        public Boolean Delete_kus_GVHopDong(int GVID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from kus_GVHopDong where GVID=@GVID";
            SqlParameter pGVID = new SqlParameter("@GVID", GVID);
            this.DB.Updatedata(sql, pGVID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
