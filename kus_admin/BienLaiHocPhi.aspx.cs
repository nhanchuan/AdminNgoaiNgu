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

public partial class kus_admin_BienLaiHocPhi : BasePage
{
    kus_BienLaiBLL kus_bienlai;
    kus_LichHocBLL kus_lichhoc;
    kus_HocVienBLL kus_hocvien;
    kus_GhiDanhBLL kus_ghidanh;
    ImagesBLL images;
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
                if (!check_permiss(ac.UserID, FunctionName.NewUser))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    string BLCode = Request.QueryString["BienLaiCode"];
                    if (!CheckQueryStr(BLCode))
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/QLHocPhi.aspx");
                    }
                    else
                    {
                        this.load_BienLaiInfor(BLCode);
                    }
                }
            }
        }
    }
    public Boolean CheckQueryStr(string BLCode)
    {
        kus_bienlai = new kus_BienLaiBLL();
        bool check = true;
        if (string.IsNullOrEmpty(BLCode) || string.IsNullOrWhiteSpace(BLCode))
        {
            check = false;
        }
        else
        {
            List<kus_BienLai> lstBL = kus_bienlai.getListBienLaiWithCode(BLCode);
            kus_BienLai bienlai = lstBL.FirstOrDefault();
            if (bienlai == null)
            {
                check = false;
            }
            else
            {
                check = true;
            }
        }
        return check;
    }
    private void load_BienLaiInfor(string BLCode)
    {
        kus_bienlai = new kus_BienLaiBLL();
        DataTable tbBienLai = kus_bienlai.kus_getBienLaiInfor(BLCode);
        foreach (DataRow r in tbBienLai.Rows)
        {
            lblBienLaicode.Text = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
            lblMaBienLai.Text= (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
            lblMaHocVien.Text= (string.IsNullOrEmpty(r[15].ToString())) ? "" : (string)r[15];
            lblLopHoc.Text = (string.IsNullOrEmpty(r[30].ToString())) ? "" : (string)r[30];
            lblLopHoc.Text += (string.IsNullOrEmpty(r[31].ToString())) ? "" : " - " + (string)r[31];
            lblLopHoc.Text += (string.IsNullOrEmpty(r[41].ToString())) ? "" : " | Cơ sở : " + (string)r[41];
            lblHoTenHV.Text = (string.IsNullOrEmpty(r[27].ToString())) ? "" : (string)r[27];
            lblHoTenHV.Text += (string.IsNullOrEmpty(r[28].ToString())) ? "" : " " + (string)r[28];
            lblBirthday.Text= (string.IsNullOrEmpty(r[29].ToString())) ? "" : ((DateTime)r[29]).ToString("dd/MM/yyyy");
            lblLyDoThu.Text= (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];

            txtHPNgayKG.Text = (string.IsNullOrEmpty(r[33].ToString())) ? "" : ((DateTime)r[33]).ToString("dd/MM/yyyy");
            txtHPNgayKT.Text = (string.IsNullOrEmpty(r[34].ToString())) ? "" : ((DateTime)r[34]).ToString("dd/MM/yyyy");
            lblMucHocPhi.Text= (string.IsNullOrEmpty(r[38].ToString())) ? "0" : ((int)r[38]).ToString("C", new CultureInfo("vi-VN"));
            lblMienGiam.Text= (string.IsNullOrEmpty(r[3].ToString())) ? "0" : ((int)r[3]).ToString()+"% ( số tiền giảm: " +(Convert.ToUInt32((string.IsNullOrEmpty(r[38].ToString())) ? "0" : ((int)r[38]).ToString())*(int)r[3]/100).ToString("C", new CultureInfo("vi-VN"))+" )";
            lblthoiluong.Text= (string.IsNullOrEmpty(r[32].ToString())) ? "0" : ((int)r[32]).ToString()+" tiết";
            lblthanhtien.Text= (string.IsNullOrEmpty(r[4].ToString())) ? "0" : ((int)r[4]).ToString("C", new CultureInfo("vi-VN"));
            lblDatCoc.Text= (string.IsNullOrEmpty(r[13].ToString())) ? "0" : ((int)r[13]).ToString("C", new CultureInfo("vi-VN"));

            this.load_LichHoc(string.IsNullOrEmpty(r[9].ToString()) ? 0 : (int)r[9]);
            this.load_ImgHocVien((string.IsNullOrEmpty(r[14].ToString())) ? "" : (string)r[14]);
        }
    }
    private void load_LichHoc(int lophocID, int daysID, int buoiID, GridView gwLichHoc)
    {
        kus_lichhoc = new kus_LichHocBLL();
        gwLichHoc.DataSource = kus_lichhoc.getkus_LichHocWithLopHocandDayandBuoi(lophocID, daysID, buoiID);
        gwLichHoc.DataBind();
    }
    private void load_LichHoc(int LopHocID)
    {
        this.load_LichHoc(LopHocID, 1, 1, gwThu2Sang);
        this.load_LichHoc(LopHocID, 1, 2, gwThu2Chieu);
        this.load_LichHoc(LopHocID, 1, 3, gwThu2Toi);
        this.load_LichHoc(LopHocID, 2, 1, gwThu3Sang);
        this.load_LichHoc(LopHocID, 2, 2, gwThu3Chieu);
        this.load_LichHoc(LopHocID, 2, 3, gwThu3Toi);
        this.load_LichHoc(LopHocID, 3, 1, gwThu4Sang);
        this.load_LichHoc(LopHocID, 3, 2, gwThu4Chieu);
        this.load_LichHoc(LopHocID, 3, 3, gwThu4Toi);
        this.load_LichHoc(LopHocID, 4, 1, gwThu5Sang);
        this.load_LichHoc(LopHocID, 4, 2, gwThu5Chieu);
        this.load_LichHoc(LopHocID, 4, 3, gwThu5Toi);
        this.load_LichHoc(LopHocID, 5, 1, gwThu6Sang);
        this.load_LichHoc(LopHocID, 5, 2, gwThu6Chieu);
        this.load_LichHoc(LopHocID, 5, 3, gwThu6Toi);
        this.load_LichHoc(LopHocID, 6, 1, gwThu7Sang);
        this.load_LichHoc(LopHocID, 6, 2, gwThu7Chieu);
        this.load_LichHoc(LopHocID, 6, 3, gwThu7Toi);
        this.load_LichHoc(LopHocID, 7, 1, gwChuNhatSang);
        this.load_LichHoc(LopHocID, 7, 2, gwChuNhatChieu);
        this.load_LichHoc(LopHocID, 7, 3, gwChuNhatToi);
    }
    //------Load Images-----------------------------------------------------------------------------
    protected void load_ImgHocVien(string code)
    {
        kus_hocvien = new kus_HocVienBLL();
        kus_ghidanh = new kus_GhiDanhBLL();
        images = new ImagesBLL();
        List<kus_GhiDanh> lstGD = kus_ghidanh.getListGDCode(code);
        kus_GhiDanh ghidanh = lstGD.FirstOrDefault();
        if(ghidanh==null)
        {
            imgCusprofile.Src = "../images/default_images.jpg";
        }
        else
        {
            List<kus_HocVien> lstHV = kus_hocvien.getHocVienWithID(ghidanh.HocVienID);
            kus_HocVien hocvien = lstHV.FirstOrDefault();
            List<Images> lstImg = images.getImagesWithId(hocvien.ImgID);
            Images img = lstImg.FirstOrDefault();
            imgCusprofile.Src = (img == null) ? "../images/default_images.jpg" : "../" + img.ImagesUrl;
        }
        
    }
}