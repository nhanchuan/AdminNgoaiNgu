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

public partial class ChuongTrinhHoc_LopHoc : BasePage
{
    nc_LoaiCTDaoTaoBLL nc_loaictdaotao;
    nc_ChuongTrinhDaoTaoBLL nc_chuongtrinhdaotao;
    nc_LopHocBLL nc_lophoc;
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
                if (!check_permiss(ac.UserID, FunctionName.LopHoc))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlLoaiChuongtrinh();
                    this.load_gwLopHoc();
                    btnEditLopHoc.Attributes.Add("class", "btn btn-warning disabled");
                }
            }
        }
    }
    private void load_dlLoaiChuongtrinh()
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        dlLoaiChuongtrinh.DataSource = nc_loaictdaotao.getListLoaiCTDaoTao();
        dlLoaiChuongtrinh.DataTextField = "TenChuongTrinh";
        dlLoaiChuongtrinh.DataValueField = "ID";
        dlLoaiChuongtrinh.DataBind();
        dlLoaiChuongtrinh.Items.Insert(0, new ListItem("-- Chọn loại chương trình --", "0"));
    }
    private void load_dlELoaiChuongTrinh()
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        dlELoaiChuongTrinh.DataSource = nc_loaictdaotao.getListLoaiCTDaoTao();
        dlELoaiChuongTrinh.DataTextField = "TenChuongTrinh";
        dlELoaiChuongTrinh.DataValueField = "ID";
        dlELoaiChuongTrinh.DataBind();
        dlELoaiChuongTrinh.Items.Insert(0, new ListItem("-- Chọn loại chương trình --", "0"));
    }
    private void load_dlEChuongTrinh(int loai)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        dlEChuongTrinh.DataSource = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithLoai(loai);
        dlEChuongTrinh.DataTextField = "TenChuongTrinh";
        dlEChuongTrinh.DataValueField = "ID";
        dlEChuongTrinh.DataBind();
        dlEChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình --", "0"));
    }
    protected void dlLoaiChuongtrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        dlChuongtrinh.DataSource = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithLoai(Convert.ToInt32(dlLoaiChuongtrinh.SelectedValue));
        dlChuongtrinh.DataTextField = "TenChuongTrinh";
        dlChuongtrinh.DataValueField = "ID";
        dlChuongtrinh.DataBind();
        dlChuongtrinh.Items.Insert(0, new ListItem("-- Chọn chương trình --", "0"));
    }
    private void load_gwLopHoc()
    {
        nc_lophoc = new nc_LopHocBLL();
        gwLopHoc.DataSource = nc_lophoc.getTBLopHoc();
        gwLopHoc.DataBind();
    }

    protected void gwLopHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        btnEditLopHoc.Attributes.Add("class", "btn btn-warning");
        int lophocID = Convert.ToInt32((gwLopHoc.SelectedRow.FindControl("lblID") as Label).Text);
        List<nc_LopHoc> lst = nc_lophoc.getListLopHocWithID(lophocID);
        nc_LopHoc lophoc = lst.FirstOrDefault();
        if(lophoc!=null)
        {
            txtETenLopHoc.Text = lophoc.TenLopHoc;
            txtEThoiLuong.Text = lophoc.ThoiLuong.ToString();
            txtEBangCap.Text = lophoc.BangCap;
            this.load_dlELoaiChuongTrinh();
            this.load_dlEChuongTrinh(lophoc.LoaiChuongTrinh);
            dlELoaiChuongTrinh.Items.FindByValue(lophoc.LoaiChuongTrinh.ToString()).Selected = true;
            dlEChuongTrinh.Items.FindByValue(lophoc.ChuongTrinh.ToString()).Selected = true;
            txtEMoTa.Text = lophoc.MoTa;
            txtEMucHocPhi.Text = lophoc.MucHocPhi.ToString();
        }
        else
        {
            return;
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        try
        {
            string tenlop = txtTenLopHoc.Text;
            int thoiluong = Convert.ToInt32(txtThoLuong.Text);
            string bangcap = txtBangCap.Text;
            int muchocphi = Convert.ToInt32(txtHocPhi.Text);
            int loaict = Convert.ToInt32(dlLoaiChuongtrinh.SelectedValue);
            int chuongtrinh = Convert.ToInt32(dlChuongtrinh.SelectedValue);
            string mota = txtMota.Text;
            int index = nc_lophoc.MaxItemindex() + 1;
            if (nc_lophoc.New_nc_LopHoc(tenlop, thoiluong, bangcap, muchocphi, loaict, chuongtrinh, mota, index))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Thêm thất bại. Lỗi kết nối cơ sở dữ liệu !')</script>");
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void dlELoaiChuongTrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        dlEChuongTrinh.DataSource = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithLoai(Convert.ToInt32(dlELoaiChuongTrinh.SelectedValue));
        dlEChuongTrinh.DataTextField = "TenChuongTrinh";
        dlEChuongTrinh.DataValueField = "ID";
        dlEChuongTrinh.DataBind();
        dlEChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình --", "0"));
    }

    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        try
        {
            int LopID = Convert.ToInt32((gwLopHoc.SelectedRow.FindControl("lblID") as Label).Text);
            string tenlop = txtETenLopHoc.Text;
            int thoiluong = Convert.ToInt32(txtEThoiLuong.Text);
            string bangcap = txtEBangCap.Text;
            int muchocphi = Convert.ToInt32(txtEMucHocPhi.Text);
            int loaict = Convert.ToInt32(dlELoaiChuongTrinh.SelectedValue);
            int chuongtrinh = Convert.ToInt32(dlEChuongTrinh.SelectedValue);
            string mota = txtEMoTa.Text;
            int index = nc_lophoc.MaxItemindex() + 1;
            if (nc_lophoc.Update_nc_LopHoc(LopID, tenlop, thoiluong, bangcap, muchocphi, loaict, chuongtrinh, mota))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Cập nhật thất bại. Lỗi kết nối cơ sở dữ liệu !')</script>");
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void gwLopHoc_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gwLopHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This Process is Building ! !')</script>");
    }

    [Serializable]
    class Number
    {
        int num;
        public Number(int num) // ham khoi tao
        {
            this.num = num;
        }
        public int getNum()     // ham tra ve gia tri num
        {
            return num;
        }
        public void setNum(int num) // ham set gia tri num
        {
            this.num = num;
        }
    }
    private void swap(Number a, Number b) // ham hoan vi
    {
        int temp = a.getNum();                  // gan num cua a cho temp
        a.setNum(b.getNum());                   // gan num cua b cho a
        b.setNum(temp);                         // gan temp cho num cua b
    }
    protected void lkbtnUp_Click(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int lop_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;

        List<nc_LopHoc> lst = nc_lophoc.getListLopHocWithID(lop_id);
        nc_LopHoc lophoc = lst.FirstOrDefault();

        List<nc_LopHoc> lstUP = nc_lophoc.getListLopHocWithIndex(nc_lophoc.MaxItemindexLK(lophoc.SapXep)); //index B
        nc_LopHoc lophoc_Up = lstUP.FirstOrDefault();

        if (lophoc_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(lophoc.ID);
            B = new Number(lophoc_Up.ID);
            a = new Number(lophoc.SapXep);
            b = new Number(lophoc_Up.SapXep);
            this.swap(a, b);
            this.nc_lophoc.UpdateSapXep(a.getNum(), A.getNum());
            this.nc_lophoc.UpdateSapXep(b.getNum(), B.getNum());
            this.load_gwLopHoc();
            gwLopHoc.SelectedIndex = -1;
        }
    }

    protected void lkbtnDown_Click(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int lop_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;

        List<nc_LopHoc> lst = nc_lophoc.getListLopHocWithID(lop_id);
        nc_LopHoc lophoc = lst.FirstOrDefault();

        List<nc_LopHoc> lstUP = nc_lophoc.getListLopHocWithIndex(nc_lophoc.MinItemindexLK(lophoc.SapXep)); //index B
        nc_LopHoc lophoc_Up = lstUP.FirstOrDefault();

        if (lophoc_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(lophoc.ID);
            B = new Number(lophoc_Up.ID);
            a = new Number(lophoc.SapXep);
            b = new Number(lophoc_Up.SapXep);
            this.swap(a, b);
            this.nc_lophoc.UpdateSapXep(a.getNum(), A.getNum());
            this.nc_lophoc.UpdateSapXep(b.getNum(), B.getNum());
            this.load_gwLopHoc();
            gwLopHoc.SelectedIndex = -1;
        }
    }
}