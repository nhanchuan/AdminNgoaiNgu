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

    public class InternationalSchoolBLL
    {
        DataServices DB = new DataServices();
        DateTime DefaultBirthday = Convert.ToDateTime("12/12/1900");
        public List<InternationalSchool> GetAllInternationalSchool()
        {
            string sql = "select * from InternationalSchool";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<InternationalSchool> lst = new List<InternationalSchool>();
            foreach(DataRow r in tb.Rows)
            {
                InternationalSchool InS = new InternationalSchool();
                InS.SchoolID = (int)r["SchoolID"];
                InS.SchoolName = (string.IsNullOrEmpty(r["SchoolName"].ToString())) ? "" : (string)r["SchoolName"];
                InS.SchoolAddress= (string.IsNullOrEmpty(r["SchoolAddress"].ToString())) ? "" : (string)r["SchoolAddress"];
                InS.WebSite= (string.IsNullOrEmpty(r["WebSite"].ToString())) ? "" : (string)r["WebSite"];
                InS.SchoolLvl= (string.IsNullOrEmpty(r["SchoolLvl"].ToString())) ? "" : (string)r["SchoolLvl"];
                InS.AboutLink= (string.IsNullOrEmpty(r["AboutLink"].ToString())) ? "" : (string)r["AboutLink"];
                InS.CountryID= (string.IsNullOrEmpty(r["CountryID"].ToString())) ? 0 : (int)r["CountryID"];
                InS.ProvinceID = (string.IsNullOrEmpty(r["ProvinceID"].ToString())) ? 0 : (int)r["ProvinceID"];
                InS.DistrictID = (string.IsNullOrEmpty(r["DistrictID"].ToString())) ? 0 : (int)r["DistrictID"];
                InS.GoogleMap= (string.IsNullOrEmpty(r["GoogleMap"].ToString())) ? "" : (string)r["GoogleMap"];
                InS.Phone= (string.IsNullOrEmpty(r["Phone"].ToString())) ? "" : (string)r["Phone"];
                InS.Establish= (string.IsNullOrEmpty(r["Establish"].ToString())) ? DefaultBirthday : (DateTime)r["Establish"];
                InS.HocPhi = (string.IsNullOrEmpty(r["HocPhi"].ToString())) ? "" : (string)r["HocPhi"];
                InS.PhiKhac= (string.IsNullOrEmpty(r["PhiKhac"].ToString())) ? "" : (string)r["PhiKhac"];
                InS.DatCoc = (string.IsNullOrEmpty(r["DatCoc"].ToString())) ? "" : (string)r["DatCoc"];
                InS.DieuKienNhapHoc = (string.IsNullOrEmpty(r["DieuKienNhapHoc"].ToString())) ? "" : (string)r["DieuKienNhapHoc"];
                InS.HocBong = (string.IsNullOrEmpty(r["HocBong"].ToString())) ? "" : (string)r["HocBong"];
                InS.Images = (string.IsNullOrEmpty(r["Images"].ToString())) ? 0 : (int)r["Images"];
                lst.Add(InS);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetTbInternationalSchool()
        {
            string sql = "select ins.SchoolID,ins.SchoolName,ins.SchoolAddress,ins.WebSite,ins.SchoolLvl,ins.AboutLink,ins.CountryID,ins.GoogleMap,ins.Phone,ins.Establish,ct.CountryName from InternationalSchool ins join CountryAdvisory ct on ins.CountryID=ct.CountryAdvisoryID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetTbInternationalSchoolWithCountry(int countryID)
        {
            string sql = "select ins.SchoolID,ins.SchoolName,ins.SchoolAddress,ins.WebSite,ins.SchoolLvl,ins.AboutLink,ins.CountryID,ins.GoogleMap,ins.Phone,ins.Establish,ct.CountryName from InternationalSchool ins join CountryAdvisory ct on ins.CountryID=ct.CountryAdvisoryID where ins.CountryID=@countryID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcountryID = new SqlParameter("countryID", countryID);
            DataTable tb = DB.DAtable(sql,pcountryID);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetTbInternationalSchoolWithSchoolLvl(string SchoolLvl)
        {
            string sql = "select ins.SchoolID,ins.SchoolName,ins.SchoolAddress,ins.WebSite,ins.SchoolLvl,ins.AboutLink,ins.CountryID,ins.GoogleMap,ins.Phone,ins.Establish,ct.CountryName from InternationalSchool ins join CountryAdvisory ct on ins.CountryID=ct.CountryAdvisoryID where ins.SchoolLvl=@SchoolLvl";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pSchoolLvl = new SqlParameter("SchoolLvl", SchoolLvl);
            DataTable tb = DB.DAtable(sql, pSchoolLvl);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetInternationalSchoolOrderByName(int orderby)
        {
            string sql = "Exec GetInternationalSchoolOrderByName @orderby";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter porderbyl = new SqlParameter("orderby", orderby);
            DataTable tb = DB.DAtable(sql, porderbyl);
            this.DB.CloseConnection();
            return tb;
        }
        public Boolean NewInternationalSchool(string SchoolName, string SchoolAddress, string WebSite, string SchoolLvl, string AboutLink, int CountryID, string gmap, string phone)
        {
            string sql = "insert into InternationalSchool(SchoolName,SchoolAddress,WebSite,SchoolLvl,AboutLink,CountryID,GoogleMap,Phone) values(@SchoolName,@SchoolAddress,@WebSite,@SchoolLvl,@AboutLink,@CountryID,@gmap,@phone)";
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pSchoolName = new SqlParameter("SchoolName", SchoolName);
            SqlParameter pSchoolAddress = new SqlParameter("SchoolAddress", SchoolAddress);
            SqlParameter pWebSite = new SqlParameter("WebSite", WebSite);
            SqlParameter pSchoolLvl = new SqlParameter("SchoolLvl", SchoolLvl);
            SqlParameter pAboutLink = new SqlParameter("AboutLink", AboutLink);
            SqlParameter pCountryID = (CountryID == 0) ? new SqlParameter("CountryID", DBNull.Value) : new SqlParameter("CountryID", CountryID);
            SqlParameter pgmap = new SqlParameter("gmap", gmap);
            SqlParameter pPhone = new SqlParameter("phone", phone);
            this.DB.Updatedata(sql, pSchoolName, pSchoolAddress, pWebSite, pSchoolLvl, pAboutLink, pCountryID, pgmap, pPhone);
            this.DB.CloseConnection();
            return true;
        }
    }
}
