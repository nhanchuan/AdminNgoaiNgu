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

public partial class Demo_In_Project_ViewLich : System.Web.UI.Page
{
    ViewLichHocBLL viewlichhoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        viewlichhoc = new ViewLichHocBLL();
        if (!IsPostBack)
        {
            //gwLichHoc.DataSource = viewlichhoc.getLichHocEvents(new DateTime(1970, 1, 1), new DateTime(2020, 1, 1), Convert.ToInt32(Session.GetCurrentCoSoID()));
            //gwLichHoc.DataBind();
        }
    }
}