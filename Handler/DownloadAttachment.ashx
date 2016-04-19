<%@ WebHandler Language="C#" Class="DownloadAttachment" %>

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


public class DownloadAttachment : IHttpHandler {
    BagAttachmentsBLL bagattachment;
    ListOfMIMETypesBLL lstOfMMType;
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        int id = int.Parse(context.Request.QueryString["attachmentId"]);
        string contentType;
        string name;
        string extension;
        //video = new VideosBLL();
        // List<Videos> lstvi = video.getVideoWithId(id);
        //Videos vi = lstvi.FirstOrDefault();
        bagattachment = new BagAttachmentsBLL();
        lstOfMMType = new ListOfMIMETypesBLL();
        List<BagAttachments> lst = bagattachment.GetbagattWihAttId(id);
        BagAttachments bag = lst.FirstOrDefault();

        //contentType = vi.ContentType;
        extension = bag.AttachmentURL.Substring(bag.AttachmentURL.LastIndexOf("."));
        List<ListOfMIMETypes> lstOMT = lstOfMMType.getMIMETypeWithEx(extension);
        ListOfMIMETypes OMT = lstOMT.FirstOrDefault();
        contentType = OMT.MIMEType;

        name = bag.AttachmentName;
        string path = context.Server.MapPath("../" + bag.AttachmentURL);
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