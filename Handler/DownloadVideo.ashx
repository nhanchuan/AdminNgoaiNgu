<%@ WebHandler Language="C#" Class="DownloadVideo" %>

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

public class DownloadVideo : IHttpHandler {
    VideosBLL video;
    public void ProcessRequest (HttpContext context) {
        int id = int.Parse(context.Request.QueryString["videoId"]);
        string contentType;
        string name;
        video = new VideosBLL();
        List<Videos> lstvi = video.getVideoWithId(id);
        Videos vi = lstvi.FirstOrDefault();
        contentType = vi.ContentType;
        name = vi.VideoUrl.Substring(vi.VideoUrl.LastIndexOf("/")+1);
        string path = context.Server.MapPath("../" + vi.VideoUrl);
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