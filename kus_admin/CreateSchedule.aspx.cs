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

public partial class kus_admin_CreateSchedule : BasePage
{
    nc_KhoaHocBLL nc_khoahoc;
    kus_LichHocBLL kus_lichhoc;
    WeekdaysBLL weekdays;
    kus_PhongHocBLL kus_phonghoc;
    kus_GioHocBLL kus_giohoc;
    EmployeesBLL employees;
    kus_GVHopDongBLL kus_gvhopdong;
    ViewLichHocBLL viewlichhoc;
    nc_ChuongTrinhDaoTaoBLL nc_chuongtrinhdaotao;
    nc_LopHocBLL nc_lophoc;
    kus_CoSoBLL kus_coso;
    nc_LoaiCTDaoTaoBLL nc_loaictdaotao;
    kus_HTChiNhanhBLL kus_htchinhanh;
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

                if (!check_permiss(ac.UserID, FunctionName.GhiDanhHocVien))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    string MaKhoaHoc = Request.QueryString["makhoahoc"];
                    if (!CheckQuerystring(MaKhoaHoc))
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/GhiDanhKhoaHoc.aspx");
                    }
                    else
                    {
                        lblKhoaHocChose.Text = KhoaHocDangChon(MaKhoaHoc);
                        this.checkLichHoc();
                        this.load_dlELoaiChuongTrinh();
                        this.load_dlEHTChiNhanh();
                        this.load_dlECoSo();
                        this.load_KhoaHocInfor(MaKhoaHoc);
                        this.load_reportNumTiet();
                    }
                }
            }
        }
    }
    private Boolean CheckQuerystring(string code)
    {
        nc_khoahoc = new nc_KhoaHocBLL();

        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrEmpty(code))
        {
            return false;
        }
        else
        {
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(code);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            if (khoahoc == null)
            {
                return false;
            }
        }
        return true;
    }
    private string KhoaHocDangChon(string code)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(code);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
        return khoahoc.MaKhoaHoc + " - " + khoahoc.TenKhoaHoc;
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
    private void load_dlEChuongTrinh(int loaichuongtrinh)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        dlEChuongTrinh.DataSource = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithLoai(loaichuongtrinh);
        dlEChuongTrinh.DataTextField = "TenChuongTrinh";
        dlEChuongTrinh.DataValueField = "ID";
        dlEChuongTrinh.DataBind();
        dlEChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình --", "0"));
    }
    private void load_dlELopHoc(int chuongtrinh)
    {
        nc_lophoc = new nc_LopHocBLL();
        dlELopHoc.DataSource = nc_lophoc.getListLopHocWithChuongTrinh(chuongtrinh);
        dlELopHoc.DataTextField = "TenLopHoc";
        dlELopHoc.DataValueField = "ID";
        dlELopHoc.DataBind();
        dlELopHoc.Items.Insert(0, new ListItem("-- Chọn lớp học --", "0"));
    }
    private void load_dlEHTChiNhanh()
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        dlEHTChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
        dlEHTChiNhanh.DataTextField = "tenHTChiNhanh";
        dlEHTChiNhanh.DataValueField = "hTChiNhanhID";
        dlEHTChiNhanh.DataBind();
        dlEHTChiNhanh.Items.Insert(0, new ListItem("------- Chọn Hệ Thống Chi Nhánh -------", "0"));
    }
    private void load_dlECoSo()
    {
        kus_coso = new kus_CoSoBLL();
        dlECoSo.DataSource = kus_coso.getAllHTCoSo();
        dlECoSo.DataTextField = "TenCoSo";
        dlECoSo.DataValueField = "CoSoID";
        dlECoSo.DataBind();
        dlECoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở -------", "0"));
    }
    private void load_KhoaHocInfor(string code)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        kus_coso = new kus_CoSoBLL();
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(code);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
        if (khoahoc != null)
        {
            this.load_dlEChuongTrinh(khoahoc.LoaiChuongTrinh);
            this.load_dlELopHoc(khoahoc.ChuongTrinh);
            txtETenKhoaHoc.Text = khoahoc.TenKhoaHoc;
            txtESoLuong.Text = khoahoc.SoLuong.ToString();
            txtENgayKhaiGiang.Text = (khoahoc.NgayKhaiGiang.Year <= 1900) ? "" : khoahoc.NgayKhaiGiang.ToString("dd-MM-yyyy");
            txtENgayKetThuc.Text = (khoahoc.NgayKetThuc.Year <= 1900) ? "" : khoahoc.NgayKetThuc.ToString("dd-MM-yyyy");
            txtEThoiLuong.Text = khoahoc.ThoiLuong.ToString();
            dlELoaiChuongTrinh.Items.FindByValue(khoahoc.LoaiChuongTrinh.ToString()).Selected = true;
            dlEChuongTrinh.Items.FindByValue(khoahoc.ChuongTrinh.ToString()).Selected = true;
            dlELopHoc.Items.FindByValue(khoahoc.LopHoc.ToString()).Selected = true;
            dlECoSo.Items.FindByValue(khoahoc.CoSoID.ToString()).Selected = true;

            List<kus_CoSo> lstCoSo = kus_coso.getLSTCoSoWithID(khoahoc.CoSoID);
            kus_CoSo coso = lstCoSo.FirstOrDefault();
            dlEHTChiNhanh.Items.FindByValue((coso == null) ? 0.ToString() : coso.HTChiNhanhID.ToString()).Selected = true;
        }
        else
        {
            return;
        }
    }
    private void load_reportNumTiet()
    {
        string MaKhoaHoc = Request.QueryString["makhoahoc"];
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
        this.reportNumTiet(khoahoc.ID);
    }
    //check lich hoc
    private void checkLichHoc()
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        kus_lichhoc = new kus_LichHocBLL();
        weekdays = new WeekdaysBLL();
        string MaKhoaHoc = Request.QueryString["makhoahoc"];
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
        List<kus_LichHoc> lstLichHoc = kus_lichhoc.getListLichHocWithKhoaHoc(khoahoc.ID);
        kus_LichHoc lichhoc = lstLichHoc.FirstOrDefault();
        if (lichhoc == null)
        {
            panelLichHoc.Visible = false;
            btnCreateLichHoc.Visible = true;
        }
        else
        {
            panelLichHoc.Visible = true;
            btnCreateLichHoc.Visible = false;
            this.load_LichHoc();
            this.load_dlChoseWeekday();
            this.load_dlChoseTietHoc();
            this.load_dlChosePhongHoc(khoahoc.CoSoID);
            this.load_dlGiaoVienTT();
            this.load_dlGiaoVienHD();
            lblCheckAddLichHoc.Text = "";
        }
    }
    protected void btnCreateLichHoc_ServerClick(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        string MaKhoaHoc = Request.QueryString["makhoahoc"];
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
        panelLichHoc.Visible = true;
        btnCreateLichHoc.Visible = false;
        this.load_LichHoc();
        this.load_dlChoseWeekday();
        this.load_dlChoseTietHoc();
        this.load_dlChosePhongHoc(khoahoc.CoSoID);
        this.load_dlGiaoVienTT();
        this.load_dlGiaoVienHD();
        lblCheckAddLichHoc.Text = "";
    }
    private void load_LichHoc(int khoahoc, int daysID, int buoiID, GridView gwLichHoc)
    {
        kus_lichhoc = new kus_LichHocBLL();
        gwLichHoc.DataSource = kus_lichhoc.getkus_LichHocWith_KhoaHoc_Day_Buoi(khoahoc, daysID, buoiID);
        gwLichHoc.DataBind();
    }
    private void load_LichHoc()
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        string MaKhoaHoc = Request.QueryString["makhoahoc"];
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
        this.load_LichHoc(khoahoc.ID, 1, 1, gwThu2Sang);
        this.load_LichHoc(khoahoc.ID, 1, 2, gwThu2Chieu);
        this.load_LichHoc(khoahoc.ID, 1, 3, gwThu2Toi);
        this.load_LichHoc(khoahoc.ID, 2, 1, gwThu3Sang);
        this.load_LichHoc(khoahoc.ID, 2, 2, gwThu3Chieu);
        this.load_LichHoc(khoahoc.ID, 2, 3, gwThu3Toi);
        this.load_LichHoc(khoahoc.ID, 3, 1, gwThu4Sang);
        this.load_LichHoc(khoahoc.ID, 3, 2, gwThu4Chieu);
        this.load_LichHoc(khoahoc.ID, 3, 3, gwThu4Toi);
        this.load_LichHoc(khoahoc.ID, 4, 1, gwThu5Sang);
        this.load_LichHoc(khoahoc.ID, 4, 2, gwThu5Chieu);
        this.load_LichHoc(khoahoc.ID, 4, 3, gwThu5Toi);
        this.load_LichHoc(khoahoc.ID, 5, 1, gwThu6Sang);
        this.load_LichHoc(khoahoc.ID, 5, 2, gwThu6Chieu);
        this.load_LichHoc(khoahoc.ID, 5, 3, gwThu6Toi);
        this.load_LichHoc(khoahoc.ID, 6, 1, gwThu7Sang);
        this.load_LichHoc(khoahoc.ID, 6, 2, gwThu7Chieu);
        this.load_LichHoc(khoahoc.ID, 6, 3, gwThu7Toi);
        this.load_LichHoc(khoahoc.ID, 7, 1, gwChuNhatSang);
        this.load_LichHoc(khoahoc.ID, 7, 2, gwChuNhatChieu);
        this.load_LichHoc(khoahoc.ID, 7, 3, gwChuNhatToi);
    }
    private void load_dlChoseWeekday()
    {
        weekdays = new WeekdaysBLL();
        dlChoseWeekday.DataSource = weekdays.ListWeekdays();
        dlChoseWeekday.DataTextField = "WeekdaysNameEN";
        dlChoseWeekday.DataValueField = "DayID";
        dlChoseWeekday.DataBind();
        dlChoseWeekday.Items.Insert(0, new ListItem("-- Chọn Thứ --", "0"));
    }
    private void load_dlChoseTietHoc()
    {
        kus_giohoc = new kus_GioHocBLL();
        dlChoseTietHoc.DataSource = kus_giohoc.getTBForDropdown();
        dlChoseTietHoc.DataTextField = "TietHoc";
        dlChoseTietHoc.DataValueField = "GioHocID";
        dlChoseTietHoc.DataBind();
        dlChoseTietHoc.Items.Insert(0, new ListItem("-- Chọn tiết học --", "0"));
    }
    private void load_dlGiaoVienTT()
    {
        employees = new EmployeesBLL();
        dlGiaoVienTT.DataSource = employees.GetEmployeesWithDepartmentsDL(5);
        dlGiaoVienTT.DataTextField = "GVName";
        dlGiaoVienTT.DataValueField = "EmployeesID";
        dlGiaoVienTT.DataBind();
        dlGiaoVienTT.Items.Insert(0, new ListItem("-- Chọn giáo viên Trung Tâm --", "0"));
    }
    private void load_dlGiaoVienHD()
    {
        kus_gvhopdong = new kus_GVHopDongBLL();
        dlGiaoVienHD.DataSource = kus_gvhopdong.kus_GetGVHopDongDL();
        dlGiaoVienHD.DataTextField = "GVname";
        dlGiaoVienHD.DataValueField = "GVID";
        dlGiaoVienHD.DataBind();
        dlGiaoVienHD.Items.Insert(0, new ListItem("-- Chọn giáo viên Hợp Đồng --", "0"));
    }
    private void load_dlChosePhongHoc(int cosoID)
    {
        kus_phonghoc = new kus_PhongHocBLL();
        dlChosePhongHoc.DataSource = kus_phonghoc.getTBDropdownPHWithCoSOID(cosoID);
        dlChosePhongHoc.DataTextField = "SoPhongHoc";
        dlChosePhongHoc.DataValueField = "PhongHocID";
        dlChosePhongHoc.DataBind();
        dlChosePhongHoc.Items.Insert(0, new ListItem("-- Chọn phòng học --", "0"));
    }
    [Serializable()]
    public class clsTietHoc
    {
        public string Text { get; set; }
        public string Values { get; set; }
        public clsTietHoc(string text, string values)
        {
            Text = text;
            Values = values;
        }
    }
    protected void dlChoseTietHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_giohoc = new kus_GioHocBLL();
        List<kus_GioHoc> lstGH = kus_giohoc.getAllkus_GioHocWithID(Convert.ToInt32(dlChoseTietHoc.SelectedValue));
        kus_GioHoc giohoc = lstGH.FirstOrDefault();
        int LastTietHoc = kus_giohoc.LastTietHoc();
        if (giohoc != null)
        {
            int j = 1;
            List<clsTietHoc> lst = new List<clsTietHoc>();
            for (int i = giohoc.TietHoc; i <= LastTietHoc; i++)
            {
                lst.Add(new clsTietHoc(j.ToString(), j.ToString()));
                j++;
            }
            dlChoseSoTiet.DataSource = lst;
            dlChoseSoTiet.DataTextField = "Text";
            dlChoseSoTiet.DataValueField = "Values";
            dlChoseSoTiet.DataBind();
            dlChoseSoTiet.Items.Insert(0, new ListItem("-- Chọn số tiết --", "0"));
        }
    }
    protected void btnAddLichHoc_Click(object sender, EventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        nc_khoahoc = new nc_KhoaHocBLL();
        viewlichhoc = new ViewLichHocBLL();

        int dayID = Convert.ToInt32(dlChoseWeekday.SelectedValue);
        int phonghocID = Convert.ToInt32(dlChosePhongHoc.SelectedValue);
        int tiethocID = Convert.ToInt32(dlChoseTietHoc.SelectedValue);
        int sotiet = Convert.ToInt32(dlChoseSoTiet.SelectedValue);

        string MaKhoaHoc = Request.QueryString["makhoahoc"];
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();

        //lvlCountSetted.Text = "Số Tiết pat sinh : " + viewlichhoc.CountSoTietPhatSinh(khoahoc.ID, dlChoseWeekday.SelectedItem.ToString(), sotiet).ToString();
        if ((viewlichhoc.CountSoTietPhatSinh(khoahoc.ID, dlChoseWeekday.SelectedItem.ToString(), sotiet) + viewlichhoc.CountSoTieted(khoahoc.ID)) > khoahoc.ThoiLuong)
        {
            lblCheckAddLichHoc.Text = "Không thể thêm lịch học vì vượt quá thời lượng cho phép !";
            return;
        }
        else
        {
            List<kus_LichHoc> lstCheckLH = kus_lichhoc.kus_CheckAddLichHoc(dayID, phonghocID, tiethocID, sotiet);
            kus_LichHoc lichhoc = lstCheckLH.FirstOrDefault();
            if (lichhoc != null)
            {
                lblCheckAddLichHoc.Text = "Không thể thêm vì Lịch học này đã có lớp ! Vui lòng chọn lịch học khác !";
            }
            else
            {
                List<kus_LichHoc> lstLHWithKhoaHoc = kus_lichhoc.kus_CheckAddLichHocWithKhoaHoc(dayID, khoahoc.ID, tiethocID, sotiet);
                kus_LichHoc lichhocWithLH = lstLHWithKhoaHoc.FirstOrDefault();
                if (lichhocWithLH != null)
                {
                    lblCheckAddLichHoc.Text = "Không thể thêm vì giờ học này đã có trong lịch học ! Vui lòng chọn giờ học khác !";
                }
                else
                {
                    int GVTT = Convert.ToInt32(dlGiaoVienTT.SelectedValue);
                    int GVHD = Convert.ToInt32(dlGiaoVienHD.SelectedValue);
                    if (this.kus_lichhoc.AddNewLichHoc(khoahoc.ID, dayID, tiethocID, phonghocID, sotiet, GVTT, GVHD))
                    {
                        this.load_LichHoc();
                        lblCheckAddLichHoc.Text = "";
                        this.reportNumTiet(khoahoc.ID);
                    }
                    else
                    {
                        lblCheckAddLichHoc.Text = "Thêm Lịch học không thành công. Lỗi kết nối csdl !";
                    }
                }
            }
        }
    }
    private void reportNumTiet(int lophocID)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        viewlichhoc = new ViewLichHocBLL();
        string MaKhoaHoc = Request.QueryString["makhoahoc"];
        List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
        nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
        lvlCountSetted.Text = "Số Tiết đã set : " + viewlichhoc.CountSoTieted(khoahoc.ID).ToString() + " tiết";
        lblCountSotietcon.Text = "Số Tiết còn lại : " + (khoahoc.ThoiLuong - viewlichhoc.CountSoTieted(khoahoc.ID)).ToString() + " tiết";
    }
    #region DataBound
    protected void gwThu2Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu2Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu2Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu3Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu3Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu3Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu4Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu4Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu4Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu5Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu5Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu5Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu6Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu6Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu6Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu7Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu7Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwThu7Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwChuNhatSang_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwChuNhatChieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwChuNhatToi_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    #endregion DataBound 
    #region RowDeleting
    protected void gwThu2Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu2Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 1, 1, gwThu2Sang);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu2Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu2Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 1, 2, gwThu2Chieu);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu2Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu2Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 1, 3, gwThu2Toi);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu3Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu3Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 2, 1, gwThu3Sang);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu3Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu3Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 2, 2, gwThu3Chieu);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu3Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu3Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 2, 3, gwThu3Toi);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu4Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu4Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 3, 1, gwThu4Sang);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu4Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu4Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 3, 2, gwThu4Chieu);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu4Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu4Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 3, 3, gwThu4Toi);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu5Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu5Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 4, 1, gwThu5Sang);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu5Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu5Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 4, 2, gwThu5Chieu);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu5Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu5Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 4, 3, gwThu5Toi);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu6Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu6Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 5, 1, gwThu6Sang);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu6Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu6Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 5, 2, gwThu6Chieu);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu6Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu6Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 5, 3, gwThu6Toi);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu7Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu7Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 6, 1, gwThu7Sang);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu7Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu7Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 6, 2, gwThu7Chieu);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwThu7Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwThu7Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 6, 3, gwThu7Toi);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwChuNhatSang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwChuNhatSang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 7, 1, gwChuNhatSang);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwChuNhatChieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwChuNhatChieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 7, 2, gwChuNhatChieu);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gwChuNhatToi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lichhoc = new kus_LichHocBLL();
        int id = Convert.ToInt32((gwChuNhatToi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

        if (this.kus_lichhoc.DeleteLichHoc(id))
        {
            nc_khoahoc = new nc_KhoaHocBLL();
            string MaKhoaHoc = Request.QueryString["makhoahoc"];
            List<nc_KhoaHoc> lstkh = nc_khoahoc.getListKhoaHocWithMaKhoaHoc(MaKhoaHoc);
            nc_KhoaHoc khoahoc = lstkh.FirstOrDefault();
            this.load_LichHoc(khoahoc.ID, 7, 3, gwChuNhatToi);
            this.reportNumTiet(khoahoc.ID);
            lblCheckAddLichHoc.Text = "";
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    #endregion RowDeleting
}