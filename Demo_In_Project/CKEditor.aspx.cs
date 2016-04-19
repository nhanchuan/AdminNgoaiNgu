using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CKEditor;
using CKFinder;

public partial class Demo_In_Project_CKEditor : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "/ckfinder/";
        _FileBrowser.SetupCKEditor(CKEditor1);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}