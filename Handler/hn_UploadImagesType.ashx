<%@ WebHandler Language="C#" Class="hn_UploadImagesType" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;

public class hn_UploadImagesType : IHttpHandler, IReadOnlySessionState
{
    ImagesBLL images;
    ImagesTypeBLL imagestype;
    public void ProcessRequest(HttpContext context)
    {
        images = new ImagesBLL();
        imagestype = new ImagesTypeBLL();
        UserAccounts ac = context.Session.GetCurrentUser();
        List<ImagesType> lstImgType = imagestype.getImagesTypeWithID(Convert.ToInt32(context.Session.GetCurrentImagesTypeID()));
        ImagesType imt = lstImgType.FirstOrDefault();

        context.Response.ContentType = "text/plain";
        //string dirFullPath = HttpContext.Current.Server.MapPath("../images/Upload/ImageGallery/");
        string dirFullPath = HttpContext.Current.Server.MapPath("../images/Upload/" + RemoveSpecialCharacters(imt.ImagesTypeName) + "/");
        if (!Directory.Exists(dirFullPath))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
        {
            Directory.CreateDirectory(dirFullPath);
        }

        string str_image = "";
        string dateString = DateTime.Now.ToString("dd-MM-yyyy");
        ImageCodecInfo jgpEncoder = null;
        foreach (string s in context.Request.Files)
        {
            HttpPostedFile file = context.Request.Files[s];
            string fileName = file.FileName;
            string fileExtension = file.ContentType;
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = "Anh-Van-Hoi-Anh-My-" + dateString + "-" + RandomName + fileExtension;
                File.Delete(dirFullPath + str_image); // DELETE THE FILE BEFORE CREATING A NEW ONE.

                //file.SaveAs(pathToSave);
                System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream);
                if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Tiff);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Gif);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Bmp);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Png);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Icon);
                else
                    throw new System.ArgumentException("Invalid File Type");
                Bitmap bmp1 = new Bitmap(file.InputStream);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(dirFullPath + str_image, jgpEncoder, myEncoderParameters);
                this.images.InsertImages(str_image, "images/Upload/" + RemoveSpecialCharacters(imt.ImagesTypeName) + "/" + str_image, Convert.ToInt32(context.Session.GetCurrentImagesTypeID()), ac.UserID);
            }
        }
        context.Response.Write(str_image);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private string RandomName
    {
        get
        {
            return new string(
                Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 6)
                    .Select(s =>
                    {
                        var cryptoResult = new byte[6];
                        new RNGCryptoServiceProvider().GetBytes(cryptoResult);
                        return s[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(s.Length)];
                    })
                    .ToArray());
        }
    }
    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
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
}