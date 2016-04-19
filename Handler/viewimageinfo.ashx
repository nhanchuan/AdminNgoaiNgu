<%@ WebHandler Language="C#" Class="viewimageinfo" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;

public class viewimageinfo : IHttpHandler {
    ImagesBLL images;
    public void ProcessRequest (HttpContext context) {
        //int id = int.Parse(context.Request.QueryString["imggid"]);

        //images = new ImagesBLL();

        //List<Images> lst = images.getImagesWithId(id);
        //Images im = lst.FirstOrDefault();


        ////context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        context.Response.ContentType = "text/plain";
        string param = context.Request.Params["Name"];
        context.Response.Write("Hello, " + param);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}