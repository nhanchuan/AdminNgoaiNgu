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

public partial class kus_admin_KhoiLop : BasePage
{
    kus_KhoiLopBLL khoilop;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if(!IsPostBack)
        {
            UserAccounts ac = Session.GetCurrentUser();
            if (ac == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(ac.UserID, FunctionName.QLKhoiLop))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.ShowKhoiLop();
                }
            }
        }
    }
    public void ShowKhoiLop()
    {
        khoilop = new kus_KhoiLopBLL();
        gvKhoiLop.DataSource = khoilop.getAllKhoiLop();
        gvKhoiLop.DataBind();
    }

    protected void gvKhoiLop_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvKhoiLop.EditIndex = -1;
        ShowKhoiLop();
    }

    protected void gvKhoiLop_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvKhoiLop.EditIndex = e.NewEditIndex;
        ShowKhoiLop();
    }

    protected void gvKhoiLop_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        khoilop = new kus_KhoiLopBLL();
        string id = "";
        string tenkhoi = "";
        string mota = "";

        GridViewRow row = gvKhoiLop.Rows[e.RowIndex];

        id = ((Label)(row.FindControl("lblKhoiLop_ID"))).Text;
        tenkhoi = ((TextBox)(row.FindControl("txtTenKhoi"))).Text;
        mota = ((TextBox)(row.FindControl("txtMoTa"))).Text;

         if(!this.khoilop.Update_KhoiLop(id, tenkhoi, mota))
        {
            Response.Write("<script>alert('Cập nhật Khối Lớp thất bại. Lỗi kết nối csdl !')</script>");
        }
         else
        {
            gvKhoiLop.EditIndex = -1;
            ShowKhoiLop();
        }
    }

    protected void gvKhoiLop_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton del = e.Row.Cells[5].Controls[0] as LinkButton;
                LinkButton del = e.Row.FindControl("lkDelKhoiLop") as LinkButton;
                del.Attributes.Add("onclick", "return confirm ('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {
        }
    }

    protected void gvKhoiLop_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        khoilop = new kus_KhoiLopBLL();
        string id = "";
        id = ((Label)(gvKhoiLop.Rows[e.RowIndex].FindControl("lblKhoiLop_ID"))).Text;
        
        if (!this.khoilop.Delete_KhoiLop(id))
            Response.Write("<script>alert('Xóa thất bại. Xin thử lại')</script>");
        else
        {
            gvKhoiLop.EditIndex = -1;
            ShowKhoiLop();
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        khoilop = new kus_KhoiLopBLL();
        string tenkhoi = "";
        string mota = "";

        TextBox txttenkhoi = (TextBox)gvKhoiLop.FooterRow.FindControl("txtAddTenKhoi");
        tenkhoi = txttenkhoi.Text;

        TextBox txtmota = (TextBox)gvKhoiLop.FooterRow.FindControl("txtAddMoTa");
        mota = txtmota.Text;

       if(khoilop.AddNew_KhoiLop(tenkhoi,mota))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
       else
        {
            Response.Write("<script>alert('Thêm Khối Lớp thất bại. Lỗi kết nối csdl !')</script>");
        }
        gvKhoiLop.EditIndex = -1;
        ShowKhoiLop();
    }
}