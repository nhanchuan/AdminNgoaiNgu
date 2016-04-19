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

public partial class kus_admin_Books : BasePage
{
    kus_BooksBLL kus_books;
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
                if (!check_permiss(ac.UserID, FunctionName.QLGiaoTrinh))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_gvBook();
                }
            }
        }
    }
    private void load_gvBook()
    {
        kus_books = new kus_BooksBLL();
        gvBook.DataSource = kus_books.getAllBooks();
        gvBook.DataBind();
    }
    protected void gvBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBook.EditIndex = -1;
        this.load_gvBook();
    }
    protected void gvBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        kus_books = new kus_BooksBLL();
        int id = Convert.ToInt32((gvBook.Rows[e.RowIndex].FindControl("lblBook_ID") as Label).Text);

        if(this.kus_books.Delete_Book(id))
        {
            gvBook.EditIndex = -1;
            this.load_gvBook();
        }
        else
        {
            Response.Write("<script>alert('Xóa Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gvBook_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBook.EditIndex = e.NewEditIndex;
        this.load_gvBook();
    }
    protected void gvBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        kus_books = new kus_BooksBLL();
        GridViewRow row = gvBook.Rows[e.RowIndex];
        int id = Convert.ToInt32((row.FindControl("lblBook_ID") as Label).Text);
        string name = (row.FindControl("txtName") as TextBox).Text;
        string author = (row.FindControl("txtAuthor") as TextBox).Text;
        string publisher = (row.FindControl("txtPublisher") as TextBox).Text;
        string nxb = (row.FindControl("txtNgayXB") as TextBox).Text;
        int sotrang = (string.IsNullOrWhiteSpace((row.FindControl("txtSoTrang") as TextBox).Text)) ? 0 : Convert.ToInt32((row.FindControl("txtSoTrang") as TextBox).Text);
        string hinhthuc = (row.FindControl("txtHinhThuc") as TextBox).Text;
        string languages = (row.FindControl("txtLanguages") as TextBox).Text;
        DateTime ngayxb;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (nxb == "" || string.IsNullOrWhiteSpace(nxb) || DateTime.TryParseExact(nxb, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out ngayxb))
        {
            ngayxb = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            ngayxb = DateTime.ParseExact(getday(nxb) + "/" + getmonth(nxb) + "/" + getyear(nxb), "dd/MM/yyyy", null);
        }

        if(this.kus_books.Update_Book(id, name, author, publisher, ngayxb, sotrang, hinhthuc, languages))
        {
            gvBook.EditIndex = -1;
            this.load_gvBook();
        }
        else
        {
            Response.Write("<script>alert('Cập nhật Sách thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    protected void gvBook_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        kus_books = new kus_BooksBLL();
        string name = (gvBook.FooterRow.FindControl("txtAddName") as TextBox).Text;
        string author = (gvBook.FooterRow.FindControl("txtAddAuthor") as TextBox).Text;
        string publisher = (gvBook.FooterRow.FindControl("txtAddPublisher") as TextBox).Text;
        string nxb = (gvBook.FooterRow.FindControl("txtAddNXB") as TextBox).Text;
        int sotrang = (string.IsNullOrWhiteSpace((gvBook.FooterRow.FindControl("txtAddSoTrang") as TextBox).Text)) ? 0 : Convert.ToInt32((gvBook.FooterRow.FindControl("txtAddSoTrang") as TextBox).Text);
        string hinhthuc = (gvBook.FooterRow.FindControl("txtAddHinhThuc") as TextBox).Text;
        string languages = (gvBook.FooterRow.FindControl("txtAddLanguage") as TextBox).Text;
        DateTime ngayxb;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (nxb == "" || string.IsNullOrWhiteSpace(nxb) || DateTime.TryParseExact(nxb, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out ngayxb) || getday(nxb) == "" || getmonth(nxb) == "" || getyear(nxb) == "")
        {
            ngayxb = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            ngayxb = DateTime.ParseExact(getday(nxb) + "/" + getmonth(nxb) + "/" + getyear(nxb), "dd/MM/yyyy", null);
        }
        if(this.kus_books.AddNew_Book(name, author, publisher, ngayxb, sotrang, hinhthuc, languages))
        {
            gvBook.EditIndex = -1;
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm Cơ sở thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
}