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

public partial class QuanLyHoSo_TraCuuHoSo : BasePage
{
    BagProfileTypeBLL bagprofiletype;
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
                if (!check_permiss(ac.UserID, FunctionName.TraCuuHoSo))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlLoaiHoSo();   
                }
            }
        }
    }
    private void load_dlLoaiHoSo()
    {
        bagprofiletype = new BagProfileTypeBLL();
        this.load_DropdownList(dlLoaiHoSo, bagprofiletype.getAllBagProfileType(), "TypeName", "BagProfileTypeID");
        dlLoaiHoSo.Items.Insert(0, new ListItem("-- Chọn loại hồ sơ --", "0"));
    }
}