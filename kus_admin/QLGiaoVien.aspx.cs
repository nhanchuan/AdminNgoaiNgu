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

public partial class kus_admin_QLGiaoVien : BasePage
{
    kus_GVHopDongBLL kus_gvhopdong;
    kus_HopDongGVBLL kus_hopdonggv;
    EmployeesBLL employees;
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
                if (!check_permiss(ac.UserID, FunctionName.QLGiaoVien))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.Getkus_GVHopDongPageWise(1);
                    this.Getkus_ListGiaoVienTTPageWise(1);
                    btlichsunhopdonggv.Visible = false;
                    btnEditInfor.Visible = false;
                    btnnhapHD.Visible = false;
                }
            }
        }
    }
    private void Getkus_GVHopDongPageWise(int pageIndex)
    {
        kus_gvhopdong = new kus_GVHopDongBLL();
        int recordCount = 0;
        gwGVHopDong.DataSource = kus_gvhopdong.kus_GetGVHopDongPageWise(pageIndex, PageSize);
        recordCount = kus_gvhopdong.Countkus_GetGVHopDong();
        gwGVHopDong.DataBind();
        this.PopulatePager(recordCount, pageIndex);
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
        this.Getkus_GVHopDongPageWise(pageIndex);
    }
    private void load_EditGVHopDong(int gvhdId)
    {
        kus_gvhopdong = new kus_GVHopDongBLL();
        List<kus_GVHopDong> lst = kus_gvhopdong.getGVHopDongWithID(gvhdId);
        kus_GVHopDong gvhd = lst.FirstOrDefault();
        txtElastname.Text = gvhd.LastName;
        txtEFirstname.Text = gvhd.FirstName;
        txtEngaysinh.Text = gvhd.Birthday.ToString("dd/MM/yyyy");
        rdEnam.Checked = (gvhd.Sex == 1) ? true : false;
        rdENu.Checked = (gvhd.Sex == 2) ? true : false;
        txtEscmnd.Text = gvhd.CMND;
        txtEDiaChiTT.Text = gvhd.GVAddress;
        txtEEmail.Text = gvhd.Email;
        txtEPhone.Text = gvhd.Phone;
        txtEGhiChu.Text = gvhd.GhiChu;
        CKEditorEMota.Text = gvhd.MoTaGV;
    }
    protected void gwGVHopDong_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_hopdonggv = new kus_HopDongGVBLL();
        string GVID = (gwGVHopDong.SelectedRow.FindControl("lblGVID") as Label).Text;
        List<kus_HopDongGV> lstHD = kus_hopdonggv.getHDGVWithGiaoVienID(Convert.ToInt32(GVID));
        kus_HopDongGV hopdonggv = lstHD.FirstOrDefault();
        btnEditInfor.Visible = true;
        if (hopdonggv == null)
        {
            btnnhapHD.Visible = true;
            btlichsunhopdonggv.Visible = false;
        }
        else
        {
            if (hopdonggv.NgayHopDong.AddMonths(hopdonggv.ThoiHan) < DateTime.Now || hopdonggv.TinhTrangHD != 1)
            {
                btnnhapHD.Visible = true;
                btlichsunhopdonggv.Visible = true;
                gwlstHDGV.DataSource = lstHD;
                gwlstHDGV.DataBind();
            }
            else
            {
                btnnhapHD.Visible = false;
                btlichsunhopdonggv.Visible = true;
            }
        }
        this.load_EditGVHopDong(Convert.ToInt32(GVID));
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
    protected void btnnhapHDGV_Click(object sender, EventArgs e)
    {
        kus_hopdonggv = new kus_HopDongGVBLL();
        string GVID = (gwGVHopDong.SelectedRow.FindControl("lblGVID") as Label).Text;

        DateTime ngayHD;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (DateTime.TryParseExact(txtNhapNgayHD.Text, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out ngayHD) || getday(txtNhapNgayHD.Text) == "" || getmonth(txtNhapNgayHD.Text) == "" || getyear(txtNhapNgayHD.Text) == "")
        {
            Response.Write("<script>alert('datetime false to format!')</script>");
        }
        else
        {
            ngayHD = DateTime.ParseExact(getday(txtNhapNgayHD.Text) + "/" + getmonth(txtNhapNgayHD.Text) + "/" + getyear(txtNhapNgayHD.Text), "dd/MM/yyyy", null);
        }
        if (kus_hopdonggv.newHopDong(Convert.ToInt32(GVID), ngayHD, Convert.ToInt32(txtthoihannhaphd.Text),1))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        //Response.Write("<script>alert('"+ GVID + ngayHD.ToString()+ txtthoihannhaphd.Text + "')</script>");
    }
    protected void btnthemgiaovienHD_Click(object sender, EventArgs e)
    {
        kus_gvhopdong = new kus_GVHopDongBLL();
        string lname = txtlastnameIn.Text;
        string fname = txtfirstnameIn.Text;
        int sex;
        if (!rdformnam.Checked && !rdformnu.Checked)
        {
            sex = 0;
        }
        else
        {
            sex = (rdformnam.Checked) ? 1 : (rdformnu.Checked) ? 2 : 0;
        }
        string ngaysinh = txtNgaySinhIn.Text;
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
        string CMND = txtSoCMNDIn.Text;
        string Address = txtDCThuongTru.Text;
        string Email = txtEmail.Text;
        string phone = txtPhoneIn.Text;
        string ghichu = txtGhiChuIn.Text;
        string MotaGV = CKContentDescription.Text;
        if (kus_gvhopdong.kus_AddNewGVHopDong(fname, lname, birthday, sex, CMND, Address, Email, phone, ghichu, MotaGV))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm không thành công . Lỗi kết nối data!')</script>");
        }
    }

    //================GIAO VIEN TRUNG TAM=====================================================================================================================================

    private void Getkus_ListGiaoVienTTPageWise(int pageIndex)
    {
        employees = new EmployeesBLL();
        int recordCount = 0;
        gwGiaoVienTrungtam.DataSource = employees.kus_ListGiaoVienTTPageWise(pageIndex, PageSize, 5);
        recordCount = employees.Countkus_ListGiaoVienTT(5);
        gwGiaoVienTrungtam.DataBind();
        this.PopulateGVTTPage(recordCount, pageIndex);
    }
    private void PopulateGVTTPage(int recordCount, int currentPage)
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
        rpGVTT.DataSource = pages;
        rpGVTT.DataBind();
    }
    protected void GVTTPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.Getkus_ListGiaoVienTTPageWise(pageIndex);
    }

    protected void btnViewLichGiang_Click(object sender, EventArgs e)
    {
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        //ProductId
        //int gvid = int.Parse(commandArgument);

        //Response.Write("<script>alert('" + gvid.ToString() + "')</script>");
        Session.SetCurrentGVHD(commandArgument);
        Session.SetCurrentGVTT(0.ToString());
        string script = "window.onload = function() { lichdayEvent_click(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "lichdayEvent_click", script, true);
    }

    protected void btnViewLichGiangTT_Click(object sender, EventArgs e)
    {
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        //ProductId
        
        Session.SetCurrentGVHD(0.ToString());
        Session.SetCurrentGVTT(commandArgument);
        string script = "window.onload = function() { lichdayEvent_click(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "lichdayEvent_click", script, true);
    }

    protected void gwGVHopDong_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDelGVHopDong") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Xóa có thể dẫn tới lỗi hệ thống. Bạn có chắc muốn xóa nữa không ? OK -> Bạn chịu trách nhiệm || Cancel -> coi như không có gì xảy ra !')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwGVHopDong_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_hopdonggv = new kus_HopDongGVBLL();
        kus_gvhopdong = new kus_GVHopDongBLL();
        int GVID = Convert.ToInt32((gwGVHopDong.Rows[e.RowIndex].FindControl("lblGVID") as Label).Text);
        bool delhopdong = this.kus_hopdonggv.Delete_kus_GVHopDong(GVID);
        bool delGVHD = this.kus_gvhopdong.Delete_kus_GVHopDong(GVID);
        if (!delhopdong || !delGVHD)
        {
            Response.Write("<script>alert('Xóa Danh mục thất bại. Lỗi kết nối csdl !')</script>");
        }
        else
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {
        kus_gvhopdong = new kus_GVHopDongBLL();
        if(gwGVHopDong.SelectedRow==null)
        {
            Response.Write("<script>alert('Chưa chọn giáo viên !')</script>");
        }
        else
        {
            string GVID = (gwGVHopDong.SelectedRow.FindControl("lblGVID") as Label).Text;
            string lname = txtElastname.Text;
            string fname = txtEFirstname.Text;
            int sex;
            if (!rdEnam.Checked && !rdENu.Checked)
            {
                sex = 0;
            }
            else
            {
                sex = (rdEnam.Checked) ? 1 : (rdENu.Checked) ? 2 : 0;
            }
            string ngaysinh = txtEngaysinh.Text;
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
            string CMND = txtEscmnd.Text;
            string Address = txtEDiaChiTT.Text;
            string Email = txtEEmail.Text;
            string phone = txtEPhone.Text;
            string ghichu = txtEGhiChu.Text;
            string MotaGV = CKEditorEMota.Text;
            if (kus_gvhopdong.kus_UpdateGVHopDong(Convert.ToInt32(GVID), fname, lname, birthday, sex, CMND, Address, Email, phone, ghichu, MotaGV))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Update không thành công . Lỗi kết nối data!')</script>");
            }
        }
        
        
    }
}