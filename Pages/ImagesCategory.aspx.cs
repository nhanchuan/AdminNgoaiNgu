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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public partial class Pages_ImagesCategory : BasePage
{
    ImagesBLL images;
    ImagesTypeBLL imagestype;
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
                if (!check_permiss(ac.UserID, FunctionName.CategoryImages))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_gwImagesCategory();
                    btnsave.Visible = false;
                    btnfixImagesCT.Visible = false;
                    btnuploadImagse.Visible = false;
                }
            }
        }
    }
    private void load_gwImagesCategory()
    {
        imagestype = new ImagesTypeBLL();
        DataTable tb = imagestype.getTBListImagesCategory();
        gwImagesCategory.DataSource = tb;
        gwImagesCategory.DataBind();
    }
    protected void btnAddImgCategory_Click(object sender, EventArgs e)
    {
        imagestype = new ImagesTypeBLL();
        if(this.imagestype.NewImagesCategory(txtImgCategory.Text))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm Danh Mục thất bại. Lỗi kết nối CSDL !')</script>");
        }
    }



    protected void gwImagesCategory_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gwImagesCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This function is in the process of building!')</script>");
    }

    protected void gwImagesCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        imagestype = new ImagesTypeBLL();
        btnfixImagesCT.Visible = true;
        btnuploadImagse.Visible = true;
        btnsave.Visible = true;
        string ImgTypeID = (gwImagesCategory.SelectedRow.FindControl("lblImagesTypeID") as Label).Text;
        List<ImagesType> lst = imagestype.getImagesTypeWithID(Convert.ToInt32(ImgTypeID));
        ImagesType imt = lst.FirstOrDefault();
        txtEditImagesCategory.Text = imt.ImagesTypeName;
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        imagestype = new ImagesTypeBLL();
        if(gwImagesCategory.SelectedRow==null)
        {
            Response.Write("<script>alert('Chưa chọn danh mục hình !')</script>");
        }
        else
        {
            string ImgTypeID = (gwImagesCategory.SelectedRow.FindControl("lblImagesTypeID") as Label).Text;
            if (imagestype.Update(txtEditImagesCategory.Text,Convert.ToInt32(ImgTypeID)))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Chỉnh sửa Danh Mục thất bại. Lỗi kết nối CSDL !')</script>");
            }
        }
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
    protected void btnUploadImages_Click(object sender, EventArgs e)
    {
        //ImgEditPC.Src = txtuploadImgTemp.Text;
        UserAccounts ac = Session.GetCurrentUser();
        images = new ImagesBLL();
        imagestype = new ImagesTypeBLL();
        string ImgTypeID = (gwImagesCategory.SelectedRow.FindControl("lblImagesTypeID") as Label).Text;
        List<ImagesType> lstImgType = imagestype.getImagesTypeWithID(Convert.ToInt32(ImgTypeID));
        ImagesType imt = lstImgType.FirstOrDefault();

        string dateString = DateTime.Now.ToString("dd-MM-yyyy");
        string fileName = Path.GetFileName(fileUploadImg.PostedFile.FileName);
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        string fileExtension = "";
        try
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = "Anh-Van-Hoi-Anh-My-" + dateString + "-" + RandomName + fileExtension;
                //string pathToSave = Server.MapPath("../images/Upload/ImagesForCustomerProfile/") + str_image;

                string path = Server.MapPath("../images/Upload/" + RemoveSpecialCharacters(imt.ImagesTypeName) + "/");
                if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                {
                    Directory.CreateDirectory(path);
                }

                File.Delete(path + str_image); // DELETE THE FILE BEFORE CREATING A NEW ONE.
                
                //file.SaveAs(pathToSave);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fileUploadImg.FileContent);
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
                Bitmap bmp1 = new Bitmap(fileUploadImg.FileContent);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 10L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(path + str_image, jgpEncoder, myEncoderParameters);
                this.images.InsertImages(str_image, "images/Upload/" + RemoveSpecialCharacters(imt.ImagesTypeName) + "/" + str_image, Convert.ToInt32(ImgTypeID), ac.UserID);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Upload Image False !')</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            lblConfirm.Text = ex.Message.ToString();
            lblConfirm.Attributes.Add("style", "color:red; font: bold 14px/16px Sans-Serif,Arial");
        }
        
    }
}