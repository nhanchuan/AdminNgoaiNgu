using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;

public partial class Login : BasePage
{
    UserAccountsBLL useraccount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name) != null)
            {
                ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name).Selected = true;
            }
            if (Request.Cookies["UserAdminName"] != null && Request.Cookies["PasswordAdmin"] != null)
            {
                txtusername.Text = Request.Cookies["UserAdminName"].Value;
                txtpasswords.Attributes["value"] = Request.Cookies["PasswordAdmin"].Value;
            }
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
    public void check_rememberUser()
    {
        if (chkRememberMe.Checked)
        {
            Response.Cookies["UserAdminName"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["PasswordAdmin"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["UserAdminName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["PasswordAdmin"].Expires = DateTime.Now.AddDays(-1);

        }
        Response.Cookies["UserAdminName"].Value = txtusername.Text.Trim();
        Response.Cookies["PasswordAdmin"].Value = txtpasswords.Text.Trim();
    }
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.SetCurrentLang(ddlLanguages.SelectedValue);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    public Boolean checkUriLogin() //Kiem tra session Url co phai trang login ko ? Neu dung return True | return False
    {
        string url = Session.GetCurrentURL();
        if (url == "" || url == null)
        {
            return false;
        }
        return true;
    }
    protected Boolean check_login(string key, string password)
    {
        useraccount = new UserAccountsBLL();
        List<UserAccounts> lst = useraccount.getLoginUser(key, password);
        UserAccounts user = lst.FirstOrDefault();
        if (user != null)
        {
            Session.SetCurrentUser(user);
            Session.SetLockGreen(user);
            return true;
        }
        return false;
    }

    protected void btnloginform_Click(object sender, EventArgs e)
    {
        if (check_login(txtusername.Text, CreateSHAHash(txtpasswords.Text, SaltPassword())))
        {
            this.check_rememberUser();
            if (checkUriLogin() == false)
            {
                Response.Redirect("/Pages/MyProfile.aspx");
            }
            else
            {
                Response.Redirect(Session.GetCurrentURL());
            }
            //Response.Redirect("/Pages/ServerMaintenance.aspx");
        }
        else
        {
            lblFalalseLogin.Text = Resources.Resource.falselogin;
        }
    }
}