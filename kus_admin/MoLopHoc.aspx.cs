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

public partial class kus_admin_MoLopHoc : BasePage
{
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
    kus_KhoiLopBLL kus_khoilop;
    kus_CapDoBLL kus_capdo;
    kus_LopHocBLL kus_lophoc;
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
                if (!check_permiss(ac.UserID, FunctionName.ThemLopHoc))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlHTChiNhanh();
                    this.load_dlKhoiLop();
                    dlHTChiNhanh.Items.Insert(0, new ListItem("------- Chọn Hệ Thống Chi Nhánh -------", "0"));
                    dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
                    dlKhoiLop.Items.Insert(0, new ListItem("------- Chọn Chương Trình Học -------", "0"));
                    dlCapDo.Items.Insert(0, new ListItem("------- Chọn Cấp Độ trong Chương Trình Học -------", "0"));
                }
            }
        }
    }
    private void load_dlHTChiNhanh()
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        dlHTChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
        dlHTChiNhanh.DataTextField = "tenHTChiNhanh";
        dlHTChiNhanh.DataValueField = "hTChiNhanhID";
        dlHTChiNhanh.DataBind();
    }
    protected void dlHTChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        dlCoSo.DataSource = kus_coso.getLSTCoSoWithChiNhanhID(Convert.ToInt32(dlHTChiNhanh.SelectedValue));
        dlCoSo.DataTextField = "TenCoSo";
        dlCoSo.DataValueField = "CoSoID";
        dlCoSo.DataBind();
        dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------","0"));
    }
    private void load_dlKhoiLop()
    {
        kus_khoilop = new kus_KhoiLopBLL();
        dlKhoiLop.DataSource = kus_khoilop.getAllKhoiLop();
        dlKhoiLop.DataTextField = "TenKhoiLop";
        dlKhoiLop.DataValueField = "KhoiLopID";
        dlKhoiLop.DataBind();
    }

    protected void dlKhoiLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_capdo = new kus_CapDoBLL();
        dlCapDo.DataSource = kus_capdo.getCapDoWithKhoiLopID(Convert.ToInt32(dlKhoiLop.SelectedValue));
        dlCapDo.DataTextField = "TenCapDo";
        dlCapDo.DataValueField = "CapDoID";
        dlCapDo.DataBind();
        dlCapDo.Items.Insert(0, new ListItem("------- Chọn Cấp Độ trong Chương Trình Học -------", "0"));
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
    protected void btnLuuThongTin_Click(object sender, EventArgs e)
    {
        kus_lophoc = new kus_LopHocBLL();
        string tenlop = txtTenLopHoc.Text;
        string ngaykhaigiang = txtNgayKG.Text;
        int thoiluong = Convert.ToInt32(txtThoiLuongHoc.Text);
        string ngayketthuc = txtNgayKT.Text;
        int sisotoida = Convert.ToInt32(txtSiSoToiDa.Text);
        int muchocphi = Convert.ToInt32(txtMucHocPhi.Text);
        int capdo = Convert.ToInt32(dlCapDo.SelectedValue);
        int coso = Convert.ToInt32(dlCoSo.SelectedValue);

        DateTime NgayKG;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (ngaykhaigiang == "" || string.IsNullOrWhiteSpace(ngaykhaigiang) || DateTime.TryParseExact(ngaykhaigiang, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKG) || getday(ngaykhaigiang) == "" || getmonth(ngaykhaigiang) == "" || getyear(ngaykhaigiang) == "")
        {
            NgayKG = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            NgayKG = DateTime.ParseExact(getday(ngaykhaigiang) + "/" + getmonth(ngaykhaigiang) + "/" + getyear(ngaykhaigiang), "dd/MM/yyyy", null);
        }
        DateTime NgayKT;
        if (ngayketthuc == "" || string.IsNullOrWhiteSpace(ngayketthuc) || DateTime.TryParseExact(ngayketthuc, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKT) || getday(ngayketthuc) == "" || getmonth(ngayketthuc) == "" || getyear(ngayketthuc) == "")
        {
            NgayKT = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            NgayKT = DateTime.ParseExact(getday(ngayketthuc) + "/" + getmonth(ngayketthuc) + "/" + getyear(ngayketthuc), "dd/MM/yyyy", null);
        }

        if(kus_lophoc.NewLopHoc(tenlop,NgayKG,thoiluong,NgayKT,sisotoida,capdo,muchocphi,1,coso))
        {
            Response.Write("<script>alert('Tạo Lớp Mới thành công !')</script>");
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Mở Lớp Mới không thành công ! Lỗi kết nối máy chủ !')</script>");
        }
    }
}