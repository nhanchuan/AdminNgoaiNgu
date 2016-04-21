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
}