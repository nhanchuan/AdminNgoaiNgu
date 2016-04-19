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

public partial class ChuongTrinhHoc_KhoaHoc : BasePage
{
    nc_LoaiCTDaoTaoBLL nc_loaictdaotao;
    nc_ChuongTrinhDaoTaoBLL nc_chuongtrinhdaotao;
    nc_LopHocBLL nc_lophoc;
    nc_KhoaHocBLL nc_khoahoc;
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
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
                    this.load_dlLoaiChuongTrinh();
                    this.load_dlHTChiNhanh();
                    dlChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình --", "0"));
                    dlLopHoc.Items.Insert(0, new ListItem("-- Chọn lớp học --", "0"));
                    dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
                    if(Session["pageIndexnc_lophoc"]==null)
                    {
                        this.Getnc_KhoaHocPageWise(1);
                    }
                    else
                    {
                        int pageIndex = Convert.ToInt32(Session["pageIndexnc_lophoc"].ToString());
                        this.Getnc_KhoaHocPageWise(pageIndex);
                    }
                    btnEditKhoaHoc.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default disabled");
                    rptPager.Visible = true;
                    rptSearch.Visible = false;
                }
            }
        }
    }
    private void load_dlLoaiChuongTrinh()
    {
        nc_loaictdaotao = new nc_LoaiCTDaoTaoBLL();
        dlLoaiChuongTrinh.DataSource = nc_loaictdaotao.getListLoaiCTDaoTao();
        dlLoaiChuongTrinh.DataTextField = "TenChuongTrinh";
        dlLoaiChuongTrinh.DataValueField = "ID";
        dlLoaiChuongTrinh.DataBind();
        dlLoaiChuongTrinh.Items.Insert(0, new ListItem("-- Chọn loại chương trình --", "0"));
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
    protected void dlLoaiChuongTrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        dlChuongTrinh.DataSource = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithLoai(Convert.ToInt32(dlLoaiChuongTrinh.SelectedValue));
        dlChuongTrinh.DataTextField = "TenChuongTrinh";
        dlChuongTrinh.DataValueField = "ID";
        dlChuongTrinh.DataBind();
        dlChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình --", "0"));
    }
    protected void dlChuongTrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        dlLopHoc.DataSource = nc_lophoc.getListLopHocWithChuongTrinh(Convert.ToInt32(dlChuongTrinh.SelectedValue));
        dlLopHoc.DataTextField = "TenLopHoc";
        dlLopHoc.DataValueField = "ID";
        dlLopHoc.DataBind();
        dlLopHoc.Items.Insert(0, new ListItem("-- Chọn lớp học --", "0"));
    }
    private void load_dlHTChiNhanh()
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        dlHTChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
        dlHTChiNhanh.DataTextField = "tenHTChiNhanh";
        dlHTChiNhanh.DataValueField = "hTChiNhanhID";
        dlHTChiNhanh.DataBind();
        dlHTChiNhanh.Items.Insert(0, new ListItem("------- Chọn Hệ Thống Chi Nhánh -------", "0"));
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
    protected void dlHTChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        dlCoSo.DataSource = kus_coso.getLSTCoSoWithChiNhanhID(Convert.ToInt32(dlHTChiNhanh.SelectedValue));
        dlCoSo.DataTextField = "TenCoSo";
        dlCoSo.DataValueField = "CoSoID";
        dlCoSo.DataBind();
        dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
    }
    private void Getnc_KhoaHocPageWise(int pageIndex)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        int recordCount = 0;
        gwKhoaHoc.DataSource = nc_khoahoc.get_Tabel_nc_KhoaHoc(pageIndex, PageSize);
        recordCount = nc_khoahoc.Count_khoahoc();
        gwKhoaHoc.DataBind();
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
        this.Getnc_KhoaHocPageWise(pageIndex);
        Session["pageIndexnc_lophoc"] = pageIndex.ToString();
        rptPager.Visible = true;
        rptSearch.Visible = false;
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
    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        try
        {
            string tenkhoahoc = txtTenKhoaHoc.Text;
            int soluong = (txtSoLuong.Text == "") ? 0 : Convert.ToInt32(txtSoLuong.Text);
            int thoiluong = (txtThoiLuong.Text == "") ? 0 : Convert.ToInt32(txtThoiLuong.Text);
            string ngaykhaigiang = txtNgayKG.Text;
            string ngayketthuc = txtNgayKT.Text;
            DateTime NgayKG;
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
            if (string.IsNullOrWhiteSpace(ngaykhaigiang) || DateTime.TryParseExact(ngaykhaigiang, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKG) || getday(ngaykhaigiang) == "" || getmonth(ngaykhaigiang) == "" || getyear(ngaykhaigiang) == "")
            {
                NgayKG = Convert.ToDateTime("12/12/1900");
            }
            else
            {
                NgayKG = DateTime.ParseExact(getday(ngaykhaigiang) + "/" + getmonth(ngaykhaigiang) + "/" + getyear(ngaykhaigiang), "dd/MM/yyyy", null);
            }
            DateTime NgayKT;
            if (string.IsNullOrWhiteSpace(ngayketthuc) || DateTime.TryParseExact(ngayketthuc, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKT) || getday(ngayketthuc) == "" || getmonth(ngayketthuc) == "" || getyear(ngayketthuc) == "")
            {
                NgayKT = Convert.ToDateTime("12/12/1900");
            }
            else
            {
                NgayKT = DateTime.ParseExact(getday(ngayketthuc) + "/" + getmonth(ngayketthuc) + "/" + getyear(ngayketthuc), "dd/MM/yyyy", null);
            }
            int loaichuongtrinh = Convert.ToInt32(dlLoaiChuongTrinh.SelectedValue);
            int chuongtrinh = Convert.ToInt32(dlChuongTrinh.SelectedValue);
            int lophoc = Convert.ToInt32(dlLopHoc.SelectedValue);
            int coso = Convert.ToInt32(dlCoSo.SelectedValue);
            if (nc_khoahoc.New_nc_KhoaHoc(tenkhoahoc, soluong, NgayKG, thoiluong, NgayKT, loaichuongtrinh, chuongtrinh, lophoc, coso))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Thêm thất bại. Lỗi kết nối cơ sở dữ liệu !')</script>");
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }
    protected void gwKhoaHoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDel") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {

        }
    }
    protected void gwKhoaHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This Process is Building ! !')</script>");
    }
    protected void gwKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        kus_coso = new kus_CoSoBLL();
        btnEditKhoaHoc.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default");
        this.load_dlELoaiChuongTrinh();
        this.load_dlEHTChiNhanh();
        this.load_dlECoSo();
        int khoahocID = Convert.ToInt32((gwKhoaHoc.SelectedRow.FindControl("lblID") as Label).Text);
        List<nc_KhoaHoc> lst = nc_khoahoc.getListKhoaHocWithID(khoahocID);
        nc_KhoaHoc khoahoc = lst.FirstOrDefault();
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
    protected void btnSaveEditKhoaHoc_Click(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        try
        {
            int khoahocID = Convert.ToInt32((gwKhoaHoc.SelectedRow.FindControl("lblID") as Label).Text);
            string tenkhoahoc = txtETenKhoaHoc.Text;
            int soluong = (txtESoLuong.Text == "") ? 0 : Convert.ToInt32(txtESoLuong.Text);
            int thoiluong = (txtEThoiLuong.Text == "") ? 0 : Convert.ToInt32(txtEThoiLuong.Text);
            string ngaykhaigiang = txtENgayKhaiGiang.Text;
            string ngayketthuc = txtENgayKetThuc.Text;
            DateTime NgayKG;
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
            if (string.IsNullOrWhiteSpace(ngaykhaigiang) || DateTime.TryParseExact(ngaykhaigiang, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKG) || getday(ngaykhaigiang) == "" || getmonth(ngaykhaigiang) == "" || getyear(ngaykhaigiang) == "")
            {
                NgayKG = Convert.ToDateTime("12/12/1900");
            }
            else
            {
                NgayKG = DateTime.ParseExact(getday(ngaykhaigiang) + "/" + getmonth(ngaykhaigiang) + "/" + getyear(ngaykhaigiang), "dd/MM/yyyy", null);
            }
            DateTime NgayKT;
            if (string.IsNullOrWhiteSpace(ngayketthuc) || DateTime.TryParseExact(ngayketthuc, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out NgayKT) || getday(ngayketthuc) == "" || getmonth(ngayketthuc) == "" || getyear(ngayketthuc) == "")
            {
                NgayKT = Convert.ToDateTime("12/12/1900");
            }
            else
            {
                NgayKT = DateTime.ParseExact(getday(ngayketthuc) + "/" + getmonth(ngayketthuc) + "/" + getyear(ngayketthuc), "dd/MM/yyyy", null);
            }
            int loaichuongtrinh = Convert.ToInt32(dlELoaiChuongTrinh.SelectedValue);
            int chuongtrinh = Convert.ToInt32(dlEChuongTrinh.SelectedValue);
            int lophoc = Convert.ToInt32(dlELopHoc.SelectedValue);
            int coso = Convert.ToInt32(dlECoSo.SelectedValue);
            if (nc_khoahoc.Update_nc_KhoaHoc(khoahocID, tenkhoahoc, soluong, NgayKG, thoiluong, NgayKT, loaichuongtrinh, chuongtrinh, lophoc, coso))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Cập nhật thất bại. Lỗi kết nối cơ sở dữ liệu !')</script>");
            }
            //------------------------------------------------------------------------
            
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
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
    protected void dlELoaiChuongTrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_chuongtrinhdaotao = new nc_ChuongTrinhDaoTaoBLL();
        dlEChuongTrinh.DataSource = nc_chuongtrinhdaotao.GetChuongTrinhDaoTaoWithLoai(Convert.ToInt32(dlELoaiChuongTrinh.SelectedValue));
        dlEChuongTrinh.DataTextField = "TenChuongTrinh";
        dlEChuongTrinh.DataValueField = "ID";
        dlEChuongTrinh.DataBind();
        dlEChuongTrinh.Items.Insert(0, new ListItem("-- Chọn chương trình --", "0"));
    }
    protected void dlEChuongTrinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_lophoc = new nc_LopHocBLL();
        dlELopHoc.DataSource = nc_lophoc.getListLopHocWithChuongTrinh(Convert.ToInt32(dlEChuongTrinh.SelectedValue));
        dlELopHoc.DataTextField = "TenLopHoc";
        dlELopHoc.DataValueField = "ID";
        dlELopHoc.DataBind();
        dlELopHoc.Items.Insert(0, new ListItem("-- Chọn lớp học --", "0"));
    }
    protected void dlEHTChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        dlCoSo.DataSource = kus_coso.getLSTCoSoWithChiNhanhID(Convert.ToInt32(dlEHTChiNhanh.SelectedValue));
        dlCoSo.DataTextField = "TenCoSo";
        dlCoSo.DataValueField = "CoSoID";
        dlCoSo.DataBind();
        dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
    }

    //search
    private void GetSearchKhoaHocPageWise(int pageIndex, string keysearch)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        int recordCount = 0;
        gwKhoaHoc.DataSource = nc_khoahoc.Search_nc_KhoaHoc(pageIndex, PageSize, keysearch);
        recordCount = nc_khoahoc.Count_search_khoahoc(keysearch);
        gwKhoaHoc.DataBind();
        this.PopulateSearch(recordCount, pageIndex);
    }
    private void PopulateSearch(int recordCount, int currentPage)
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
        rptSearch.DataSource = pages;
        rptSearch.DataBind();
    }
    protected void Search_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetSearchKhoaHocPageWise(pageIndex, txtsearch.Value);
        rptPager.Visible = false;
        rptSearch.Visible = true;
    }
    protected void btnSearchKhoaHoc_ServerClick(object sender, EventArgs e)
    {
        this.GetSearchKhoaHocPageWise(1, txtsearch.Value);
        rptPager.Visible = false;
        rptSearch.Visible = true;
    }

    protected void btnRefreshLstKhoaHoc_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}