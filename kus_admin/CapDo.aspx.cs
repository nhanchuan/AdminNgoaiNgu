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

public partial class kus_admin_CapDo : BasePage
{
    kus_CapDoBLL capdo;
    kus_KhoiLopBLL khoilop;
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
                if (!check_permiss(ac.UserID, FunctionName.QLCapDo))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_gvCapDo();
                    this.ShowDLKhoiLop();
                }
            }
        }
    }
    private void load_gvCapDo()
    {
        capdo = new kus_CapDoBLL();
        gvCapDo.DataSource = capdo.getTBAllCapDo();
        gvCapDo.DataBind();
    }
    public void ShowDLKhoiLop()
    {
        khoilop = new kus_KhoiLopBLL();
        DropDownList ddlKhoiLop = gvCapDo.FooterRow.FindControl("dlAddKhoiLop") as DropDownList;
        ddlKhoiLop.DataSource = this.khoilop.getAllKhoiLop();
        ddlKhoiLop.DataTextField = "TenKhoiLop";
        ddlKhoiLop.DataValueField = "KhoiLopID";
        ddlKhoiLop.DataBind();

        ddlKhoiLop.Items.Insert(0, new ListItem("-----------", "0"));
    }
    protected void gvCapDo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCapDo.EditIndex = -1;
        this.load_gvCapDo();
        this.ShowDLKhoiLop();
    }

    protected void gvCapDo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCapDo.EditIndex = e.NewEditIndex;
        this.load_gvCapDo();
        this.ShowDLKhoiLop();
    }

    protected void gvCapDo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        capdo = new kus_CapDoBLL();
        int id = 0;
        string cdo = "";
        string mota = "";
        int klop = 0;

        GridViewRow row = gvCapDo.Rows[e.RowIndex];
        id = Convert.ToInt32(((Label)(row.FindControl("lblCapDoID"))).Text);
        cdo = ((TextBox)(row.FindControl("txtTenCapDo"))).Text;
        mota = ((TextBox)(row.FindControl("txtMoTaNgan"))).Text;

        klop = Convert.ToInt32(((DropDownList)row.FindControl("dlKhoiLop")).SelectedValue);

        if (this.capdo.Update_CapDo(id, cdo, klop, mota))
        {
            gvCapDo.EditIndex = -1;
            this.load_gvCapDo();
            this.ShowDLKhoiLop();
        }
        else
        {
            Response.Write("<script>alert('Cập nhật Cấp độ thất bại. Lỗi kết nối csdl !')</script>");
        }
       // Response.Write("<script>alert('"+id.ToString()+"  "+cdo+" "+mota+ "   " +klop.ToString()+"')</script>");
    }

    protected void gvCapDo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        khoilop = new kus_KhoiLopBLL();
        capdo = new kus_CapDoBLL();
        if (e.Row.RowType == DataControlRowType.DataRow &&
        (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        {
            DropDownList dlKhoiLop = (DropDownList)e.Row.FindControl("dlKhoiLop");
            dlKhoiLop.DataSource = khoilop.getAllKhoiLop();
            dlKhoiLop.DataValueField = "KhoiLopID";
            dlKhoiLop.DataTextField = "TenKhoiLop";
            dlKhoiLop.DataBind();
            dlKhoiLop.Items.Insert(0, new ListItem("-----------", "0"));

            Label lblCapdoId = (Label)e.Row.FindControl("lblUpdateCapDoID");
            List<kus_CapDo> lst = capdo.getAllCapDoWithId(int.Parse(lblCapdoId.Text));
            kus_CapDo cdo = lst.FirstOrDefault();

            dlKhoiLop.Items.FindByValue(cdo.KhoiLopID.ToString()).Selected = true;

            

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton del = e.Row.FindControl("lkDelKhoiLop") as LinkButton;
            del.Attributes.Add("onclick", "return confirm ('Bạn chắc chắn muốn xóa ?')");
        }

    }

    protected void gvCapDo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        capdo = new kus_CapDoBLL();
        int id = 0;
        id = Convert.ToInt32((gvCapDo.Rows[e.RowIndex].FindControl("lblCapDoID") as Label).Text);

        if(this.capdo.Delete_CapDo(id))
        {
            this.load_gvCapDo();
            this.ShowDLKhoiLop();
        }
        else
        {
            Response.Write("<script>alert('Xóa Cấp độ thất bại. Lỗi kết nối csdl !')</script>");
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        capdo = new kus_CapDoBLL();
        string cd = "";
        string mota = "";
        string khoilop = "";
        cd = (gvCapDo.FooterRow.FindControl("txtAddTenCapDo") as TextBox).Text;
        mota = (gvCapDo.FooterRow.FindControl("txtAddMoTa") as TextBox).Text;
        khoilop = (gvCapDo.FooterRow.FindControl("dlAddKhoiLop") as DropDownList).SelectedValue;

        if(this.capdo.AddNew_CapDo(cd,Convert.ToInt32(khoilop), mota))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm Cấp độ thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
}