<%@ WebHandler Language="C#" Class="DownloadFileTrans" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using DAL;
using BLL;

public class DownloadFileTrans : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        BagFileTranslateBLL bagfiletrans;
        ListOfMIMETypesBLL lstOfMMType;
        int id = int.Parse(context.Request.QueryString["TranslateId"]);
        string contentType;
        string name;
        string extension;
        //video = new VideosBLL();
        // List<Videos> lstvi = video.getVideoWithId(id);
        //Videos vi = lstvi.FirstOrDefault();
        bagfiletrans = new BagFileTranslateBLL();
        lstOfMMType = new ListOfMIMETypesBLL();
        List<BagFileTranslate> lst = bagfiletrans.GetBagFileTranslateId(id);
        BagFileTranslate bag = lst.FirstOrDefault();

        //contentType = vi.ContentType;
        extension = bag.FileTranslateURL.Substring(bag.FileTranslateURL.LastIndexOf("."));
        List<ListOfMIMETypes> lstOMT = lstOfMMType.getMIMETypeWithEx(extension);
        ListOfMIMETypes OMT = lstOMT.FirstOrDefault();
        contentType = OMT.MIMEType;
        
        string path = context.Server.MapPath("../" + bag.FileTranslateURL);
        FileInfo file = new FileInfo(path);
        try
        {
            context.Response.Clear();
            context.Response.ContentType = contentType;
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(path));
            context.Response.AddHeader("Content-Length", file.Length.ToString());
            context.Response.TransmitFile(path);
            context.Response.Flush();
            context.Response.End();
        }

        catch (Exception e)
        {
            context.Response.Write(e);
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}