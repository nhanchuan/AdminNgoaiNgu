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
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

public partial class Pages_Images_upload : BasePage
{
    UserAccounts useraccount;
    ImagesBLL images;
    ImagesTypeBLL imagestype;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!IsPostBack)
        {
            if (Session.GetCurrentUser() == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(Session.GetCurrentUser().UserID, FunctionName.NewImages))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    //do something
                    this.load_dlImagesCategory();
                }
            }
        }
    }
    private void load_dlImagesCategory()
    {
        imagestype = new ImagesTypeBLL();
        dlImagesCategory.DataSource = imagestype.getallImagesType();
        dlImagesCategory.DataTextField = "ImagesTypeName";
        dlImagesCategory.DataValueField = "ImagesTypeID";
        dlImagesCategory.DataBind();
        dlImagesCategory.Items.Insert(0, new ListItem("-- Chọn danh mục hình ảnh --", "0"));
    }
    public static string RemoveSpecialCharacters(string str)
    {
       System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (char c in str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        //ImgEditPC.Src = txtuploadImgTemp.Text;
        UserAccounts ac = Session.GetCurrentUser();
        images = new ImagesBLL();
        imagestype = new ImagesTypeBLL();
        int ImgTypeID = (string.IsNullOrEmpty(Session.GetCurrentImagesTypeID())) ? 3 : Convert.ToInt32(Session.GetCurrentImagesTypeID());
        List<ImagesType> lstImgType = imagestype.getImagesTypeWithID(ImgTypeID);
        ImagesType imt = lstImgType.FirstOrDefault();

        string dateString = DateTime.Now.ToString("dd-MM-yyyy");
        string fileName = Path.GetFileName(FileImgUpload.PostedFile.FileName);
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        string fileExtension = "";
        if (!string.IsNullOrEmpty(fileName))
        {
            fileExtension = Path.GetExtension(fileName);
            str_image = "Anh-Van-Hoi-Anh-My-" + dateString + "-" + RandomName + fileExtension;

            string path = Server.MapPath("../images/Upload/" + RemoveSpecialCharacters(imt.ImagesTypeName) + "/");
            if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(path);
            }

            File.Delete(path + str_image); // DELETE THE FILE BEFORE CREATING A NEW ONE.


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
            bmp1.Save(path + str_image, jgpEncoder, myEncoderParameters);
            this.images.InsertImages(str_image, "images/Upload/" + RemoveSpecialCharacters(imt.ImagesTypeName) + "/" + str_image, ImgTypeID, ac.UserID);
            
            Response.Redirect("http://" + Request.Url.Authority + "/Pages/ImagesManager.aspx");
        }
        else
        {
            Response.Write("<script>alert('Upload Image False !')</script>");
            return;
        }
    }

    protected void dlImagesCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        panelUpoadImages.Attributes.Add("style", "display:block;");
        Session.SetCurrentImagesTypeID(dlImagesCategory.SelectedValue);
    }
}