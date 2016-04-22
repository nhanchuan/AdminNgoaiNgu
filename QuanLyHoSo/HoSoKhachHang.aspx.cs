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
using System.IO;

public partial class QuanLyHoSo_HoSoKhachHang : BasePage
{
    BagAttachmentsBLL bagattachments;
    CustomerBasicInfoBLL customerbasicinfo;
    CustomerProfilePrivateBLL customerProPri;
    BagProfileBLL bagprofile;
    BagProfileTypeBLL bagprofiletype;
    BagFileTranslateBLL bagtranslate;
    public int PageSize = 10;
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
                if (!check_permiss(ac.UserID, FunctionName.HoSoKhachHang))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.gopro();
                    lblSuccess.Visible = false;
                    rptPager.Visible = true;
                    RpSearchKey.Visible = false;
                    RpOrderBy.Visible = false;
                    this.load_bagattachment();
                    this.load_gwFileTranslate();
                }
            }
        }
    }
    public void gopro()
    {
        string BaseCode = Request.QueryString["FileCode"];
        if (BaseCode != null && CheckQueryStr(BaseCode))
        {
            this.load_GetInfoProFile(BaseCode);
        }
        else
        {
            Response.Redirect("http://" + Request.Url.Authority + "/QuanLyHoSo/ThuLyHoSo.aspx");
        }
    }
    public Boolean CheckQueryStr(string query)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        customerProPri = new CustomerProfilePrivateBLL();
        if (query == "")
        {
            return false;
        }
        else
        {
            List<CustomerBasicInfo> lsCustBas = customerbasicinfo.GetCusBasicInfoWithCode(query);
            CustomerBasicInfo bs = lsCustBas.FirstOrDefault();
            if (bs == null)
            {
                return false;
            }
        }
        return true;
    }
    private void load_GetInfoProFile(string filecode)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        customerbasicinfo = new CustomerBasicInfoBLL();
        bagprofiletype = new BagProfileTypeBLL();
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(filecode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();
        DataTable tbBag = customerProPri.GetInfoProFile(cb.InfoID);
        foreach (DataRow r in tbBag.Rows)
        {
            imgavatarCus.Src = (string.IsNullOrEmpty(r[21].ToString())) ? "../images/default_images.jpg" : "../" + (string)r[21];
            string fname = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
            string lname = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
            lblFullName.Text = lname + " " + fname;
            lblUnitCopyright.Text = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
            lblProfilecode.Text = (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];
            string paddress = (string.IsNullOrEmpty(r[12].ToString())) ? "" : (string)r[12];
            string country = (string.IsNullOrEmpty(r[18].ToString())) ? "" : (string)r[18];
            string province = (string.IsNullOrEmpty(r[19].ToString())) ? "" : (string)r[19];
            string district = (string.IsNullOrEmpty(r[20].ToString())) ? "" : (string)r[20];
            lblPermanentAddress.Text = paddress + ", " + district + ", " + province + ", " + country;
            lblCellPhone.Text = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[11];
            lblEmail.Text = (string.IsNullOrEmpty(r[14].ToString())) ? "" : (string)r[14];
            txtlistfile.Text = (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];

            List<BagProfileType> lstbptype = bagprofiletype.getBagProfileTypeWithId((string.IsNullOrEmpty(r[17].ToString())) ? 0 : (int)r[17]);
            BagProfileType bgtype = lstbptype.FirstOrDefault();
            lblBagProfileType.Text = bgtype.TypeName;
            switch ((string.IsNullOrEmpty(r[17].ToString())) ? 0 : (int)r[17])
            {
                case 1:
                    liTypeStyle.Attributes.Add("class", "list-group-item bg-blue");
                    break;
                case 2:
                    liTypeStyle.Attributes.Add("class", "list-group-item bg-danger");
                    break;
                case 3:
                    liTypeStyle.Attributes.Add("class", "list-group-item bg-green");
                    break;
                case 4:
                    liTypeStyle.Attributes.Add("class", "list-group-item bg-yellow");
                    break;
            }
            this.GetBagProfilePageWise(1, cb.InfoID);
        }

    }
    protected void btnaddnewDoc_ServerClick(object sender, EventArgs e)
    {
        bagprofile = new BagProfileBLL();
        customerbasicinfo = new CustomerBasicInfoBLL();
        string docname = txtDocName.Text;
        string docNote = CKDocNote.Text;
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();

        if (cb == null)
        {
            return;
        }
        else
        {
            if (bagprofile.NewDocProfile(cb.InfoID, txtDocName.Text, docNote, 1))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                return;
            }
        }
    }
    private void GetBagProfilePageWise(int pageIndex, int InfoID)
    {
        bagprofile = new BagProfileBLL();
        int recordCount = 0;
        gwBagProfileManager.DataSource = bagprofile.GetBagProfilePageWise(pageIndex, PageSize, InfoID);
        recordCount = bagprofile.CountGetBagProfilePageWise(InfoID);
        gwBagProfileManager.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        lblSumHoSo.Text = recordCount.ToString();
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
        customerbasicinfo = new CustomerBasicInfoBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetBagProfilePageWise(pageIndex, cb.InfoID);
    }
    protected void btnBagFileTranslate_ServerClick(object sender, EventArgs e)
    {
        bagtranslate = new BagFileTranslateBLL();
        UserAccounts ad = Session.GetCurrentUser();
        bool swit = (gwBagProfileManager.SelectedRow == null) ? true : false;
        switch (swit)
        {
            case false:
                foreach (HttpPostedFile postedFile in fileBagFileTranslate.PostedFiles)
                {
                    int profileId = Convert.ToInt32((gwBagProfileManager.SelectedRow.FindControl("lblBagProfileID") as Label).Text);
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(postedFile.FileName).ToLower();
                    string RandomFileName = "Anh-van-hoi-anh-my-" + RandomName + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
                    string filePath = "FileManager/BagFileTranslate/" + RandomFileName + fileExtension;
                    List<BagFileTranslate> lstBT = bagtranslate.GetBagFileTranslateName(fileName, profileId);
                    BagFileTranslate btl = lstBT.FirstOrDefault();
                    if (btl != null)
                    {
                        return;
                    }
                    else
                    {
                        this.bagtranslate.UploadBagFileTranslate(fileName, filePath, profileId, ad.UserID);
                        postedFile.SaveAs(Server.MapPath("../" + filePath));
                    }
                }
                lblSuccess.Visible = true;
                lblSuccess.Text = string.Format("Upload thành công {0} files dịch hồ sơ \n! <br />", fileBagFileTranslate.PostedFiles.Count);
                this.load_gwFileTranslate();
                break;
            case true:
                Response.Write("<script>alert('Chưa chọn hồ sơ !')</script>");
                break;
        }
        //gwBagProfileManager.SelectedIndex = -1;
    }
    protected void btnBagAttachments_Click(object sender, EventArgs e)
    {
        bagattachments = new BagAttachmentsBLL();
        UserAccounts ad = Session.GetCurrentUser();
        bool swit = (gwBagProfileManager.SelectedRow == null) ? true : false;
        switch (swit)
        {
            case false:
                foreach (HttpPostedFile postedFile in fileUploadBagAttachments.PostedFiles)
                {
                    int profileId = Convert.ToInt32((gwBagProfileManager.SelectedRow.FindControl("lblBagProfileID") as Label).Text);
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(postedFile.FileName).ToLower();
                    string RandomFileName = "Anh-van-hoi-anh-my-" + RandomName + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
                    string filePath = "FileManager/BagAttachments/" + RandomFileName + fileExtension;
                    List<BagAttachments> lstBg = bagattachments.GetbagattWihname(fileName, profileId);
                    BagAttachments bg = lstBg.FirstOrDefault();
                    if (bg != null)
                    {
                        return;
                    }
                    else
                    {
                        this.bagattachments.UploadBagAttachments(fileName, filePath, profileId, ad.UserID);
                        postedFile.SaveAs(Server.MapPath("../" + filePath));
                    }
                }
                lblSuccess.Visible = true;
                lblSuccess.Text = string.Format("Upload thành công {0} files đính kèm \n! <br />", fileUploadBagAttachments.PostedFiles.Count);
                this.load_bagattachment();
                break;
            case true:
                Response.Write("<script>alert('Chưa chọn hồ sơ !')</script>");
                break;
        }
    }
    private void GetKeySearchBagProfilePageWise(int pageIndex, int InfoID, string keysearch)
    {
        bagprofile = new BagProfileBLL();
        int recordCount = 0;
        gwBagProfileManager.DataSource = bagprofile.GetKeySearchBagProfilePageWise(pageIndex, PageSize, InfoID, keysearch);
        recordCount = bagprofile.CountKeySearchBagProfilePageWise(InfoID, keysearch);
        gwBagProfileManager.DataBind();
        this.KeySearchPopulatePager(recordCount, pageIndex);
    }
    private void KeySearchPopulatePager(int recordCount, int currentPage)
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
        RpSearchKey.DataSource = pages;
        RpSearchKey.DataBind();
    }
    protected void SearchKeyPage_Changed(object sender, EventArgs e)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetKeySearchBagProfilePageWise(pageIndex, cb.InfoID, txtsearchbagfile.Value);
    }
    protected void btnSearchKey_ServerClick(object sender, EventArgs e)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();
        this.GetKeySearchBagProfilePageWise(1, cb.InfoID, txtsearchbagfile.Value);
        rptPager.Visible = false;
        RpOrderBy.Visible = false;
        RpSearchKey.Visible = true;
    }
    private void GetOrderByNameBagProfilePageWise(int pageIndex, int InfoID, int orderby)
    {
        bagprofile = new BagProfileBLL();
        int recordCount = 0;
        gwBagProfileManager.DataSource = new ObjectDataSource();
        switch (orderby)
        {
            case 1:
                gwBagProfileManager.DataSource = bagprofile.GetOrderByNameBagProfilePageWise(pageIndex, PageSize, InfoID, 1);
                recordCount = bagprofile.CountGetBagProfilePageWise(InfoID);
                gwBagProfileManager.DataBind();
                this.OrderByPopulatePager(recordCount, pageIndex);
                break;
            case 2:
                gwBagProfileManager.DataSource = bagprofile.GetOrderByNameBagProfilePageWise(pageIndex, PageSize, InfoID, 2);
                recordCount = bagprofile.CountGetBagProfilePageWise(InfoID);
                gwBagProfileManager.DataBind();
                this.OrderByPopulatePager(recordCount, pageIndex);
                break;
            default:
                gwBagProfileManager.DataSource = bagprofile.GetBagProfilePageWise(pageIndex, PageSize, InfoID);
                recordCount = bagprofile.CountGetBagProfilePageWise(InfoID);
                gwBagProfileManager.DataBind();
                this.OrderByPopulatePager(recordCount, pageIndex);
                break;
        }
    }
    private void OrderByPopulatePager(int recordCount, int currentPage)
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
        RpOrderBy.DataSource = pages;
        RpOrderBy.DataBind();
    }
    protected void OrderByPage_Changed(object sender, EventArgs e)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetOrderByNameBagProfilePageWise(pageIndex, cb.InfoID, Convert.ToInt32(dlFilter.SelectedValue));
    }
    protected void dlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();
        this.GetOrderByNameBagProfilePageWise(1, cb.InfoID, Convert.ToInt32(dlFilter.SelectedValue));
        rptPager.Visible = false;
        RpOrderBy.Visible = true;
        RpSearchKey.Visible = false;
    }
    //======View BagAttachment=======================================================================================
    private void load_bagattachment()
    {
        bagattachments = new BagAttachmentsBLL();
        UserAccounts ac = Session.GetCurrentUser();
        customerProPri = new CustomerProfilePrivateBLL();
        customerbasicinfo = new CustomerBasicInfoBLL();
        bagprofiletype = new BagProfileTypeBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();

        gwFileAttachment.DataSource = bagattachments.GetBagAttWihUidInfoId(ac.UserID, cb.InfoID);
        gwFileAttachment.DataBind();
    }
    //=======View Bag File Translate============================================================================================
    private void load_gwFileTranslate()
    {
        bagtranslate = new BagFileTranslateBLL();
        UserAccounts ac = Session.GetCurrentUser();
        customerProPri = new CustomerProfilePrivateBLL();
        customerbasicinfo = new CustomerBasicInfoBLL();
        bagprofiletype = new BagProfileTypeBLL();
        string BaseCode = Request.QueryString["FileCode"];
        List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
        CustomerBasicInfo cb = lstcus.FirstOrDefault();
        gwFileTranslate.DataSource = bagtranslate.GetFileTranslatWihUidInfoId(ac.UserID, cb.InfoID);
        gwFileTranslate.DataBind();
    }
    
    protected void gwFileAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btbDeleteAtt") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwFileAttachment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bagattachments = new BagAttachmentsBLL();
        int AttachmentID = Convert.ToInt32((gwFileAttachment.Rows[e.RowIndex].FindControl("lblAttachmentID") as Label).Text);
        List<BagAttachments> lst = bagattachments.GetbagattWihAttId(AttachmentID);
        BagAttachments bag = lst.FirstOrDefault();
        string filename = Server.MapPath("../" + bag.AttachmentURL);
        if (this.bagattachments.DeleteBagAttachments(AttachmentID))
        {

            if (filename != null || filename != string.Empty)
            {
                if ((System.IO.File.Exists(filename)))
                {
                    System.IO.File.Delete(filename);
                    //this.load_bagattachment();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    return;
                }
            }
        }
        else
        {
            Response.Write("<script>alert('Delete false! Connect database error !')</script>");
            return;
        }

    }

    protected void gwFileTranslate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("btnDeleteTrans") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwFileTranslate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bagtranslate = new BagFileTranslateBLL();
        int FileTranslateID = Convert.ToInt32((gwFileTranslate.Rows[e.RowIndex].FindControl("lblFileTranslateID") as Label).Text);
        List<BagFileTranslate> lst = bagtranslate.GetBagFileTranslateId(FileTranslateID);
        BagFileTranslate tran = lst.FirstOrDefault();
        string filename = Server.MapPath("../" + tran.FileTranslateURL);
        if (this.bagtranslate.DeleteBagFileTranslate(FileTranslateID))
        {
            if (filename != null || filename != string.Empty)
            {
                if ((System.IO.File.Exists(filename)))
                {
                    System.IO.File.Delete(filename);
                    //this.load_gwFileTranslate();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    return;
                }
            }
        }
        else
        {
            Response.Write("<script>alert('Delete false! Connect database error !')</script>");
            return;
        }
    }

    protected void gwBagProfileManager_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gwBagProfileManager_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gwBagProfileManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bagprofile = new BagProfileBLL();
        customerbasicinfo = new CustomerBasicInfoBLL();
        try
        {
            int BagProfileID = Convert.ToInt32((gwBagProfileManager.Rows[e.RowIndex].FindControl("lblBagProfileID") as Label).Text);
            this.DeleteBagAttachment(BagProfileID);
            this.DeleteBagFileTranslate(BagProfileID);
            this.bagprofile.DeleteBagProfile(BagProfileID);

            string BaseCode = Request.QueryString["FileCode"];
            List<CustomerBasicInfo> lstcus = customerbasicinfo.GetCusBasicInfoWithCode(BaseCode);
            CustomerBasicInfo cb = lstcus.FirstOrDefault();
            this.GetBagProfilePageWise(1, cb.InfoID);

            this.load_bagattachment();
            this.load_gwFileTranslate();
        }
        catch (Exception ex)
        {
            lblSuccess.Text = ex.ToString(); 
        }
    }
    private void DeleteBagAttachment(int bagprofileID)
    {
        bagattachments = new BagAttachmentsBLL();
        List<BagAttachments> lst = bagattachments.getListWithBagProfileID(bagprofileID);
        foreach(BagAttachments itm in lst)
        {
            this.bagattachments.DeleteBagAttachments(itm.AttachmentID);
            System.IO.File.Delete(Server.MapPath("../" + itm.AttachmentURL));
        }
    }
    private void DeleteBagFileTranslate(int bagprofileID)
    {
        bagtranslate = new BagFileTranslateBLL();
        List<BagFileTranslate> lst = bagtranslate.getListWithBagProfileID(bagprofileID);
        foreach(BagFileTranslate itm in lst)
        {
            this.bagtranslate.DeleteBagFileTranslate(itm.FileTranslateID);
            System.IO.File.Delete(Server.MapPath("../" + itm.FileTranslateURL));
        }
    }
}