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
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography;

public partial class Pages_Post_New : BasePage
{
    CategoryBLL category;
    Post_Category_relationshipsBLL postCtRelationship;
    TagsBLL tags;
    Tags_relationshipsBLL tagsrelationship;
    ImagesBLL images;
    ImagesTypeBLL imagestype;
    PostBLL posts;
   
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
                if (!check_permiss(admin.UserID, FunctionName.PostManager))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.PopulateRootLevel();
                    this.load_cbltags();
                    this.load_rpLstImg(admin.UserID);
                    lblExeption.Visible = false;
                }
            }
        }
    }
    private void PopulateRootLevel()
    {
        category = new CategoryBLL();
        DataTable tbnodeRoot = category.getCategoryWithParentNull();
        PopulateNodes(tbnodeRoot, treeboxCategory.Nodes);
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
    protected void treeboxCategory_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(int.Parse(e.Node.Value), e.Node);
    }
    protected void load_cbltags()
    {
        tags = new TagsBLL();
        cbltags.DataSource = tags.getAllTagsTagsNameASC();
        cbltags.DataTextField = "TagsName";
        cbltags.DataValueField = "TagsID";
        cbltags.DataBind();
    }
    protected void btninsertfastPC_Click(object sender, EventArgs e)
    {
        category = new CategoryBLL();
        if (this.category.QuickInserCategory(txtCategoryname.Text, txtCategoryDecs.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('New Post Category False !')</script>");
            return;
        }
    }
    protected Boolean checktagsname(string name)
    {
        tags = new TagsBLL();
        List<Tags> lst = tags.getTagsWithName(name);
        Tags tg = lst.FirstOrDefault();
        if (tg != null)
        {
            return false;
        }
        return true;
    }
    protected void btnAddTags_ServerClick(object sender, EventArgs e)
    {
        tags = new TagsBLL();
        if (checktagsname(txttagsname.Text) == false)
        {
            return;
        }
        else
        {
            this.tags.newTagsName(txttagsname.Text);
            this.load_cbltags();
        }
        cbltags.Items.FindByText(txttagsname.Text).Selected = true;
        string script = "window.onload = function() { calltagspanelClickEvent(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "calltagspanelClickEvent", script, true);
    }
    protected void txttagsname_TextChanged(object sender, EventArgs e)
    {
        if (checktagsname(txttagsname.Text) == false)
        {
            lbltagsExsit.Text = "Tags đã tồn tại !";
        }
        else
        {
            lbltagsExsit.Text = "";
        }
    }
    protected void btnuploadImg_ServerClick(object sender, EventArgs e)
    {
        //ImgEditPC.Src = txtuploadImgTemp.Text;
        try {
            UserAccounts ac = Session.GetCurrentUser();

            images = new ImagesBLL();
            string dateString = DateTime.Now.ToString("MM-dd-yyyy");
            string fileName = Path.GetFileName(fileUploadImgPost.PostedFile.FileName);
            ImageCodecInfo jgpEncoder = null;
            string str_image = "";
            string fileExtension = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = "Hollywood-" + dateString + "-" + RandomName + fileExtension;
                string pathToSave = Server.MapPath("../images/Upload/ImagesForPost/") + str_image;
                //file.SaveAs(pathToSave);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fileUploadImgPost.FileContent);
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
                Bitmap bmp1 = new Bitmap(fileUploadImgPost.FileContent);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
                this.images.InsertImages(str_image, "images/Upload/ImagesForPost/" + str_image, 5, ac.UserID);
                txtPostImgTemp.Text = "images/Upload/ImagesForPost/" + str_image;
                imgpost.Src = "../images/Upload/ImagesForPost/" + str_image;
            }
            else
            {
                Response.Write("<script>alert('Upload Image False !')</script>");
                return;
            }
            string script = "window.onload = function() { callImagesPanelClickEvent(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "callImagesPanelClickEvent", script, true);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + " !')</script>");
        }
    }
    protected void load_rpLstImg(int UserUpload)
    {
        images = new ImagesBLL();
        rpLstImg.DataSource = images.getImagesWithType(5);
        rpLstImg.DataBind();
    }
    protected void btnchangeImgPost_Click(object sender, EventArgs e)
    {
        string http = "http://" + Request.Url.Authority + "/";
        txtPostImgTemp.Text = HiddenimgSelect.Value.Remove(0, http.Length);
        imgpost.Src = "../" + HiddenimgSelect.Value.Remove(0, http.Length);
        string script = "window.onload = function() { callImagesPanelClickEvent(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callImagesPanelClickEvent", script, true);
    }
    protected void btnUpdateTimePost_Click(object sender, EventArgs e)
    {
        string time = timePost.Value.ToString();
        lblTimePost.Text = time;
    }
    private string getday(string str)
    {
        string day = str.Substring(0, 2);
        return day;
    }
    private string getmonth(string str)
    {
        string month = "";
        List<clsmonth> lstmonth = new List<clsmonth>();
        lstmonth.Add(new clsmonth("01", "January"));
        lstmonth.Add(new clsmonth("02", "February"));
        lstmonth.Add(new clsmonth("03", "March"));
        lstmonth.Add(new clsmonth("04", "April"));
        lstmonth.Add(new clsmonth("05", "May"));
        lstmonth.Add(new clsmonth("06", "June"));
        lstmonth.Add(new clsmonth("07", "July"));
        lstmonth.Add(new clsmonth("08", "August"));
        lstmonth.Add(new clsmonth("09", "September"));
        lstmonth.Add(new clsmonth("10", "October"));
        lstmonth.Add(new clsmonth("11", "November"));
        lstmonth.Add(new clsmonth("12", "December"));
        foreach (clsmonth itm in lstmonth)
        {
            if (str.Contains(itm.Strmonth))
            {
                month = itm.Num;
            }
        }
        return month;
    }
    [Serializable()]
    public class clsmonth
    {
        public string Num { get; set; }
        public string Strmonth { get; set; }
        public clsmonth(string num, string strmonth)
        {
            Num = num;
            Strmonth = strmonth;
        }
    }   
    private string getyear(string str)
    {
        string year = str.Substring(str.IndexOf("-") - 5, 4);
        return year;
    }
    private string gethours(string str)
    {
        string hours = str.Substring(str.IndexOf(":") - 2, 2);
        return hours;
    }
    private string getminutes(string str)
    {
        string minutes = str.Substring(str.IndexOf(":") + 1, 2);
        return minutes;
    }
    private string gettimeRefix(string str)
    {
        string re = str.Substring(str.Length - 2, 2);
        return re;
    }
    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    protected void btnChangepost_status_ServerClick(object sender, EventArgs e)
    {
        lblpost_status.Text = dlpost_status.SelectedItem.ToString();
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
            ImID = images.ImagesID(filename);
        }
        return ImID;
    }
    protected Boolean NewPost(string postcode)
    {
        bool newpost;
        posts = new PostBLL();
        UserAccounts ac = Session.GetCurrentUser();
        string contentVN = EditorPostContentVN.Text;
        string contentEN = EditorPostContentEN.Text;
        if (ImagesID(txtPostImgTemp.Text) == 0)
            newpost = this.posts.NewPostWithoutImg(txtPostTitle.Value, txtMetaKeywords.Text, txtMetaDescription.Text, contentVN, contentEN, ac.UserID, 2, postcode);
        else newpost = this.posts.NewPost(txtPostTitle.Value, txtMetaKeywords.Text, txtMetaDescription.Text, contentVN, contentEN, ac.UserID, 2, ImagesID(txtPostImgTemp.Text), postcode);
        return newpost;
    }
    protected Boolean NewPostWithModified(string postcode, DateTime mod)
    {
        bool newpost;
        posts = new PostBLL();
        UserAccounts ac = Session.GetCurrentUser();
        string contentVN = EditorPostContentVN.Text;
        string contentEN = EditorPostContentEN.Text;
        //string modified = getmonth(time) + "/" + getday(time) + "/" + getyear(time) + " " + gethours(time) + ":" + getminutes(time) + ":00"+" "+gettimeRefix(time);
        if (ImagesID(txtPostImgTemp.Text) == 0)
            newpost = this.posts.NewPostWithPostModifiedWithoutImg(txtPostTitle.Value, txtMetaKeywords.Text, txtMetaDescription.Text, contentVN, contentEN, mod, ac.UserID, 2, postcode);
        else newpost = this.posts.NewPostWithPostModified(txtPostTitle.Value, txtMetaKeywords.Text, txtMetaDescription.Text, contentVN, contentEN, mod, ac.UserID, 2, ImagesID(txtPostImgTemp.Text), postcode);
        return newpost;
    }
    protected class CategoryPost : IEquatable<CategoryPost>, IComparable<CategoryPost>
    {
        public int id { get; set; }
        public string name { get; set; }

        public int CompareTo(CategoryPost other)
        {
            if (other == null)
                return 1;

            else
                return this.id.CompareTo(other.id);
        }

        public bool Equals(CategoryPost other)
        {
            if (other == null) return false;
            CategoryPost objAsPost = other as CategoryPost;
            if (objAsPost == null) return false;
            else return Equals(objAsPost);
        }
    }
    protected class TagsPost : IEquatable<TagsPost>, IComparable<TagsPost>
    {
        public int id { get; set; }
        public string name { get; set; }

        public int CompareTo(TagsPost other)
        {
            if (other == null)
                return 1;

            else
                return this.id.CompareTo(other.id);
        }

        public bool Equals(TagsPost other)
        {
            if (other == null) return false;
            TagsPost objAsPost = other as TagsPost;
            if (objAsPost == null) return false;
            else return Equals(objAsPost);
        }
    }
    protected void New_Post_Category_relationships(string postcode)
    {
        posts = new PostBLL();
        postCtRelationship = new Post_Category_relationshipsBLL();
        int postid = posts.PostIdWithPostCode(postcode);
        List<CategoryPost> cp = new List<CategoryPost>();
        foreach (TreeNode n in treeboxCategory.CheckedNodes)
        {
            // arr.Add(n.Value);
            cp.Add(new CategoryPost() { id = int.Parse(n.Value), name = n.Text });
        }
        List<CategoryPost> newl = cp.OrderBy(r => r.id).ToList();
        foreach (CategoryPost itm in newl)
        {
            this.postCtRelationship.New_Post_Category_relationships(postid, itm.id);
        }
    }
    protected void New_Tags_relationships(string postcode)
    {
        posts = new PostBLL();
        tagsrelationship = new Tags_relationshipsBLL();
        int postid = posts.PostIdWithPostCode(postcode);
        List<TagsPost> lstp = new List<TagsPost>();
        foreach (ListItem itm in cbltags.Items)
        {
            if (itm.Selected) lstp.Add(new TagsPost() { id = int.Parse(itm.Value), name = itm.Text });
        }
        List<TagsPost> newlt = lstp.OrderBy(r => r.id).ToList();
        foreach (TagsPost tp in newlt)
        {
            this.tagsrelationship.New_Tags_relationships(postid, tp.id);
        }
    }
    protected void btnPostNew_Click(object sender, EventArgs e)
    {
        posts = new PostBLL();
        string contentVN = EditorPostContentVN.Text;
        string contentEN = EditorPostContentEN.Text;
        string dateString = DateTime.Now.ToString("MM-dd-yyyy");
        string postcode = RandomName + "-" + dateString;
        int timepost = (timePost.Value == "") ? 1 : 2;
        try
        {
            switch (timepost)
            {
                case 1:
                    if (NewPost(postcode))
                    {
                        this.New_Post_Category_relationships(postcode);
                        this.New_Tags_relationships(postcode);
                        Response.Redirect("http://" + Request.Url.Authority + "/Pages/Post-Update.aspx?PostCode=" + posts.PostIdWithPostCode(postcode));
                    }
                    else
                    {
                        return;
                    }
                    break;
                case 2:
                    string time = timePost.Value.ToString();
                    DateTime modified;
                    try
                    {
                        modified = Convert.ToDateTime(getmonth(time) + "/" + getday(time) + "/" + getyear(time) + " " + gethours(time) + ":" + getminutes(time) + ":00" + " " + gettimeRefix(time));
                        if (NewPostWithModified(postcode, modified))
                        {
                            this.New_Post_Category_relationships(postcode);
                            this.New_Tags_relationships(postcode);
                            Response.Redirect("http://" + Request.Url.Authority + "/Pages/Post-Update.aspx?PostCode=" + posts.PostIdWithPostCode(postcode));
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblTimePost.Attributes.Add("style", "color:red;");
                        lblTimePost.Text = "Fales to Datetime format !";
                        string script = "window.onload = function() { calldropdownTimepostClickEvent(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "calldropdownTimepostClickEvent", script, true);
                        timePost.Value = "";
                        timePost.Focus();
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            lblExeption.Text = ex.ToString();
        }
        

    }
    
}