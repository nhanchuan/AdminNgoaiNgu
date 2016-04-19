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
    public class kus_PhongHocBLL
    {
        DataServices DB = new DataServices();
        public List<kus_PhongHoc> getListPhongHocWithID(int phonghocID)
        {
            string sql = "select * from kus_PhongHoc where PhongHocID=@phonghocID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pphonghocID = new SqlParameter("phonghocID", phonghocID);
            DataTable tb = DB.DAtable(sql, pphonghocID);
            List<kus_PhongHoc> lst = new List<kus_PhongHoc>();
            foreach (DataRow r in tb.Rows)
            {
                kus_PhongHoc ph = new kus_PhongHoc();
                ph.PhongHocID = (int)r[0];
                ph.DayPhong = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                ph.Tang = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                ph.SoPhong = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                ph.CoSoID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                lst.Add(ph);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getTBDropdownPHWithCoSOID(int cosoID)
        {
            string sql = "select PhongHocID,(DayPhong+Tang+'.'+CONVERT(varchar(5),SoPhong)) as SoPhongHoc from kus_PhongHoc where CoSoID=@cosoID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcosoID = new SqlParameter("cosoID", cosoID);
            DataTable tb = DB.DAtable(sql, pcosoID);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetGetkus_PhongHocPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec Getkus_PhongHocPageWise @PageIndex,@PageSize";
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
        public int CounGetkus_PhongHocPageWise()
        {
            int RC = 0;
            string sql = "select COUNT(*) from kus_PhongHoc";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        //Add New
        public Boolean AddNewPhongHoc(string dayph, string tang, int sophong, int cosoid)
        {
            string sql = "insert into kus_PhongHoc(DayPhong,Tang,SoPhong,CoSoID) values(@dayph,@tang,@sophong,@cosoid)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pdayph = new SqlParameter("dayph", dayph);
            SqlParameter ptang = new SqlParameter("tang", tang);
            SqlParameter psophong = (sophong <= 0) ? new SqlParameter("sophong", DBNull.Value) : new SqlParameter("sophong", sophong);
            SqlParameter pcosoid = (cosoid <= 0) ? new SqlParameter("cosoid", DBNull.Value) : new SqlParameter("cosoid", cosoid);
            this.DB.Updatedata(sql, pdayph, ptang, psophong, pcosoid);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean UpdatePhongHoc(int phonghocID, string dayph, string tang, int sophong, int cosoid)
        {
            string sql = "update kus_PhongHoc set DayPhong=@dayph,Tang=@tang,SoPhong=@sophong, CoSoID=@cosoid where PhongHocID=@phonghocID";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pphonghocID = new SqlParameter("phonghocID", phonghocID);
            SqlParameter pdayph = new SqlParameter("dayph", dayph);
            SqlParameter ptang = new SqlParameter("tang", tang);
            SqlParameter psophong = (sophong <= 0) ? new SqlParameter("sophong", DBNull.Value) : new SqlParameter("sophong", sophong);
            SqlParameter pcosoid = (cosoid <= 0) ? new SqlParameter("cosoid", DBNull.Value) : new SqlParameter("cosoid", cosoid);
            this.DB.Updatedata(sql, pphonghocID, pdayph, ptang, psophong, pcosoid);
            this.DB.CloseConnection();
            return true;
        }

    }
}
