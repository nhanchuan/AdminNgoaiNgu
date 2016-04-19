using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using DAL;
using System.IO;

public partial class Demo_In_Project_UploadBagAttachment : BasePage
{
    BagAttachmentsBLL bagattachments;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uploadBagAttachments_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        bagattachments = new BagAttachmentsBLL();
        UserAccounts ad = Session.GetCurrentUser();
        
       
            string RandomFileName = RandomName + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            //int profileId = Convert.ToInt32((gwBagProfileManager.SelectedRow.FindControl("lblBagProfileID") as Label).Text);
            string fileExtension = Path.GetExtension(e.FileName).ToLower();
            string fileName = Path.GetFileNameWithoutExtension(e.FileName);
            if (this.bagattachments.UploadBagAttachments(fileName + fileExtension, "FileManager/BagAttachments/" + RandomFileName + fileExtension, 5, ad.UserID))
            {
                uploadBagAttachments.SaveAs(Server.MapPath("../FileManager/BagAttachments/" + RandomFileName + fileExtension));
            }
            else
            {
                //Response.Write("<script>alert('Upload Video False !')</script>");
                return;
            }
    }
}