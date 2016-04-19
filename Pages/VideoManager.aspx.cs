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

public partial class Pages_VideoManager : BasePage
{
    VideosBLL video;
    VideoTypeBLL videotype;
    private int PageSize = 5;
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
                if (!check_permiss(admin.UserID, FunctionName.VideoManager))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlVideotype();
                    dlVideotype.Items.Insert(0, new ListItem("-- Hiển thị tất cả --", "0"));
                    this.GetVideoTypePageWise(1, 0);
                    rptPager.Visible = true;
                    divrownumber.Visible = true;
                    lblstartindex.Text = ((1 - 1) * PageSize + 1).ToString();
                    lblendindex.Text = ((((1 - 1) * PageSize + 1) + PageSize) - 1).ToString();
                    Repeatersearch.Visible = false;
                    divsearch.Visible = false;
                }
            }
        }
    }
    protected void load_dlVideotype()
    {
        videotype = new VideoTypeBLL();
        dlVideotype.DataSource = videotype.getallVideoType();
        dlVideotype.DataTextField = "TypeName";
        dlVideotype.DataValueField = "VideotypeID";
        dlVideotype.DataBind();
    }
    public void load_gwvideomanager()
    {
        video = new VideosBLL();
        gwvideomanager.DataSource = video.getallVideo();
        gwvideomanager.DataBind();
    }

    private void GetVideoTypePageWise(int pageIndex, int Type)
    {
        video = new VideosBLL();
        gwvideomanager.DataSource = new ObjectDataSource();
        int recordCount = 0;
        if (Type <= 0)
        {
            gwvideomanager.DataSource = video.GetVideoPageWise(pageIndex, PageSize);
            recordCount = video.CountRecordVideo();
        }
        else
        {
            gwvideomanager.DataSource = video.GetVideoTypePageWise(pageIndex, PageSize, Type);
            recordCount = video.CountRecordVideoType(Type);
        }
        gwvideomanager.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        lbltotalAudio.Text = recordCount.ToString();
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
        this.GetVideoTypePageWise(pageIndex, int.Parse(dlVideotype.SelectedValue));
        lblstartindex.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        lblendindex.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();

    }

    protected void gwvideomanager_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetVideoTypePageWise(1, int.Parse(dlVideotype.SelectedValue));
        rptPager.Visible = true;
        divrownumber.Visible = true;
        Repeatersearch.Visible = false;
        divsearch.Visible = false;
    }

    private void GetVideoSearchPageWise(int pageIndex, string keysearch)
    {
        video = new VideosBLL();
        gwvideomanager.DataSource = new ObjectDataSource();
        int recordCount = 0;
        if (keysearch == "" || keysearch == null)
        {
            gwvideomanager.DataSource = video.GetVideoPageWise(pageIndex, PageSize);
            recordCount = video.CountRecordVideo();
        }
        else
        {
            gwvideomanager.DataSource = video.GetVideoSearchPageWise(pageIndex, PageSize, keysearch);
            recordCount = video.CountRecordVideoSearch(keysearch);
        }
        gwvideomanager.DataBind();
        this.PopulateSearchPager(recordCount, pageIndex);
        lbltotalSearchAudio.Text = recordCount.ToString();
    }
    private void PopulateSearchPager(int recordCount, int currentPage)
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
        Repeatersearch.DataSource = pages;
        Repeatersearch.DataBind();
    }
    protected void Page_SearchChanged(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetVideoSearchPageWise(pageIndex, txtsearchVideo.Value.ToString());
        lblsearchstart.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        lblsearchend.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();
    }


    protected void btnreload_ServerClick(object sender, EventArgs e)
    {
        this.GetVideoTypePageWise(1, 0);
        rptPager.Visible = true;
        divrownumber.Visible = true;

        Repeatersearch.Visible = false;
        divsearch.Visible = false;
        lblstartindex.Text = ((1 - 1) * PageSize + 1).ToString();
        lblendindex.Text = ((((1 - 1) * PageSize + 1) + PageSize) - 1).ToString();
    }

    protected void btnsearchVideo_ServerClick(object sender, EventArgs e)
    {
        this.GetVideoSearchPageWise(1, txtsearchVideo.Value);
        rptPager.Visible = false;
        divrownumber.Visible = false;
        Repeatersearch.Visible = true;
        divsearch.Visible = true;
        //dlAudiotype.Items.FindByValue("1").Selected = true;
        lblsearchstart.Text = ((1 - 1) * PageSize + 1).ToString();
        lblsearchend.Text = ((((1 - 1) * PageSize + 1) + PageSize) - 1).ToString();


    }
}