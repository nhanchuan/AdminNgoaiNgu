using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;

public partial class Pages_UserInfor : BasePage
{
    UserAccountsBLL useraccount;
    UserProfileBLL userprofile;
    UserPermissBLL userpermiss;
    CountryBLL country;
    ProvinceBLL province;
    DistrictBLL district;
    ImagesBLL images;
    SecuriryServices sv;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!IsPostBack)
        {
            UserAccounts ac = Session.GetCurrentUser();
            if (ac == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(ac.UserID, FunctionName.ThongTinThanhVien))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    string userid = Request.QueryString["Userid"];
                    if (!checkQueryString(userid))
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/Pages/Users.aspx");
                    }
                    else
                    {
                        this.load_dlcountry();

                        this.load_userprofile(Convert.ToInt32(userid));
                        this.load_rpchangeAvatar(Convert.ToInt32(userid));
                        this.load_gwPermisstion();
                    }
                }
            }
        }
    }
    private void load_gwPermisstion()
    {
        userpermiss = new UserPermissBLL();
        string userid = Request.QueryString["Userid"];
        gwPermisstion.DataSource = userpermiss.getUserPermissWithUID(Convert.ToInt32(userid));
        gwPermisstion.DataBind();
    }
    public Boolean checkQueryString(string UserID)
    {
        useraccount = new UserAccountsBLL();
        if (string.IsNullOrEmpty(UserID))
        {
            return false;
        }
        else
        {
            if(!IsNumber(UserID))
            {
                return false;
            }
            else
            {
                List<UserAccounts> lst = useraccount.getUseraccountUID(Convert.ToInt32(UserID));
                UserAccounts acc = lst.FirstOrDefault();
                if (acc == null)
                {
                    return false;
                }
            }
        }
        return true;
    }
    protected void load_userprofile(int userId)
    {
        userprofile = new UserProfileBLL();
        country = new CountryBLL();
        province = new ProvinceBLL();
        district = new DistrictBLL();
        images = new ImagesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(userId);
        UserProfile pr = lstPR.FirstOrDefault();
        lblUserFullName.Text = pr.LastName + " " + pr.FirstName;
        lblabout.Text = pr.About;
        lblmywebsite.Text = pr.WebsiteUrl;
        lblOccupation.Text = pr.Occupation;
        lbladdress.Text = pr.Address_ui;
        lblBirthday.Text = pr.Birthday.ToString("dd/MM/yyyy");
        List<Country> lstCt = country.getCountryWithId(pr.CountryID);
        Country ct = lstCt.FirstOrDefault();

        txtfirtname.Text = pr.FirstName;
        txtlastname.Text = pr.LastName;
        txtBirthday.Text = pr.Birthday.ToString("dd/MM/yyyy");

        rdnam.Checked = (pr.Sex == 1) ? true : false;
        rdnu.Checked = (pr.Sex == 2) ? true : false;
        this.load_dllProvinceWithIdCountry(pr.CountryID);
        dlProvices.Items.Insert(0, new ListItem("-- Select Province --", "0"));
        this.load_dllDistricWithIdProid(pr.ProvinceID);
        dlDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
        dlCountry.Items.FindByValue(pr.CountryID.ToString()).Selected = true;
        dlProvices.Items.FindByValue(pr.ProvinceID.ToString()).Selected = true;
        dlDistrict.Items.FindByValue(pr.DistrictID.ToString()).Selected = true;
        txtaddress.Text = pr.Address_ui;
        txtphone.Text = pr.MobileNumber;
        txtInterests.Text = pr.Interests;
        txtOccupation.Text = pr.Occupation;
        txtAbout.Text = pr.About;
        txtwebsite.Text = pr.WebsiteUrl;
        useraccount = new UserAccountsBLL();
        txtCurrentEmail.Text = useraccount.GetEmailWithID(Session.GetCurrentUser().UserID);
        imgUserAvatar.Src = "../" + images.ImagesUrl(pr.Img_id);
        imgTabAvatar.ImageUrl = "~/" + images.ImagesUrl(pr.Img_id);
    }
    protected void load_dlcountry()
    {
        country = new CountryBLL();
        dlCountry.DataSource = country.getAllCountry();
        dlCountry.DataTextField = "CountryName";
        dlCountry.DataValueField = "CountryID";
        dlCountry.DataBind();
        dlCountry.Items.Insert(0, new ListItem("-- Select Country --", "0"));
    }
    public void load_dllProvinceWithIdCountry(int idctry)
    {
        province = new ProvinceBLL();
        dlProvices.DataSource = province.getProvinceWithCid(idctry);
        dlProvices.DataTextField = "ProvinceName";
        dlProvices.DataValueField = "ProvinceID";
        dlProvices.DataBind();
    }
    public void load_dllDistricWithIdProid(int proid)
    {
        district = new DistrictBLL();
        dlDistrict.DataSource = district.getDistrictwithProid(proid);
        dlDistrict.DataTextField = "DistrictName";
        dlDistrict.DataValueField = "DistrictID";
        dlDistrict.DataBind();
    }
    protected void dlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        province = new ProvinceBLL();
        dlProvices.DataSource = province.getProvinceWithCid(int.Parse(dlCountry.SelectedValue));
        dlProvices.DataTextField = "ProvinceName";
        dlProvices.DataValueField = "ProvinceID";
        dlProvices.DataBind();
        dlProvices.Items.Insert(0, new ListItem("-- Select Province --", "0"));
        dlDistrict.DataSource = null;
        district = new DistrictBLL();
        dlDistrict.DataSource = district.getDistrictwithProid(0);
        dlDistrict.DataTextField = "DistrictName";
        dlDistrict.DataValueField = "DistrictID";
        dlDistrict.DataBind();
        dlDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }
    protected void dlProvices_SelectedIndexChanged(object sender, EventArgs e)
    {
        district = new DistrictBLL();
        dlDistrict.DataSource = district.getDistrictwithProid(int.Parse(dlProvices.SelectedValue));
        dlDistrict.DataTextField = "DistrictName";
        dlDistrict.DataValueField = "DistrictID";
        dlDistrict.DataBind();
        dlDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }
    private Boolean UpdatePersonalInfo()
    {
        bool updateinfo;
        try
        {
            int userid = Convert.ToInt32(Request.QueryString["Userid"]);
            userprofile = new UserProfileBLL();
            int sex = 0;
            if (rdnam.Checked == true) { sex = 1; }
            else
            {
                if (rdnu.Checked == true) { sex = 2; }
            }
            DateTime birthday = DateTime.ParseExact(txtBirthday.Text, "dd/MM/yyyy", null);
            int countryid = int.Parse(dlCountry.SelectedValue);
            int provinceid = int.Parse(dlProvices.SelectedValue);
            int distrctid = int.Parse(dlDistrict.SelectedValue);
            if (countryid == 0 && provinceid == 0 && distrctid == 0)
                updateinfo = userprofile.UpdatePersonalInfoWithoutCountryProvinceDistrict(userid, txtfirtname.Text, txtlastname.Text, sex, birthday, txtaddress.Text, txtphone.Text, txtInterests.Text, txtOccupation.Text, txtAbout.Text, txtwebsite.Text);
            else if (countryid != 0 && provinceid == 0 && distrctid == 0)
                updateinfo = userprofile.UpdatePersonalInfoWithoutProvinceAndDistrict(userid, txtfirtname.Text, txtlastname.Text, sex, birthday, countryid, txtaddress.Text, txtphone.Text, txtInterests.Text, txtOccupation.Text, txtAbout.Text, txtwebsite.Text);
            else if (countryid != 0 && provinceid != 0 && distrctid == 0)
                updateinfo = userprofile.UpdatePersonalInfoWithoutDistrict(userid, txtfirtname.Text, txtlastname.Text, sex, birthday, countryid, provinceid, txtaddress.Text, txtphone.Text, txtInterests.Text, txtOccupation.Text, txtAbout.Text, txtwebsite.Text);
            else
                updateinfo = userprofile.UpdatePersonalInfo(userid, txtfirtname.Text, txtlastname.Text, sex, birthday, countryid, provinceid, distrctid, txtaddress.Text, txtphone.Text, txtInterests.Text, txtOccupation.Text, txtAbout.Text, txtwebsite.Text);
            updateinfo = true;
        }
        catch(Exception ex)
        {
            updateinfo = false;
        }
        return updateinfo;
    }
    protected void btnSavePersonalInfo_Click(object sender, EventArgs e)
    {

        if (UpdatePersonalInfo())
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Update False ! Connect dadabase Error !')</script>");
        }

    }
    protected void btnChangeEmail_Click(object sender, EventArgs e)
    {
        useraccount = new UserAccountsBLL();
        int userid = Convert.ToInt32(Request.QueryString["Userid"]);
        if (useraccount.UpdateEmail(userid, txtreEmail.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Update False ! Connect dadabase Error !')</script>");
        }
    }
    public static string CreateSHAHash(string Password, string Salt)
    {
        System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
        Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Password, Salt));
        Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
        HashTool.Clear();
        return Convert.ToBase64String(EncryptedBytes);
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        useraccount = new UserAccountsBLL();
        int userid = Convert.ToInt32(Request.QueryString["Userid"]);
        if (CreateSHAHash(txtCurrrentPassword.Text, SaltPassword()) != useraccount.GetPasswordWithID(userid))
        {
            Response.Write("<script>alert('Current Password Incorrect !')</script>");
            return;
        }
        else
        {
            if (useraccount.UpadatePassword(userid, CreateSHAHash(txtRepassword.Text, SaltPassword())))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Update False ! Connect dadabase Error !')</script>");
            }
        }
    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        //ImgEditPC.Src = txtuploadImgTemp.Text;
        UserAccounts ac = Session.GetCurrentUser();
        int userid = Convert.ToInt32(Request.QueryString["Userid"]);
        userprofile = new UserProfileBLL();
        images = new ImagesBLL();
        string dateString = DateTime.Now.ToString("MM-dd-yyyy");
        string fileName = Path.GetFileName(FileImgUpload.PostedFile.FileName);
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        string fileExtension = "";
        try
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = "Anh-van-hoi-anh-my-" + dateString + "-" + RandomName + fileExtension;
                string pathToSave = Server.MapPath("../images/Upload/Avatar/") + str_image;
                //file.SaveAs(pathToSave);
                System.Drawing.Image image = System.Drawing.Image.FromStream(FileImgUpload.FileContent);
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
                Bitmap bmp1 = new Bitmap(FileImgUpload.FileContent);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
                this.images.InsertImages(str_image, "images/Upload/Avatar/" + str_image, 1, ac.UserID);
                this.userprofile.UpdateImages(userid, images.ImagesID(str_image));
                imgTabAvatar.ImageUrl = "~/images/Upload/Avatar/" + str_image;
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Upload Image False !')</script>");
                return;
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + " !')</script>");
        }
    }
    public void load_rpchangeAvatar(int UserUpload)
    {
        images = new ImagesBLL();
        rpchangeAvatar.DataSource = images.getImagesWithType(2);
        rpchangeAvatar.DataBind();
    }
    protected void btnchangeAvatar_Click(object sender, EventArgs e)
    {
        images = new ImagesBLL();
        userprofile = new UserProfileBLL();
        int userid = Convert.ToInt32(Request.QueryString["Userid"]);
        string http = "http://" + Request.Url.Authority + "/";
        string imgUrl = HiddenimgSelect.Value.Remove(0, http.Length);
        bool changeImgBL = userprofile.UpdateImages(userid, images.ImagesIDUrl(imgUrl));
        if (changeImgBL)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Update False ! Connect dadabase Error !')</script>");
        }
    }
    protected void dlImgCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        images = new ImagesBLL();
        rpchangeAvatar.DataSource = new ObjectDataSource();
        if (dlImgCategory.SelectedValue == "1")
        {
            rpchangeAvatar.DataSource = images.getImagesWithType(2);
            rpchangeAvatar.DataBind();
        }
        else
        {
            if (dlImgCategory.SelectedValue == "2")
            {
                rpchangeAvatar.DataSource = images.getImagesWithUserUpload(Session.GetCurrentUser().UserID);
                rpchangeAvatar.DataBind();
            }

        }
    }
    public void clearcheckbox()
    {
        chkAddnew.Checked = false;
        chkEdit.Checked = false;
        chkDelete.Checked = false;
        chkView.Checked = false;
    }
    public TypeAudit addnew()
    {
        TypeAudit tau = new TypeAudit();
        if (chkAddnew.Checked == true)
        {
            tau = TypeAudit.AddNew;
        }
        else { tau = 0; }
        return tau;
    }
    public TypeAudit edit()
    {
        TypeAudit tau = new TypeAudit();
        if (chkEdit.Checked == true)
        {
            tau = TypeAudit.Edit;
        }
        else { tau = 0; }
        return tau;
    }
    public TypeAudit delete()
    {
        TypeAudit tau = new TypeAudit();
        if (chkDelete.Checked == true)
        {
            tau = TypeAudit.Delete;
        }
        else { tau = 0; }
        return tau;
    }
    public TypeAudit view()
    {
        TypeAudit tau = new TypeAudit();
        if (chkView.Checked == true)
        {
            tau = TypeAudit.View;
        }
        else { tau = 0; }
        return tau;
    }
    protected void gwPermisstion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.clearcheckbox();
        sv = new SecuriryServices();
        string PermissFuncID = (gwPermisstion.SelectedRow.FindControl("lblPermissFuncID") as Label).Text;
        int PerNum = (string.IsNullOrEmpty((gwPermisstion.SelectedRow.FindControl("lblPermisstionNumber") as Label).Text)) ? 0 : Convert.ToInt32((gwPermisstion.SelectedRow.FindControl("lblPermisstionNumber") as Label).Text);
        bool addnew = sv.HasPermission(TypeAudit.AddNew, PerNum);
        bool edit = sv.HasPermission(TypeAudit.Edit, PerNum);
        bool delete = sv.HasPermission(TypeAudit.Delete, PerNum);
        bool view = sv.HasPermission(TypeAudit.View, PerNum);
        if (addnew)
        {
            chkAddnew.Checked = true;
        }
        if (edit)
        {
            chkEdit.Checked = true;
        }
        if (delete)
        {
            chkDelete.Checked = true;
        }
        if (view)
        {
            chkView.Checked = true;
        }
    }

    protected void btnsavechangePermiss_Click(object sender, EventArgs e)
    {
        userpermiss = new UserPermissBLL();
        int t = 0;
        t = (int)(addnew() | edit() | delete() | view());
        string userid = Request.QueryString["Userid"];
        if (gwPermisstion.SelectedRow!=null)
        {
            string PermissFuncID = (gwPermisstion.SelectedRow.FindControl("lblPermissFuncID") as Label).Text;
            this.userpermiss.setpermission(Convert.ToInt32(userid), Convert.ToInt32(PermissFuncID), t);
            this.load_gwPermisstion();
        }
        else
        {
            Response.Write("<script>alert('PermissFunction not Available, please select a PermissFunction... !')</script>");
            return;
        }
    }
}