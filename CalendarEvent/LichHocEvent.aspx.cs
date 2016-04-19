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

public partial class CalendarEvent_LichHocEvent : System.Web.UI.Page
{
    kus_CoSoBLL kus_coso;
    protected void Page_Load(object sender, EventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        if(!IsPostBack)
        {
            string cosoid = Session.GetCurrentCoSoID();
            if(string.IsNullOrEmpty(cosoid)|| string.IsNullOrWhiteSpace(cosoid))
            {
                lblcoso.Text = "Chưa chọn Cở Sở";
            }
            else
            {
                List<kus_CoSo> lstCS = kus_coso.getLSTCoSoWithID(Convert.ToInt32(cosoid));
                kus_CoSo coso = lstCS.FirstOrDefault();
                lblcoso.Text = coso.TenCoSo;
            }
        }
    }
}