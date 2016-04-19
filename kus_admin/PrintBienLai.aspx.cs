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
            lblBienLaicodeLien1.Text = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
            lblMaGhiDanhLien1.Text= (string.IsNullOrEmpty(r[14].ToString())) ? "" : (string)r[14];
            lblLopHocLien1.Text = (string.IsNullOrEmpty(r[30].ToString())) ? "" : (string)r[30];
            lblLopHocLien1.Text += (string.IsNullOrEmpty(r[31].ToString())) ? "" : " - " + (string)r[31];
            lblHoTenHVLien1.Text = (string.IsNullOrEmpty(r[27].ToString())) ? "" : (string)r[27];
            lblHoTenHVLien1.Text += (string.IsNullOrEmpty(r[28].ToString())) ? "" : " " + (string)r[28];
            lblLyDoThuLien1.Text = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
            lblthoiluongLien1.Text = (string.IsNullOrEmpty(r[32].ToString())) ? "0" : ((int)r[32]).ToString() + " tiết";
            lblThanhTienLien1.Text = (string.IsNullOrEmpty(r[4].ToString())) ? "0" : ((int)r[4]).ToString("C", new CultureInfo("vi-VN"));
            lblThanhTienChuLien1.Text= (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
            lblDiaChiLien1.Text= (string.IsNullOrEmpty(r[17].ToString())) ? "" : (string)r[17];
            lblDienthoaiLien1.Text= (string.IsNullOrEmpty(r[19].ToString())) ? "" : (string)r[19];
            NVGhiDanhLien1.Text= (string.IsNullOrEmpty(r[58].ToString())) ? "" : (string)r[58];
            NVGhiDanhLien1.Text += (string.IsNullOrEmpty(r[57].ToString())) ? "" : " " + (string)r[57];

            lblBienLaicodeLien2.Text = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
            lblMaGhiDanhLien2.Text = (string.IsNullOrEmpty(r[14].ToString())) ? "" : (string)r[14];
            lblLopHocLien2.Text = (string.IsNullOrEmpty(r[30].ToString())) ? "" : (string)r[30];
            lblLopHocLien2.Text += (string.IsNullOrEmpty(r[31].ToString())) ? "" : " - " + (string)r[31];
            lblHoTenHVLien2.Text = (string.IsNullOrEmpty(r[27].ToString())) ? "" : (string)r[27];
            lblHoTenHVLien2.Text += (string.IsNullOrEmpty(r[28].ToString())) ? "" : " " + (string)r[28];
            lblLyDoThuLien2.Text = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
            lblthoiluongLien2.Text = (string.IsNullOrEmpty(r[32].ToString())) ? "0" : ((int)r[32]).ToString() + " tiết";
            lblThanhTienLien2.Text = (string.IsNullOrEmpty(r[4].ToString())) ? "0" : ((int)r[4]).ToString("C", new CultureInfo("vi-VN"));
            lblThanhTienChuLien2.Text = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
            lblDiaChiLien2.Text = (string.IsNullOrEmpty(r[17].ToString())) ? "" : (string)r[17];
            lblDienthoaiLien2.Text = (string.IsNullOrEmpty(r[19].ToString())) ? "" : (string)r[19];
            NVGhiDanhLien2.Text = (string.IsNullOrEmpty(r[58].ToString())) ? "" : (string)r[58];
            NVGhiDanhLien2.Text += (string.IsNullOrEmpty(r[57].ToString())) ? "" : " " + (string)r[57];

        }

    }
}