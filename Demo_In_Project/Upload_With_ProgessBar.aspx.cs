using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AjaxControlToolkit;

public partial class Demo_In_Project_Upload_With_ProgessBar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        string fileName = Path.GetFileName(e.FileName);
        AjaxFileUpload1.SaveAs(Server.MapPath("~/videos/uploads/" + fileName));
    }
}