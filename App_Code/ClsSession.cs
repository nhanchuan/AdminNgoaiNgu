using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DAL;

/// <summary>
/// Summary description for ClsSession
/// </summary>
public static class ClsSession
{
    public static void SetCurrentUser(this HttpSessionState session, UserAccounts user)
    {
        session["currentUser"] = user;
    }
    public static UserAccounts GetCurrentUser(this HttpSessionState session)
    {
        return session["currentUser"] as UserAccounts;
    }
    //session URL
    public static void SetCurrentURL(this HttpSessionState session, string url)
    {
        session["currentURL"] = url;
    }
    public static string GetCurrentURL(this HttpSessionState session)
    {
        return session["currentURL"] as String;
    }
    //session Languages
    public static void SetCurrentLang(this HttpSessionState session, string lang)
    {
        session["currentLang"] = lang;
    }
    public static string GetCurrentLang(this HttpSessionState session)
    {
        return session["currentLang"] as String;
    }

    //session Lock Green
    public static void SetLockGreen(this HttpSessionState session, UserAccounts user)
    {
        session["lockgreenstatus"] = user;
    }
    public static UserAccounts GetLockGreen(this HttpSessionState session)
    {
        return session["lockgreenstatus"] as UserAccounts;
    }
    //session CoSoID
    public static void SetCurrentCoSoID(this HttpSessionState session, string cosoid)
    {
        session["currentCSID"] = cosoid;
    }
    public static string GetCurrentCoSoID(this HttpSessionState session)
    {
        return session["currentCSID"] as String;
    }
    //session Giao vien Trung Tam ID
    public static void SetCurrentGVTT(this HttpSessionState session, string gvid)
    {
        session["currentGVTT"] = gvid;
    }
    public static string GetCurrentGVTT(this HttpSessionState session)
    {
        return session["currentGVTT"] as String;
    }
    //session Giao vien Hop Dong ID
    public static void SetCurrentGVHD(this HttpSessionState session, string gvid)
    {
        session["currentGVHD"] = gvid;
    }
    public static string GetCurrentGvHD(this HttpSessionState session)
    {
        return session["currentGVHD"] as String;
    }
    //session ImagesType
    public static void SetCurrentImagesTypeID(this HttpSessionState session, string ImagesTypeID)
    {
        session["currentImagesTypeID"] = ImagesTypeID;
    }
    public static string GetCurrentImagesTypeID(this HttpSessionState session)
    {
        return session["currentImagesTypeID"] as String;
    }
    
}