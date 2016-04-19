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

public partial class Pages_VideoType : BasePage
{
    VideoTypeBLL videotype;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();

        if (!this.IsPostBack)
        {
            UserAccounts user = Session.GetCurrentUser();
            if (user == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(user.UserID, FunctionName.CategoryVideo))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_gwVideotype();
                    lblnoselect.Visible = true;
                    pannelEdit.Visible = false;
                    btnupdate.Visible = false;
                }
            }
        }
    }
    protected void load_gwVideotype()
    {
        videotype = new VideoTypeBLL();
        gwVideotype.DataSource = videotype.getallVideoType();
        gwVideotype.DataBind();
    }


    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        videotype = new VideoTypeBLL();
        if (this.videotype.NewVideoType(txtVideotypeName.Text, txtshortdescription.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('New Audio Type flase' !)</script>");
            return;
        }
    }

    protected void gwVideotype_PageIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gwVideotype_SelectedIndexChanged(object sender, EventArgs e)
    {
        videotype = new VideoTypeBLL();
        string vid = (gwVideotype.SelectedRow.FindControl("lblVideoTypeID") as Label).Text;
        List<VideoType> lst = videotype.getVideoTypeWithTypeID(int.Parse(vid));
        VideoType vt = lst.FirstOrDefault();
        txtMname.Text = vt.TypeName;
        txtMshortDc.Text = vt.ShortDesciption;

        lblnoselect.Visible = false;
        pannelEdit.Visible = true;
        btnupdate.Visible = true;
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        videotype = new VideoTypeBLL();
        string vid = (gwVideotype.SelectedRow.FindControl("lblVideoTypeID") as Label).Text;
        if (this.videotype.UpdateVideoType(int.Parse(vid), txtMname.Text, txtMshortDc.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Update false ! Error conected database !')</script>");
            return;
        }
    }
}