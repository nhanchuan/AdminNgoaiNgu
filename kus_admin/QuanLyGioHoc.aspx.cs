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

public partial class kus_admin_QuanLyGioHoc : BasePage
{
    kus_GioHocBLL kus_giohoc;
    kus_GioThiBLL kus_gioiothi;
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
                if (!check_permiss(ac.UserID, FunctionName.QLGioHoc))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    if (!check_permiss(ac.UserID, FunctionName.NewUser))
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                    }
                    else
                    {
                        this.loadgwkus_GioHoc();
                        this.loadgwgwkus_GioThi();
                    }
                }
                
            }
        }
        
    }
    private void loadgwkus_GioHoc()
    {
        kus_giohoc = new kus_GioHocBLL();
        gvGioHoc.DataSource = kus_giohoc.getAllkus_GioHoc();
        gvGioHoc.DataBind();
    }
    protected void gvGioHoc_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGioHoc.EditIndex = e.NewEditIndex;
        this.loadgwkus_GioHoc();
    }
    protected void gvGioHoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGioHoc.EditIndex = -1;
        this.loadgwkus_GioHoc();
    }
    private string getday(string str)
    {
        string day = str.Substring(0, 2);
        return day;
    }
    private string getmonth(string str)
    {
        string month = "";
        List<clsmonth> lstmonth = new List<clsmonth>();
        lstmonth.Add(new clsmonth("01", "January"));
        lstmonth.Add(new clsmonth("02", "February"));
        lstmonth.Add(new clsmonth("03", "March"));
        lstmonth.Add(new clsmonth("04", "April"));
        lstmonth.Add(new clsmonth("05", "May"));
        lstmonth.Add(new clsmonth("06", "June"));
        lstmonth.Add(new clsmonth("07", "July"));
        lstmonth.Add(new clsmonth("08", "August"));
        lstmonth.Add(new clsmonth("09", "September"));
        lstmonth.Add(new clsmonth("10", "October"));
        lstmonth.Add(new clsmonth("11", "November"));
        lstmonth.Add(new clsmonth("12", "December"));
        foreach (clsmonth itm in lstmonth)
        {
            if (str.Contains(itm.Strmonth))
            {
                month = itm.Num;
            }
        }
        return month;
    }
    [Serializable()]
    public class clsmonth
    {
        public string Num { get; set; }
        public string Strmonth { get; set; }
        public clsmonth(string num, string strmonth)
        {
            Num = num;
            Strmonth = strmonth;
        }
    }
    private string getyear(string str)
    {
        string year = str.Substring(str.IndexOf("-") - 5, 4);
        return year;
    }
    private string gethours(string str)
    {
        string hours = str.Substring(str.IndexOf(":") - 2, 2);
        return hours;
    }
    private string getminutes(string str)
    {
        string minutes = str.Substring(str.IndexOf(":") + 1, 2);
        return minutes;
    }
    private string gettimeRefix(string str)
    {
        string re = str.Substring(str.Length - 2, 2);
        return re;
    }
    protected void gvGioHoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //lấy thông tin text box
        string id = "";
        string tiethoc = "";
        string starttime = "";
        string endtime = "";
        kus_giohoc = new kus_GioHocBLL();
        GridViewRow row = gvGioHoc.Rows[e.RowIndex];

        id = ((Label)(row.FindControl("lblGioHoc_ID"))).Text;
        tiethoc = ((Label)(row.FindControl("lblETietHoc"))).Text;
        starttime = ((TextBox)(row.FindControl("txtEditStartTime"))).Text;
        endtime = ((TextBox)(row.FindControl("txtEditEndTime"))).Text;

        //DateTime StartTime;
        //DateTime EndTime;
        try
        {
            //StartTime=(string.IsNullOrWhiteSpace(starttime))? Convert.ToDateTime("01/01/1900"): Convert.ToDateTime(getmonth(starttime) + "/" + getday(starttime) + "/" + getyear(starttime) + " " + gethours(starttime) + ":" + getminutes(starttime) + ":00" + " " + gettimeRefix(starttime));
            //EndTime= (string.IsNullOrWhiteSpace(endtime)) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(getmonth(endtime) + "/" + getday(endtime) + "/" + getyear(endtime) + " " + gethours(endtime) + ":" + getminutes(endtime) + ":00" + " " + gettimeRefix(endtime));
            this.kus_giohoc.GioHoc_Update(id, tiethoc, starttime, endtime);
        }
        catch
        {
            Response.Write("<script>alert('Fales to Datetime format !')</script>");
        }
        gvGioHoc.EditIndex = -1;
        this.loadgwkus_GioHoc();
    }
    protected void gvGioHoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton del = e.Row.Cells[5].Controls[0] as LinkButton;
                LinkButton del = e.Row.FindControl("lkDelGiohoc") as LinkButton;
                del.Attributes.Add("onclick", "return confirm ('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {
        }
    }
    protected void gvGioHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_giohoc = new kus_GioHocBLL();
        string id = "";
        id = ((Label)(gvGioHoc.Rows[e.RowIndex].FindControl("lblDelGioHoc_ID"))).Text;
        
        if (!this.kus_giohoc.GioHoc_Delete(id))
            Response.Write("<script>alert('Xóa thất bại. Xin thử lại')</script>");
        else
        {
            gvGioHoc.EditIndex = -1;
            this.loadgwkus_GioHoc();
        }
    }
    private void loadgwgwkus_GioThi()
    {
        kus_gioiothi = new kus_GioThiBLL();
        gvGioThi.DataSource = kus_gioiothi.getAllkus_GioThi();
        gvGioThi.DataBind();
    }
    protected void gvGioThi_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGioThi.EditIndex = -1;
        this.loadgwgwkus_GioThi();
    }
    protected void gvGioThi_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGioThi.EditIndex = e.NewEditIndex;
        this.loadgwgwkus_GioThi();
    }
    
    protected void gvGioThi_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        kus_gioiothi = new kus_GioThiBLL();
        //lấy thông tin text box
        string id = "";
        string tietthi = "";
        string giothi = "";
        GridViewRow row = gvGioThi.Rows[e.RowIndex];
        id = ((Label)(row.FindControl("lblGioThi_ID"))).Text;
        tietthi = ((TextBox)(row.FindControl("txtTietThi"))).Text;
        giothi = ((TextBox)(row.FindControl("txtGioThi"))).Text;
        this.kus_gioiothi.GioThi_Update(id, tietthi, giothi);
        gvGioThi.EditIndex = -1;
        this.loadgwgwkus_GioThi();
    }
    protected void gvGioThi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton del = e.Row.Cells[4].Controls[0] as LinkButton;
                LinkButton del = e.Row.FindControl("lkDelGioThi") as LinkButton;
                del.Attributes.Add("onclick", "return confirm ('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {
        }
    }
    protected void gvGioThi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_gioiothi = new kus_GioThiBLL();
        string id = "";
        id = ((Label)(gvGioThi.Rows[e.RowIndex].FindControl("lblDelGioThi_ID"))).Text;

        if (!this.kus_gioiothi.GioThi_Delete(id))
            Response.Write("<script>alert('Xóa thất bại. Xin thử lại')</script>");
        else
        {
            gvGioThi.EditIndex = -1;
            this.loadgwgwkus_GioThi();
        }
    }

    protected void btnNewGioHoc_Click(object sender, EventArgs e)
    {
        kus_giohoc = new kus_GioHocBLL();
        string tiethoc = "";
        string starttime = "";
        string endtime = "";
        int buoihoc = 0;
        TextBox txttiethoc = (TextBox)gvGioHoc.FooterRow.FindControl("txtNewTietHoc");
        tiethoc = txttiethoc.Text;
        TextBox txtstarttime = (TextBox)gvGioHoc.FooterRow.FindControl("txtAddStartTime");
        starttime = txtstarttime.Text;
        TextBox txtendtime = (TextBox)gvGioHoc.FooterRow.FindControl("txtAddEndTime");
        endtime = txtendtime.Text;
        DropDownList dlbuoihoc = (DropDownList)gvGioHoc.FooterRow.FindControl("dlNewBuoiHoc");
        buoihoc = Convert.ToInt32(dlbuoihoc.SelectedValue);

        if (this.kus_giohoc.GioHoc_AddNew(tiethoc, starttime, endtime, buoihoc))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
            Response.Write("<script>alert('Thêm giờ học thất bại, vui lòng thử lại')</script>");
    }
    protected void btnAddGioThi_Click(object sender, EventArgs e)
    {
        kus_gioiothi = new kus_GioThiBLL();
        string tietthi = "";
        string giothi = "";
        TextBox txttietthi = (TextBox)gvGioThi.FooterRow.FindControl("txtAddTietThi");
        TextBox txtgiothi = (TextBox)gvGioThi.FooterRow.FindControl("txtAddGioThi");
        tietthi = txttietthi.Text;
        giothi = txtgiothi.Text;
        if (this.kus_gioiothi.GioThi_AddNew(tietthi, giothi))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
            Response.Write("<script>alert('Thêm giờ học thất bại, vui lòng thử lại')</script>");
    }
}