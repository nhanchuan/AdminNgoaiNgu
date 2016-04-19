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
using System.IO;
using System.Text.RegularExpressions;

public partial class Pages_VideoEditInfo : BasePage
{
    VideosBLL video;
    VideoTypeBLL videotype;
    UserAccountsBLL admin;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!this.IsPostBack)
        {
            UserAccounts admin = Session.GetCurrentUser();
            if (admin == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(admin.UserID, FunctionName.VideoEdit))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    string videoID = Request.QueryString["VideoID"];
                    if (videoID != null && check_QueryString(videoID))
                    {
                        this.load_dlvideoType();
                        this.getVideoInfo(videoID);
                    }
                    else
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/Pages/VideoManager.aspx");
                    }
                }
            }
        }
    }
    public bool IsNumber(string pText)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        return regex.IsMatch(pText);
    }
    protected Boolean check_QueryString(string videoId)
    {
        video = new VideosBLL();
        if (videoId == "")
        {
            return false;
        }
        else
        {
            if (IsNumber(videoId) == false)
            {
                return false;
            }
            else
            {
                int vid = int.Parse(videoId);
                List<Videos> lst = video.getVideoWithId(vid);
                Videos vi = lst.FirstOrDefault();
                if (vi == null)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void load_dlvideoType()
    {
        videotype = new VideoTypeBLL();
        dlvideoType.DataSource = videotype.getallVideoType();
        dlvideoType.DataTextField = "TypeName";
        dlvideoType.DataValueField = "VideotypeID";
        dlvideoType.DataBind();
    }
    protected void getVideoInfo(string videoid)
    {
        int vid = int.Parse(videoid);
        video = new VideosBLL();
        admin = new UserAccountsBLL();
        List<Videos> lst = video.getVideoWithId(vid);
        Videos vi = lst.FirstOrDefault();
        txtvideoname.Text = vi.VideoName;
        txtshortdescription.Text = vi.ShortDecsription;
        dlvideoType.Items.FindByValue(vi.VideotypeID.ToString()).Selected = true;
        videoplayer.HRef = "../Handler/ReaderVideo.ashx?videoId=" + videoid;
        btndownload.HRef = "../Handler/DownloadVideo.ashx?videoId=" + videoid;
        lbldateupload.Text = vi.DateOfCreate.ToString();
        string Userupload = admin.GetEmailWithID(vi.UserUpload);
      
            lbluserupload.Text =(Userupload != null)? Userupload:"#";
      
        lblfilename.Text = vi.VideoUrl.Substring(vi.VideoUrl.LastIndexOf("/") + 1);
        lblfiletype.Text = vi.ContentType;
        string path = Server.MapPath("../" + vi.VideoUrl);
        FileInfo file = new FileInfo(path);
        float filesize = file.Length / 1024;
        lblfilesize.Text = filesize.ToString() + " kB";
        txtlinkFileVideo.Text = "http://www/hollywood.edu.vn/" + vi.VideoUrl;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        video = new VideosBLL();
        string videoID = Request.QueryString["VideoID"];
        if (this.video.UpdateVideoInfo(int.Parse(videoID), txtvideoname.Text, int.Parse(dlvideoType.SelectedValue), txtshortdescription.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Update false ! Error Connected Database !')</script>");
            return;
        }
    }
}