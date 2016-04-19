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

public partial class kus_admin_ListLopHoc : BasePage
{
    private int PageSize = 10;
    kus_LopHocBLL kus_lophoc;
    kus_LopHoc_BooksBLL kus_lophoc_books;
    kus_BooksBLL kus_books;
    kus_LichHocBLL kus_lichhoc;
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
                if (!check_permiss(ac.UserID, FunctionName.QLLopHoc))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.Getkus_LopHocPageWise(1);
                }
            }
        }
    }
    private void Getkus_LopHocPageWise(int pageIndex)
    {
        kus_lophoc = new kus_LopHocBLL();
        int recordCount = 0;
        gwListLopHoc.DataSource = kus_lophoc.Getkus_KhoiLopPageWise(pageIndex, PageSize);
        recordCount = kus_lophoc.Counkus_KhoiLopPageWise();
        gwListLopHoc.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        //lbltotalRecord.Text = recordCount.ToString();
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
        this.Getkus_LopHocPageWise(pageIndex);
    }
    protected void gwListLopHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_books = new kus_BooksBLL();
        kus_lophoc = new kus_LopHocBLL();
        kus_lophoc_books = new kus_LopHoc_BooksBLL();
        string LHCode =(gwListLopHoc.SelectedRow.FindControl("lblLopHocCode") as Label).Text;
        List<kus_LopHoc> lstLH = kus_lophoc.GetListLopHocWithCode(LHCode);
        kus_LopHoc lophoc = lstLH.FirstOrDefault();
        lblchoseMaLop.Text = lophoc.LopHocCode;
        lblchoseLop.Text = lophoc.TenLopHoc;
        lblchoseNgayKG.Text = lophoc.NgayKhaiGiang.ToShortDateString();
        lblchoseNgayKT.Text = lophoc.NgayKetThuc.ToShortDateString();

        gwkus_LopHoc_Books.DataSource = kus_lophoc_books.getTBkus_LopHoc_BooksWithLopID(lophoc.LopHocID);
        gwkus_LopHoc_Books.DataBind();

        dlAddBooks.DataSource = kus_books.GetTBBoook();
        dlAddBooks.DataTextField = "BookNames";
        dlAddBooks.DataValueField = "BookID";
        dlAddBooks.DataBind();

        dlAddBooks.Items.Insert(0, new ListItem("--> Chọn Sách - Giáo Trình <--", "0"));

        lblvalidAddSach.Text = "";

        this.load_LichHoc(lophoc.LopHocID);

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (gwListLopHoc.SelectedRow == null)
        {
            Response.Write("<script>alert('Chưa chọn Lớp học trong danh sách !')</script>");
            return;
        }
        else
        {
            string LHCode = (gwListLopHoc.SelectedRow.FindControl("lblLopHocCode") as Label).Text;
            string cosoID = (gwListLopHoc.SelectedRow.FindControl("lblCoSoID") as Label).Text;
            Session.SetCurrentCoSoID(cosoID);
            Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/LopHocEdit.aspx?Code="+LHCode);
        }
    }
    [Serializable()]
    public class Weekdays
    {
        public int DayID { get; set; }
        public string WeekdaysNameEN { get; set; }
        public string WeekdaysNameVN { get; set; }
        public Weekdays(int id, string nameEN,string nameVN)
        {
            DayID = id;
            WeekdaysNameEN = nameEN;
            WeekdaysNameVN = nameVN;
        }
    }
    private List<Weekdays> getWeekdaysName()
    {
        List<Weekdays> lst = new List<Weekdays>();
        lst.Add(new Weekdays(1, "Monday", "thứ Hai"));
        lst.Add(new Weekdays(2, "Tuesday", "thứ Ba"));
        lst.Add(new Weekdays(3, "Wednesday", "thứ Tư"));
        lst.Add(new Weekdays(4, "Thursday", "thứ Năm"));
        lst.Add(new Weekdays(5, "Friday", "thứ Sáu"));
        lst.Add(new Weekdays(6, "Saturday", "thứ Bảy"));
        lst.Add(new Weekdays(7, "Sunday", "Chủ Nhật"));
        return lst;
    }
    private Boolean CheckAvailableBook()
    {
        kus_lophoc_books = new kus_LopHoc_BooksBLL();
        string LopHocid = (gwListLopHoc.SelectedRow.FindControl("lvlLopHocID") as Label).Text;
        List<kus_LopHoc_Books> lstLH_Book = kus_lophoc_books.getListLopHocBookWithLHID(Convert.ToInt32(LopHocid));
        foreach (kus_LopHoc_Books itm in lstLH_Book)
        {
            if (Convert.ToInt32(dlAddBooks.SelectedValue) == itm.BookID)
            {
                
                return false;
            }
        }
        return true;
    }
    protected void btnAddBook_ServerClick(object sender, EventArgs e)
    {
        kus_lophoc_books = new kus_LopHoc_BooksBLL();
        if (gwListLopHoc.SelectedRow==null)
        {
            lblvalidAddSach.Text = "Chưa chọn Lớp Học !";
        }
        else
        {
            if(dlAddBooks.SelectedValue=="0")
            {
                lblvalidAddSach.Text = "Chưa chọn Sách - Giáo trình !";
            }
            else
            {
                if (!CheckAvailableBook())
                {
                    lblvalidAddSach.Text = "Lớp Học hiện đã có sách - giáo trình này !";
                }
                else
                {
                    string LopHocid = (gwListLopHoc.SelectedRow.FindControl("lvlLopHocID") as Label).Text;
                    if (!this.kus_lophoc_books.InsertBook(Convert.ToInt32(LopHocid), Convert.ToInt32(dlAddBooks.SelectedValue)))
                    {
                        lblvalidAddSach.Text = "Thêm sách - giáo trình False ! Lỗi kết nối DB";
                    }
                    else
                    {
                        lblvalidAddSach.Text = "";
                        gwkus_LopHoc_Books.DataSource = kus_lophoc_books.getTBkus_LopHoc_BooksWithLopID(Convert.ToInt32(LopHocid));
                        gwkus_LopHoc_Books.DataBind();
                    }
                }
            }
           
        }
    }
    protected void gwkus_LopHoc_Books_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelBook") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception ex)
        {
            lblvalidAddSach.Text = ex.ToString();
        }
    }
    protected void gwkus_LopHoc_Books_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_lophoc_books = new kus_LopHoc_BooksBLL();
        string LopHocid = (gwListLopHoc.SelectedRow.FindControl("lvlLopHocID") as Label).Text;
        int bookid = Convert.ToInt32((gwkus_LopHoc_Books.Rows[e.RowIndex].FindControl("lblBookID") as Label).Text);
        if (this.kus_lophoc_books.DeletetBook(Convert.ToInt32(LopHocid),bookid))
        {
            gwkus_LopHoc_Books.DataSource = kus_lophoc_books.getTBkus_LopHoc_BooksWithLopID(Convert.ToInt32(LopHocid));
            gwkus_LopHoc_Books.DataBind();
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
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
    protected void btnreload_Click(object sender, EventArgs e)
    {
        this.Getkus_LopHocPageWise(1);
    }
    protected void gwListLopHoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDelLopHoc") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception) { }
    }
    protected void gwListLopHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This function is in the process of building!')</script>");
    }
}