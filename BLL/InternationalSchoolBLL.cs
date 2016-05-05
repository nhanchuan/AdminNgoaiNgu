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
                InS.ChuyenNganhNoiBat = (string.IsNullOrEmpty(r["ChuyenNganhNoiBat"].ToString())) ? "" : (string)r["ChuyenNganhNoiBat"];
                lst.Add(InS);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<InternationalSchool> GetInternationalSchoolWithSchoolID(int SchoolID)
        {

            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from InternationalSchool where SchoolID=@SchoolID";
            SqlParameter pSchoolID = new SqlParameter("@SchoolID", SchoolID);
            DataTable tb = DB.DAtable(sql, pSchoolID);
            List<InternationalSchool> lst = new List<InternationalSchool>();
            foreach (DataRow r in tb.Rows)
            {
                InternationalSchool InS = new InternationalSchool();
                InS.SchoolID = (int)r["SchoolID"];
                InS.SchoolName = (string.IsNullOrEmpty(r["SchoolName"].ToString())) ? "" : (string)r["SchoolName"];
                InS.SchoolAddress = (string.IsNullOrEmpty(r["SchoolAddress"].ToString())) ? "" : (string)r["SchoolAddress"];
                InS.WebSite = (string.IsNullOrEmpty(r["WebSite"].ToString())) ? "" : (string)r["WebSite"];
                InS.SchoolLvl = (string.IsNullOrEmpty(r["SchoolLvl"].ToString())) ? "" : (string)r["SchoolLvl"];
                InS.AboutLink = (string.IsNullOrEmpty(r["AboutLink"].ToString())) ? "" : (string)r["AboutLink"];
                InS.CountryID = (string.IsNullOrEmpty(r["CountryID"].ToString())) ? 0 : (int)r["CountryID"];
                InS.ProvinceID = (string.IsNullOrEmpty(r["ProvinceID"].ToString())) ? 0 : (int)r["ProvinceID"];
                InS.DistrictID = (string.IsNullOrEmpty(r["DistrictID"].ToString())) ? 0 : (int)r["DistrictID"];
                InS.GoogleMap = (string.IsNullOrEmpty(r["GoogleMap"].ToString())) ? "" : (string)r["GoogleMap"];
                InS.Phone = (string.IsNullOrEmpty(r["Phone"].ToString())) ? "" : (string)r["Phone"];
                InS.Establish = (string.IsNullOrEmpty(r["Establish"].ToString())) ? DefaultBirthday : (DateTime)r["Establish"];
                InS.HocPhi = (string.IsNullOrEmpty(r["HocPhi"].ToString())) ? "" : (string)r["HocPhi"];
                InS.PhiKhac = (string.IsNullOrEmpty(r["PhiKhac"].ToString())) ? "" : (string)r["PhiKhac"];
                InS.DatCoc = (string.IsNullOrEmpty(r["DatCoc"].ToString())) ? "" : (string)r["DatCoc"];
                InS.DieuKienNhapHoc = (string.IsNullOrEmpty(r["DieuKienNhapHoc"].ToString())) ? "" : (string)r["DieuKienNhapHoc"];
                InS.HocBong = (string.IsNullOrEmpty(r["HocBong"].ToString())) ? "" : (string)r["HocBong"];
                InS.Images = (string.IsNullOrEmpty(r["Images"].ToString())) ? 0 : (int)r["Images"];
                InS.ChuyenNganhNoiBat = (string.IsNullOrEmpty(r["ChuyenNganhNoiBat"].ToString())) ? "" : (string)r["ChuyenNganhNoiBat"];
                lst.Add(InS);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<InternationalSchool> GetAllInternationalSchoolWithName(string SchoolName)
        {
            
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from InternationalSchool where SchoolName=@SchoolName";
            SqlParameter pSchoolName = new SqlParameter("@SchoolName", SchoolName);
            DataTable tb = DB.DAtable(sql, pSchoolName);
            List<InternationalSchool> lst = new List<InternationalSchool>();
            foreach (DataRow r in tb.Rows)
            {
                InternationalSchool InS = new InternationalSchool();
                InS.SchoolID = (int)r["SchoolID"];
                InS.SchoolName = (string.IsNullOrEmpty(r["SchoolName"].ToString())) ? "" : (string)r["SchoolName"];
                InS.SchoolAddress = (string.IsNullOrEmpty(r["SchoolAddress"].ToString())) ? "" : (string)r["SchoolAddress"];
                InS.WebSite = (string.IsNullOrEmpty(r["WebSite"].ToString())) ? "" : (string)r["WebSite"];
                InS.SchoolLvl = (string.IsNullOrEmpty(r["SchoolLvl"].ToString())) ? "" : (string)r["SchoolLvl"];
                InS.AboutLink = (string.IsNullOrEmpty(r["AboutLink"].ToString())) ? "" : (string)r["AboutLink"];
                InS.CountryID = (string.IsNullOrEmpty(r["CountryID"].ToString())) ? 0 : (int)r["CountryID"];
                InS.ProvinceID = (string.IsNullOrEmpty(r["ProvinceID"].ToString())) ? 0 : (int)r["ProvinceID"];
                InS.DistrictID = (string.IsNullOrEmpty(r["DistrictID"].ToString())) ? 0 : (int)r["DistrictID"];
                InS.GoogleMap = (string.IsNullOrEmpty(r["GoogleMap"].ToString())) ? "" : (string)r["GoogleMap"];
                InS.Phone = (string.IsNullOrEmpty(r["Phone"].ToString())) ? "" : (string)r["Phone"];
                InS.Establish = (string.IsNullOrEmpty(r["Establish"].ToString())) ? DefaultBirthday : (DateTime)r["Establish"];
                InS.HocPhi = (string.IsNullOrEmpty(r["HocPhi"].ToString())) ? "" : (string)r["HocPhi"];
                InS.PhiKhac = (string.IsNullOrEmpty(r["PhiKhac"].ToString())) ? "" : (string)r["PhiKhac"];
                InS.DatCoc = (string.IsNullOrEmpty(r["DatCoc"].ToString())) ? "" : (string)r["DatCoc"];
                InS.DieuKienNhapHoc = (string.IsNullOrEmpty(r["DieuKienNhapHoc"].ToString())) ? "" : (string)r["DieuKienNhapHoc"];
                InS.HocBong = (string.IsNullOrEmpty(r["HocBong"].ToString())) ? "" : (string)r["HocBong"];
                InS.Images = (string.IsNullOrEmpty(r["Images"].ToString())) ? 0 : (int)r["Images"];
                InS.ChuyenNganhNoiBat = (string.IsNullOrEmpty(r["ChuyenNganhNoiBat"].ToString())) ? "" : (string)r["ChuyenNganhNoiBat"];
                lst.Add(InS);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetTbInternationalSchool()
        {
            string sql = "select * from InternationalSchool ins full outer join Country ct on ins.CountryID=ct.CountryID where ins.SchoolID is not null";
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
            string sql = "select * from InternationalSchool ins full outer join Country ct on ins.CountryID=ct.CountryID where ins.SchoolID is not null and ins.CountryID=@countryID";
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
            string sql = "select * from InternationalSchool ins full outer join Country ct on ins.CountryID=ct.CountryID where ins.SchoolID is not null and ins.SchoolLvl like '%' + @SchoolLvl + '%'";
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

        // New 
        public Boolean NewInternationalSchool(string SchoolName, string SchoolAddress, string WebSite, string SchoolLvl, string AboutLink, int CountryID, int ProvinceID, int DistrictID, string GoogleMap, string Phone, DateTime Establish, string HocPhi, string PhiKhac, string DatCoc, string DieuKienNhapHoc, string HocBong, string ChuyenNganhNoiBat)
        {
            string sql = "Exec NewInternationalSchool @SchoolName,@SchoolAddress,@WebSite,@SchoolLvl,@AboutLink,@CountryID,@ProvinceID,@DistrictID,@GoogleMap,@Phone,@Establish,@HocPhi,@PhiKhac,@DatCoc,@DieuKienNhapHoc,@HocBong,@ChuyenNganhNoiBat";
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pSchoolName = new SqlParameter("@SchoolName", SchoolName);
            SqlParameter pSchoolAddress = (SchoolAddress == "") ? new SqlParameter("@SchoolAddress", DBNull.Value) : new SqlParameter("@SchoolAddress", SchoolAddress);
            SqlParameter pWebSite = (WebSite == "") ? new SqlParameter("@WebSite", DBNull.Value) : new SqlParameter("@WebSite", WebSite);
            SqlParameter pSchoolLvl = new SqlParameter("@SchoolLvl", SchoolLvl);
            SqlParameter pAboutLink = (AboutLink == "") ? new SqlParameter("@AboutLink", DBNull.Value) : new SqlParameter("@AboutLink", AboutLink);
            SqlParameter pCountryID = (CountryID == 0) ? new SqlParameter("@CountryID", DBNull.Value) : new SqlParameter("@CountryID", CountryID);
            SqlParameter pProvinceID = (ProvinceID == 0) ? new SqlParameter("@ProvinceID", DBNull.Value) : new SqlParameter("@ProvinceID", ProvinceID);
            SqlParameter pDistrictID = (DistrictID == 0) ? new SqlParameter("@DistrictID", DBNull.Value) : new SqlParameter("@DistrictID", DistrictID);
            SqlParameter pGoogleMap = (GoogleMap == "") ? new SqlParameter("@GoogleMap", DBNull.Value) : new SqlParameter("@GoogleMap", GoogleMap);
            SqlParameter pPhone = (Phone == "") ? new SqlParameter("@Phone", DBNull.Value) : new SqlParameter("@Phone", Phone);
            SqlParameter pEstablish = (Establish.Year <= 1900) ? new SqlParameter("@Establish", DBNull.Value) : new SqlParameter("@Establish", Establish);
            SqlParameter pHocPhi = (HocPhi == "") ? new SqlParameter("@HocPhi", DBNull.Value) : new SqlParameter("@HocPhi", HocPhi);
            SqlParameter pPhiKhac = (PhiKhac == "") ? new SqlParameter("@PhiKhac", DBNull.Value) : new SqlParameter("@PhiKhac", PhiKhac);
            SqlParameter pDatCoc = (DatCoc == "") ? new SqlParameter("@DatCoc", DBNull.Value) : new SqlParameter("@DatCoc", DatCoc);
            SqlParameter pDieuKienNhapHoc = new SqlParameter("@DieuKienNhapHoc", DieuKienNhapHoc);
            SqlParameter pHocBong = (HocBong == "") ? new SqlParameter("@HocBong", DBNull.Value) : new SqlParameter("@HocBong", HocBong);
            SqlParameter pChuyenNganhNoiBat = (ChuyenNganhNoiBat == "") ? new SqlParameter("@ChuyenNganhNoiBat", DBNull.Value) : new SqlParameter("@ChuyenNganhNoiBat", ChuyenNganhNoiBat);
            this.DB.Updatedata(sql, pSchoolName, pSchoolAddress, pWebSite, pSchoolLvl, pAboutLink, pCountryID, pProvinceID, pDistrictID, pGoogleMap, pPhone, pEstablish, pHocPhi, pPhiKhac, pDatCoc, pDieuKienNhapHoc, pHocBong, pChuyenNganhNoiBat);
            this.DB.CloseConnection();
            return true;
        }
        //UPDATE
        public Boolean UpdateInternationalSchool(int SchoolID, string SchoolName, string SchoolAddress, string WebSite, string SchoolLvl, string AboutLink, int CountryID, int ProvinceID, int DistrictID, string GoogleMap, string Phone, DateTime Establish, string HocPhi, string PhiKhac, string DatCoc, string DieuKienNhapHoc, string HocBong, string ChuyenNganhNoiBat)
        {
            string sql = "Exec UpdateInternationalSchool @SchoolID,@SchoolName,@SchoolAddress,@WebSite,@SchoolLvl,@AboutLink,@CountryID,@ProvinceID,@DistrictID,@GoogleMap,@Phone,@Establish,@HocPhi,@PhiKhac,@DatCoc,@DieuKienNhapHoc,@HocBong,@ChuyenNganhNoiBat";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pSchoolID = new SqlParameter("@SchoolID", SchoolID);
            SqlParameter pSchoolName = new SqlParameter("@SchoolName", SchoolName);
            SqlParameter pSchoolAddress = (SchoolAddress == "") ? new SqlParameter("@SchoolAddress", DBNull.Value) : new SqlParameter("@SchoolAddress", SchoolAddress);
            SqlParameter pWebSite = (WebSite == "") ? new SqlParameter("@WebSite", DBNull.Value) : new SqlParameter("@WebSite", WebSite);
            SqlParameter pSchoolLvl = new SqlParameter("@SchoolLvl", SchoolLvl);
            SqlParameter pAboutLink = (AboutLink == "") ? new SqlParameter("@AboutLink", DBNull.Value) : new SqlParameter("@AboutLink", AboutLink);
            SqlParameter pCountryID = (CountryID == 0) ? new SqlParameter("@CountryID", DBNull.Value) : new SqlParameter("@CountryID", CountryID);
            SqlParameter pProvinceID = (ProvinceID == 0) ? new SqlParameter("@ProvinceID", DBNull.Value) : new SqlParameter("@ProvinceID", ProvinceID);
            SqlParameter pDistrictID = (DistrictID == 0) ? new SqlParameter("@DistrictID", DBNull.Value) : new SqlParameter("@DistrictID", DistrictID);
            SqlParameter pGoogleMap = (GoogleMap == "") ? new SqlParameter("@GoogleMap", DBNull.Value) : new SqlParameter("@GoogleMap", GoogleMap);
            SqlParameter pPhone = (Phone == "") ? new SqlParameter("@Phone", DBNull.Value) : new SqlParameter("@Phone", Phone);
            SqlParameter pEstablish = (Establish.Year <= 1900) ? new SqlParameter("@Establish", DBNull.Value) : new SqlParameter("@Establish", Establish);
            SqlParameter pHocPhi = (HocPhi == "") ? new SqlParameter("@HocPhi", DBNull.Value) : new SqlParameter("@HocPhi", HocPhi);
            SqlParameter pPhiKhac = (PhiKhac == "") ? new SqlParameter("@PhiKhac", DBNull.Value) : new SqlParameter("@PhiKhac", PhiKhac);
            SqlParameter pDatCoc = (DatCoc == "") ? new SqlParameter("@DatCoc", DBNull.Value) : new SqlParameter("@DatCoc", DatCoc);
            SqlParameter pDieuKienNhapHoc = new SqlParameter("@DieuKienNhapHoc", DieuKienNhapHoc);
            SqlParameter pHocBong = (HocBong == "") ? new SqlParameter("@HocBong", DBNull.Value) : new SqlParameter("@HocBong", HocBong);
            SqlParameter pChuyenNganhNoiBat = (ChuyenNganhNoiBat == "") ? new SqlParameter("@ChuyenNganhNoiBat", DBNull.Value) : new SqlParameter("@ChuyenNganhNoiBat", ChuyenNganhNoiBat);
            this.DB.Updatedata(sql, pSchoolID, pSchoolName, pSchoolAddress, pWebSite, pSchoolLvl, pAboutLink, pCountryID, pProvinceID, pDistrictID, pGoogleMap, pPhone, pEstablish, pHocPhi, pPhiKhac, pDatCoc, pDieuKienNhapHoc, pHocBong, pChuyenNganhNoiBat);
            this.DB.CloseConnection();
            return true;
        }
        // InternationalSchoolPageWise
        public DataTable InternationalSchoolPageWise(int PageIndex, int PageSize)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec InternationalSchoolPageWise @PageIndex,@PageSize";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountInternationalSchoolPageWise()
        {
            int count = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from InternationalSchool";
            count = DB.GetValues(sql);
            this.DB.CloseConnection();
            return count;
        }
        //Search InternationalSchool
        public DataTable SearchInternationalSchoolPageWise(int PageIndex, int PageSize, string keysearch)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec SearchInternationalSchoolPageWise @PageIndex,@PageSize,@keysearch";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            SqlParameter pkeysearch = (keysearch == "") ? new SqlParameter("@keysearch", DBNull.Value) : new SqlParameter("@keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountSearchInternationalSchoolPageWise(string keysearch)
        {
            int count = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from InternationalSchool where SchoolName like '%'+@keysearch+'%'";
            SqlParameter pkeysearch = (keysearch == "") ? new SqlParameter("@keysearch", DBNull.Value) : new SqlParameter("@keysearch", keysearch);
            count = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return count;
        }
        //Update Images
        public Boolean UpdateImages(int Images, int SchoolID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Update InternationalSchool set Images=@Images where SchoolID=@SchoolID";
            SqlParameter pImages = new SqlParameter("@Images", Images);
            SqlParameter pSchoolID = new SqlParameter("@SchoolID", SchoolID);
            this.DB.Updatedata(sql, pImages, pSchoolID);
            this.DB.CloseConnection();
            return true;
        }

    }
}
