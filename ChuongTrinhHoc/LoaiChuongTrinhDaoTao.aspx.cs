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

public partial class ChuongTrinhHoc_LoaiChuongTrinhDaoTao : BasePage
{
    nc_LoaiHinhDaoTaoBLL nc_loaihinhdaotao;
    nc_LoaiCTDaoTaoBLL nc_loaictdaotao;
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
                if (!check_permiss(ac.UserID, FunctionName.LoaiChuongTrinhDaoTao))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlLoaiHinhDaoTao();
                    this.load_gwLoaiCTDaoTao();
                    btnEditLoaiChuongTrinhDT.Attributes.Add("class", "btn btn-warning disabled");
                }
            }
        }
    }
    private void load_dlLoaiHinhDaoTao()
    {
        nc_loaihinhdaotao = new nc_LoaiHinhDaoTaoBLL();
        dlLoaiHinhDaoTao.DataSource = nc_loaihinhdaotao.getListLoaiHinhDaoTao();
        dlLoaiHinhDaoTao.DataTextField = "TenLoaiHinh";
        dlLoaiHinhDaoTao.DataValueField = "ID";
        dlLoaiHinhDaoTao.DataBind();
        dlLoaiHinhDaoTao.Items.Insert(0, new ListItem("-- Chọn loại hình đào tạo --", "0"));
    }
    private void load_dlEthuocLoai()
    {
        nc_loaihinhdaotao = new nc_LoaiHinhDaoTaoBLL();
        dlEthuocLoai.DataSource = nc_loaihinhdaotao.getListLoaiHinhDaoTao();
        dlEthuocLoai.DataTextField = "TenLoaiHinh";
        dlEthuocLoai.DataValueField = "ID";
        dlEthuocLoai.DataBind();
        dlEthuocLoai.Items.Insert(0, new ListItem("-- Chọn loại hình đào tạo --", "0"));
    }
    private void load_gwLoaiCTDaoTao()
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        gwLoaiCTDaoTao.DataSource = nc_loaictdaotao.getTableLoaiCTDaoTao();
        gwLoaiCTDaoTao.DataBind();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        string machuongtrinh = txtMaLoaiChuongTrinh.Text;
        string tenchuongtrinh = txtTenLoaiChuongTrinh.Text;
        int lhdt = Convert.ToInt32(dlLoaiHinhDaoTao.SelectedValue);
        if (nc_loaictdaotao.NewLoaiCTDaoTao(machuongtrinh, tenchuongtrinh, lhdt, nc_loaictdaotao.MaxItemindex() + 1))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm thất bại. Lỗi kết nối cơ sở dữ liệu !')</script>");
        }
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
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int loai_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<nc_LoaiCTDaoTao> lst = nc_loaictdaotao.getLoaiCTDaoTaoWithID(loai_id);
        nc_LoaiCTDaoTao LCTDT = lst.FirstOrDefault();

        List<nc_LoaiCTDaoTao> lstUP = nc_loaictdaotao.getLoaiCTDaoTaoWithIndex(nc_loaictdaotao.MaxItemindexLK(LCTDT.SapXep)); //index B
        nc_LoaiCTDaoTao LCTDT_Up = lstUP.FirstOrDefault();

        if (LCTDT_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(LCTDT.ID);
            B = new Number(LCTDT_Up.ID);
            a = new Number(LCTDT.SapXep);
            b = new Number(LCTDT_Up.SapXep);
            this.swap(a, b);
            this.nc_loaictdaotao.UpdateSapXep(a.getNum(), A.getNum());
            this.nc_loaictdaotao.UpdateSapXep(b.getNum(), B.getNum());
            this.load_gwLoaiCTDaoTao();
            gwLoaiCTDaoTao.SelectedIndex = -1;
        }
    }

    protected void lkbtnDown_Click(object sender, EventArgs e)
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int loai_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<nc_LoaiCTDaoTao> lst = nc_loaictdaotao.getLoaiCTDaoTaoWithID(loai_id);
        nc_LoaiCTDaoTao LCTDT = lst.FirstOrDefault();

        List<nc_LoaiCTDaoTao> lstUP = nc_loaictdaotao.getLoaiCTDaoTaoWithIndex(nc_loaictdaotao.MinItemindexLK(LCTDT.SapXep)); //index B
        nc_LoaiCTDaoTao LCTDT_Up = lstUP.FirstOrDefault();

        if (LCTDT_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(LCTDT.ID);
            B = new Number(LCTDT_Up.ID);
            a = new Number(LCTDT.SapXep);
            b = new Number(LCTDT_Up.SapXep);
            this.swap(a, b);
            this.nc_loaictdaotao.UpdateSapXep(a.getNum(), A.getNum());
            this.nc_loaictdaotao.UpdateSapXep(b.getNum(), B.getNum());
            this.load_gwLoaiCTDaoTao();
            gwLoaiCTDaoTao.SelectedIndex = -1;
        }
    }

    protected void gwLoaiCTDaoTao_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        btnEditLoaiChuongTrinhDT.Attributes.Add("class", "btn btn-warning");
        int lctID = Convert.ToInt32((gwLoaiCTDaoTao.SelectedRow.FindControl("lblID") as Label).Text);
        List<nc_LoaiCTDaoTao> lst = nc_loaictdaotao.getLoaiCTDaoTaoWithID(lctID);
        nc_LoaiCTDaoTao lct = lst.FirstOrDefault();
        txtEMaLoai.Text = lct.MaChuongTrinh;
        txtETenLoai.Text = lct.TenChuongTrinh;
        this.load_dlEthuocLoai();
        dlEthuocLoai.Items.FindByValue(lct.LHDT.ToString()).Selected = true;
    }

    protected void gwLoaiCTDaoTao_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gwLoaiCTDaoTao_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This Process is Building ! !')</script>");
    }

    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        

        if (gwLoaiCTDaoTao.SelectedRow == null)
        {
            Response.Write("<script>alert('Vui lòng chọn một loại chương trình đào tạo !')</script>");
        }
        else
        {
            string machuongtrinh = txtEMaLoai.Text;
            string tenchuongtrinh = txtETenLoai.Text;
            int lhdt = Convert.ToInt32(dlEthuocLoai.SelectedValue);
            int lctID = Convert.ToInt32((gwLoaiCTDaoTao.SelectedRow.FindControl("lblID") as Label).Text);
            if (nc_loaictdaotao.UpdateLoaiCTDaoTao(machuongtrinh, tenchuongtrinh, lhdt, lctID))
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