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

public partial class GlobalMasterPage : System.Web.UI.MasterPage
{
    ImagesBLL images;
    UserAccountsBLL useraccount;
    UserProfileBLL userprofile;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session.GetCurrentUser() == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                this.load_UserInfo();
            }
        }
    }

    protected void btnlogout_ServerClick(object sender, EventArgs e)
    {
        Session.SetCurrentUser(null);
        Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
    }
    protected void load_UserInfo()
    {
        imgAvatar.Src = "images/default_images.jpg";
        images = new ImagesBLL();
        useraccount = new UserAccountsBLL();
        userprofile = new UserProfileBLL();
        UserAccounts ac = Session.GetCurrentUser();
        List<UserProfile> lstai = userprofile.getUserProfileWithID(ac.UserID);
        UserProfile pr = lstai.FirstOrDefault();
        List<Images> lstIm = images.getImagesWithId(pr.Img_id);
        Images im = lstIm.FirstOrDefault();
        if (im != null)
        {
            imgAvatar.Src = im.ImagesUrl;
        }
        lblUsername.Text = pr.LastName + " " + pr.FirstName;
    }
    protected void btnLockScreen_ServerClick(object sender, EventArgs e)
    {
        Session.SetLockGreen(null);
        Response.Redirect("http://" + Request.Url.Authority + "/Lock-screen.aspx");
    }



    
}
