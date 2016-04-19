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
using System.Web.Security;

public partial class Lock_screen : BasePage
{
    UserAccounts useraccount;
    UserProfileBLL userprofile;
    ImagesBLL images;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.GetCurrentUser() == null)
        {
            Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
        }
        else
        {
            //do something
            this.load_Lock_Info();
        }
    }

    private void load_Lock_Info()
    {
        UserAccounts useraccount = Session.GetCurrentUser();
        userprofile = new UserProfileBLL();
        images = new ImagesBLL();
        List<UserProfile> lst = userprofile.getUserProfileWithID(useraccount.UserID);
        UserProfile ainfo = lst.FirstOrDefault();
        List<Images> lstIm = images.getImagesWithId(ainfo.Img_id);
        Images im = lstIm.FirstOrDefault();
        lblusername.Text = ainfo.FirstName + " " + ainfo.LastName;
        lblisUserName.Text = ainfo.FirstName + " " + ainfo.LastName;
        imgavatar.Src =(im==null)? "../images/default_images.jpg" : "../" + im.ImagesUrl;
    }
    public static string CreateSHAHash(string Password, string Salt)
    {
        System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
        Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Password, Salt));
        Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
        HashTool.Clear();
        return Convert.ToBase64String(EncryptedBytes);
    }
    protected void btnNotUser_ServerClick(object sender, EventArgs e)
    {
        Session.SetCurrentUser(null);
        Session.SetLockGreen(null);
        Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
    }
    protected Boolean check_LockScreen(string password)
    {
        UserAccounts useraccount = Session.GetCurrentUser();
        if (useraccount != null)
        {
            if (password == useraccount.Passwords)
            {
                Session.SetLockGreen(useraccount);
                return true;
            }
        }
        return false;
    }


    protected void btnloginform_Click(object sender, EventArgs e)
    {
        if (check_LockScreen(CreateSHAHash(txtpasswords.Text,SaltPassword())))
        {
            Response.Redirect(Session.GetCurrentURL());
        }
        else
        {
            lblFalalseLogin.Text = Resources.Resource.wrongpassword;
        }
    }
}