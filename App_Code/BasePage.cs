using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    SecuriryServices services;
    
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void setcurenturl()
    {
        string url = "";
        url = Request.Url.AbsoluteUri;
        Session.SetCurrentURL(url);
    }
    protected override void InitializeCulture()
    {
        string language = "en-US";
        //Detect User's Language.
        if (Request.UserLanguages != null)
        {
            //Set the Language.
            language = Request.UserLanguages[0];
        }
        //Check if PostBack is caused by Language DropDownList.
        string sesionlang = Session.GetCurrentLang();
        if (sesionlang != null)
        {
            //Set the Language.
            language = sesionlang;
        }
        //Set the Culture.
        //Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        base.InitializeCulture();
    }
    //value Salt pasword
    protected string SaltPassword()
    {
        return "AS@2d23";
    }
    protected string RandomName
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
    public bool IsNumber(string pText)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        return regex.IsMatch(pText);
    }
    protected ImageCodecInfo GetEncoder(ImageFormat format)
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
    
    public bool check_permiss(int uid, string FCode)
    {
        services = new SecuriryServices();
        bool checkp = services.Check_PermissionFunct(uid, FCode);
        return checkp;
    }
    // LOAD DROPDOWNLIST()
    public void load_DropdownList(DropDownList dl, Object obj, string textfield, string valuefield)
    {
        dl.DataSource = obj;
        dl.DataTextField = textfield;
        dl.DataValueField = valuefield;
        dl.DataBind();
    }
}