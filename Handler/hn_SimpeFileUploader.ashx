<%@ WebHandler Language="C#" Class="hn_SimpeFileUploader" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Web.SessionState;
using DAL;
using BLL;

public class hn_SimpeFileUploader : IHttpHandler, IReadOnlySessionState {
    ImagesBLL images;

    public void ProcessRequest (HttpContext context) {
        images = new ImagesBLL();
        UserAccounts ac = context.Session.GetCurrentUser();

        context.Response.ContentType = "text/plain";
        string dirFullPath = HttpContext.Current.Server.MapPath("../images/Upload/ImageGallery/");
        string[] files;
        int numFiles;
        files = System.IO.Directory.GetFiles(dirFullPath);
        numFiles = files.Length;
        numFiles = numFiles + 1;
        string str_image = "";
        string dateString = DateTime.Now.ToString("MM-dd-yyyy");
        ImageCodecInfo jgpEncoder = null;
        foreach (string s in context.Request.Files)
        {
            HttpPostedFile file = context.Request.Files[s];
            string fileName = file.FileName;
            string fileExtension = file.ContentType;
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = "Anh-Van-Hoi-Anh-My-" + dateString + "-" + RandomName + numFiles.ToString() + fileExtension;
                string pathToSave = HttpContext.Current.Server.MapPath("../images/Upload/ImageGallery/") + str_image;
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
                bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
                this.images.InsertImages(str_image, "images/Upload/ImageGallery/" + str_image, 3, ac.UserID);
            }
        }
        context.Response.Write(str_image);
    }
    public bool IsReusable {
        get {
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

}