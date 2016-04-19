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
    public class REGISTRATION_FORM_ADVISORY_BLL
    {
        DataServices DB = new DataServices();
        DateTime DefaultBirthday = Convert.ToDateTime("12/12/1900");
        public List<REGISTRATION_FORM_ADVISORY> getREGISTRATION_FORM_ADVISORY_WithId(int advID)
        {
            string sql = "select * from REGISTRATION_FORM_ADVISORY where RegistrationID=@advID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter padvID = new SqlParameter("advID", advID);
            DataTable tb = DB.DAtable(sql,padvID);
            List<REGISTRATION_FORM_ADVISORY> lst = new List<REGISTRATION_FORM_ADVISORY>();
            foreach(DataRow r in tb.Rows)
            {
                REGISTRATION_FORM_ADVISORY rf = new REGISTRATION_FORM_ADVISORY();
                rf.CountryAdvisoryID = (int)r[0];
                rf.FullName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                rf.CountryID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                rf.ProvinceID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                rf.DistrictID = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                rf.Address_form = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                rf.Birthday =(string.IsNullOrEmpty(r[6].ToString()))?DefaultBirthday: (DateTime)r[6];
                rf.Sex = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                rf.Phone = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                rf.Email = (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                rf.TypeID = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                rf.StudyLV = (string.IsNullOrEmpty(r[11].ToString())) ? 0 : (int)r[11];
                rf.CountryAdvisoryID = (string.IsNullOrEmpty(r[12].ToString())) ? 0 : (int)r[12];
                rf.ContentAdvisory = (string.IsNullOrEmpty(r[13].ToString())) ? "" : (string)r[13];
                rf.DateOfCreate = (DateTime)r[14];
                rf.Status_form = (int)r[15];
                rf.UserAdvisory = (string.IsNullOrEmpty(r[16].ToString())) ? 0 : (int)r[16];
                rf.FF = (int)r[17];
                rf.ProgressForm = (string.IsNullOrEmpty(r[18].ToString())) ? 0 : (int)r[18];
                lst.Add(rf);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean NewCustomerAdvisory (string fullname, int countryID, int provinceId, int districtId, string address, DateTime bitrhday, int sex, string phone, string email, int typeId, int studyLv, int countryAdsId, string content, int status, int FF, int ProgressForm)
        {
            string sql = "Exec NewCustomerAdvisory @fullname,@countryID,@provinceId,@districtId,@address,@bitrhday,@sex,@phone,@email,@typeId,@studyLv,@countryAdsId,@content,@status, @FF, @ProgressForm";
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            int year = bitrhday.Year;
            SqlParameter pfullname = new SqlParameter("fullname", fullname);
            SqlParameter pcountryID =(countryID==0)? new SqlParameter("countryID", DBNull.Value) : new SqlParameter("countryID", countryID);
            SqlParameter pprovinceId =(provinceId==0)? new SqlParameter("provinceId", DBNull.Value) : new SqlParameter("provinceId", provinceId);
            SqlParameter pdistrictId =(districtId==0)? new SqlParameter("districtId", DBNull.Value) : new SqlParameter("districtId", districtId);
            SqlParameter paddress = new SqlParameter("address", address);
            SqlParameter pbitrhday =(year<=1990)? new SqlParameter("bitrhday", DBNull.Value) : new SqlParameter("bitrhday", bitrhday);
            SqlParameter psex =(sex==0)? new SqlParameter("sex", DBNull.Value) : new SqlParameter("sex", sex);
            SqlParameter pphone = new SqlParameter("phone", phone);
            SqlParameter pemail = new SqlParameter("email", email);
            SqlParameter ptypeId =(typeId==0)? new SqlParameter("typeId", DBNull.Value) : new SqlParameter("typeId", typeId);
            SqlParameter pstudyLv =(studyLv==0)? new SqlParameter("studyLv", DBNull.Value) : new SqlParameter("studyLv", studyLv);
            SqlParameter pcountryAdsId = (countryAdsId == 0) ? new SqlParameter("countryAdsId", DBNull.Value) : new SqlParameter("countryAdsId", countryAdsId);
            SqlParameter pcontent = new SqlParameter("content", content);
            SqlParameter pstatus = new SqlParameter("status", status);
            SqlParameter pFF = new SqlParameter("FF", FF);
            SqlParameter pProgressForm = new SqlParameter("ProgressForm", ProgressForm);
            this.DB.Updatedata(sql, pfullname, pcountryID, pprovinceId, pdistrictId, paddress, pbitrhday, psex, pphone, pemail, ptypeId, pstudyLv, pcountryAdsId, pcontent, pstatus , pFF, pProgressForm);
            this.DB.CloseConnection();
            return true;
        }
        public int CountNew()
        {
            int count = 0;
            string sql = "select COUNT(*) from REGISTRATION_FORM_ADVISORY where Status_form=0";
            if(!this.DB.OpenConnection())
            {
                return 0;
            }
            count = this.DB.GetValues(sql);
            this.DB.CloseConnection();
            return count;
        }
        public int CountRecordForm_Advisory()
        {
            int rc = 0;
            string sql = "select count(*) from REGISTRATION_FORM_ADVISORY where Status_form=0";
            if (!this.DB.OpenConnection())
            {
                rc = 0;
            }
            rc = DB.GetValues(sql);
            this.DB.CloseConnection();
            return rc;
        }
        public DataTable GetForm_AdvisoryPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec GetForm_AdvisoryPageWise @PageIndex,@PageSize";
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
        public DataTable SearchDLForm_AdvisoryPageWise(int PageIndex, int PageSize, int type, int eduLv, int coutryAdv)
        {
            string sql = "Exec SearchDLForm_AdvisoryPageWise @PageIndex,@PageSize,@type,@eduLv,@coutryAdv";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter ptype = new SqlParameter("type", type);
            SqlParameter peduLv = new SqlParameter("eduLv", eduLv);
            SqlParameter pcoutryAdv = new SqlParameter("coutryAdv", coutryAdv);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, ptype, peduLv, pcoutryAdv);
            this.DB.CloseConnection();
            return tb;
        }
        public int Count_SearchDLForm_AdvisoryPageWise(int type, int eduLv, int coutryAdv)
        {
            int RC = 0;
            string sql = "select COUNT(*)  from REGISTRATION_FORM_ADVISORY where (TypeID=@type or StudyLV=@eduLv or CountryAdvisoryID=@coutryAdv) and Status_form=0";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter ptype = new SqlParameter("type", type);
            SqlParameter peduLv = new SqlParameter("eduLv", eduLv);
            SqlParameter pcoutryAdv = new SqlParameter("coutryAdv", coutryAdv);
            RC= DB.GetValues(sql, ptype, peduLv, pcoutryAdv);
            this.DB.CloseConnection();
            return RC;
        }

        //======SEARCH KEY=======================================================================================================
        public DataTable SearchKey_DL_Form_AdvisoryPageWise(int PageIndex, int PageSize, string keysearch)
        {
            string sql = "Exec SearchKey_DL_Form_AdvisoryPageWise @PageIndex,@PageSize,@keysearch";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public int Count_SearchKey_DL_Form_AdvisoryPageWise(string keysearch)
        {
            int RC = 0;
            string sql = "select COUNT(*)  from REGISTRATION_FORM_ADVISORY where (FullName like '%'+@keysearch+'%') and Status_form=0";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            RC = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return RC;
        }
        //=======Update Form_Advisory==================================================================================================


        public Boolean Update_Form_Advisory(int AdvisoryID, string fullname, int countryID, int provinceId, int districtId, string address, DateTime bitrhday, int sex, string phone, string email, int typeId, int studyLv, int countryAdsId, string content)
        {
            string sql = "Exec Update_Form_Advisory @AdvisoryID, @fullname,@countryID,@provinceId,@districtId,@address,@bitrhday,@sex,@phone,@email,@typeId,@studyLv,@countryAdsId,@content";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int year = bitrhday.Year;
            SqlParameter pAdvisoryID = new SqlParameter("AdvisoryID", AdvisoryID);
            SqlParameter pfullname = new SqlParameter("fullname", fullname);
            SqlParameter pcountryID = (countryID == 0) ? new SqlParameter("countryID", DBNull.Value) : new SqlParameter("countryID", countryID);
            SqlParameter pprovinceId = (provinceId == 0) ? new SqlParameter("provinceId", DBNull.Value) : new SqlParameter("provinceId", provinceId);
            SqlParameter pdistrictId = (districtId == 0) ? new SqlParameter("districtId", DBNull.Value) : new SqlParameter("districtId", districtId);
            SqlParameter paddress = new SqlParameter("address", address);
            SqlParameter pbitrhday = (year <= 1990) ? new SqlParameter("bitrhday", DBNull.Value) : new SqlParameter("bitrhday", bitrhday);
            SqlParameter psex = (sex == 0) ? new SqlParameter("sex", DBNull.Value) : new SqlParameter("sex", sex);
            SqlParameter pphone = new SqlParameter("phone", phone);
            SqlParameter pemail = new SqlParameter("email", email);
            SqlParameter ptypeId = (typeId == 0) ? new SqlParameter("typeId", DBNull.Value) : new SqlParameter("typeId", typeId);
            SqlParameter pstudyLv = (studyLv == 0) ? new SqlParameter("studyLv", DBNull.Value) : new SqlParameter("studyLv", studyLv);
            SqlParameter pcountryAdsId = (countryAdsId == 0) ? new SqlParameter("countryAdsId", DBNull.Value) : new SqlParameter("countryAdsId", countryAdsId);
            SqlParameter pcontent = new SqlParameter("content", content);
            this.DB.Updatedata(sql, pAdvisoryID, pfullname, pcountryID, pprovinceId, pdistrictId, paddress, pbitrhday, psex, pphone, pemail, ptypeId, pstudyLv, pcountryAdsId, pcontent);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdateUserAdvisory(int UserId,int RegisID)
        {
            string sql = "Update REGISTRATION_FORM_ADVISORY set UserAdvisory=@UserId, Status_form=1  where RegistrationID=@RegisID";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pUserId = new SqlParameter("UserId", UserId);
            SqlParameter pRegisID = new SqlParameter("RegisID", RegisID);
            this.DB.Updatedata(sql, pUserId, pRegisID);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean DeleteAdvisory(int RegisID)
        {
            string sql = "delete from REGISTRATION_FORM_ADVISORY where RegistrationID=@RegisID";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pRegisID = new SqlParameter("RegisID", RegisID);
            this.DB.Updatedata(sql, pRegisID);
            this.DB.CloseConnection();
            return true;
        }
        //=======CHECK FORM==========================================================
        public DataTable GetCheckForm_AdvisoryPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec GetCheckForm_AdvisoryPageWise @PageIndex,@PageSize";
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
        public int CountCheckRecordForm_Advisory()
        {
            int rc = 0;
            string sql = "select count(*) from REGISTRATION_FORM_ADVISORY where Status_form=1";
            if (!this.DB.OpenConnection())
            {
                rc = 0;
            }
            rc = DB.GetValues(sql);
            this.DB.CloseConnection();
            return rc;
        }

        public DataTable SearchCheckDLForm_AdvisoryPageWise(int PageIndex, int PageSize, int type, int eduLv, int coutryAdv)
        {
            string sql = "Exec SearchCheckDLForm_AdvisoryPageWise @PageIndex,@PageSize,@type,@eduLv,@coutryAdv";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter ptype = new SqlParameter("type", type);
            SqlParameter peduLv = new SqlParameter("eduLv", eduLv);
            SqlParameter pcoutryAdv = new SqlParameter("coutryAdv", coutryAdv);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, ptype, peduLv, pcoutryAdv);
            this.DB.CloseConnection();
            return tb;
        }
        public int Count_SearchCheckDLForm_AdvisoryPageWise(int type, int eduLv, int coutryAdv)
        {
            int RC = 0;
            string sql = "select COUNT(*)  from REGISTRATION_FORM_ADVISORY where (TypeID=@type or StudyLV=@eduLv or CountryAdvisoryID=@coutryAdv) and Status_form=1";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter ptype = new SqlParameter("type", type);
            SqlParameter peduLv = new SqlParameter("eduLv", eduLv);
            SqlParameter pcoutryAdv = new SqlParameter("coutryAdv", coutryAdv);
            RC = DB.GetValues(sql, ptype, peduLv, pcoutryAdv);
            this.DB.CloseConnection();
            return RC;
        }
        public DataTable SearchKey_CheckDL_Form_AdvisoryPageWise(int PageIndex, int PageSize, string keysearch)
        {
            string sql = "Exec SearchKey_CheckDL_Form_AdvisoryPageWise @PageIndex,@PageSize,@keysearch";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public int Count_SearchCheckKey_DL_Form_AdvisoryPageWise(string keysearch)
        {
            int RC = 0;
            string sql = "select COUNT(*)  from REGISTRATION_FORM_ADVISORY where (FullName like '%'+@keysearch+'%') and Status_form=1";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            RC = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return RC;
        }
        //=====================================================================================================
        public DataTable DLUserAdv_Form_AdvisoryPageWise(int PageIndex, int PageSize, int userAdv)
        {
            string sql = "Exec DLUserAdv_Form_AdvisoryPageWise @PageIndex,@PageSize,@userAdv";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter puserAdv = new SqlParameter("userAdv", userAdv);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, puserAdv);
            this.DB.CloseConnection();
            return tb;
        }
        public int Count_DLUserAdv_Form_AdvisoryPageWise(int userAdv)
        {
            int RC = 0;
            string sql = "select COUNT(*)  from REGISTRATION_FORM_ADVISORY where UserAdvisory=@userAdv and Status_form=1";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter puserAdv = new SqlParameter("userAdv", userAdv);
            RC = DB.GetValues(sql, puserAdv);
            this.DB.CloseConnection();
            return RC;
        }
        //=====USER SEARCH KEY===========================================================================================================
        public DataTable SearchKey_Emp_Form_AdvisoryPageWise(int PageIndex, int PageSize, string keysearch, int empId)
        {
            string sql = "Exec SearchKey_Emp_Form_AdvisoryPageWise @PageIndex,@PageSize,@keysearch,@empId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            SqlParameter pempId = new SqlParameter("empId", empId);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pkeysearch, pempId);
            this.DB.CloseConnection();
            return tb;
        }
        public int Count_Emp_Form_AdvisoryPageWise(string keysearch, int empId)
        {
            int RC = 0;
            string sql = "select COUNT(*) from REGISTRATION_FORM_ADVISORY where (FullName like '%'+@keysearch+'%' ) and Status_form=1 and UserAdvisory=@empId";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            SqlParameter pempId = new SqlParameter("empId", empId);
            RC = DB.GetValues(sql, pkeysearch, pempId);
            this.DB.CloseConnection();
            return RC;
        }
        //======SEARCH MORE DL================================================================================================
        public DataTable SearchMore_Emp_Form_AdvisoryPageWise(int PageIndex, int PageSize, int type, int eduLv, int coutryAdv, int empId)
        {
            string sql = "Exec SearchMore_Emp_Form_AdvisoryPageWise @PageIndex,@PageSize,@type,@eduLv,@coutryAdv,@empId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter ptype = new SqlParameter("type", type);
            SqlParameter peduLv = new SqlParameter("eduLv", eduLv);
            SqlParameter pcoutryAdv = new SqlParameter("coutryAdv", coutryAdv);
            SqlParameter pempId = new SqlParameter("empId", empId);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, ptype, peduLv, pcoutryAdv, pempId);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountMoreEmpForm_AdvisoryPageWise(int type, int eduLv, int coutryAdv, int empId)
        {
            int RC = 0;
            string sql = "select COUNT(*)  from REGISTRATION_FORM_ADVISORY where (TypeID=@type or StudyLV=@eduLv or CountryAdvisoryID=@coutryAdv) and Status_form=1 and UserAdvisory=@empId";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter ptype = new SqlParameter("type", type);
            SqlParameter peduLv = new SqlParameter("eduLv", eduLv);
            SqlParameter pcoutryAdv = new SqlParameter("coutryAdv", coutryAdv);
            SqlParameter pempId = new SqlParameter("empId", empId);
            RC = DB.GetValues(sql, ptype, peduLv, pcoutryAdv, pempId);
            this.DB.CloseConnection();
            return RC;
        }
        //======Filter Progress============================================================================================================
        public DataTable FilterProgress_Form_AdvisoryPageWise(int PageIndex, int PageSize, int ProgressForm, int empId)
        {
            string sql = "Exec FilterProgress_Form_AdvisoryPageWise @PageIndex,@PageSize,@ProgressForm,@empId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pProgressForm = new SqlParameter("ProgressForm", ProgressForm);
            SqlParameter pempId = new SqlParameter("empId", empId);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pProgressForm, pempId);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountFilterProgress_AdvisoryPageWise(int ProgressForm, int empId)
        {
            int RC = 0;
            string sql = "select COUNT(*) from REGISTRATION_FORM_ADVISORY where UserAdvisory=@empId and Status_form=1 and ProgressForm=@ProgressForm";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pProgressForm = new SqlParameter("ProgressForm", ProgressForm);
            SqlParameter pempId = new SqlParameter("empId", empId);
            RC = DB.GetValues(sql, pProgressForm, pempId);
            this.DB.CloseConnection();
            return RC;
        }
        //======check Filter Progress============================================================================================================
        public DataTable CheckFilterProgress_Form_AdvisoryPageWise(int PageIndex, int PageSize, int ProgressForm)
        {
            string sql = "Exec CheckFilterProgress_Form_AdvisoryPageWise @PageIndex,@PageSize,@ProgressForm";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pProgressForm = new SqlParameter("ProgressForm", ProgressForm);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pProgressForm);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountCheckFilterProgress_AdvisoryPageWise(int ProgressForm)
        {
            int RC = 0;
            string sql = "select COUNT(*) from REGISTRATION_FORM_ADVISORY where Status_form=1 and ProgressForm=@ProgressForm";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pProgressForm = new SqlParameter("ProgressForm", ProgressForm);
            RC = DB.GetValues(sql, pProgressForm);
            this.DB.CloseConnection();
            return RC;
        }
        //======UPDATE PROGRESS=================================================================================================================
        public Boolean updateProgress(int progress, int regisId)
        {
            string sql = "update REGISTRATION_FORM_ADVISORY set ProgressForm=@progress where RegistrationID=@regisId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pprogress = new SqlParameter("progress", progress);
            SqlParameter pregisId = new SqlParameter("regisId", regisId);
            this.DB.Updatedata(sql, pprogress, pregisId);
            this.DB.CloseConnection();
            return true;
        }
        //=======SUM ===========================================================================================================================
        public int SumAdv(int UserAdv)
        {
            int RC = 0;
            string sql = "select COUNT(*) from REGISTRATION_FORM_ADVISORY where UserAdvisory=@UserAdv";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pUserAdv = new SqlParameter("UserAdv", UserAdv);
            RC = DB.GetValues(sql, pUserAdv);
            this.DB.CloseConnection();
            return RC;
        }
        public int SumAdvAsDAY(int UserAdv, string day)
        {
            int RC = 0;
            string sql = "select COUNT(*) from REGISTRATION_FORM_ADVISORY where UserAdvisory=@UserAdv and SUBSTRING(CONVERT(nvarchar(9),DateOfCreate, 112),7,2)=@day";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pUserAdv = new SqlParameter("UserAdv", UserAdv);
            SqlParameter pday = new SqlParameter("day", day);
            RC = DB.GetValues(sql, pUserAdv, pday);
            this.DB.CloseConnection();
            return RC;
        }
        public int SumAdvAsMONTH(int UserAdv, string month)
        {
            int RC = 0;
            string sql = "select COUNT(*) from REGISTRATION_FORM_ADVISORY where UserAdvisory=@UserAdv  and SUBSTRING(CONVERT(nvarchar(6),DateOfCreate, 112),5,2)=@month";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pUserAdv = new SqlParameter("UserAdv", UserAdv);
            SqlParameter pmonth = new SqlParameter("month", month);
            RC = DB.GetValues(sql, pUserAdv, pmonth);
            this.DB.CloseConnection();
            return RC;
        }
    }
}
