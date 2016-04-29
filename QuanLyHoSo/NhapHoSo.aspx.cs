using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Globalization;

public partial class QuanLyHoSo_NhapHoSo : BasePage
{
    CustomerBasicInfoBLL customerbasicinfo;
    CustomerProfilePrivateBLL customerProPri;
    REGISTRATION_FORM_ADVISORY_BLL registrationForm;
    CountryBLL country;
    ProvinceBLL province;
    DistrictBLL district;
    Registration_TypeBLL regisType;
    EducationLVBLL educationlvl;
    CountryAdvisoryBLL coutryadv;
    EmployeesBLL employees;
    UserProfileBLL userprofile;
    ImagesBLL images;
    ImagesTypeBLL imagestype;
    UserAccountsBLL useraccount;
    ListOfNationalitiesBLL lstOfNationalities;
    EthnicListBLL ethniclist;
    ListOfReligionBLL lstOfReligoin;
    BloodGroupBLL bloodgroup;
    BagProfileTypeBLL bagprofiletype;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!IsPostBack)
        {
            UserAccounts user = Session.GetCurrentUser();
            if (user == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(user.UserID, FunctionName.NhapHoSo))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_rpLstImg();
                    this.load_dlBagProfileType();
                    this.load_dlNationality();
                    this.load_dlEthnic();
                    this.load_dlReligionID();
                    load_dlCountrys();
                    dlProvince.Items.Insert(0, new ListItem("-- Chọn Tỉnh - Thành --", "0"));
                    dlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận - Huyện --", "0"));
                    load_dlBloodGroup();
                }
            }
        }
    }
    private string CountryStr(int countryId)
    {
        country = new CountryBLL();
        List<Country> lst = country.getCountryWithId(countryId);
        Country cty = lst.FirstOrDefault();
        return (cty == null) ? "" : cty.CountryName;
    }
    private string ProvinceStr(int provinceId)
    {
        province = new ProvinceBLL();
        List<Province> lst = province.getProvinceWithProId(provinceId);
        Province priv = lst.FirstOrDefault();
        return (priv == null) ? "" : priv.ProvinceName;
    }
    private string DistrictStr(int disID)
    {
        district = new DistrictBLL();
        List<District> lst = district.getDistrictwithDisId(disID);
        District dis = lst.FirstOrDefault();
        return (dis == null) ? "" : dis.DistrictName;
    }
    private void load_dlBagProfileType()
    {
        bagprofiletype = new BagProfileTypeBLL();
        this.load_DropdownList(dlBagProfileType, bagprofiletype.getAllBagProfileType(), "TypeName", "BagProfileTypeID");
        dlBagProfileType.Items.Insert(0, new ListItem("-- Chọn loại Hồ Sơ --", "0"));
    }
    private void load_dlNationality()
    {
        lstOfNationalities = new ListOfNationalitiesBLL();
        dlNationality.DataSource = lstOfNationalities.getAllListOfNationalities();
        dlNationality.DataTextField = "NationalityName";
        dlNationality.DataValueField = "NationalityID";
        dlNationality.DataBind();
        dlNationality.Items.Insert(0, new ListItem("-- Chọn Quốc Tịch --", "0"));
    }
    private void load_dlEthnic()
    {
        ethniclist = new EthnicListBLL();
        this.load_DropdownList(dlEthnic, ethniclist.GetallEthnicList(), "EthnicName", "EthnicID");
        dlEthnic.Items.Insert(0, new ListItem("-- Chọn Dân Tộc --", "0"));
    }
    private void load_dlEthnic(int NaID)
    {
        ethniclist = new EthnicListBLL();
        dlEthnic.DataSource = ethniclist.GetallEthnicListWithNationID(NaID);
        dlEthnic.DataValueField = "EthnicID";
        dlEthnic.DataTextField = "EthnicName";
        dlEthnic.DataBind();
    }
    private void load_dlReligionID()
    {
        lstOfReligoin = new ListOfReligionBLL();
        this.load_DropdownList(dlReligion, lstOfReligoin.getAllListOfReligion(), "ReligionName", "ReligionID");
        dlReligion.Items.Insert(0, new ListItem("-- Chọn Tôn Giáo --", "0"));
    }
    private void load_dlCountrys()
    {
        country = new CountryBLL();
        this.load_DropdownList(dlCountry, country.getAllCountry(), "CountryName", "CountryID");
        dlCountry.Items.Insert(0, new ListItem("-- Chọn Quốc Gia --", "0"));
    }
    private void load_dlBloodGroup()
    {
        bloodgroup = new BloodGroupBLL();
        this.load_DropdownList(dlBloodGroup, bloodgroup.GetAllBloodGroup(), "BloodName", "BloodID");
        dlBloodGroup.Items.Insert(0, new ListItem("-- Chọn Nhóm Máu", "0"));
    }
    
    protected void dlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        province = new ProvinceBLL();
        this.load_DropdownList(dlProvince, province.getProvinceWithCid(Convert.ToInt32(dlCountry.SelectedValue)), "ProvinceName", "ProvinceID");
        dlProvince.Items.Insert(0, new ListItem("-- Chọn Tỉnh - Thành --", "0"));
    }
    protected void dlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        district = new DistrictBLL();
        this.load_DropdownList(dlDistrict, district.getDistrictwithProid(Convert.ToInt32(dlProvince.SelectedValue)), "DistrictName", "DistrictID");
        dlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận - Huyện --", "0"));
    }
    
    private string RegisFormTypeStr(int typeId)
    {
        regisType = new Registration_TypeBLL();
        List<Registration_Type> lst = regisType.getAllRegistration_TypeWithId(typeId);
        Registration_Type rt = lst.FirstOrDefault();
        return (rt == null) ? "" : rt.TypeName;
    }
    private string EducationSrt(int EdiId)
    {
        educationlvl = new EducationLVBLL();
        List<EducationLV> lst = educationlvl.getallEducationLVWithId(EdiId);
        EducationLV edu = lst.FirstOrDefault();
        return (edu == null) ? "" : edu.NAME;
    }
    private string CountryAdvStr(int CountryId)
    {
        coutryadv = new CountryAdvisoryBLL();
        List<CountryAdvisory> lst = coutryadv.getallCountryAdvisoryWithId(CountryId);
        CountryAdvisory cadv = lst.FirstOrDefault();
        return (cadv == null) ? "" : cadv.CountryName;
    }
    //===Lay thong tin phieu tu van===
    //private void load_FormAdvisory(string FileCode)
    //{
    //    registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
    //    customerbasicinfo = new CustomerBasicInfoBLL();
    //    customerProPri = new CustomerProfilePrivateBLL();
    //    images = new ImagesBLL();
    //    province = new ProvinceBLL();
    //    district = new DistrictBLL();

    //    this.load_dlNationality(); //--GET ALL NATIONALITY
    //    dlNationality.Items.Insert(0, new ListItem("-- Quốc Tịch --", "0"));
    //    this.load_dlEthnic();
    //    dlEthnic.Items.Insert(0, new ListItem("-- Dân tộc --", "0"));
    //    this.load_dlReligionID();
    //    dlReligion.Items.Insert(0, new ListItem("-- Tôn Giáo --", "0"));
    //    this.load_dlCountrys();
    //    dlCountry.Items.Insert(0, new ListItem("-- Select Country --", "0"));
    //    this.load_dlBloodGroup();
    //    dlBloodGroup.Items.Insert(0, new ListItem("-- Nhóm máu --", "0"));
    //    this.load_dlBagProfileType();
    //    dlBagProfileType.Items.Insert(0, new ListItem("-- Loại hồ sơ --", "0"));

    //    List<CustomerBasicInfo> lstBsInfo = customerbasicinfo.GetCusBasicInfoWithCode(FileCode);
    //    CustomerBasicInfo bsInfo = lstBsInfo.FirstOrDefault();
    //    List<CustomerProfilePrivate> lstPri = customerProPri.GetCustomerProfilePrivateWithInfoID(bsInfo.InfoID);
    //    CustomerProfilePrivate CusPri = lstPri.FirstOrDefault();
    //    List<REGISTRATION_FORM_ADVISORY> lstReF = registrationForm.getREGISTRATION_FORM_ADVISORY_WithId(CusPri.RegistrationID);
    //    REGISTRATION_FORM_ADVISORY regForm = lstReF.FirstOrDefault();
    //    List<Images> lstImg = images.getImagesWithId(CusPri.ProfileImg);
    //    Images img = lstImg.FirstOrDefault();

    //    dlProvince.DataSource = province.getAllProvince();
    //    dlProvince.DataTextField = "ProvinceName";
    //    dlProvince.DataValueField = "ProvinceID";
    //    dlProvince.DataBind();
    //    dlProvince.Items.Insert(0, new ListItem("-- Select Province --", "0"));
    //    dlDistrict.DataSource = null;

    //    dlDistrict.DataSource = district.getallDistrict();
    //    dlDistrict.DataTextField = "DistrictName";
    //    dlDistrict.DataValueField = "DistrictID";
    //    dlDistrict.DataBind();
    //    dlDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));

    //    //lblAdvFullName.Text = regForm.FullName;
    //    //lbladvAddress.Text = regForm.Address_form + ", " + DistrictStr(regForm.DistrictID) + ", " + ProvinceStr(regForm.ProvinceID) + ", " + CountryStr(regForm.CountryID);
    //    //lblAdvEmail.Text = regForm.Email;
    //    //lblAdvPhone.Text = regForm.Phone;
    //    //lblAdvSex.Text = (regForm.Sex == 1) ? "Nam" : (regForm.Sex == 2) ? "Nữ" : " - - -";

    //    //switch (regForm.TypeID)
    //    //{
    //    //    case 1:
    //    //        lblAdvType.Text = RegisFormTypeStr(1);
    //    //        spanTagsAdv.Attributes.Add("class", "label label-primary");
    //    //        break;
    //    //    case 2:
    //    //        lblAdvType.Text = RegisFormTypeStr(2);
    //    //        spanTagsAdv.Attributes.Add("class", "label label-default");
    //    //        break;
    //    //    case 3:
    //    //        lblAdvType.Text = RegisFormTypeStr(3);
    //    //        spanTagsAdv.Attributes.Add("class", "label label-success");
    //    //        break;
    //    //    case 4:
    //    //        lblAdvType.Text = RegisFormTypeStr(4);
    //    //        spanTagsAdv.Attributes.Add("class", "label label-warning");
    //    //        break;
    //    //}
    //    //lblAdvEdulvl.Text = EducationSrt(regForm.StudyLV);
    //    //lblAdvcoutry.Text = CountryAdvStr(regForm.CountryAdvisoryID);
    //    imgCusprofile.Src = (img == null) ? "../images/default_images.jpg" : "../" + img.ImagesUrl;

    //    txtformFirstName.Text = bsInfo.FirstName;
    //    txtformLastName.Text = bsInfo.LastName;
    //    txtformOtherName.Text = bsInfo.OtherName;
    //    txtformBirthday.Value = (bsInfo.Birthday.Year <= 1900) ? "" : bsInfo.Birthday.ToString("dd/MM/yyyy");
    //    txtformBirthPlace.Text = bsInfo.BirthPlace;
    //    rdformnam.Checked = (bsInfo.Sex == 1) ? true : false;
    //    rdformnu.Checked = (bsInfo.Sex == 2) ? true : false;
    //    txtformIdentityCard.Text = bsInfo.IdentityCard;
    //    txtformDateOfIdentityCard.Value = (bsInfo.DateOfIdentityCard.Year <= 1900) ? "" : bsInfo.DateOfIdentityCard.ToString("dd/MM/yyyy");
    //    txtformPlaceOfIdentityCard.Text = bsInfo.PlaceOfIdentityCard;

    //    dlNationality.Items.FindByValue(CusPri.NationalityID.ToString()).Selected = true;
    //    dlEthnic.Items.FindByValue(CusPri.EthnicID.ToString()).Selected = true;
    //    dlReligion.Items.FindByValue(CusPri.ReligionID.ToString()).Selected = true;
    //    dlCountry.Items.FindByValue(CusPri.CountryID.ToString()).Selected = true;
    //    dlProvince.Items.FindByValue(CusPri.ProvinceID.ToString()).Selected = true;
    //    dlDistrict.Items.FindByValue(CusPri.DistrictID.ToString()).Selected = true;
    //    dlBloodGroup.Items.FindByValue(CusPri.BloodID.ToString()).Selected = true;
    //    dlBagProfileType.Items.FindByValue(CusPri.BagProfileTypeID.ToString()).Selected = true;

    //    txtCommune_Ward.Text = CusPri.Commune_Ward;
    //    txtPermanentAddress.Text = CusPri.PermanentAddress;
    //    txtAddressPresent.Text = CusPri.AddressPresent;
    //    txtCompanyPhone.Text = CusPri.CompanyPhone;
    //    txtHomePhone.Text = CusPri.HomePhone;
    //    txtCellPhone.Text = CusPri.CellPhone;
    //    txtEmail.Text = CusPri.Email;
    //    txtMaritalStatus.Text = CusPri.MaritalStatus;
    //    txtTPXuatThan.Text = CusPri.TPXuatThan;
    //    txtUuTienGD.Text = CusPri.UuTienGD;
    //    txtUuTienBanThan.Text = CusPri.UuTienBanThan;
    //    txtNangKhieu.Text = CusPri.NangKhieu;
    //    txtDisability.Text = CusPri.Disability;
    //    txtHealthCondition.Text = CusPri.HealthCondition;
    //    txtHeight.Text = CusPri.Height.ToString();
    //    txtWeight.Text = CusPri.Weight.ToString();
    //    txtDateOfBHXH.Value = CusPri.DateOfBHXH.ToString("dd/MM/yyyy");
    //    txtNumOfBHXH.Text = CusPri.NumOfBHXH;
    //    txtBank.Text = CusPri.Bank;
    //    txtAccountNumber.Text = CusPri.AccountNumber;
    //}
   
    //====LOAD MODAL IMAGES==========================================================================================================
    protected void load_rpLstImg()
    {
        images = new ImagesBLL();
        rpLstImg.DataSource = images.getImagesWithType(6);
        rpLstImg.DataBind();
    }
    private void UpdateImages(int proId, int ImgId)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        if (this.customerProPri.UpdateImages(proId, ImgId))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Change Image False !')</script>");
            return;
        }
    }
    protected int ImagesID(string filename)
    {
        int ImID = 0;
        images = new ImagesBLL();

        if (string.IsNullOrWhiteSpace(filename))
        {
            ImID = 0;
        }
        else
        {
            ImID = images.ImagesID(filename);
        }
        return ImID;
    }
    protected void btnchangeImgCusPro_Click(object sender, EventArgs e)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        customerProPri = new CustomerProfilePrivateBLL();
        string http = "http://" + Request.Url.Authority + "/";
        txtPostImgTemp.Text = HiddenimgSelect.Value.Remove(0, http.Length);
        imgCusprofile.Src = "../" + HiddenimgSelect.Value.Remove(0, http.Length);
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstBsInfo = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo bsInfo = lstBsInfo.FirstOrDefault();
        List<CustomerProfilePrivate> lstPri = customerProPri.GetCustomerProfilePrivateWithInfoID(bsInfo.InfoID);
        CustomerProfilePrivate CusPri = lstPri.FirstOrDefault();
        UpdateImages(CusPri.ProfileID, ImagesID(txtPostImgTemp.Text));
    }
    protected void btnuploadImg_ServerClick(object sender, EventArgs e)
    {
        //ImgEditPC.Src = txtuploadImgTemp.Text;
        UserAccounts ac = Session.GetCurrentUser();
        customerbasicinfo = new CustomerBasicInfoBLL();
        customerProPri = new CustomerProfilePrivateBLL();
        images = new ImagesBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstBsInfo = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo bsInfo = lstBsInfo.FirstOrDefault();
        List<CustomerProfilePrivate> lstPri = customerProPri.GetCustomerProfilePrivateWithInfoID(bsInfo.InfoID);
        CustomerProfilePrivate CusPri = lstPri.FirstOrDefault();
        string dateString = DateTime.Now.ToString("MM-dd-yyyy");
        string fileName = Path.GetFileName(fileUploadImgPost.PostedFile.FileName);
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        string fileExtension = "";
        if (!string.IsNullOrEmpty(fileName))
        {

            fileExtension = Path.GetExtension(fileName);
            str_image = XoaKyTuDacBiet(bsInfo.LastName + " " + bsInfo.FirstName) + "-" + dateString + "-" + RandomName + fileExtension;
            string pathToSave = Server.MapPath("../images/Upload/ImagesForCustomerProfile/") + str_image;
            //file.SaveAs(pathToSave);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fileUploadImgPost.FileContent);
            if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Gif);
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Bmp);
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Png);
            else
                throw new System.ArgumentException("Invalid File Type");
            Bitmap bmp1 = new Bitmap(fileUploadImgPost.FileContent);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
            this.images.InsertImages(str_image, "images/Upload/ImagesForCustomerProfile/" + str_image, 6, ac.UserID);
            txtPostImgTemp.Text = "images/Upload/ImagesForCustomerProfile/" + str_image;
            imgCusprofile.Src = "../images/Upload/ImagesForCustomerProfile/" + str_image;
            this.load_rpLstImg();
            this.UpdateImages(CusPri.ProfileID, ImagesID(txtPostImgTemp.Text));
        }
        else
        {
            Response.Write("<script>alert('Upload Image False !')</script>");
            return;
        }
    }
    private string getday(string str)
    {
        string day = str.Substring(0, 2);
        return day;
    }
    private string getmonth(string str)
    {
        string month = str.Substring(3, 2);
        return month;
    }
    private string getyear(string str)
    {
        string year = str.Substring(6, 4);
        return year;
    }
    private Boolean UpdateCustomerBasicInfo()
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstBsInfo = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo bsInfo = lstBsInfo.FirstOrDefault();
        int sex;
        if (!rdformnam.Checked && !rdformnu.Checked)
        {
            sex = 0;
        }
        else
        {
            sex = (rdformnam.Checked) ? 1 : (rdformnu.Checked) ? 2 : 0;
        }
        DateTime birthday;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (txtformBirthday.Value == "" || string.IsNullOrWhiteSpace(txtformBirthday.Value) || DateTime.TryParseExact(txtformBirthday.Value, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out birthday))
        {
            birthday = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            birthday = DateTime.ParseExact(getday(txtformBirthday.Value) + "/" + getmonth(txtformBirthday.Value) + "/" + getyear(txtformBirthday.Value), "dd/MM/yyyy", null);
        }
        DateTime dateOfIdentityCard;
        if (txtformDateOfIdentityCard.Value == "" || string.IsNullOrWhiteSpace(txtformDateOfIdentityCard.Value) || DateTime.TryParseExact(txtformDateOfIdentityCard.Value, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out dateOfIdentityCard))
        {
            dateOfIdentityCard = Convert.ToDateTime("10/10/1900");
        }
        else
        {
            dateOfIdentityCard = DateTime.ParseExact(getday(txtformDateOfIdentityCard.Value) + "/" + getmonth(txtformDateOfIdentityCard.Value) + "/" + getyear(txtformDateOfIdentityCard.Value), "dd/MM/yyyy", null);
        }
        bool hasUpadte = customerbasicinfo.UpdateCustomerBasicInfo(bsInfo.InfoID, txtformFirstName.Text, txtformLastName.Text, txtformOtherName.Text, birthday, txtformBirthPlace.Text, sex, txtformIdentityCard.Text, dateOfIdentityCard, txtformPlaceOfIdentityCard.Text);
        return (hasUpadte) ? true : false;
    }
    private Boolean UpdateCustomerProfilePrivate()
    {
        customerProPri = new CustomerProfilePrivateBLL();
        customerbasicinfo = new CustomerBasicInfoBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstBsInfo = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo bsInfo = lstBsInfo.FirstOrDefault();
        List<CustomerProfilePrivate> lstPri = customerProPri.GetCustomerProfilePrivateWithInfoID(bsInfo.InfoID);
        CustomerProfilePrivate CusPri = lstPri.FirstOrDefault();

        int Nationality = Convert.ToInt32(dlNationality.SelectedValue);
        int Ethnic = Convert.ToInt32(dlEthnic.SelectedValue);
        int Religion = Convert.ToInt32(dlReligion.SelectedValue);
        int Country = Convert.ToInt32(dlCountry.SelectedValue);
        int Province = Convert.ToInt32(dlProvince.SelectedValue);
        int District = Convert.ToInt32(dlDistrict.SelectedValue);
        int Height = (txtHeight.Text == "") ? 0 : Convert.ToInt32(txtHeight.Text);
        int Weight = (txtWeight.Text == "") ? 0 : Convert.ToInt32(txtWeight.Text);
        int BloodID = Convert.ToInt32(dlBloodGroup.SelectedValue);
        int bagPPID = Convert.ToInt32(dlBagProfileType.SelectedValue);

        DateTime DateOfBHXH;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (txtDateOfBHXH.Value == "" || string.IsNullOrWhiteSpace(txtDateOfBHXH.Value) || DateTime.TryParseExact(txtDateOfBHXH.Value, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out DateOfBHXH))
        {
            DateOfBHXH = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            DateOfBHXH = DateTime.ParseExact(getday(txtDateOfBHXH.Value) + "/" + getmonth(txtDateOfBHXH.Value) + "/" + getyear(txtDateOfBHXH.Value), "dd/MM/yyyy", null);
        }
        bool hasUpdate = customerProPri.UpdateCustomerProfilePrivate(CusPri.ProfileID, txtCompanyCopyright.Text, Nationality, Ethnic, Religion, Country, Province, District, txtCommune_Ward.Text, txtPermanentAddress.Text, txtAddressPresent.Text, txtCompanyPhone.Text, txtHomePhone.Text, txtCellPhone.Text, txtEmail.Text, txtMaritalStatus.Text, txtTPXuatThan.Text, txtUuTienGD.Text, txtUuTienBanThan.Text, txtNangKhieu.Text, txtDisability.Text, txtHealthCondition.Text, Height, Weight, BloodID, DateOfBHXH, txtNumOfBHXH.Text, txtBank.Text, txtAccountNumber.Text, 1, bagPPID);
        return (hasUpdate) ? true : false;
        
    }
    protected void btnSavePrivateProfile_Click(object sender, EventArgs e)
    {
        if (!UpdateCustomerBasicInfo() || !UpdateCustomerProfilePrivate())
        {
            Response.Write("<script>alert('Cập nhật thông tin [1] không thành công - lỗi kết nối CSDL !')</script>");
        }
        else
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

    protected void btnCreateBagProFile_ServerClick(object sender, EventArgs e)
    {

    }
}