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

public partial class kus_admin_LopHocEdit : BasePage
{
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
    kus_PhongHocBLL kus_phonghoc;
    kus_KhoiLopBLL kus_khoilop;
    kus_CapDoBLL kus_capdo;
    kus_LopHocBLL kus_lophoc;
    kus_LichHocBLL kus_lichhoc;
    kus_GioHocBLL kus_giohoc;
    WeekdaysBLL weekdays;
    EmployeesBLL employees;
    kus_GVHopDongBLL kus_gvhopdong;
    ViewLichHocBLL viewlichhoc;
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
                if (!check_permiss(ac.UserID, FunctionName.SuaThongTinLop))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    //string ClassCode = Request.QueryString["Code"];
                    //if (ClassCode != null && checkQueryString(ClassCode))
                    //{
                    //    this.load_dlHTChiNhanh();
                    //    this.load_dlKhoiLop();
                    //    this.load_LopHocInfo();
                    //    this.checkLichHoc();
                    //}
                    //else
                    //{
                    //    Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/ListLopHoc.aspx");
                    //}
                }
            }
        }
    }
    //public Boolean checkQueryString(string  code)
    //{
    //    kus_lophoc = new kus_LopHocBLL();
    //    if(code=="")
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(code);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        if(lophoc==null)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
    //private void load_dlHTChiNhanh()
    //{
    //    kus_htchinhanh = new kus_HTChiNhanhBLL();
    //    dlHTChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
    //    dlHTChiNhanh.DataTextField = "tenHTChiNhanh";
    //    dlHTChiNhanh.DataValueField = "hTChiNhanhID";
    //    dlHTChiNhanh.DataBind();
    //}
    //protected void dlHTChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    kus_coso = new kus_CoSoBLL();
    //    dlCoSo.DataSource = kus_coso.getLSTCoSoWithChiNhanhID(Convert.ToInt32(dlHTChiNhanh.SelectedValue));
    //    dlCoSo.DataTextField = "TenCoSo";
    //    dlCoSo.DataValueField = "CoSoID";
    //    dlCoSo.DataBind();
    //    dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
    //}
    //private void load_dlKhoiLop()
    //{
    //    kus_khoilop = new kus_KhoiLopBLL();
    //    dlKhoiLop.DataSource = kus_khoilop.getAllKhoiLop();
    //    dlKhoiLop.DataTextField = "TenKhoiLop";
    //    dlKhoiLop.DataValueField = "KhoiLopID";
    //    dlKhoiLop.DataBind();
    //}
    //private void load_LopHocInfo()
    //{
    //    kus_lophoc = new kus_LopHocBLL();
    //    string ClassCode = Request.QueryString["Code"];
    //    List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //    kus_LopHoc lophoc = lst.FirstOrDefault();
    //    txtTenLopHoc.Text = lophoc.TenLopHoc;
    //    txtNgayKG.Text = (lophoc.NgayKhaiGiang.Year <= 1900) ? "" : lophoc.NgayKhaiGiang.ToString("dd-MM-yyyy");
    //    txtThoiLuongHoc.Text = lophoc.ThoiLuong.ToString();
    //    txtNgayKT.Text = (lophoc.NgayKetThuc.Year <= 1900) ? "" : lophoc.NgayKetThuc.ToString("dd-MM-yyyy");
    //    txtSiSoToiDa.Text = lophoc.SiSoToiDa.ToString();
    //    txtMucHocPhi.Text = lophoc.MucHocPhi.ToString();

    //    kus_capdo = new kus_CapDoBLL();
    //    dlCapDo.DataSource = kus_capdo.getAllCapDo();
    //    dlCapDo.DataTextField = "TenCapDo";
    //    dlCapDo.DataValueField = "CapDoID";
    //    dlCapDo.DataBind();
    //    dlCapDo.Items.Insert(0, new ListItem("------- Chọn Cấp Độ trong Chương Trình Học -------", "0"));

    //    kus_coso = new kus_CoSoBLL();
    //    dlCoSo.DataSource = kus_coso.getAllHTCoSo();
    //    dlCoSo.DataTextField = "TenCoSo";
    //    dlCoSo.DataValueField = "CoSoID";
    //    dlCoSo.DataBind();
    //    dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));

    //    kus_khoilop = new kus_KhoiLopBLL();
    //    dlKhoiLop.DataSource = kus_khoilop.getAllKhoiLop();
    //    dlKhoiLop.DataTextField = "TenKhoiLop";
    //    dlKhoiLop.DataValueField = "KhoiLopID";
    //    dlKhoiLop.DataBind();
    //    dlKhoiLop.Items.Insert(0, new ListItem("------- Chọn Chương Trình Học -------", "0"));

    //    dlCapDo.Items.FindByValue(string.IsNullOrEmpty(lophoc.CapDoID.ToString())? "0": lophoc.CapDoID.ToString()).Selected = true;
    //    dlCoSo.Items.FindByValue(string.IsNullOrEmpty(lophoc.CoSoID.ToString()) ? "0" : lophoc.CoSoID.ToString()).Selected = true;

    //    List<kus_CapDo> lstCapdo = kus_capdo.getAllCapDoWithId(string.IsNullOrEmpty(lophoc.CapDoID.ToString())?0: lophoc.CapDoID);
    //    kus_CapDo capdo = lstCapdo.FirstOrDefault();
    //    List<kus_KhoiLop> lstKL = kus_khoilop.getKhoiLopWithID((capdo==null)?0: capdo.KhoiLopID);
    //    kus_KhoiLop khoilop = lstKL.FirstOrDefault();
    //    dlKhoiLop.Items.FindByValue((khoilop == null) ? "0" : khoilop.KhoiLopID.ToString()).Selected = true;

    //    kus_htchinhanh = new kus_HTChiNhanhBLL();
    //    dlHTChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
    //    dlHTChiNhanh.DataTextField = "tenHTChiNhanh";
    //    dlHTChiNhanh.DataValueField = "hTChiNhanhID";
    //    dlHTChiNhanh.DataBind();
    //    dlHTChiNhanh.Items.Insert(0, new ListItem("------- Chọn Hệ Thống Chi Nhánh -------", "0"));

    //    List<kus_CoSo> lstCS = kus_coso.getLSTCoSoWithID(string.IsNullOrEmpty(lophoc.CoSoID.ToString()) ? 0 : lophoc.CoSoID);
    //    kus_CoSo coso = lstCS.FirstOrDefault();
    //    List<kus_HTChiNhanh> lstHTCN = kus_htchinhanh.getlistHTChiNHanhWithID((coso==null)? 0 : coso.HTChiNhanhID);
    //    kus_HTChiNhanh htcn = lstHTCN.FirstOrDefault();
    //    dlHTChiNhanh.Items.FindByValue((htcn == null) ? "0" : htcn.HTChiNhanhID.ToString()).Selected = true;

    //    lblLichHocCoSo.Text = coso.TenCoSo;

    //    lblCheckAddLichHoc.Text = "";
    //    this.reportNumTiet(lophoc.LopHocID);

    //}
    //protected void dlKhoiLop_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    kus_capdo = new kus_CapDoBLL();
    //    dlCapDo.DataSource = kus_capdo.getCapDoWithKhoiLopID(Convert.ToInt32(dlKhoiLop.SelectedValue));
    //    dlCapDo.DataTextField = "TenCapDo";
    //    dlCapDo.DataValueField = "CapDoID";
    //    dlCapDo.DataBind();
    //    dlCapDo.Items.Insert(0, new ListItem("------- Chọn Cấp Độ trong Chương Trình Học -------", "0"));
    //}
    //public bool IsNumber(string pText)
    //{
    //    Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
    //    return regex.IsMatch(pText);
    //}
    //private string getday(string str)
    //{
    //    string day = "";
    //    if (!IsNumber(str.Substring(0, 2)))
    //    {
    //        return "";
    //    }
    //    else
    //    {
    //        day = str.Substring(0, 2);
    //    }
    //    return day;
    //}
    //private string getmonth(string str)
    //{
    //    string month = "";
    //    if (!IsNumber(str.Substring(3, 2)))
    //    {
    //        return "";
    //    }
    //    else
    //    {
    //        month = str.Substring(3, 2);
    //    }
    //    return month;
    //}
    //private string getyear(string str)
    //{
    //    string year = "";
    //    if (str.Length != 10)
    //    {
    //        return "";
    //    }
    //    else
    //    {
    //        if (!IsNumber(str.Substring(6, 4)))
    //        {
    //            return "";
    //        }
    //        else
    //        {
    //            year = str.Substring(6, 4);
    //        }
    //    }
    //    return year;
    //}
    //protected void btnLuuThongTin_Click(object sender, EventArgs e)
    //{
    //    kus_lophoc = new kus_LopHocBLL();
    //    kus_lichhoc = new kus_LichHocBLL();
    //    string ClassCode = Request.QueryString["Code"];
    //    List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //    kus_LopHoc lophoc = lst.FirstOrDefault();
    //    string tenlop = txtTenLopHoc.Text;
    //    string ngaykhaigiang = txtNgayKG.Text;
    //    int thoiluong = Convert.ToInt32(txtThoiLuongHoc.Text);
    //    string ngayketthuc = txtNgayKT.Text;
    //    int sisotoida = Convert.ToInt32(txtSiSoToiDa.Text);
    //    int muchocphi = Convert.ToInt32(txtMucHocPhi.Text);
    //    int capdo = Convert.ToInt32(dlCapDo.SelectedValue);
    //    int coso = Convert.ToInt32(dlCoSo.SelectedValue);

    //    DateTime NgayKG;
    //    string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
    //    if (ngaykhaigiang == "" || string.IsNullOrWhiteSpace(ngaykhaigiang) || DateTime.TryParseExact(ngaykhaigiang, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKG) || getday(ngaykhaigiang) == "" || getmonth(ngaykhaigiang) == "" || getyear(ngaykhaigiang) == "")
    //    {
    //        NgayKG = Convert.ToDateTime("01/01/1900");
    //    }
    //    else
    //    {
    //        NgayKG = DateTime.ParseExact(getday(ngaykhaigiang) + "/" + getmonth(ngaykhaigiang) + "/" + getyear(ngaykhaigiang), "dd/MM/yyyy", null);
    //    }
    //    DateTime NgayKT;
    //    if (ngayketthuc == "" || string.IsNullOrWhiteSpace(ngayketthuc) || DateTime.TryParseExact(ngayketthuc, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKT) || getday(ngayketthuc) == "" || getmonth(ngayketthuc) == "" || getyear(ngayketthuc) == "")
    //    {
    //        NgayKT = Convert.ToDateTime("01/01/1900");
    //    }
    //    else
    //    {
    //        NgayKT = DateTime.ParseExact(getday(ngayketthuc) + "/" + getmonth(ngayketthuc) + "/" + getyear(ngayketthuc), "dd/MM/yyyy", null);
    //    }
    //    if ((lophoc.NgayKhaiGiang.ToString("dd/MM/yyyy") != NgayKG.ToString("dd/MM/yyyy")) || (lophoc.NgayKetThuc.ToString("dd/MM/yyyy") != NgayKT.ToString("dd/MM/yyyy")))
    //    {
    //        //btnLuuThongTin.Attributes.Add("onclick", "");
    //        //Response.Write("<script>alert('ajhdbjsgfvbj')</script>");
    //        this.kus_lichhoc.DeleteLichHocWithLopHoc(lophoc.LopHocID);
    //        if (kus_lophoc.kus_UpdateLopHoc(lophoc.LopHocID, tenlop, NgayKG, thoiluong, NgayKT, sisotoida, capdo, muchocphi, 1, coso))
    //        {
    //            Session.SetCurrentCoSoID(coso.ToString());
    //            Response.Redirect(Request.Url.AbsoluteUri);
    //        }
    //        else
    //        {
    //            Response.Write("<script>alert('Cập Nhật không thành công ! Lỗi kết nối máy chủ !')</script>");
    //        }
    //    }
    //    else
    //    {
    //        if (kus_lophoc.kus_UpdateLopHoc(lophoc.LopHocID, tenlop, NgayKG, thoiluong, NgayKT, sisotoida, capdo, muchocphi, 1, coso))
    //        {
    //            Session.SetCurrentCoSoID(coso.ToString());
    //            Response.Redirect(Request.Url.AbsoluteUri);
    //        }
    //        else
    //        {
    //            Response.Write("<script>alert('Cập Nhật không thành công ! Lỗi kết nối máy chủ !')</script>");
    //        }
    //    }
        
    //}

    ////check lich hoc
    //private void checkLichHoc()
    //{
    //    kus_lophoc = new kus_LopHocBLL();
    //    kus_lichhoc = new kus_LichHocBLL();
    //    weekdays = new WeekdaysBLL();
    //    string ClassCode = Request.QueryString["Code"];
    //    List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //    kus_LopHoc lophoc = lst.FirstOrDefault();
    //    List<kus_LichHoc> lstLichHoc = kus_lichhoc.getListLichHocWithLophocID(lophoc.LopHocID);
    //    kus_LichHoc lichhoc = lstLichHoc.FirstOrDefault();
    //    if (lichhoc == null)
    //    {
    //        panelLichHoc.Visible = false;
    //        btnCreateLichHoc.Visible = true;
    //    }
    //    else
    //    {
    //        panelLichHoc.Visible = true;
    //        btnCreateLichHoc.Visible = false;
    //        this.load_LichHoc();
    //        this.load_dlChoseWeekday();
    //        this.load_dlChoseTietHoc();
    //        this.load_dlChosePhongHoc(lophoc.CoSoID);
    //        this.load_dlGiaoVienTT();
    //        this.load_dlGiaoVienHD();
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //}
    //protected void btnCreateLichHoc_ServerClick(object sender, EventArgs e)
    //{
    //    kus_lophoc = new kus_LopHocBLL();
    //    string ClassCode = Request.QueryString["Code"];
    //    List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //    kus_LopHoc lophoc = lst.FirstOrDefault();
    //    panelLichHoc.Visible = true;
    //    btnCreateLichHoc.Visible = false;
    //    this.load_LichHoc();
    //    this.load_dlChoseWeekday();
    //    this.load_dlChoseTietHoc();
    //    this.load_dlChosePhongHoc(lophoc.CoSoID);
    //    this.load_dlGiaoVienTT();
    //    this.load_dlGiaoVienHD();
    //    lblCheckAddLichHoc.Text = "";
    //}
    //private void load_LichHoc(int lophocID, int daysID, int buoiID, GridView gwLichHoc)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    gwLichHoc.DataSource = kus_lichhoc.getkus_LichHocWithLopHocandDayandBuoi(lophocID, daysID, buoiID);
    //    gwLichHoc.DataBind();
    //}
    //private void load_LichHoc()
    //{
    //    kus_lophoc = new kus_LopHocBLL();
    //    string ClassCode = Request.QueryString["Code"];
    //    List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //    kus_LopHoc lophoc = lst.FirstOrDefault();
    //    this.load_LichHoc(lophoc.LopHocID, 1, 1, gwThu2Sang);
    //    this.load_LichHoc(lophoc.LopHocID, 1, 2, gwThu2Chieu);
    //    this.load_LichHoc(lophoc.LopHocID, 1, 3, gwThu2Toi);
    //    this.load_LichHoc(lophoc.LopHocID, 2, 1, gwThu3Sang);
    //    this.load_LichHoc(lophoc.LopHocID, 2, 2, gwThu3Chieu);
    //    this.load_LichHoc(lophoc.LopHocID, 2, 3, gwThu3Toi);
    //    this.load_LichHoc(lophoc.LopHocID, 3, 1, gwThu4Sang);
    //    this.load_LichHoc(lophoc.LopHocID, 3, 2, gwThu4Chieu);
    //    this.load_LichHoc(lophoc.LopHocID, 3, 3, gwThu4Toi);
    //    this.load_LichHoc(lophoc.LopHocID, 4, 1, gwThu5Sang);
    //    this.load_LichHoc(lophoc.LopHocID, 4, 2, gwThu5Chieu);
    //    this.load_LichHoc(lophoc.LopHocID, 4, 3, gwThu5Toi);
    //    this.load_LichHoc(lophoc.LopHocID, 5, 1, gwThu6Sang);
    //    this.load_LichHoc(lophoc.LopHocID, 5, 2, gwThu6Chieu);
    //    this.load_LichHoc(lophoc.LopHocID, 5, 3, gwThu6Toi);
    //    this.load_LichHoc(lophoc.LopHocID, 6, 1, gwThu7Sang);
    //    this.load_LichHoc(lophoc.LopHocID, 6, 2, gwThu7Chieu);
    //    this.load_LichHoc(lophoc.LopHocID, 6, 3, gwThu7Toi);
    //    this.load_LichHoc(lophoc.LopHocID, 7, 1, gwChuNhatSang);
    //    this.load_LichHoc(lophoc.LopHocID, 7, 2, gwChuNhatChieu);
    //    this.load_LichHoc(lophoc.LopHocID, 7, 3, gwChuNhatToi);
    //}
    //private void load_dlChoseWeekday()
    //{
    //    weekdays = new WeekdaysBLL();
    //    dlChoseWeekday.DataSource = weekdays.ListWeekdays();
    //    dlChoseWeekday.DataTextField = "WeekdaysNameEN";
    //    dlChoseWeekday.DataValueField = "DayID";
    //    dlChoseWeekday.DataBind();
    //    dlChoseWeekday.Items.Insert(0, new ListItem("-- Chọn Thứ --", "0"));
    //}
    //private void load_dlChoseTietHoc()
    //{
    //    kus_giohoc = new kus_GioHocBLL();
    //    dlChoseTietHoc.DataSource = kus_giohoc.getTBForDropdown();
    //    dlChoseTietHoc.DataTextField = "TietHoc";
    //    dlChoseTietHoc.DataValueField = "GioHocID";
    //    dlChoseTietHoc.DataBind();
    //    dlChoseTietHoc.Items.Insert(0, new ListItem("-- Chọn tiết học --", "0"));
    //}
    //private void load_dlGiaoVienTT()
    //{
    //    employees = new EmployeesBLL();
    //    dlGiaoVienTT.DataSource = employees.GetEmployeesWithDepartmentsDL(5);
    //    dlGiaoVienTT.DataTextField = "GVName";
    //    dlGiaoVienTT.DataValueField = "EmployeesID";
    //    dlGiaoVienTT.DataBind();
    //    dlGiaoVienTT.Items.Insert(0, new ListItem("-- Chọn giáo viên Trung Tâm --", "0"));
    //}
    //private void load_dlGiaoVienHD()
    //{
    //    kus_gvhopdong = new kus_GVHopDongBLL();
    //    dlGiaoVienHD.DataSource = kus_gvhopdong.kus_GetGVHopDongDL();
    //    dlGiaoVienHD.DataTextField = "GVname";
    //    dlGiaoVienHD.DataValueField = "GVID";
    //    dlGiaoVienHD.DataBind();
    //    dlGiaoVienHD.Items.Insert(0, new ListItem("-- Chọn giáo viên Hợp Đồng --", "0"));
    //}
    //private void load_dlChosePhongHoc(int cosoID)
    //{
    //    kus_phonghoc = new kus_PhongHocBLL();
    //    dlChosePhongHoc.DataSource = kus_phonghoc.getTBDropdownPHWithCoSOID(cosoID);
    //    dlChosePhongHoc.DataTextField = "SoPhongHoc";
    //    dlChosePhongHoc.DataValueField = "PhongHocID";
    //    dlChosePhongHoc.DataBind();
    //    dlChosePhongHoc.Items.Insert(0, new ListItem("-- Chọn phòng học --", "0"));
    //}
    //[Serializable()]
    //public class clsTietHoc
    //{
    //    public string Text { get; set; }
    //    public string Values { get; set; }
    //    public clsTietHoc(string text, string values)
    //    {
    //        Text = text;
    //        Values = values;
    //    }
    //}
    //protected void dlChoseTietHoc_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    kus_giohoc = new kus_GioHocBLL();
    //    List<kus_GioHoc> lstGH = kus_giohoc.getAllkus_GioHocWithID(Convert.ToInt32(dlChoseTietHoc.SelectedValue));
    //    kus_GioHoc giohoc = lstGH.FirstOrDefault();
    //    int LastTietHoc = kus_giohoc.LastTietHoc();
    //    if (giohoc != null)
    //    {
    //        int j = 1;
    //        List<clsTietHoc> lst = new List<clsTietHoc>();
    //        for (int i=giohoc.TietHoc; i <= LastTietHoc; i++)
    //        {
    //            lst.Add(new clsTietHoc(j.ToString(), j.ToString()));
    //            j++;
    //        }
    //        dlChoseSoTiet.DataSource = lst;
    //        dlChoseSoTiet.DataTextField = "Text";
    //        dlChoseSoTiet.DataValueField = "Values";
    //        dlChoseSoTiet.DataBind();
    //        dlChoseSoTiet.Items.Insert(0, new ListItem("-- Chọn số tiết --", "0"));
    //    }
    //}
    //protected void btnAddLichHoc_Click(object sender, EventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    kus_lophoc = new kus_LopHocBLL();
    //    viewlichhoc = new ViewLichHocBLL();

    //    int dayID = Convert.ToInt32(dlChoseWeekday.SelectedValue);
    //    int phonghocID = Convert.ToInt32(dlChosePhongHoc.SelectedValue);
    //    int tiethocID = Convert.ToInt32(dlChoseTietHoc.SelectedValue);
    //    int sotiet = Convert.ToInt32(dlChoseSoTiet.SelectedValue);

    //    string ClassCode = Request.QueryString["Code"];
    //    List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //    kus_LopHoc lophoc = lst.FirstOrDefault();

    //    //lvlCountSetted.Text = "Số Tiết pat sinh : " + viewlichhoc.CountSoTietPhatSinh(lophoc.LopHocID, dlChoseWeekday.SelectedItem.ToString(), sotiet).ToString();
    //    if ((viewlichhoc.CountSoTietPhatSinh(lophoc.LopHocID, dlChoseWeekday.SelectedItem.ToString(), sotiet) + viewlichhoc.CountSoTieted(lophoc.LopHocID)) > lophoc.ThoiLuong)
    //    {
    //        lblCheckAddLichHoc.Text = "Không thể thêm lịch học vì vượt quá thời lượng cho phép !";
    //        return;
    //    }
    //    else
    //    {
    //        List<kus_LichHoc> lstCheckLH = kus_lichhoc.kus_CheckAddLichHoc(dayID, phonghocID, tiethocID, sotiet);
    //        kus_LichHoc lichhoc = lstCheckLH.FirstOrDefault();
    //        if (lichhoc != null)
    //        {
    //            lblCheckAddLichHoc.Text = "Không thể thêm vì Lịch học này đã có lớp ! Vui lòng chọn lịch học khác !";
    //        }
    //        else
    //        {
    //            List<kus_LichHoc> lstLHWithLop = kus_lichhoc.kus_CheckAddLichHocWithLopHoc(dayID, lophoc.LopHocID, tiethocID, sotiet);
    //            kus_LichHoc lichhocWithLH = lstLHWithLop.FirstOrDefault();
    //            if (lichhocWithLH != null)
    //            {
    //                lblCheckAddLichHoc.Text = "Không thể thêm vì giờ học này đã có trong lịch học ! Vui lòng chọn giờ học khác !";
    //            }
    //            else
    //            {
    //                int GVTT = Convert.ToInt32(dlGiaoVienTT.SelectedValue);
    //                int GVHD = Convert.ToInt32(dlGiaoVienHD.SelectedValue);
    //                if (this.kus_lichhoc.AddNewLichHoc(lophoc.LopHocID, dayID, tiethocID, phonghocID, sotiet, GVTT, GVHD))
    //                {
    //                    this.load_LichHoc();
    //                    lblCheckAddLichHoc.Text = "";
    //                    this.reportNumTiet(lophoc.LopHocID);
    //                }
    //                else
    //                {
    //                    lblCheckAddLichHoc.Text = "Thêm Lịch học không thành công. Lỗi kết nối csdl !";
    //                }
    //            }
    //        }
    //    }
    //}
    //private void reportNumTiet(int lophocID)
    //{
    //    kus_lophoc = new kus_LopHocBLL();
    //    viewlichhoc = new ViewLichHocBLL();
    //    string ClassCode = Request.QueryString["Code"];
    //    List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //    kus_LopHoc lophoc = lst.FirstOrDefault();
    //    lvlCountSetted.Text = "Số Tiết đã set : " + viewlichhoc.CountSoTieted(lophoc.LopHocID).ToString() + " tiết";
    //    lblCountSotietcon.Text = "Số Tiết còn lại : " + (lophoc.ThoiLuong - viewlichhoc.CountSoTieted(lophoc.LopHocID)).ToString() + " tiết";
    //}
    //#region DataBound
    //protected void gwThu2Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu2Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu2Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu3Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu3Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu3Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu4Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu4Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu4Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu5Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu5Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu5Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu6Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu6Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu6Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu7Sang_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu7Chieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwThu7Toi_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwChuNhatSang_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwChuNhatChieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //protected void gwChuNhatToi_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            LinkButton del = e.Row.FindControl("btnDelLH") as LinkButton;
    //            del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
    //        }
    //    }
    //    catch (Exception) { }
    //}
    //#endregion DataBound 
    //#region RowDeleting
    //protected void gwThu2Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu2Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 1, 1, gwThu2Sang);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu2Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu2Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 1, 2, gwThu2Chieu);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu2Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu2Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 1, 3, gwThu2Toi);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu3Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu3Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 2, 1, gwThu3Sang);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu3Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu3Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 2, 2, gwThu3Chieu);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu3Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu3Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 2, 3, gwThu3Toi);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu4Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu4Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 3, 1, gwThu4Sang);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu4Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu4Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 3, 2, gwThu4Chieu);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu4Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu4Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 3, 3, gwThu4Toi);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu5Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu5Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 4, 1, gwThu5Sang);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu5Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu5Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 4, 2, gwThu5Chieu);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu5Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu5Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 4, 3, gwThu5Toi);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu6Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu6Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 5, 1, gwThu6Sang);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu6Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu6Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 5, 2, gwThu6Chieu);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu6Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu6Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 5, 3, gwThu6Toi);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu7Sang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu7Sang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 6, 1, gwThu7Sang);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu7Chieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu7Chieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 6, 2, gwThu7Chieu);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwThu7Toi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwThu7Toi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 6, 3, gwThu7Toi);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwChuNhatSang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwChuNhatSang.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 7, 1, gwChuNhatSang);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwChuNhatChieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwChuNhatChieu.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 7, 2, gwChuNhatChieu);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //protected void gwChuNhatToi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    kus_lichhoc = new kus_LichHocBLL();
    //    int id = Convert.ToInt32((gwChuNhatToi.Rows[e.RowIndex].FindControl("lblLichHocID") as Label).Text);

    //    if (this.kus_lichhoc.DeleteLichHoc(id))
    //    {
    //        kus_lophoc = new kus_LopHocBLL();
    //        string ClassCode = Request.QueryString["Code"];
    //        List<kus_LopHoc> lst = kus_lophoc.GetListLopHocWithCode(ClassCode);
    //        kus_LopHoc lophoc = lst.FirstOrDefault();
    //        this.load_LichHoc(lophoc.LopHocID, 7, 3, gwChuNhatToi);
    //        this.reportNumTiet(lophoc.LopHocID);
    //        lblCheckAddLichHoc.Text = "";
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
    //    }
    //}
    //#endregion RowDeleting
    
}