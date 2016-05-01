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

public partial class Demo_In_Project_getTBCustomer : System.Web.UI.Page
{
    CustomerBasicInfoBLL customerbasicinfo;
    CustomerProfilePrivateBLL customerProPri;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.loadgwCustomerBasicInfo();
            this.loadgwCustomerProfilePrivate();
        }
    }
    private void loadgwCustomerBasicInfo()
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        customerProPri = new CustomerProfilePrivateBLL();
        List<CustomerBasicInfo> lstBsInfo = customerbasicinfo.GetCusBasicInfoWithCode("ISEdFv2942016");
        gwCustomerBasicInfo.DataSource = lstBsInfo;
        gwCustomerBasicInfo.DataBind();
    }
    private void loadgwCustomerProfilePrivate()
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        customerProPri = new CustomerProfilePrivateBLL();
        List<CustomerProfilePrivate> lstPri = customerProPri.GetCustomerProfilePrivateWithInfoID(4032);
        gwCustomerProfilePrivate.DataSource = lstPri;
        gwCustomerProfilePrivate.DataBind();
    }
}