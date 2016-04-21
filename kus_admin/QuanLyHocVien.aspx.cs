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

public partial class kus_admin_QuanLyHocVien : BasePage
{
    kus_HTChiNhanhBLL kus_hethongchinhanh;
    kus_CoSoBLL kus_coso;
    nc_LoaiCTDaoTaoBLL nc_loaichuongtrinhdt;
    nc_ChuongTrinhDaoTaoBLL nc_chuongtrinhdaotao;
    nc_LopHocBLL nc_lophoc;
    nc_KhoaHocBLL nc_khoahoc;
    kus_HocVienBLL kus_hocvien;
    public int PageSize = 20;
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
                    this.load_dlHTChiNhanh();
                    this.load_dlLoaiChuongTrinh();
                    dlCoso.Items.Insert(0, new ListItem("-- Chọn Cơ Sở thuộc Chi Nhánh --", "0"));
                    dlChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình đào tạo --", "0"));
                    dlLopHoc.Items.Insert(0, new ListItem("-- Chọn lớp học thuộc chương trình --", "0"));
                    dlKhoaHoc.Items.Insert(0, new ListItem("-- Chọn khóa thuộc lớp học --", "0"));
                }
            }
        }
    }
    private void load_dlHTChiNhanh()
    {
        kus_hethongchinhanh = new kus_HTChiNhanhBLL();
        this.load_DropdownList(dlHTChiNhanh, kus_hethongchinhanh.getlAllHTChiNHanh(), "TenHTChiNhanh", "HTChiNhanhID");
        dlHTChiNhanh.Items.Insert(0, new ListItem("-- Chọn Hệ Thống chi Nhánh --", "0"));
    }
    private void load_dlLoaiChuongTrinh()
    {
        nc_loaichuongtrinhdt = new nc_LoaiCTDaoTaoBLL();
        this.load_DropdownList(dlLoaiChuongTrinh, nc_loaichuongtrinhdt.getListLoaiCTDaoTao(), "TenChuongTrinh", "ID");
        dlLoaiChuongTrinh.Items.Insert(0, new ListItem("-- Chọn loại chương trình --", "0"));
    }

    protected void dlHTChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        this.load_DropdownList(dlCoso, kus_coso.getLSTCoSoWithChiNhanhID(Convert.ToInt32(dlHTChiNhanh.SelectedValue)), "TenCoSo", "CoSoID");
        dlCoso.Items.Insert(0, new ListItem("-- Chọn Cơ Sở thuộc Chi Nhánh --", "0"));
    }

    protected void dlLoaiChuongTrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        dlLopHoc.ClearSelection();
        dlKhoaHoc.ClearSelection();
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        this.load_DropdownList(dlChuongTrinh, nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithLoai(Convert.ToInt32(dlLoaiChuongTrinh.SelectedValue)), "TenChuongTrinh", "ID");
        dlChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình đào tạo --", "0"));
    }

    protected void dlChuongTrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        dlKhoaHoc.ClearSelection();
        this.load_DropdownList(dlLopHoc, nc_lophoc.getListLopHocWithChuongTrinh(Convert.ToInt32(dlChuongTrinh.SelectedValue)), "TenLopHoc", "ID");
        dlLopHoc.Items.Insert(0, new ListItem("-- Chọn lớp học thuộc chương trình --", "0"));
    }

    protected void dlLopHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        this.load_DropdownList(dlKhoaHoc, nc_khoahoc.get_Tabel_DL_KhoaHoc(Convert.ToInt32(dlLopHoc.SelectedValue)), "TenKhoaHoc", "ID");
        dlKhoaHoc.Items.Insert(0, new ListItem("-- Chọn khóa thuộc lớp học --", "0"));
    }
    private void SearchHocVienPageWise(int pageIndex, int CoSoID, int LoaiChuongTrinh, int ChuongTrinh, int LopHoc, int khoahoc, string HocVienCode, string TenHocVien, string Email, string DienThoai, string IdentityCard, string HoTenPH)
    {
        kus_hocvien = new kus_HocVienBLL();
        int recordCount = 0;
        gwListHocVien.DataSource = kus_hocvien.SearchHocVienPageWise(pageIndex, PageSize, CoSoID, LoaiChuongTrinh, ChuongTrinh, LopHoc, khoahoc, HocVienCode, TenHocVien, Email, DienThoai, IdentityCard, HoTenPH);
        recordCount = kus_hocvien.CounthHocVienPageWise(CoSoID, LoaiChuongTrinh, ChuongTrinh, LopHoc, khoahoc, HocVienCode, TenHocVien, Email, DienThoai, IdentityCard, HoTenPH);
        gwListHocVien.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        //lblCountKhoaHoc.Text = recordCount.ToString();
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;

        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        int CoSoID = Convert.ToInt32(dlCoso.SelectedValue);
        int LoaiChuongTrinh = Convert.ToInt32(dlLoaiChuongTrinh.SelectedValue);
        int ChuongTrinh = Convert.ToInt32(dlChuongTrinh.SelectedValue);
        int LopHoc = Convert.ToInt32(dlLopHoc.SelectedValue);
        int khoahoc = Convert.ToInt32(dlKhoaHoc.SelectedValue);
        string HocVienCode = txtMaHocVien.Text;
        string TenHocVien = txtTenHocVien.Text;
        string Email = txtEmail.Text;
        string DienThoai = txtDienThoai.Text;
        string IdentityCard = txtCMND.Text;
        string HoTenPH = txtHoTenPhuHuynh.Text;
        this.SearchHocVienPageWise(pageIndex, CoSoID, LoaiChuongTrinh, ChuongTrinh, LopHoc, khoahoc, HocVienCode, TenHocVien, Email, DienThoai, IdentityCard, HoTenPH);
        //Session["pageIndexnc_lophoc"] = pageIndex.ToString();
        rptPager.Visible = true;
        //rptSearch.Visible = false;
    }
    protected void btnSearchHocVien_ServerClick(object sender, EventArgs e)
    {
        kus_hocvien = new kus_HocVienBLL();
        int CoSoID = Convert.ToInt32(dlCoso.SelectedValue);
        int LoaiChuongTrinh = Convert.ToInt32(dlLoaiChuongTrinh.SelectedValue);
        int ChuongTrinh = Convert.ToInt32(dlChuongTrinh.SelectedValue);
        int LopHoc = Convert.ToInt32(dlLopHoc.SelectedValue);
        int khoahoc = Convert.ToInt32(dlKhoaHoc.SelectedValue);
        string HocVienCode = txtMaHocVien.Text;
        string TenHocVien = txtTenHocVien.Text;
        string Email = txtEmail.Text;
        string DienThoai = txtDienThoai.Text;
        string IdentityCard = txtCMND.Text;
        string HoTenPH = txtHoTenPhuHuynh.Text;
        this.SearchHocVienPageWise(1, CoSoID, LoaiChuongTrinh, ChuongTrinh, LopHoc, khoahoc, HocVienCode, TenHocVien, Email, DienThoai, IdentityCard, HoTenPH);
    }
}