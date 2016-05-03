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
    public class CustomerProfilePrivateBLL
    {
        DataServices DB = new DataServices();
        DateTime DefaultBirthday = Convert.ToDateTime("12/12/1900");
        public List<CustomerProfilePrivate> GetCustomerProfilePrivateWithInfoID(int InfoID)
        {
            string sql = "select * from CustomerProfilePrivate where InfoID=@InfoID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            DataTable tb = DB.DAtable(sql, pInfoID);
            List<CustomerProfilePrivate> lst = new List<CustomerProfilePrivate>();
            foreach (DataRow r in tb.Rows)
            {
                CustomerProfilePrivate cp = new CustomerProfilePrivate();
                cp.ProfileID = (int)r["ProfileID"];
                cp.ProfileCode = (string)r["ProfileCode"];
                cp.InfoID = (int)r["InfoID"];
                cp.UnitCopyright = (string.IsNullOrEmpty(r["UnitCopyright"].ToString())) ? "" : (string)r["UnitCopyright"];
                cp.StaffWork = (string.IsNullOrEmpty(r["StaffWork"].ToString())) ? 0 : (int)r["StaffWork"];
                cp.NationalityID = (string.IsNullOrEmpty(r["NationalityID"].ToString())) ? 0 : (int)r["NationalityID"];
                cp.EthnicID = (string.IsNullOrEmpty(r["EthnicID"].ToString())) ? 0 : (int)r["EthnicID"];
                cp.ReligionID = (string.IsNullOrEmpty(r["ReligionID"].ToString())) ? 0 : (int)r["ReligionID"];
                cp.CountryID = (string.IsNullOrEmpty(r["CountryID"].ToString())) ? 0 : (int)r["CountryID"];
                cp.ProvinceID = (string.IsNullOrEmpty(r["ProvinceID"].ToString())) ? 0 : (int)r["ProvinceID"];
                cp.DistrictID = (string.IsNullOrEmpty(r["DistrictID"].ToString())) ? 0 : (int)r["DistrictID"];
                cp.Commune_Ward = (string.IsNullOrEmpty(r["Commune_Ward"].ToString())) ? "" : (string)r["Commune_Ward"];
                cp.PermanentAddress = (string.IsNullOrEmpty(r["PermanentAddress"].ToString())) ? "" : (string)r["PermanentAddress"];
                cp.AddressPresent = (string.IsNullOrEmpty(r["AddressPresent"].ToString())) ? "" : (string)r["AddressPresent"];
                cp.CompanyPhone = (string.IsNullOrEmpty(r["CompanyPhone"].ToString())) ? "" : (string)r["CompanyPhone"];
                cp.HomePhone = (string.IsNullOrEmpty(r["HomePhone"].ToString())) ? "" : (string)r["HomePhone"];
                cp.CellPhone = (string.IsNullOrEmpty(r["CellPhone"].ToString())) ? "" : (string)r["CellPhone"];
                cp.Email = (string.IsNullOrEmpty(r["Email"].ToString())) ? "" : (string)r["Email"];
                cp.MaritalStatus = (string.IsNullOrEmpty(r["MaritalStatus"].ToString())) ? "" : (string)r["MaritalStatus"];
                cp.TPXuatThan = (string.IsNullOrEmpty(r["TPXuatThan"].ToString())) ? "" : (string)r["TPXuatThan"];
                cp.UuTienGD = (string.IsNullOrEmpty(r["UuTienGD"].ToString())) ? "" : (string)r["UuTienGD"];
                cp.UuTienBanThan = (string.IsNullOrEmpty(r["UuTienBanThan"].ToString())) ? "" : (string)r["UuTienBanThan"];
                cp.NangKhieu = (string.IsNullOrEmpty(r["NangKhieu"].ToString())) ? "" : (string)r["NangKhieu"];
                cp.Disability = (string.IsNullOrEmpty(r["Disability"].ToString())) ? "" : (string)r["Disability"];
                cp.HealthCondition = (string.IsNullOrEmpty(r["HealthCondition"].ToString())) ? "" : (string)r["HealthCondition"];
                cp.Height = (string.IsNullOrEmpty(r["Height"].ToString())) ? 0 : (int)r["Height"];
                cp.Weight = (string.IsNullOrEmpty(r["Weight"].ToString())) ? 0 : (int)r["Weight"];
                cp.BloodID = (string.IsNullOrEmpty(r["BloodID"].ToString())) ? 0 : (int)r["BloodID"];
                cp.DateOfBHXH = (string.IsNullOrEmpty(r["DateOfBHXH"].ToString())) ? DefaultBirthday : (DateTime)r["DateOfBHXH"];
                cp.NumOfBHXH = (string.IsNullOrEmpty(r["NumOfBHXH"].ToString())) ? "" : (string)r["NumOfBHXH"];
                cp.Bank = (string.IsNullOrEmpty(r["Bank"].ToString())) ? "" : (string)r["Bank"];
                cp.AccountNumber = (string.IsNullOrEmpty(r["AccountNumber"].ToString())) ? "" : (string)r["AccountNumber"];
                cp.ProfileImg = (string.IsNullOrEmpty(r["ProfileImg"].ToString())) ? 0 : (int)r["ProfileImg"];
                cp.DateOfCreate = (DateTime)r["DateOfCreate"];
                cp.ProfileStatus = (string.IsNullOrEmpty(r["ProfileStatus"].ToString())) ? 0 : (int)r["ProfileStatus"];
                cp.RegistrationID = (string.IsNullOrEmpty(r["RegistrationID"].ToString())) ? 0 : (int)r["RegistrationID"];
                cp.EmpFile = (string.IsNullOrEmpty(r["EmpFile"].ToString())) ? 0 : (int)r["EmpFile"];
                cp.BagProfileTypeID = (string.IsNullOrEmpty(r["BagProfileTypeID"].ToString())) ? 0 : (int)r["BagProfileTypeID"];
                cp.InternationalSchool = (string.IsNullOrEmpty(r["InternationalSchool"].ToString())) ? 0 : (int)r["InternationalSchool"];
                lst.Add(cp);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<CustomerProfilePrivate> GetCustomerProfilePrivateWithRegisID(int regisID)
        {
            string sql = "select * from CustomerProfilePrivate where RegistrationID=@regisID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pregisID = new SqlParameter("regisID", regisID);
            DataTable tb = DB.DAtable(sql, pregisID);
            List<CustomerProfilePrivate> lst = new List<CustomerProfilePrivate>();
            foreach (DataRow r in tb.Rows)
            {
                CustomerProfilePrivate cp = new CustomerProfilePrivate();
                cp.ProfileID = (int)r[0];
                cp.ProfileCode = (string)r[1];
                cp.InfoID = (int)r[2];
                cp.UnitCopyright = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                cp.StaffWork = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                cp.NationalityID = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                cp.EthnicID = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                cp.ReligionID = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                cp.CountryID = (string.IsNullOrEmpty(r[8].ToString())) ? 0 : (int)r[8];
                cp.ProvinceID = (string.IsNullOrEmpty(r[9].ToString())) ? 0 : (int)r[9];
                cp.DistrictID = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                cp.Commune_Ward = (string.IsNullOrEmpty(r[11].ToString())) ? "" : (string)r[11];
                cp.PermanentAddress = (string.IsNullOrEmpty(r[12].ToString())) ? "" : (string)r[12];
                cp.AddressPresent = (string.IsNullOrEmpty(r[13].ToString())) ? "" : (string)r[13];
                cp.CompanyPhone = (string.IsNullOrEmpty(r[14].ToString())) ? "" : (string)r[14];
                cp.HomePhone = (string.IsNullOrEmpty(r[15].ToString())) ? "" : (string)r[15];
                cp.CellPhone = (string.IsNullOrEmpty(r[16].ToString())) ? "" : (string)r[16];
                cp.Email = (string.IsNullOrEmpty(r[17].ToString())) ? "" : (string)r[17];
                cp.MaritalStatus = (string.IsNullOrEmpty(r[18].ToString())) ? "" : (string)r[18];
                cp.TPXuatThan = (string.IsNullOrEmpty(r[19].ToString())) ? "" : (string)r[19];
                cp.UuTienGD = (string.IsNullOrEmpty(r[20].ToString())) ? "" : (string)r[20];
                cp.UuTienBanThan = (string.IsNullOrEmpty(r[21].ToString())) ? "" : (string)r[21];
                cp.NangKhieu = (string.IsNullOrEmpty(r[22].ToString())) ? "" : (string)r[22];
                cp.Disability = (string.IsNullOrEmpty(r[23].ToString())) ? "" : (string)r[23];
                cp.HealthCondition = (string.IsNullOrEmpty(r[24].ToString())) ? "" : (string)r[24];
                cp.Height = (string.IsNullOrEmpty(r[25].ToString())) ? 0 : (int)r[25];
                cp.Weight = (string.IsNullOrEmpty(r[26].ToString())) ? 0 : (int)r[26];
                cp.BloodID = (string.IsNullOrEmpty(r[27].ToString())) ? 0 : (int)r[27];
                cp.DateOfBHXH = (string.IsNullOrEmpty(r[28].ToString())) ? DefaultBirthday : (DateTime)r[28];
                cp.NumOfBHXH = (string.IsNullOrEmpty(r[29].ToString())) ? "" : (string)r[29];
                cp.Bank = (string.IsNullOrEmpty(r[30].ToString())) ? "" : (string)r[30];
                cp.AccountNumber = (string.IsNullOrEmpty(r[31].ToString())) ? "" : (string)r[31];
                cp.ProfileImg = (string.IsNullOrEmpty(r[32].ToString())) ? 0 : (int)r[32];
                cp.DateOfCreate = (DateTime)r[33];
                cp.ProfileStatus = (string.IsNullOrEmpty(r[34].ToString())) ? 0 : (int)r[34];
                cp.RegistrationID = (string.IsNullOrEmpty(r[35].ToString())) ? 0 : (int)r[35];
                cp.EmpFile = (string.IsNullOrEmpty(r[36].ToString())) ? 0 : (int)r[36];
                cp.BagProfileTypeID = (string.IsNullOrEmpty(r[37].ToString())) ? 0 : (int)r[37];
                cp.InternationalSchool = (string.IsNullOrEmpty(r[38].ToString())) ? 0 : (int)r[38];
                lst.Add(cp);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<CustomerProfilePrivate> GetCustomerProfilePrivateWithProfileID(int ProfileID)
        {
            string sql = "select * from CustomerProfilePrivate where ProfileID=@ProfileID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pProfileID = new SqlParameter("ProfileID", ProfileID);
            DataTable tb = DB.DAtable(sql, pProfileID);
            List<CustomerProfilePrivate> lst = new List<CustomerProfilePrivate>();
            foreach (DataRow r in tb.Rows)
            {
                CustomerProfilePrivate cp = new CustomerProfilePrivate();
                cp.ProfileID = (int)r[0];
                cp.ProfileCode = (string)r[1];
                cp.InfoID = (int)r[2];
                cp.UnitCopyright = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                cp.StaffWork = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                cp.NationalityID = (string.IsNullOrEmpty(r[5].ToString())) ? 0 : (int)r[5];
                cp.EthnicID = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                cp.ReligionID = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                cp.CountryID = (string.IsNullOrEmpty(r[8].ToString())) ? 0 : (int)r[8];
                cp.ProvinceID = (string.IsNullOrEmpty(r[9].ToString())) ? 0 : (int)r[9];
                cp.DistrictID = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                cp.Commune_Ward = (string.IsNullOrEmpty(r[11].ToString())) ? "" : (string)r[11];
                cp.PermanentAddress = (string.IsNullOrEmpty(r[12].ToString())) ? "" : (string)r[12];
                cp.AddressPresent = (string.IsNullOrEmpty(r[13].ToString())) ? "" : (string)r[13];
                cp.CompanyPhone = (string.IsNullOrEmpty(r[14].ToString())) ? "" : (string)r[14];
                cp.HomePhone = (string.IsNullOrEmpty(r[15].ToString())) ? "" : (string)r[15];
                cp.CellPhone = (string.IsNullOrEmpty(r[16].ToString())) ? "" : (string)r[16];
                cp.Email = (string.IsNullOrEmpty(r[17].ToString())) ? "" : (string)r[17];
                cp.MaritalStatus = (string.IsNullOrEmpty(r[18].ToString())) ? "" : (string)r[18];
                cp.TPXuatThan = (string.IsNullOrEmpty(r[19].ToString())) ? "" : (string)r[19];
                cp.UuTienGD = (string.IsNullOrEmpty(r[20].ToString())) ? "" : (string)r[20];
                cp.UuTienBanThan = (string.IsNullOrEmpty(r[21].ToString())) ? "" : (string)r[21];
                cp.NangKhieu = (string.IsNullOrEmpty(r[22].ToString())) ? "" : (string)r[22];
                cp.Disability = (string.IsNullOrEmpty(r[23].ToString())) ? "" : (string)r[23];
                cp.HealthCondition = (string.IsNullOrEmpty(r[24].ToString())) ? "" : (string)r[24];
                cp.Height = (string.IsNullOrEmpty(r[25].ToString())) ? 0 : (int)r[25];
                cp.Weight = (string.IsNullOrEmpty(r[26].ToString())) ? 0 : (int)r[26];
                cp.BloodID = (string.IsNullOrEmpty(r[27].ToString())) ? 0 : (int)r[27];
                cp.DateOfBHXH = (string.IsNullOrEmpty(r[28].ToString())) ? DefaultBirthday : (DateTime)r[28];
                cp.NumOfBHXH = (string.IsNullOrEmpty(r[29].ToString())) ? "" : (string)r[29];
                cp.Bank = (string.IsNullOrEmpty(r[30].ToString())) ? "" : (string)r[30];
                cp.AccountNumber = (string.IsNullOrEmpty(r[31].ToString())) ? "" : (string)r[31];
                cp.ProfileImg = (string.IsNullOrEmpty(r[32].ToString())) ? 0 : (int)r[32];
                cp.DateOfCreate = (DateTime)r[33];
                cp.ProfileStatus = (string.IsNullOrEmpty(r[34].ToString())) ? 0 : (int)r[34];
                cp.RegistrationID = (string.IsNullOrEmpty(r[35].ToString())) ? 0 : (int)r[35];
                cp.EmpFile = (string.IsNullOrEmpty(r[36].ToString())) ? 0 : (int)r[36];
                cp.BagProfileTypeID = (string.IsNullOrEmpty(r[37].ToString())) ? 0 : (int)r[37];
                cp.InternationalSchool = (string.IsNullOrEmpty(r[38].ToString())) ? 0 : (int)r[38];
                lst.Add(cp);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean CreateBasicCustPri(int InfoID, int StaffWork, int RegistrationID)
        {
            string sql = "insert into CustomerProfilePrivate(InfoID,StaffWork,RegistrationID) values (@InfoID,@StaffWork,@RegistrationID)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            SqlParameter pStaffWork = new SqlParameter("StaffWork", StaffWork);
            SqlParameter pRegistrationID = (RegistrationID == 0) ? new SqlParameter("RegistrationID", DBNull.Value) : new SqlParameter("RegistrationID", RegistrationID);
            this.DB.Updatedata(sql, pInfoID, pStaffWork, pRegistrationID);
            this.DB.CloseConnection();
            return true;
        }
        //===Update Images====================
        public Boolean UpdateImages(int ProId, int ImagesId)
        {
            string sql = "update CustomerProfilePrivate set ProfileImg=@ImagesId where ProfileID=@ProId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pProId = new SqlParameter("ProId", ProId);
            SqlParameter pImagesId = new SqlParameter("ImagesId", ImagesId);
            this.DB.Updatedata(sql, pImagesId, pProId);
            this.DB.CloseConnection();
            return true;
        }
        //=====Update CustomerProfilePrivate==========================
        public Boolean UpdateCustomerProfilePrivate(int ProfileID, string UnitCopyright, int NationalityID, int EthnicID, int ReligionID, int CountryID, int ProvinceID, int DistrictID, string Commune_Ward, string PermanentAddress, string AddressPresent, string CompanyPhone, string HomePhone, string CellPhone, string Email, string MaritalStatus, string TPXuatThan, string UuTienGD, string UuTienBanThan, string NangKhieu, string Disability, string HealthCondition, int Height, int Weight, int BloodID, DateTime DateOfBHXH, string NumOfBHXH, string Bank, string AccountNumber, int ProfileStatus, int BagProfileTypeID)
        {
            string sql = "Exec UpdateCustomerProfilePrivate @ProfileID,@UnitCopyright,@NationalityID,@EthnicID,@ReligionID,@CountryID,@ProvinceID,@DistrictID,@Commune_Ward,@PermanentAddress,@AddressPresent,@CompanyPhone,@HomePhone,@CellPhone,@Email,@MaritalStatus,@TPXuatThan,@UuTienGD,@UuTienBanThan,@NangKhieu,@Disability,@HealthCondition,@Height,@Weight,@BloodID,@DateOfBHXH,@NumOfBHXH,@Bank,@AccountNumber,@ProfileStatus,@BagProfileTypeID";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int DOByear = DateOfBHXH.Year;
            SqlParameter pProfileID = new SqlParameter("ProfileID", ProfileID);
            SqlParameter pUnitCopyright = new SqlParameter("UnitCopyright", UnitCopyright);
            SqlParameter pNationalityID = (NationalityID == 0) ? new SqlParameter("NationalityID", DBNull.Value) : new SqlParameter("NationalityID", NationalityID);
            SqlParameter pEthnicID = (EthnicID == 0) ? new SqlParameter("EthnicID", DBNull.Value) : new SqlParameter("EthnicID", EthnicID);
            SqlParameter pReligionID = (ReligionID == 0) ? new SqlParameter("ReligionID", DBNull.Value) : new SqlParameter("ReligionID", ReligionID);
            SqlParameter pCountryID = (CountryID == 0) ? new SqlParameter("CountryID", DBNull.Value) : new SqlParameter("CountryID", CountryID);
            SqlParameter pProvinceID = (ProvinceID == 0) ? new SqlParameter("ProvinceID", DBNull.Value) : new SqlParameter("ProvinceID", ProvinceID);
            SqlParameter pDistrictID = (DistrictID == 0) ? new SqlParameter("DistrictID", DBNull.Value) : new SqlParameter("DistrictID", DistrictID);
            SqlParameter pCommune_Ward = new SqlParameter("Commune_Ward", Commune_Ward);
            SqlParameter pPermanentAddress = new SqlParameter("PermanentAddress", PermanentAddress);
            SqlParameter pAddressPresent = new SqlParameter("AddressPresent", AddressPresent);
            SqlParameter pCompanyPhone = new SqlParameter("CompanyPhone", CompanyPhone);
            SqlParameter pHomePhone = new SqlParameter("HomePhone", HomePhone);
            SqlParameter pCellPhone = new SqlParameter("CellPhone", CellPhone);
            SqlParameter pEmail = new SqlParameter("Email", Email);
            SqlParameter pMaritalStatus = new SqlParameter("MaritalStatus", MaritalStatus);
            SqlParameter pTPXuatThan = new SqlParameter("TPXuatThan", TPXuatThan);
            SqlParameter pUuTienGD = new SqlParameter("UuTienGD", UuTienGD);
            SqlParameter pUuTienBanThan = new SqlParameter("UuTienBanThan", UuTienBanThan);
            SqlParameter pNangKhieu = new SqlParameter("NangKhieu", NangKhieu);
            SqlParameter pDisability = new SqlParameter("Disability", Disability);
            SqlParameter pHealthCondition = new SqlParameter("HealthCondition", HealthCondition);
            SqlParameter pHeight = (Height == 0) ? new SqlParameter("Height", DBNull.Value) : new SqlParameter("Height", Height);
            SqlParameter pWeight = (Weight == 0) ? new SqlParameter("Weight", DBNull.Value) : new SqlParameter("Weight", Weight);
            SqlParameter pBloodID = (BloodID == 0) ? new SqlParameter("BloodID", DBNull.Value) : new SqlParameter("BloodID", BloodID);
            SqlParameter pDateOfBHXH = (DOByear <= 1900) ? new SqlParameter("DateOfBHXH", DBNull.Value) : new SqlParameter("DateOfBHXH", DateOfBHXH);
            SqlParameter pNumOfBHXH = new SqlParameter("NumOfBHXH", NumOfBHXH);
            SqlParameter pBank = new SqlParameter("Bank", Bank);
            SqlParameter pAccountNumber = new SqlParameter("AccountNumber", AccountNumber);
            SqlParameter pProfileStatus = new SqlParameter("ProfileStatus", ProfileStatus);
            SqlParameter pBagProfileTypeID = (BagProfileTypeID == 0) ? new SqlParameter("BagProfileTypeID", DBNull.Value) : new SqlParameter("BagProfileTypeID", BagProfileTypeID);
            this.DB.Updatedata(sql,
                pProfileID,
                pUnitCopyright,
                pNationalityID,
                pEthnicID,
                pReligionID,
                pCountryID,
                pProvinceID,
                pDistrictID,
                pCommune_Ward,
                pPermanentAddress,
                pAddressPresent,
                pCompanyPhone,
                pHomePhone,
                pCellPhone,
                pEmail,
                pMaritalStatus,
                pTPXuatThan,
                pUuTienGD,
                pUuTienBanThan,
                pNangKhieu,
                pDisability,
                pHealthCondition,
                pHeight,
                pWeight,
                pBloodID,
                pDateOfBHXH,
                pNumOfBHXH,
                pBank,
                pAccountNumber,
                pProfileStatus,
                pBagProfileTypeID);
            this.DB.CloseConnection();
            return true;
        }
        //=============================================================================================================
        public DataTable GetProfile_AdvisoryPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec GetProfile_AdvisoryPageWise @PageIndex,@PageSize";
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
        public int CountProfile_AdvisoryPageWisee()
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=1";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        //==========SEARCH KEY===================================================================================================
        public DataTable GetProfile_AdvisorySearchKeyPageWise(int PageIndex, int PageSize, string keysearch)
        {
            string sql = "Exec GetProfile_AdvisorySearchKeyPageWise @PageIndex,@PageSize,@keysearch";
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
        public int Count_GetProfile_AdvisorySearchKeyPageWise(string keysearch)
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID join Employees emp on cr.StaffWork=emp.EmployeesID where  cr.ProfileStatus=1 and (cb.LastName +' ' + cb.FirstName) like '%'+@keysearch+'%'";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            RC = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return RC;
        }
        //======UPDATE EMP=============================================================================================================
        public Boolean UpdateEmpFile(int ProId, int ProStatus, int empId)
        {
            string sql = "Update CustomerProfilePrivate set EmpFile=@empId, ProfileStatus=@ProStatus  where ProfileID=@ProId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pProId = new SqlParameter("ProId", ProId);
            SqlParameter pProStatus = new SqlParameter("ProStatus", ProStatus);
            SqlParameter pempId = new SqlParameter("empId", empId);
            this.DB.Updatedata(sql, pProId, pProStatus, pempId);
            this.DB.CloseConnection();
            return true;
        }
        //====GET GetCheckProfile_AdvisoryPageWise=========================================================================================================================
        public DataTable GetCheckProfile_AdvisoryPageWise(int PageIndex, int PageSize)
        {
            string sql = "Exec GetCheckProfile_AdvisoryPageWise @PageIndex,@PageSize";
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
        public int CountGetCheckProfile_AdvisoryPageWise()
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=2";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            RC = DB.GetValues(sql);
            this.DB.CloseConnection();
            return RC;
        }
        //====GET GetCheckKeyProfile_AdvisoryPageWise===================================================================================================
        public DataTable GetCheckKeyProfile_AdvisoryPageWise(int PageIndex, int PageSize, string keysearch)
        {
            string sql = "Exec GetCheckKeyProfile_AdvisoryPageWise @PageIndex,@PageSize,@keysearch";
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
        public int CountGetCheckKeyProfile_AdvisoryPageWise(string keysearch)
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=2 and (cb.LastName +' ' + cb.FirstName) like '%'+@keysearch+'%'";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            RC = DB.GetValues(sql, pkeysearch);
            this.DB.CloseConnection();
            return RC;
        }
        //=====GET GetThuLyHoSoPageWise===========================================================================================================================================
        public DataTable GetThuLyHoSoPageWise(int PageIndex, int PageSize, int EmpId)
        {
            string sql = "Exec GetThuLyHoSoPageWise @PageIndex,@PageSize,@EmpId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pEmpId);
            this.DB.CloseConnection();
            return tb;
        }
        public int CounThuLyHoSoPageWise(int EmpId)
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=2 and cr.EmpFile=@EmpId";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            RC = DB.GetValues(sql, pEmpId);
            this.DB.CloseConnection();
            return RC;
        }
        //=======  GET GetThuLyHoSoTypePageWise=======================================================================================================
        public DataTable GetThuLyHoSoTypePageWise(int PageIndex, int PageSize, int EmpId, int bagtype)
        {
            string sql = "Exec GetThuLyHoSoTypePageWise @PageIndex,@PageSize,@EmpId,@bagtype";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            SqlParameter pbagtype = new SqlParameter("bagtype", bagtype);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pEmpId, pbagtype);
            this.DB.CloseConnection();
            return tb;
        }
        public int CounGetThuLyHoSoTypePageWise(int EmpId, int bagtype)
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=2 and cr.EmpFile=@EmpId and cr.BagProfileTypeID=@bagtype";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            SqlParameter pbagtype = new SqlParameter("bagtype", bagtype);
            RC = DB.GetValues(sql, pEmpId, pbagtype);
            this.DB.CloseConnection();
            return RC;
        }
        //=======  GET GetSearchkeyThuLyHoSoPageWise=======================================================================================================
        public DataTable GetSearchkeyThuLyHoSoPageWise(int PageIndex, int PageSize, int EmpId, string keysearch)
        {
            string sql = "Exec GetSearchkeyThuLyHoSoPageWise @PageIndex,@PageSize,@EmpId,@keysearch";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pPageIndex = new SqlParameter("PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("PageSize", PageSize);
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pEmpId, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public int CounGetSearchkeyThuLyHoSoPageWise(int EmpId, string keysearch)
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=2 and cr.EmpFile=@EmpId and (cb.LastName +' ' + cb.FirstName) like '%'+@keysearch+'%'";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            RC = DB.GetValues(sql, pEmpId, pkeysearch);
            this.DB.CloseConnection();
            return RC;
        }
        //=======  Sum GetSearchkeyThuLyHoSoPageWise=======================================================================================================
        public int SumBagAsDAY(int EmpId, string day)
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=2 and cr.EmpFile=@EmpId and SUBSTRING(CONVERT(nvarchar(9),cr.DateOfCreate, 112),7,2)=@day";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            SqlParameter pday = new SqlParameter("day", day);
            RC = DB.GetValues(sql, pEmpId, pday);
            this.DB.CloseConnection();
            return RC;
        }
        public int SumBagAsMONTH(int EmpId, string month)
        {
            int RC = 0;
            string sql = "select COUNT(*) from CustomerBasicInfo cb join CustomerProfilePrivate cr on cb.InfoID=cr.InfoID where cr.ProfileStatus=2 and cr.EmpFile=@EmpId and SUBSTRING(CONVERT(nvarchar(6),cr.DateOfCreate, 112),5,2)=@month";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pEmpId = new SqlParameter("EmpId", EmpId);
            SqlParameter pmonth = new SqlParameter("month", month);
            RC = DB.GetValues(sql, pEmpId, pmonth);
            this.DB.CloseConnection();
            return RC;
        }
        //========GET GetInfoProFile====================================================
        public DataTable GetInfoProFile(int InfoID)
        {
            string sql = "Exec GetInfoProFile @InfoID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            DataTable tb = DB.DAtable(sql, pInfoID);
            this.DB.CloseConnection();
            return tb;
        }
        //========UPDATE InternationalSchool====================================================
        public Boolean UpdateInternationalSchool(int schoolId, int profileId)
        {
            string sql = "update CustomerProfilePrivate set InternationalSchool=@schoolId where ProfileID=@profileId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pschoolId = new SqlParameter("schoolId", schoolId);
            SqlParameter pprofileId = new SqlParameter("profileId", profileId);
            this.DB.Updatedata(sql, pschoolId, pprofileId);
            this.DB.CloseConnection();
            return true;
        }
        public int countProfileinCountry(int countryId)
        {
            int rc = 0;
            string sql = "select COUNT(*) from CustomerProfilePrivate cus join InternationalSchool ins on cus.InternationalSchool=ins.SchoolID where ins.CountryID=@countryId and cus.BagProfileTypeID=1";
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            SqlParameter pcountryId = new SqlParameter("countryId", countryId);
            rc = this.DB.GetValues(sql, pcountryId);
            this.DB.CloseConnection();
            return rc;
        }
        //TraCuuHoSoPageWise
        public DataTable TraCuuHoSoPageWise(int PageIndex, int PageSize, string ProfileCode, int BagProfileTypeID, string FullName, string Email, string IdentityCard, string Phone)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec TraCuuHoSoPageWise @PageIndex,@PageSize,@ProfileCode,@BagProfileTypeID,@FullName,@Email,@IdentityCard,@Phone";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            SqlParameter pProfileCode = (ProfileCode == "") ? new SqlParameter("@ProfileCode", DBNull.Value) : new SqlParameter("@ProfileCode", ProfileCode);
            SqlParameter pBagProfileTypeID = (BagProfileTypeID == 0) ? new SqlParameter("@BagProfileTypeID", DBNull.Value) : new SqlParameter("@BagProfileTypeID", BagProfileTypeID);
            SqlParameter pFullName = (FullName == "") ? new SqlParameter("@FullName", DBNull.Value) : new SqlParameter("@FullName", FullName);
            SqlParameter pEmail = (Email == "") ? new SqlParameter("@Email", DBNull.Value) : new SqlParameter("@Email", Email);
            SqlParameter pIdentityCard = (IdentityCard == "") ? new SqlParameter("@IdentityCard", DBNull.Value) : new SqlParameter("@IdentityCard", IdentityCard);
            SqlParameter pPhone = (Phone == "") ? new SqlParameter("@Phone", DBNull.Value) : new SqlParameter("@Phone", Phone);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pProfileCode, pBagProfileTypeID, pFullName, pEmail, pIdentityCard, pPhone);
            this.DB.CloseConnection();
            return tb;
        }
        public int CountTraCuuHoSoPageWise(string ProfileCode, int BagProfileTypeID, string FullName, string Email, string IdentityCard, string Phone)
        {
            int count = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from CustomerProfilePrivate cpp full outer join CustomerBasicInfo cbi on cpp.InfoID=cbi.InfoID full outer join BagProfileType bpt on cpp.BagProfileTypeID=bpt.BagProfileTypeID where cpp.ProfileID is not null";
            sql += " ";
            sql += "and (cpp.ProfileCode = @ProfileCode or cpp.BagProfileTypeID=@BagProfileTypeID or (cbi.LastName +' ' + cbi.FirstName) like '%'+@FullName+'%' or cpp.Email=@Email or cbi.IdentityCard=@IdentityCard or cpp.CellPhone=@Phone)";
            SqlParameter pProfileCode = (ProfileCode == "") ? new SqlParameter("@ProfileCode", DBNull.Value) : new SqlParameter("@ProfileCode", ProfileCode);
            SqlParameter pBagProfileTypeID = (BagProfileTypeID == 0) ? new SqlParameter("@BagProfileTypeID", DBNull.Value) : new SqlParameter("@BagProfileTypeID", BagProfileTypeID);
            SqlParameter pFullName = (FullName == "") ? new SqlParameter("@FullName", DBNull.Value) : new SqlParameter("@FullName", FullName);
            SqlParameter pEmail = (Email == "") ? new SqlParameter("@Email", DBNull.Value) : new SqlParameter("@Email", Email);
            SqlParameter pIdentityCard = (IdentityCard == "") ? new SqlParameter("@IdentityCard", DBNull.Value) : new SqlParameter("@IdentityCard", IdentityCard);
            SqlParameter pPhone = (Phone == "") ? new SqlParameter("@Phone", DBNull.Value) : new SqlParameter("@Phone", Phone);
            count = DB.GetValues(sql, pProfileCode, pBagProfileTypeID, pFullName, pEmail, pIdentityCard, pPhone);
            this.DB.CloseConnection();
            return count;
        }
        //DELETE
        public Boolean deleteCustomerProfilePrivate(int InfoID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from CustomerProfilePrivate where InfoID=@InfoID";
            SqlParameter pInfoID = new SqlParameter("@InfoID", InfoID);
            this.DB.Updatedata(sql, pInfoID);
            this.DB.CloseConnection();
            return true;
        }

    }
}
