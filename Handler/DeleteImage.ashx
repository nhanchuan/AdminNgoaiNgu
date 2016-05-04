<%@ WebHandler Language="C#" Class="DeleteImage" %>

using System;
using System.Web;

public class DeleteImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
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