<%@ WebHandler Language="C#" Class="ReaderVideo" %>

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

public class ReaderVideo : IHttpHandler {
    VideosBLL video;
    public void ProcessRequest (HttpContext context) {
        int vid = int.Parse(context.Request.QueryString["videoId"]);
        byte[] bytes;
        string contentType;
        string name;

        video = new VideosBLL();
        List<Videos> lstV = video.getVideoWithId(vid);
        Videos vi = lstV.FirstOrDefault();

        contentType = vi.ContentType;
        name = vi.VideoName;

        string path = context.Server.MapPath("../" + vi.VideoUrl);
        FileInfo file = new FileInfo(path);

        Stream inputstream = File.OpenRead(path);
        BufferedStream buf = new BufferedStream(inputstream);
        BinaryReader br = new BinaryReader(buf);
        bytes = br.ReadBytes((int)buf.Length);
        context.Response.Clear();
        context.Response.Buffer = true;
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
        context.Response.ContentType = contentType;
        context.Response.BinaryWrite(bytes);
        context.Response.End();

        inputstream.Close();
        buf.Close();
        //fs.Close();
        br.Close();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}