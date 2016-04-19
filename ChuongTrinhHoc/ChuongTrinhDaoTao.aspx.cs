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

public partial class ChuongTrinhHoc_ChuongTrinhDaoTao : BasePage
{
    nc_LoaiCTDaoTaoBLL nc_loaictdaotao;
    nc_ChuongTrinhDaoTaoBLL nc_chuongtrinhdaotao;
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
                    this.load_gwChuongTrinhDaoTao();
                    this.load_dlLoaiChuongtrinh();
                    //btnEditChuongTrinhDaoTao.Visible = false;
                    btnEditChuongTrinhDaoTao.Attributes.Add("class", "btn btn-warning disabled");
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
    private void load_gwChuongTrinhDaoTao()
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        gwChuongTrinhDaoTao.DataSource = nc_chuongtrinhdaotao.TableChuongTrinhDaoTao();
        gwChuongTrinhDaoTao.DataBind();
    }


    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        string machuongtrinh = txtMaChuongTrinh.Text;
        string tenchuongtrinh = txtTenChuongTrinh.Text;
        int loaichuongtring = Convert.ToInt32(dlLoaiChuongtrinh.SelectedValue);
        string mota = txtMota.Text;
        if (nc_chuongtrinhdaotao.NewChuongTrinhDaoTao(machuongtrinh, tenchuongtrinh, loaichuongtring, mota, nc_chuongtrinhdaotao.MaxItemindex() + 1))
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
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int ct_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<nc_ChuongTrinhDaoTao> lst = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithID(ct_id);
        nc_ChuongTrinhDaoTao CTDT = lst.FirstOrDefault();

        List<nc_ChuongTrinhDaoTao> lstUP = nc_chuongtrinhdaotao.getChuongTrinhDaoTaoWithIndex(nc_chuongtrinhdaotao.MaxItemindexLK(CTDT.SapXep)); //index B
        nc_ChuongTrinhDaoTao CTDT_Up = lstUP.FirstOrDefault();

        if (CTDT_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(CTDT.ID);
            B = new Number(CTDT_Up.ID);
            a = new Number(CTDT.SapXep);
            b = new Number(CTDT_Up.SapXep);
            this.swap(a, b);
            this.nc_chuongtrinhdaotao.UpdateSapXep(a.getNum(), A.getNum());
            this.nc_chuongtrinhdaotao.UpdateSapXep(b.getNum(), B.getNum());
            this.load_gwChuongTrinhDaoTao();
            gwChuongTrinhDaoTao.SelectedIndex = -1;
        }
    }

    protected void lkbtnDown_Click(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int ct_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<nc_ChuongTrinhDaoTao> lst = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithID(ct_id);
        nc_ChuongTrinhDaoTao CTDT = lst.FirstOrDefault();

        List<nc_ChuongTrinhDaoTao> lstUP = nc_chuongtrinhdaotao.getChuongTrinhDaoTaoWithIndex(nc_chuongtrinhdaotao.MinItemindexLK(CTDT.SapXep)); //index B
        nc_ChuongTrinhDaoTao CTDT_Up = lstUP.FirstOrDefault();

        if (CTDT_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(CTDT.ID);
            B = new Number(CTDT_Up.ID);
            a = new Number(CTDT.SapXep);
            b = new Number(CTDT_Up.SapXep);
            this.swap(a, b);
            this.nc_chuongtrinhdaotao.UpdateSapXep(a.getNum(), A.getNum());
            this.nc_chuongtrinhdaotao.UpdateSapXep(b.getNum(), B.getNum());
            this.load_gwChuongTrinhDaoTao();
            gwChuongTrinhDaoTao.SelectedIndex = -1;
        }
    }

    protected void gwChuongTrinhDaoTao_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gwChuongTrinhDaoTao_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This Process is Building ! !')</script>");
    }

    protected void gwChuongTrinhDaoTao_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        //btnEditChuongTrinhDaoTao.Visible = true;
        btnEditChuongTrinhDaoTao.Attributes.Add("class", "btn btn-warning");
        int ctID = Convert.ToInt32((gwChuongTrinhDaoTao.SelectedRow.FindControl("lblID") as Label).Text);
        List<nc_ChuongTrinhDaoTao> lst = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithID(ctID);
        nc_ChuongTrinhDaoTao chuongtrinh = lst.FirstOrDefault();
        this.load_dlELoaiChuongTrinh();
        txtEMaChuongTrinh.Text = chuongtrinh.MaChuongTrinh;
        txtETenChuongTrinh.Text = chuongtrinh.TenChuongTrinh;
        dlELoaiChuongTrinh.Items.FindByValue(chuongtrinh.LoaiChuongTrinh.ToString()).Selected = true;
        txtEMota.Text = chuongtrinh.MoTa;
    }

    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();


        if (gwChuongTrinhDaoTao.SelectedRow == null)
        {
            Response.Write("<script>alert('Vui lòng chọn chương trình đào tạo !')</script>");
        }
        else
        {
            string machuongtrinh = txtEMaChuongTrinh.Text;
            string tenchuongtrinh = txtETenChuongTrinh.Text;
            int loaichuongtrinh = Convert.ToInt32(dlELoaiChuongTrinh.SelectedValue);
            string mota = txtEMota.Text;
            int ctID = Convert.ToInt32((gwChuongTrinhDaoTao.SelectedRow.FindControl("lblID") as Label).Text);
            if (nc_chuongtrinhdaotao.UpdateChuongTrinhDaoTao(ctID, machuongtrinh, tenchuongtrinh, loaichuongtrinh,mota))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Cập nhật chương trình thất bại. Lỗi kết nỗi cơ sở dữ liệu !')</script>");
            }
        }
    }
}