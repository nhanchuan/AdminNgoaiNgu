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
using System.Globalization;
using System.Text.RegularExpressions;

public partial class kus_admin_HTCoSo : BasePage
{
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
    EmployeesBLL employees;
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
                if (!check_permiss(ac.UserID, FunctionName.QLCoso))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_gvCoSo();
                    this.showdlQLCoso();
                    this.load_dlAddHTChiNhanh();
                }
            }
        }
    }
    private void load_gvCoSo()
    {
        kus_coso = new kus_CoSoBLL();
        gvCoSo.DataSource = kus_coso.getAllHTCoSo();
        gvCoSo.DataBind();
    }
    private void showdlQLCoso()
    {
        employees = new EmployeesBLL();
        DropDownList dlQLCoSo = gvCoSo.FooterRow.FindControl("dlAddQLCoSo") as DropDownList;
        dlQLCoSo.DataSource = employees.DropdownEmployeesWithDepartments(4);
        dlQLCoSo.DataTextField = "Name";
        dlQLCoSo.DataValueField = "EmployeesID";
        dlQLCoSo.DataBind();
        dlQLCoSo.Items.Insert(0, new ListItem("-------------------------------", "0"));
    }
    private void load_dlAddHTChiNhanh()
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        DropDownList dlHTChiNhanh = gvCoSo.FooterRow.FindControl("dlAddHTChiNhanh") as DropDownList;
        dlHTChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
        dlHTChiNhanh.DataTextField = "TenHTChiNhanh";
        dlHTChiNhanh.DataValueField = "HTChiNhanhID";
        dlHTChiNhanh.DataBind();
        dlHTChiNhanh.Items.Insert(0, new ListItem("---------------------------", "0"));
    }
    protected void gvCoSo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCoSo.EditIndex = e.NewEditIndex;
        this.load_gvCoSo();
        this.showdlQLCoso();
        this.load_dlAddHTChiNhanh();
    }
    protected void gvCoSo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCoSo.EditIndex = -1;
        this.load_gvCoSo();
        this.showdlQLCoso();
        this.load_dlAddHTChiNhanh();
    }

    protected void gvCoSo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        employees = new EmployeesBLL();
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        {
            DropDownList dlhtChiNhanh = (DropDownList)e.Row.FindControl("dlHTChiNhanh");
            dlhtChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
            dlhtChiNhanh.DataTextField = "TenHTChiNhanh";
            dlhtChiNhanh.DataValueField = "HTChiNhanhID";
            dlhtChiNhanh.DataBind();
            dlhtChiNhanh.Items.Insert(0, new ListItem("---------------------------", "0"));

            DropDownList dlQLCoSo = (DropDownList)e.Row.FindControl("dlQLCoSo");
            dlQLCoSo.DataSource = employees.DropdownEmployeesWithDepartments(4);
            dlQLCoSo.DataTextField = "Name";
            dlQLCoSo.DataValueField = "EmployeesID";
            dlQLCoSo.DataBind();
            dlQLCoSo.Items.Insert(0, new ListItem("-------------------------------", "0"));

            Label lblHTChiNhanhID = (Label)e.Row.FindControl("lblHTChiNhanhID");
            dlhtChiNhanh.Items.FindByValue((string.IsNullOrWhiteSpace(lblHTChiNhanhID.Text)) ? "0" : lblHTChiNhanhID.Text).Selected = true;

            Label lblQLCoSo = (Label)e.Row.FindControl("lblQLCoSo");
            dlQLCoSo.Items.FindByValue((string.IsNullOrWhiteSpace(lblQLCoSo.Text)) ? "0" : lblQLCoSo.Text).Selected = true;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton del = e.Row.FindControl("linkbtnDelete") as LinkButton;
            del.Attributes.Add("onclick", "return confirm ('Bạn chắc chắn muốn xóa ?')");
        }
    }

    protected void gvCoSo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        int id = 0;
        id = Convert.ToInt32((gvCoSo.Rows[e.RowIndex].FindControl("lblCoSo_ID") as Label).Text);

        if(this.kus_coso.Delete_CoSo(id))
        {
            gvCoSo.EditIndex = -1;
            this.load_gvCoSo();
            this.showdlQLCoso();
            this.load_dlAddHTChiNhanh();
        }
        else
        {
            Response.Write("<script>alert('Xóa Cấp độ thất bại. Lỗi kết nối csdl !')</script>");
        }
    }

    protected void gvCoSo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        GridViewRow row = gvCoSo.Rows[e.RowIndex];
        int id = Convert.ToInt32((row.FindControl("lblCoSo_ID") as Label).Text);
        string coso = (row.FindControl("txtCoSo") as TextBox).Text;
        string diachi = (row.FindControl("txtDiaChi") as TextBox).Text;
        string fax = (row.FindControl("txtFax") as TextBox).Text;
        string phone = (row.FindControl("txtPhone") as TextBox).Text;
        string email = (row.FindControl("txtEmail") as TextBox).Text;
        string ghichu = (row.FindControl("txtGhiChu") as TextBox).Text;
        string nthanhlap = (row.FindControl("txtNgayThanhLap") as TextBox).Text;
        DateTime ngaythanhlap;
        int chinhanh = Convert.ToInt32((row.FindControl("dlHTChiNhanh") as DropDownList).SelectedValue);
        int qlcoso = Convert.ToInt32((row.FindControl("dlQLCoSo") as DropDownList).SelectedValue);
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (nthanhlap == "" || string.IsNullOrWhiteSpace(nthanhlap) || DateTime.TryParseExact(nthanhlap, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out ngaythanhlap))
        {
            ngaythanhlap = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            ngaythanhlap = DateTime.ParseExact(getday(nthanhlap) + "/" + getmonth(nthanhlap) + "/" + getyear(nthanhlap), "dd/MM/yyyy", null);
        }
        if (this.kus_coso.Update_CoSo(id, coso, diachi, fax, phone, email, ngaythanhlap, ghichu, chinhanh, qlcoso))
        {
            gvCoSo.EditIndex = -1;
            this.load_gvCoSo();
            this.showdlQLCoso();
            this.load_dlAddHTChiNhanh();
        }
        else
        {
            Response.Write("<script>alert('Cập nhật Cơ sở thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    public bool IsNumber(string pText)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        return regex.IsMatch(pText);
    }
    private string getday(string str)
    {
        string day = "";
        if (!IsNumber(str.Substring(0, 2)))
        {
            return "";
        }
        else
        {
            day = str.Substring(0, 2);
        }
        return day;
    }
    private string getmonth(string str)
    {
        string month = "";
        if (!IsNumber(str.Substring(3, 2)))
        {
            return "";
        }
        else
        {
            month = str.Substring(3, 2);
        }
        return month;
    }
    private string getyear(string str)
    {
        string year = "";
        if (str.Length != 10)
        {
            return "";
        }
        else
        {
            if (!IsNumber(str.Substring(6, 4)))
            {
                return "";
            }
            else
            {
                year = str.Substring(6, 4);
            }
        }
        return year;
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        kus_coso = new kus_CoSoBLL();
        string coso = (gvCoSo.FooterRow.FindControl("txtAddCoSo") as TextBox).Text;
        string diachi = (gvCoSo.FooterRow.FindControl("txtAddDiaChi") as TextBox).Text;
        string fax = (gvCoSo.FooterRow.FindControl("txtAddFax") as TextBox).Text;
        string phone = (gvCoSo.FooterRow.FindControl("txtAddPhone") as TextBox).Text;
        string email = (gvCoSo.FooterRow.FindControl("txtAddEmail") as TextBox).Text;
        string nthanhlap = (gvCoSo.FooterRow.FindControl("txtAddNgayThanhLap") as TextBox).Text;
        DateTime ngaythanhlap;
        string ghichu = (gvCoSo.FooterRow.FindControl("txtAddGhiChu") as TextBox).Text;
        int chinhanh = Convert.ToInt32((gvCoSo.FooterRow.FindControl("dlAddHTChiNhanh") as DropDownList).SelectedValue);
        int qlcoso = Convert.ToInt32((gvCoSo.FooterRow.FindControl("dlAddQLCoSo") as DropDownList).SelectedValue);
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (nthanhlap == "" || string.IsNullOrWhiteSpace(nthanhlap) || DateTime.TryParseExact(nthanhlap,formats, new CultureInfo("vi-VN"),DateTimeStyles.None, out ngaythanhlap) || getday(nthanhlap) == "" || getmonth(nthanhlap) == "" || getyear(nthanhlap) == "")
        {
            ngaythanhlap = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            ngaythanhlap = DateTime.ParseExact(getday(nthanhlap) + "/" + getmonth(nthanhlap) + "/" + getyear(nthanhlap), "dd/MM/yyyy", null);
        }
     

        if(this.kus_coso.AddNew_CoSo(coso, diachi, fax, phone, email, ngaythanhlap, ghichu, chinhanh, qlcoso))
        {
            gvCoSo.EditIndex = -1;
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm Cơ sở thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
}