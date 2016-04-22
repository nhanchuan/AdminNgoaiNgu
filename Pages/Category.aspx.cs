using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DAL;
using BLL;
using System.Drawing.Imaging;
using System.Drawing;

public partial class Pages_Category : BasePage
{
    CategoryBLL category;
    Post_Category_relationshipsBLL post_category_relationships;
    ImagesBLL images;
    ImagesTypeBLL imagestype;
    private int PageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!this.IsPostBack)
        {
            UserAccounts user = Session.GetCurrentUser();
            if (user == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(user.UserID, FunctionName.CategoryManager))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    btnshowPanelfix.Attributes.Add("class", "btn yellow disabled");
                    this.load_dlPCategory();
                    
                    this.load_dlDanhMucCha();

                    if (Session["pageIndexadmin_Category"] == null)
                    {
                        this.GetPostCategoryPageWise(1);
                    }
                    else
                    {
                        int pageIndex = Convert.ToInt32(Session["pageIndexadmin_Category"].ToString());
                        this.GetPostCategoryPageWise(pageIndex);
                        if(Session["SelectedIndex_Category"] == null)
                        {
                            gwCategory.SelectedIndex = -1;
                        }
                        else
                        {
                            gwCategory.SelectedIndex = Convert.ToInt32(Session["SelectedIndex_Category"].ToString());
                        }
                    }

                    
                    lblstartindex.Text = ((1 - 1) * PageSize + 1).ToString();
                    lblendindex.Text = ((((1 - 1) * PageSize + 1) + PageSize) - 1).ToString();
                    this.load_rpLstImg();
                    this.load_rpSelectEditImg();
                    btnUpdatePCInfo.Visible = false;
                    dlEditParent.Visible = false;
                    this.PopulateRootLevel();

                    rptPager.Visible = true;
                    rptSearchPage.Visible = false;
                    
                }
            }
        }
    }
    protected void load_dlPCategory()
    {
        category = new CategoryBLL();
        dlPCategory.DataSource = category.getTBAllCategory();
        dlPCategory.DataValueField = "CategoryID";
        dlPCategory.DataTextField = "ParentNameCategory";
        dlPCategory.DataBind();
        dlPCategory.Items.Insert(0, new ListItem("-- Trống --", "0"));
    }
    protected void load_dlDanhMucCha()
    {
        category = new CategoryBLL();
        dlDanhMucCha.DataSource = category.getTBAllCategory();
        dlDanhMucCha.DataValueField = "CategoryID";
        dlDanhMucCha.DataTextField = "ParentNameCategory";
        dlDanhMucCha.DataBind();
        dlDanhMucCha.Items.Insert(0, new ListItem("-- Trống --", "0"));
    }
    protected void btnuploadImages_Click(object sender, EventArgs e)
    {
        images = new ImagesBLL();
        UserAccounts ac = Session.GetCurrentUser();
        string fileName = Path.GetFileName(FileImgUpload.PostedFile.FileName);
        string fileExtension = "";
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        try
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = "Anh-van-hoi-anh-my" + RandomName + fileExtension;
                string pathToSave = Server.MapPath("../images/Upload/ImagesForCategory/") + str_image;
                //file.SaveAs(pathToSave);
                System.Drawing.Image image = System.Drawing.Image.FromStream(FileImgUpload.FileContent);
                if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Gif);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Bmp);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Png);
                else
                    throw new System.ArgumentException("Invalid File Type");
                Bitmap bmp1 = new Bitmap(FileImgUpload.FileContent);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
                this.images.InsertImages(str_image, "images/Upload/ImagesForCategory/" + str_image, 4, ac.UserID);
                HiddenFileImgUpload.Value = "images/Upload/ImagesForCategory/" + str_image;
            }
            else
            {
                Response.Write("<script>alert('Upload Image False !')</script>");
                return;
            }
            ImgPostCategory.Src = "http://" + Request.Url.Authority + "/images/Upload/ImagesForCategory/" + str_image;
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + " !')</script>");
        }

    }
    protected int ImagesID(string filename)
    {
        int ImID = 0;
        images = new ImagesBLL();

        if (string.IsNullOrWhiteSpace(filename))
        {
            ImID = 0;
        }
        else
        {
            ImID = images.ImagesIDUrl(filename);
        }
        return ImID;
    }
    protected Boolean newPostCategory()
    {
        category = new CategoryBLL();
        int parent = int.Parse(dlPCategory.SelectedValue);
        int imgid = ImagesID(HiddenFileImgUpload.Value);
        bool update = this.category.newCategory(txtPostCategoryName.Text, txtDescription.Text, txtPCUrl.Text, parent, imgid, (Convert.ToInt32(dlDanhMucCha.SelectedValue) == 0) ? category.MaxItemindexWithParentNull() + 1 : category.MaxItemindexWithParent(Convert.ToInt32(dlDanhMucCha.SelectedValue)) + 1);
        return update;
    }
    public void load_rpLstImg()
    {
        images = new ImagesBLL();
        rpLstImg.DataSource = images.getImagesWithType(4);
        rpLstImg.DataBind();
    }
    protected void btnselectimages_Click(object sender, EventArgs e)
    {
        string url = HiddenimgSelect.Value;
        string http = "http://" + Request.Url.Authority + "/";
        HiddenFileImgUpload.Value = url.Remove(0, http.Length);
        ImgPostCategory.Src = url;
        //Response.Write("<script>alert('"+ HiddenFileImgUpload.Value + "')</script>");
    }
    private void GetPostCategoryPageWise(int pageIndex)
    {
        category = new CategoryBLL();
        int recordCount = 0;
        gwCategory.DataSource = category.GetCategoryPageWise(pageIndex, PageSize);
        recordCount = category.CountRecordPostCategory();
        gwCategory.DataBind();
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
        this.GetPostCategoryPageWise(pageIndex);
        Session["pageIndexadmin_Category"] = pageIndex.ToString();
        lblstartindex.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        lblendindex.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();
        rptPager.Visible = true;
        rptSearchPage.Visible = false;
    }

    protected void btnnewPostCategory_Click(object sender, EventArgs e)
    {
        if (newPostCategory())
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('New Post Category False !')</script>");
            return;
        }
    }

    protected void load_dlEditParent()
    {
        category = new CategoryBLL();
        string ctId = (gwCategory.SelectedRow.FindControl("lblCategoryID") as Label).Text;
        dlEditParent.DataSource = category.getTBSubtractCategory(int.Parse(ctId));
        dlEditParent.DataValueField = "CategoryID";
        dlEditParent.DataTextField = "ParentNameCategory";
        dlEditParent.DataBind();
    }
    protected void gwCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        category = new CategoryBLL();
        images = new ImagesBLL();
        btnshowPanelfix.Attributes.Add("class", "btn yellow");
        this.load_dlEditParent();
        dlEditParent.Items.Insert(0, new ListItem("--Trống--", "0"));
        string ctId = (gwCategory.SelectedRow.FindControl("lblCategoryID") as Label).Text;
        List<Category> lst = category.getCategorWithId(int.Parse(ctId));
        Category ct = lst.FirstOrDefault();

        Session["SelectedIndex_Category"] = gwCategory.SelectedIndex.ToString();

        int imgID = 0;

        txtEditName.Text = ct.CategoryName;
        txtEditDescription.Text = ct.Descriptions;
        txtEditPermalink.Text = ct.Permalink;

        dlEditParent.Items.FindByValue(ct.Parent.ToString()).Selected = true;
        imgID = ct.CateogryImage;

        List<Images> lstImg = images.getImagesWithId(imgID);
        Images img = lstImg.FirstOrDefault();
        ImgEditPC.Src = (img == null) ? "../images/No_image.png" : "http://" + Request.Url.Authority + "/" + img.ImagesUrl;
        txtuploadImgTemp.Text = (img == null) ? "" : img.ImagesUrl;
        btnUpdatePCInfo.Visible = true;
        dlEditParent.Visible = true;
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    protected void btnuploadEditImg_ServerClick(object sender, EventArgs e)
    {
        //ImgEditPC.Src = txtuploadImgTemp.Text;
        UserAccounts ac = Session.GetCurrentUser();

        images = new ImagesBLL();
        string dateString = DateTime.Now.ToString("MM-dd-yyyy");
        string fileName = Path.GetFileName(fileUploadImgPC.PostedFile.FileName);
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        string fileExtension = "";
        if (!string.IsNullOrEmpty(fileName))
        {
            fileExtension = Path.GetExtension(fileName);
            str_image = "Hollywood-" + dateString + "-" + RandomName + fileExtension;
            string pathToSave = Server.MapPath("../images/Upload/ImagesForCategory/") + str_image;
            //file.SaveAs(pathToSave);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fileUploadImgPC.FileContent);
            if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Gif);
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Bmp);
            else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                jgpEncoder = GetEncoder(ImageFormat.Png);
            else
                throw new System.ArgumentException("Invalid File Type");
            Bitmap bmp1 = new Bitmap(fileUploadImgPC.FileContent);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
            this.images.InsertImages(str_image, "images/Upload/ImagesForCategory/" + str_image, 4, ac.UserID);
            txtuploadImgTemp.Text = "images/Upload/ImagesForCategory/" + str_image;
            ImgEditPC.Src = "../images/Upload/ImagesForCategory/" + str_image;
        }
        else
        {
            Response.Write("<script>alert('Upload Image False !')</script>");
            return;
        }
        string script = "window.onload = function() { callButtonClickEvent(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callButtonClickEvent", script, true);
    }
    protected Boolean Update()
    {
        bool updateinfo;
        UserAccounts ac = Session.GetCurrentUser();
        category = new CategoryBLL();
        string ctId = (gwCategory.SelectedRow.FindControl("lblCategoryID") as Label).Text;
        int parent = int.Parse(dlEditParent.SelectedValue);
        int imgid = ImagesID(txtuploadImgTemp.Text);
        if (parent == 0 && imgid > 0)
            updateinfo = this.category.UpdatePostCategoryparentNull(int.Parse(ctId), txtEditName.Text, txtEditDescription.Text, txtEditPermalink.Text, imgid);
        else if (imgid == 0 && parent > 0)
            updateinfo = this.category.UpdatePostCategoryImgNull(int.Parse(ctId), txtEditName.Text, txtEditDescription.Text, txtEditPermalink.Text, parent);
        else if (parent == 0 && imgid == 0)
            updateinfo = this.category.UpdatePostCategoryParentAndImgNull(int.Parse(ctId), txtEditName.Text, txtEditDescription.Text, txtEditPermalink.Text);
        else
            updateinfo = this.category.UpdatePostCategory(int.Parse(ctId), txtEditName.Text, txtEditDescription.Text, txtEditPermalink.Text, parent, imgid);

        return updateinfo;
    }
    protected void btnUpdatePCInfo_Click(object sender, EventArgs e)
    {
        UserAccounts ac = Session.GetCurrentUser();
        category = new CategoryBLL();
        if (Update())
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Upload Image False !')</script>");
            return;
        }
        //Response.Write("<script>alert('"+ int.Parse(ctId)+" - "+txtEditName.Text+" - "+ txtEditDescription.Text+" - "+ txtEditPermalink.Text+" - "+ int.Parse(dlEditParent.SelectedValue)+" - "+ ImagesID(txtuploadImgTemp.Text) + "')</script>");
    }
    public void load_rpSelectEditImg()
    {
        images = new ImagesBLL();
        rpSelectEditImg.DataSource = images.getImagesWithType(4);
        rpSelectEditImg.DataBind();
    }
    protected void btnselectEditImg_Click(object sender, EventArgs e)
    {
        string http = "http://" + Request.Url.Authority + "/";
        txtuploadImgTemp.Text = HiddenFieldEditImgesSelect.Value.Remove(0, http.Length);
        ImgEditPC.Src = "../" + HiddenFieldEditImgesSelect.Value.Remove(0, http.Length);
        string script = "window.onload = function() { callButtonClickEvent(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callButtonClickEvent", script, true);
    }
    private void PopulateRootLevel()
    {
        category = new CategoryBLL();
        DataTable tbnodeRoot = category.getCategoryWithParentNull();
        PopulateNodes(tbnodeRoot, treePostCategory.Nodes);
    }
    private void PopulateNodes(DataTable tb, TreeNodeCollection node)
    {
        foreach (DataRow r in tb.Rows)
        {
            //int parentId = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
            TreeNode child = new TreeNode
            {
                Text = r["CategoryName"].ToString(),
                Value = r["CategoryID"].ToString()
            };
            int dec = (string.IsNullOrEmpty(r["childnodecount"].ToString())) ? 0 : (int)r["childnodecount"];
            child.PopulateOnDemand = (dec > 0);
            node.Add(child);
        }
    }
    private void PopulateSubLevel(int parentid, TreeNode parentNode)
    {
        category = new CategoryBLL();
        DataTable dtChild = category.getCategoryWithParent(parentid);
        PopulateNodes(dtChild, parentNode.ChildNodes);
    }
    protected void treePostCategory_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(int.Parse(e.Node.Value), e.Node);
    }

    protected void gwCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDelCategory") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Xóa có thể dẫn tới lỗi hệ thống. Bạn có chắc muốn xóa nữa không ? OK -> Bạn chịu trách nhiệm || Cancel -> coi như không có gì xảy ra !')");
            }
        }
        catch (Exception)
        {

        }
    }
    protected void gwCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        category = new CategoryBLL();
        post_category_relationships = new Post_Category_relationshipsBLL();
        int categoryID = Convert.ToInt32((gwCategory.Rows[e.RowIndex].FindControl("lblCategoryID") as Label).Text);
        bool ctrltion = this.post_category_relationships.DeleteWithCategoryID(categoryID);
        bool delCT = this.category.DeleteCategory(categoryID);
        if (!ctrltion || !delCT)
        {
            Response.Write("<script>alert('Xóa Danh mục thất bại. Lỗi kết nối csdl !')</script>");
        }
        else
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        //Response.Write("<script>alert('Tò te tí te. Bị dụ rồi. Đâu có xóa được. hehe !')</script>");
    }

    //==SEARCH==========================================================================================================
    private void GetCategorySearchPageWise(int pageIndex, string keysearch)
    {
        category = new CategoryBLL();
        int recordCount = 0;
        gwCategory.DataSource = category.GetCategorySearchPageWise(pageIndex, PageSize, keysearch);
        recordCount = category.CountSearchCategory(keysearch);
        gwCategory.DataBind();
        this.PopulateSearchPager(recordCount, pageIndex);
        //lbltotalAudio.Text = recordCount.ToString();
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
        rptSearchPage.DataSource = pages;
        rptSearchPage.DataBind();
    }
    protected void SearchPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetCategorySearchPageWise(pageIndex, txtsearchcategory.Text);
        rptPager.Visible = false;
        rptSearchPage.Visible = true;
    }
    protected void btnsearchCategory_ServerClick(object sender, EventArgs e)
    {
        rptPager.Visible = false;
        rptSearchPage.Visible = true;
        this.GetCategorySearchPageWise(1, txtsearchcategory.Text);
    }


    private void load_gwCategorySapxep(int Parent)
    {
        category = new CategoryBLL();
        gwCategorySapxep.DataSource = category.getTBCategoryWithParent(Parent);
        gwCategorySapxep.DataBind();
    }
    protected void dlDanhMucCha_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.load_gwCategorySapxep(Convert.ToInt32(dlDanhMucCha.SelectedValue));
    }
    [Serializable]
    class Number
    {
        int num;
        public Number(int num) // ham khoi tao
        {
            this.num = num;
        }
        public int getNum()     // ham tra ve gia tri num
        {
            return num;
        }
        public void setNum(int num) // ham set gia tri num
        {
            this.num = num;
        }
    }
    private void swap(Number a, Number b) // ham hoan vi
    {
        int temp = a.getNum();                  // gan num cua a cho temp
        a.setNum(b.getNum());                   // gan num cua b cho a
        b.setNum(temp);                         // gan temp cho num cua b
    }
    protected void lkbtnUp_Click(object sender, EventArgs e)
    {
        category = new CategoryBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int category_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;

        List<Category> lst = category.getCategoryWithID(category_id);
        Category ct = lst.FirstOrDefault();

        List<Category> lstUP = category.getCategoryWithIndex(category.MaxItemindexLK(ct.ItemIndex, Convert.ToInt32(dlDanhMucCha.SelectedValue)), Convert.ToInt32(dlDanhMucCha.SelectedValue)); //index B
        Category ct_Up = lstUP.FirstOrDefault();

        if (ct_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(ct.CategoryID);
            B = new Number(ct_Up.CategoryID);
            a = new Number(ct.ItemIndex);
            b = new Number(ct_Up.ItemIndex);
            this.swap(a, b);
            this.category.UpdateIndexItem(a.getNum(), A.getNum());
            this.category.UpdateIndexItem(b.getNum(), B.getNum());
            this.load_gwCategorySapxep(Convert.ToInt32(dlDanhMucCha.SelectedValue));
            gwCategorySapxep.SelectedIndex = -1;
        }
    }

    protected void lkbtnDown_Click(object sender, EventArgs e)
    {
        category = new CategoryBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int category_id = int.Parse(commandArgument);
        Number a, b;
        Number A, B;

        List<Category> lst = category.getCategoryWithID(category_id);
        Category ct = lst.FirstOrDefault();

        List<Category> lstUP = category.getCategoryWithIndex(category.MinItemindexLK(ct.ItemIndex, Convert.ToInt32(dlDanhMucCha.SelectedValue)), Convert.ToInt32(dlDanhMucCha.SelectedValue)); //index B
        Category ct_Up = lstUP.FirstOrDefault();

        if (ct_Up == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(ct.CategoryID);
            B = new Number(ct_Up.CategoryID);
            a = new Number(ct.ItemIndex);
            b = new Number(ct_Up.ItemIndex);
            this.swap(a, b);
            this.category.UpdateIndexItem(a.getNum(), A.getNum());
            this.category.UpdateIndexItem(b.getNum(), B.getNum());
            this.load_gwCategorySapxep(Convert.ToInt32(dlDanhMucCha.SelectedValue));
            gwCategorySapxep.SelectedIndex = -1;
        }
    }
}