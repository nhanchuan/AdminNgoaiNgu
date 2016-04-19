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

public partial class ChuongTrinhHoc_LoaiHinhDaoTao : BasePage
{
    nc_LoaiHinhDaoTaoBLL nc_loaihinhdaotao;
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
                    this.load_gwLoaiHinhDaoTao();
                    btnEditLoaiHinhDT.Attributes.Add("class", "btn btn-warning disabled");
                }
            }
        }
    }
    private void load_gwLoaiHinhDaoTao()
    {
        nc_loaihinhdaotao = new nc_LoaiHinhDaoTaoBLL();
        gwLoaiHinhDaoTao.DataSource = nc_loaihinhdaotao.getListLoaiHinhDaoTao();
        gwLoaiHinhDaoTao.DataBind();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        nc_loaihinhdaotao = new nc_LoaiHinhDaoTaoBLL();
        string maloaihinh = txtMaLoaiHinh.Text;
        string tenloaihinh = txtTenLoaiHinh.Text;
        if(nc_loaihinhdaotao.NewLoaiHinhDaoTao(maloaihinh,tenloaihinh))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm loại hình thất bại. Lỗi kết nỗi cơ sở dữ liệu !')</script>");
        }
    }

    protected void gwLoaiHinhDaoTao_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDel") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwLoaiHinhDaoTao_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        nc_loaihinhdaotao = new nc_LoaiHinhDaoTaoBLL();
        try
        {
            //int ldID = Convert.ToInt32((gwLoaiHinhDaoTao.Rows[e.RowIndex].FindControl("lblID") as Label).Text);
            //if(nc_loaihinhdaotao.DeleteLoaiHinhDaoTao(ldID))
            //{
            //    Response.Redirect(Request.Url.AbsoluteUri);
            //}
            //else
            //{
            //    Response.Write("<script>alert('Xóa loại hình thất bại. Lỗi kết nỗi cơ sở dữ liệu !')</script>");
            //}
            Response.Write("<script>alert('This Process is Building ! !')</script>");
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + " !')</script>");
        }
    }

    protected void gwLoaiHinhDaoTao_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_loaihinhdaotao = new nc_LoaiHinhDaoTaoBLL();
        btnEditLoaiHinhDT.Attributes.Add("class", "btn btn-warning");
        int lhID = Convert.ToInt32((gwLoaiHinhDaoTao.SelectedRow.FindControl("lblID") as Label).Text);
        List<nc_LoaiHinhDaoTao> lst = nc_loaihinhdaotao.getListLoaiHinhDaoTaoWithID(lhID);
        nc_LoaiHinhDaoTao lhdt = lst.FirstOrDefault();
        txtEMaLoaiHinh.Text = lhdt.MaLoaiHinh;
        txtETenLoaiHinh.Text = lhdt.TenLoaiHinh;
    }

    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {
        nc_loaihinhdaotao = new nc_LoaiHinhDaoTaoBLL();
        if(gwLoaiHinhDaoTao.SelectedRow==null)
        {
            Response.Write("<script>alert('Vui lòng chọn một loại hình đào tạo !')</script>");
        }
        else
        {
            int lhID = Convert.ToInt32((gwLoaiHinhDaoTao.SelectedRow.FindControl("lblID") as Label).Text);
            string maloaihinh = txtEMaLoaiHinh.Text;
            string tenloaihinh = txtETenLoaiHinh.Text;
            if(nc_loaihinhdaotao.UpdateLoaiHinhDaoTao(lhID,maloaihinh,tenloaihinh))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Cập nhật loại hình thất bại. Lỗi kết nỗi cơ sở dữ liệu !')</script>");
            }
        }
    }
}