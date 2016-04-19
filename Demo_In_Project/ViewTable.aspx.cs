using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
using System.Data.SqlClient;

public partial class Demo_In_Project_ViewTable : BasePage
{
    UserAccountsBLL useraccount;
    UserProfileBLL userprofile;
    ImagesBLL images;
    CategoryBLL category;
    CustomerBasicInfoBLL CustomerBasicInfo;
    CustomerProfilePrivateBLL CustomerProfilePrivate;
    ListOfNationalitiesBLL lstOfNationalities;
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
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
                this.load_Useraccount();
                this.load_userprofile(1);
                this.load_images(1);
                this.load_gwcatagory();
                this.load_CustomerBasicInfo();
                this.load_CustomerProfilePrivate();
                this.load_gwNationality();
               
            }
        }
    }
   
    protected void load_Useraccount()
    {
        useraccount = new UserAccountsBLL();
        gwUserAccount.DataSource = useraccount.getAllUseraccount();
        gwUserAccount.DataBind();
    }
    protected void load_userprofile(int proid)
    {
        userprofile = new UserProfileBLL();
        gwUserProfile.DataSource = userprofile.getUserProfileWithID(proid);
        gwUserProfile.DataBind();
    }
    protected void load_images(int userid)
    {
        images = new ImagesBLL();
        gwImguserupload.DataSource = images.getImagesWithUserUpload(1);
        gwImguserupload.DataBind();
    }
    protected void load_gwcatagory()
    {
        category = new CategoryBLL();
        gwcatagory.DataSource = category.getAllCategory();
        gwcatagory.DataBind();
    }
    protected void load_CustomerBasicInfo()
    {
        CustomerBasicInfo = new CustomerBasicInfoBLL();
        gwCustomerBasicInfo.DataSource= CustomerBasicInfo.GetCusBasicInfoWithCode("tNqDzg1512016");
        gwCustomerBasicInfo.DataBind();
    }
    protected void load_CustomerProfilePrivate()
    {
        CustomerProfilePrivate = new CustomerProfilePrivateBLL();
        gwCustomerProfilePrivate.DataSource = CustomerProfilePrivate.GetCustomerProfilePrivateWithRegisID(3042);
        gwCustomerProfilePrivate.DataBind();
    }
    protected void load_gwNationality()
    {
        lstOfNationalities = new ListOfNationalitiesBLL();
        gwNationality.DataSource = lstOfNationalities.getAllListOfNationalities();
        gwNationality.DataBind();
    }
    
}