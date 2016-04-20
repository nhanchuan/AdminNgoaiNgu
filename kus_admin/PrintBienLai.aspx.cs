using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using DAL;
using System.Globalization;

public partial class kus_admin_PrintBienLai : System.Web.UI.Page
{
    kus_BienLaiBLL kus_bienlai;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string BienLaiCode = Request.QueryString["BienLaiCode"];
            this.load_BienLaiInfor(BienLaiCode);
        }
    }
    private void load_BienLaiInfor(string BLCode)
    {
        kus_bienlai = new kus_BienLaiBLL();
        lbldayLien1.Text = DateTime.Now.Day.ToString();
        lblmonthLien1.Text = DateTime.Now.Month.ToString();
        lblyearLien1.Text = DateTime.Now.Year.ToString();
        lbldayLien2.Text = DateTime.Now.Day.ToString();
        lblmonthLien2.Text = DateTime.Now.Month.ToString();
        lblyearLien2.Text = DateTime.Now.Year.ToString();
        DataTable tbBienLai = kus_bienlai.kus_getBienLaiInfor(BLCode);
        foreach (DataRow r in tbBienLai.Rows)
        {
            lblBienLaicodeLien1.Text = (string.IsNullOrEmpty(r["BienLaiCode"].ToString())) ? "" : (string)r["BienLaiCode"];
            lblMaGhiDanhLien1.Text= (string.IsNullOrEmpty(r["GhiDanhCode"].ToString())) ? "" : (string)r["GhiDanhCode"];
            lblKhoaHocLien1.Text = (string.IsNullOrEmpty(r["MaKhoaHoc"].ToString())) ? "" : (string)r["MaKhoaHoc"];
            lblKhoaHocLien1.Text += (string.IsNullOrEmpty(r["TenKhoaHoc"].ToString())) ? "" : " - " + (string)r["TenKhoaHoc"];
            lblHoTenHVLien1.Text = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
            lblHoTenHVLien1.Text += (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : " " + (string)r["FirstName"];
            lblLyDoThuLien1.Text = (string.IsNullOrEmpty(r["LyDoThu"].ToString())) ? "" : (string)r["LyDoThu"];
            lblthoiluongLien1.Text = (string.IsNullOrEmpty(r["ThoiLuong"].ToString())) ? "0" : ((int)r["ThoiLuong"]).ToString() + " tiết";
            lblThanhTienLien1.Text = (string.IsNullOrEmpty(r["SoTien"].ToString())) ? "0" : ((int)r["SoTien"]).ToString("C", new CultureInfo("vi-VN"));
            lblThanhTienChuLien1.Text= (string.IsNullOrEmpty(r["SoTienBangChu"].ToString())) ? "" : (string)r["SoTienBangChu"];
            lblDiaChiLien1.Text= (string.IsNullOrEmpty(r["DCThuongTru"].ToString())) ? "" : (string)r["DCThuongTru"];
            lblDienthoaiLien1.Text= (string.IsNullOrEmpty(r["DienThoai"].ToString())) ? "" : (string)r["DienThoai"];
            NVGhiDanhLien1.Text= (string.IsNullOrEmpty(r["LastNameNV"].ToString())) ? "" : (string)r["LastNameNV"];
            NVGhiDanhLien1.Text += (string.IsNullOrEmpty(r["FirstNameNV"].ToString())) ? "" : " " + (string)r["FirstNameNV"];

            lblBienLaicodeLien2.Text = (string.IsNullOrEmpty(r["BienLaiCode"].ToString())) ? "" : (string)r["BienLaiCode"];
            lblMaGhiDanhLien2.Text = (string.IsNullOrEmpty(r["GhiDanhCode"].ToString())) ? "" : (string)r["GhiDanhCode"];
            lblKhoaHocLien2.Text = (string.IsNullOrEmpty(r["MaKhoaHoc"].ToString())) ? "" : (string)r["MaKhoaHoc"];
            lblKhoaHocLien2.Text += (string.IsNullOrEmpty(r["TenKhoaHoc"].ToString())) ? "" : " - " + (string)r["TenKhoaHoc"];
            lblHoTenHVLien2.Text = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
            lblHoTenHVLien2.Text += (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : " " + (string)r["FirstName"];
            lblLyDoThuLien2.Text = (string.IsNullOrEmpty(r["LyDoThu"].ToString())) ? "" : (string)r["LyDoThu"];
            lblthoiluongLien2.Text = (string.IsNullOrEmpty(r["ThoiLuong"].ToString())) ? "0" : ((int)r["ThoiLuong"]).ToString() + " tiết";
            lblThanhTienLien2.Text = (string.IsNullOrEmpty(r["SoTien"].ToString())) ? "0" : ((int)r["SoTien"]).ToString("C", new CultureInfo("vi-VN"));
            lblThanhTienChuLien2.Text = (string.IsNullOrEmpty(r["SoTienBangChu"].ToString())) ? "" : (string)r["SoTienBangChu"];
            lblDiaChiLien2.Text = (string.IsNullOrEmpty(r["DCThuongTru"].ToString())) ? "" : (string)r["DCThuongTru"];
            lblDienthoaiLien2.Text = (string.IsNullOrEmpty(r["DienThoai"].ToString())) ? "" : (string)r["DienThoai"];
            NVGhiDanhLien2.Text = (string.IsNullOrEmpty(r["LastNameNV"].ToString())) ? "" : (string)r["LastNameNV"];
            NVGhiDanhLien2.Text += (string.IsNullOrEmpty(r["FirstNameNV"].ToString())) ? "" : " " + (string)r["FirstNameNV"];

        }

    }
}