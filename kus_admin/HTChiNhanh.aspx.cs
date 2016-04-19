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

public partial class kus_admin_HTChiNhanh : BasePage
{
    kus_HTChiNhanhBLL kus_htchinhanh;
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
                if (!check_permiss(ac.UserID, FunctionName.QLChiNhanh))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.ShowChiNhanh();
                    this.showdlGDChiNhanh();
                }
            }
        }
    }
    private void ShowChiNhanh()
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        gvChiNhanh.DataSource = this.kus_htchinhanh.getAllTBChiNhanh();
        gvChiNhanh.DataBind();
    }
    private void showdlGDChiNhanh()
    {
        employees = new EmployeesBLL();
        DropDownList dlGDChiNhanh = gvChiNhanh.FooterRow.FindControl("dlAddGiamDoc") as DropDownList;
        dlGDChiNhanh.DataSource = employees.DropdownEmployeesWithDepartments(4);
        dlGDChiNhanh.DataTextField = "Name";
        dlGDChiNhanh.DataValueField = "EmployeesID";
        dlGDChiNhanh.DataBind();
        dlGDChiNhanh.Items.Insert(0, new ListItem("-------------------------------", "0"));
    }
    protected void gvChiNhanh_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvChiNhanh.EditIndex = -1;
        ShowChiNhanh();
        this.showdlGDChiNhanh();
    }

    protected void gvChiNhanh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        employees = new EmployeesBLL();
        if(e.Row.RowType==DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit)==DataControlRowState.Edit)
        {
            DropDownList dlGDChiNhanh = (DropDownList)e.Row.FindControl("dlGDChiNhanh");
            dlGDChiNhanh.DataSource = employees.DropdownEmployeesWithDepartments(4);
            dlGDChiNhanh.DataTextField = "Name";
            dlGDChiNhanh.DataValueField = "EmployeesID";
            dlGDChiNhanh.DataBind();
            dlGDChiNhanh.Items.Insert(0, new ListItem("-------------------------------", "0"));
            Label lblGDchinhanh = (Label)e.Row.FindControl("lblGiamDocCN_ID");
            dlGDChiNhanh.Items.FindByValue((string.IsNullOrWhiteSpace(lblGDchinhanh.Text)) ? "0": lblGDchinhanh.Text).Selected = true;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton del = e.Row.FindControl("linkbtnDelete") as LinkButton;
            del.Attributes.Add("onclick", "return confirm ('Bạn chắc chắn muốn xóa ?')");
        }
    }

    protected void gvChiNhanh_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        int id = 0;
        id = Convert.ToInt32((gvChiNhanh.Rows[e.RowIndex].FindControl("lblChiNhanh_ID") as Label).Text);

        if(this.kus_htchinhanh.Delete_HTChiNhanh(id))
        {
            gvChiNhanh.EditIndex = -1;
            ShowChiNhanh();
            this.showdlGDChiNhanh();
        }
       else
        {
            Response.Write("<script>alert('Xóa Cấp độ thất bại. Lỗi kết nối csdl !')</script>");
        }
    }

    protected void gvChiNhanh_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvChiNhanh.EditIndex = e.NewEditIndex;
        ShowChiNhanh();
        this.showdlGDChiNhanh();
    }

    protected void gvChiNhanh_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        int id = 0;
        string chinhanh = "";
        string ghichu = "";
        int gdchinhanh = 0;

        GridViewRow row = gvChiNhanh.Rows[e.RowIndex];

        id = Convert.ToInt32((row.FindControl("lblChiNhanh_ID") as Label).Text);
        chinhanh = (row.FindControl("txtChiNhanh") as TextBox).Text;
        ghichu = (row.FindControl("txtGhiChu") as TextBox).Text;
        gdchinhanh = Convert.ToInt32((row.FindControl("dlGDChiNhanh") as DropDownList).SelectedValue);


        if (this.kus_htchinhanh.Update_HTChiNhanh(id, chinhanh, ghichu, gdchinhanh))
        {
            gvChiNhanh.EditIndex = -1;
            ShowChiNhanh();
        }
        else
        {
            Response.Write("<script>alert('Cập nhật Chi nhánh thất bại. Lỗi kết nối csdl !')</script>");
        }
        
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        string chinhanh = "";
        string ghichu = "";
        int giamdoc_id = 0;

        chinhanh = (gvChiNhanh.FooterRow.FindControl("txtAddChiNhanh") as TextBox).Text;
        ghichu = (gvChiNhanh.FooterRow.FindControl("txtAddGhiChu") as TextBox).Text;
        giamdoc_id = Convert.ToInt32((gvChiNhanh.FooterRow.FindControl("dlAddGiamDoc") as DropDownList).SelectedValue);

        if(this.kus_htchinhanh.AddNew_HTChiNhanh(chinhanh, ghichu, giamdoc_id))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm Chi Nhánh thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
}