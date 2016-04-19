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

public partial class Pages_Tags : BasePage
{
    TagsBLL tags;
    Tags_relationshipsBLL tag_relationships;
    private int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!this.IsPostBack)
        {
            UserAccounts admin = Session.GetCurrentUser();
            if (admin == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(admin.UserID, FunctionName.TagManager))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.GetTagsPageWise(1);
                    lblstartindex.Text = ((1 - 1) * PageSize + 1).ToString();
                    lblendindex.Text = ((((1 - 1) * PageSize + 1) + PageSize) - 1).ToString();
                    btnupdate.Visible = false;
                }
            }
        }
    }
    private void GetTagsPageWise(int pageIndex)
    {
        tags = new TagsBLL();
        int recordCount = 0;
        gwTagsList.DataSource = tags.GetTagsPageWise(pageIndex, PageSize);
        recordCount = tags.CountRecordTagsTB();
        gwTagsList.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        lbltotalTags.Text = recordCount.ToString();
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
        this.GetTagsPageWise(pageIndex);
        lblstartindex.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        lblendindex.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();
    }

    protected void btnaddTags_Click(object sender, EventArgs e)
    {
        tags = new TagsBLL();
        if (this.tags.newTags(txtTagName.Text, txtDescription.Text, txtTagsPermalink.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('New Tags False ! Conect database Error...')</script>");
            return;
        }
    }

    protected void gwTagsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tagsid = (gwTagsList.SelectedRow.FindControl("lblTagsID") as Label).Text;
        tags = new TagsBLL();
        List<Tags> lsttags = tags.getTagsWithID(int.Parse(tagsid));
        Tags tg = lsttags.FirstOrDefault();
        txtEditname.Text = tg.TagsName;
        txtEditDescription.Text = tg.Descritption;
        txtEditPermalink.Text = tg.Permalink;
        btnupdate.Visible = true;
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string tagsid = (gwTagsList.SelectedRow.FindControl("lblTagsID") as Label).Text;
        tags = new TagsBLL();
        if (this.tags.UpdateTags(int.Parse(tagsid), txtEditname.Text, txtEditDescription.Text, txtEditPermalink.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Update Tags False ! Conect database Error...')</script>");
            return;
        }
    }

    protected void gwTagsList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDeltag") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Xóa có thể dẫn tới lỗi hệ thống. Bạn có chắc muốn xóa nữa không ? OK -> Bạn chịu trách nhiệm || Cancel -> coi như không có gì xảy ra !')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwTagsList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        tags = new TagsBLL();
        tag_relationships = new Tags_relationshipsBLL();
        int tagID = Convert.ToInt32((gwTagsList.Rows[e.RowIndex].FindControl("lblTagsID") as Label).Text);
        bool deltagre = this.tag_relationships.DeleteWithTagsID(tagID);
        bool deltag = this.tags.DeleteTagID(tagID);
        if (!deltagre || !deltag)
        {
            Response.Write("<script>alert('Xóa Tag thất bại. Lỗi kết nối csdl !')</script>");
        }
        else
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        //Response.Write("<script>alert('Tò te tí te. Bị dụ rồi. Đâu có xóa được. hehe !')</script>");
    }
}