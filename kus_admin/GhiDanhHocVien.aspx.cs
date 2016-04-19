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
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;

public partial class kus_admin_GhiDanhHocVien : BasePage
{
    CustomerBasicInfoBLL customerbasicinfo;
    kus_HocVienBLL kus_hocvien;
    kus_HocVienMoreInFoBLL hocvienmoreinfo;
    UserProfileBLL userprofile;
    EmployeesBLL employees;
    kus_LopHocBLL kus_lophoc;
    kus_GhiDanhBLL kus_ghidanh;
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
                    string LHCode = Request.QueryString["GDlophoc"];
                    if (!CheckQuerystring(LHCode))
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/GhiDanhLopMoi.aspx");
                    }
                    else
                    {
                        lblLopChose.Text = LopDangChon(LHCode);
                        panelGhiDanhMoi.Visible = true;
                        panelDaGhiDanh.Visible = false;
                    }
                }
            }
        }
    }

    private Boolean CheckQuerystring(string code)
    {
        kus_lophoc = new kus_LopHocBLL();
        
        if(string.IsNullOrWhiteSpace(code)||string.IsNullOrEmpty(code))
        {
            return false;
        }
        else
        {
            List<kus_LopHoc> lstLop = kus_lophoc.GetListLopHocWithCode(code);
            kus_LopHoc lophoc = lstLop.FirstOrDefault();
            if(lophoc == null)
            {
                return false;
            }
        }
        return true;
    }
    private string LopDangChon(string code)
    {
        List<kus_LopHoc> lstLop = kus_lophoc.GetListLopHocWithCode(code);
        kus_LopHoc lophoc = lstLop.FirstOrDefault();
        return lophoc.LopHocCode + " - " + lophoc.TenLopHoc;
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
    protected void btnAddNewHV_Click(object sender, EventArgs e)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        kus_hocvien = new kus_HocVienBLL();
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        kus_ghidanh = new kus_GhiDanhBLL();
        kus_lophoc = new kus_LopHocBLL();
        string FileCode = RandomName + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();

        string firstname = txtFirstNameHV.Text;
        string lastname = txtLastNameHV.Text;
        string ngaysinh = txtNgaySinh.Text;
        DateTime birthday;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (ngaysinh == "" || string.IsNullOrWhiteSpace(ngaysinh) || DateTime.TryParseExact(ngaysinh, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out birthday) || getday(ngaysinh) == "" || getmonth(ngaysinh) == "" || getyear(ngaysinh) == "")
        {
            birthday = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            birthday = DateTime.ParseExact(getday(ngaysinh) + "/" + getmonth(ngaysinh) + "/" + getyear(ngaysinh), "dd/MM/yyyy", null);
        }
        string noisinh = txtNoiSinhHV.Text;
        string socmnd = txtSoCMNDHV.Text;
        string ngaycapcmnd = txtNgayCapCMND.Text;
        DateTime NgayCapCMND;
        if (ngaycapcmnd == "" || string.IsNullOrWhiteSpace(ngaycapcmnd) || DateTime.TryParseExact(ngaycapcmnd, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayCapCMND) || getday(ngaycapcmnd) == "" || getmonth(ngaycapcmnd) == "" || getyear(ngaycapcmnd) == "")
        {
            NgayCapCMND = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            NgayCapCMND = DateTime.ParseExact(getday(ngaycapcmnd) + "/" + getmonth(ngaycapcmnd) + "/" + getyear(ngaycapcmnd), "dd/MM/yyyy", null);
        }
        string noicap = txtNoiCapCMND.Text;
        int sex;
        if (!rdformnam.Checked && !rdformnu.Checked)
        {
            sex = 0;
        }
        else
        {
            sex = (rdformnam.Checked) ? 1 : (rdformnu.Checked) ? 2 : 0;
        }

        this.customerbasicinfo.CreateBasicCodeInfo(FileCode);

        List<CustomerBasicInfo> lstBS = customerbasicinfo.GetCusBasicInfoWithCode(FileCode);
        CustomerBasicInfo basicinfo = lstBS.FirstOrDefault();
        this.customerbasicinfo.UpdateCustomerBasicInfo(basicinfo.InfoID, firstname, lastname, "", birthday, noisinh, sex, socmnd, NgayCapCMND, noicap);
        string HocvienCode = RandomName + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        this.kus_hocvien.CreateCodeHocVien(HocvienCode);

        string diachithuongtru = txtDCThuongTru.Text;
        string diachitamtru = txtDCTamTru.Text;
        string email = txtEmail.Text;
        string dienthoai = txtPhoneHV.Text;
        string hotenPH = txtHoTenPH.Text;
        string nghenghiep = txtNgheNghiepPH.Text;
        string phonePH = txtDienThoaiPH.Text;
        //int NVGioiThieu=
        List<UserProfile> lstprofile = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile userpro = lstprofile.FirstOrDefault();
        List<Employees> lstemployee = employees.getEmpWithProfileId(userpro.ProfileID);
        Employees emp = lstemployee.FirstOrDefault();
        int NVGoiThieu = emp.EmployeesID;
        List<kus_HocVien> lstHV = kus_hocvien.getHVWithCode(HocvienCode);
        kus_HocVien hocvien = lstHV.FirstOrDefault();
        if(this.kus_hocvien.kus_UpdateHocVen(hocvien.HocVienID, basicinfo.InfoID, diachithuongtru, diachitamtru, email, dienthoai, hotenPH, nghenghiep, phonePH, 1))
        {
            if (NewHocVienMore(hocvien.HocVienID))
            {
                
                string LHCode = Request.QueryString["GDlophoc"];
                List<kus_LopHoc> lstLop = kus_lophoc.GetListLopHocWithCode(LHCode);
                kus_LopHoc lophoc = lstLop.FirstOrDefault();
                //Kiem tra ghi danh
                List<kus_GhiDanh> lstCheckGD = kus_ghidanh.getListGDWithHocVienandLopHoc(hocvien.HocVienID, lophoc.LopHocID);
                kus_GhiDanh check_ghidanh = lstCheckGD.FirstOrDefault();
                if (check_ghidanh != null)
                {
                    Response.Write("<script>alert('Học Viên " + hocvien.HocVienCode + " Đã Ghi Danh lớp " + lophoc.LopHocCode + " !')</script>");
                }
                else
                {
                    string ghichu = txtGhiChu.Text;
                    int datcoc = (string.IsNullOrEmpty(txtDatCoc.Text) || string.IsNullOrWhiteSpace(txtDatCoc.Text)) ? 0 : Convert.ToInt32(txtDatCoc.Text);
                    if (this.kus_ghidanh.GhiDanhMoi(hocvien.HocVienID,lophoc.LopHocID, NVGoiThieu, ghichu, datcoc))
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/QLGhiDanh.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Ghi danh thất bại ! Lỗi kết nối CSDL !')</script>");
                    }
                }
            }
            
        }
    }
    private Boolean NewHocVienMore(int HocVienID)
    {
        hocvienmoreinfo = new kus_HocVienMoreInFoBLL();
        string HVGioiThieu = txtHVGioiThieu.Text;
        string TDHocVAn = "";
        if(chkMauGiao.Checked==true)
            TDHocVAn = "Mẫu giáo";
        else if(chkTieuHoc.Checked==true)
            TDHocVAn = "Tiểu học";
        else if(chkTHCS.Checked==true)
            TDHocVAn = "Trung học cơ sở";
        else if(chkTHPT.Checked==true)
            TDHocVAn = "Trung học phổ thông";
        else
            TDHocVAn = "Đại Học - Cao Đẳng";

        string tentruong = txtTenTruong.Text;
        string CCTA = txtCCKHac.Text;
        if (chkCC1.Checked == true)
            CCTA += ";" + "Starters";
         if (chkCC2.Checked == true)
            CCTA += ";" + "Movers";
         if (chkCC3.Checked == true)
            CCTA += ";" + "Flyers";
         if (chkCC4.Checked == true)
            CCTA += ";" + "KET";
         if (chkCC5.Checked == true)
            CCTA += ";" + "PET";
         if (chkCC6.Checked == true)
            CCTA += ";" + "FCE";

        string BTT = txtBTTKHac.Text;
        if (chkBTT1.Checked == true)
            BTT += ";" + "Báo chí";
         if (chkBTT2.Checked == true)
            BTT += ";" + "Internet";
         if (chkBTT3.Checked == true)
            BTT += ";" + "Bạn bè";
         if (chkBTT4.Checked == true)
            BTT += ";" + "Website";
         if (chkBTT5.Checked == true)
            BTT += ";" + "Trực tiếp tại trung tâm";

        

        return this.hocvienmoreinfo.kus_NewHocVienMoreInFo(HocVienID, HVGioiThieu, TDHocVAn, tentruong, CCTA, BTT);

    }

    protected void dlChoseLoaiGD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dlChoseLoaiGD.SelectedValue=="0")
        {
            panelGhiDanhMoi.Visible = true;
            panelDaGhiDanh.Visible = false;
        }
        else
        {
            panelGhiDanhMoi.Visible = false;
            panelDaGhiDanh.Visible = true;
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchHocVienCode(string prefixText, int count)
    {
        kus_HocVienBLL kus_hocvien = new kus_HocVienBLL();

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["connectionStrCon"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from kus_HocVien where HocVienCode like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> lstHVCode = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        lstHVCode.Add(sdr["HocVienCode"].ToString());
                    }
                }
                conn.Close();
                return lstHVCode;
            }
        }
    }

    protected void btnGhiDanhAvailalble_Click(object sender, EventArgs e)
    {
        kus_lophoc = new kus_LopHocBLL();
        kus_hocvien = new kus_HocVienBLL();
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        kus_ghidanh = new kus_GhiDanhBLL();
        string LHCode = Request.QueryString["GDlophoc"];
        List<kus_LopHoc> lstLop = kus_lophoc.GetListLopHocWithCode(LHCode);
        kus_LopHoc lophoc = lstLop.FirstOrDefault();
        List<kus_HocVien> lstHV = kus_hocvien.getHocVienWithMaHV(txtHocVienCode.Text);
        kus_HocVien hocvien = lstHV.FirstOrDefault();
        if(hocvien==null)
        {
            Response.Write("<script>alert('Mã Học Viên " + txtHocVienCode.Text + " không tồn tại. Vui lòng thử lại !')</script>");
        }
        else
        {
            //Kiem tra ghi danh
            List<kus_GhiDanh> lstCheckGD = kus_ghidanh.getListGDWithHocVienandLopHoc(hocvien.HocVienID, lophoc.LopHocID);
            kus_GhiDanh check_ghidanh = lstCheckGD.FirstOrDefault();
            if (check_ghidanh != null)
            {
                Response.Write("<script>alert('Học Viên " + hocvien.HocVienCode + " Đã Ghi Danh lớp " + lophoc.LopHocCode + " !')</script>");
                return;
            }
            else
            {
                List<UserProfile> lstprofile = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
                UserProfile userpro = lstprofile.FirstOrDefault();
                List<Employees> lstemployee = employees.getEmpWithProfileId(userpro.ProfileID);
                Employees emp = lstemployee.FirstOrDefault();
                int NVGoiThieu = emp.EmployeesID;
                string ghichu = txtGhiChuAvailable.Text;
                int datcoc = (string.IsNullOrEmpty(txtDatCocAvailable.Text) || string.IsNullOrWhiteSpace(txtDatCocAvailable.Text)) ? 0 : Convert.ToInt32(txtDatCocAvailable.Text);
                if (this.kus_ghidanh.GhiDanhMoi(hocvien.HocVienID, lophoc.LopHocID, NVGoiThieu, ghichu, datcoc))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/QLGhiDanh.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Ghi danh thất bại ! Lỗi kết nối CSDL !')</script>");
                }
            }
        }
    }
}