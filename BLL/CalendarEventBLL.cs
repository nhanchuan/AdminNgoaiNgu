using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class CalendarEventBLL
    {
        DataServices DB = new DataServices();
        //public List<CalendarEvent> getEvents(int UserId, DateTime start, DateTime end)
        //{
        //    string sql = "select * from CalendarEvent where Event_start >= @start and Event_end <= @end and UserID=@UserId";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return null;
        //    }
        //    SqlParameter pUserId = new SqlParameter("UserId", UserId);
        //    SqlParameter pstart = new SqlParameter("start", start);
        //    SqlParameter pend = new SqlParameter("end", end);
        //    DataTable tb = DB.DAtable(sql, pUserId, pstart, pend);
        //    List<CalendarEvent> lst = new List<CalendarEvent>();
        //    foreach (DataRow r in tb.Rows)
        //    {
        //        CalendarEvent ce = new CalendarEvent();
        //        ce.EventID = (int)r[0];
        //        ce.CalTitle = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
        //        ce.CalDescription = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
        //        ce.Event_start = (DateTime)r[3];
        //        ce.Event_end = (DateTime)r[4];
        //        ce.UserID = (int)r[5];
        //        lst.Add(ce);
        //    }
        //    this.DB.CloseConnection();
        //    return lst;
        //}
        //public Boolean updateEvent(int UserId, int evenid, String title, String description)
        //{
        //    string sql = "Update CalendarEvent set CalTitle=@title, CalDescription=@description where EventID=@evenid and UserID=@UserId";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return false;
        //    }
        //    SqlParameter pUserId = new SqlParameter("UserId", UserId);
        //    SqlParameter pevenid = new SqlParameter("evenid", evenid);
        //    SqlParameter ptitle = new SqlParameter("title", title);
        //    SqlParameter pdescription = new SqlParameter("description", description);
        //    this.DB.Updatedata(sql, pUserId, pevenid, ptitle, pdescription);
        //    this.DB.CloseConnection();
        //    return true;
        //}
        //public Boolean updateEventTime(int UserId, int evenid, DateTime start, DateTime end)
        //{
        //    string sql = "UPDATE CalendarEvent SET Event_start=@start, Event_end=@end where EventID=@evenid and UserID=@UserId";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return false;
        //    }
        //    SqlParameter pUserId = new SqlParameter("UserId", UserId);
        //    SqlParameter pevenid = new SqlParameter("evenid", evenid);
        //    SqlParameter pstart = new SqlParameter("start", start);
        //    SqlParameter pend = new SqlParameter("end", end);
        //    this.DB.Updatedata(sql, pUserId, pevenid, pstart, pend);
        //    this.DB.CloseConnection();
        //    return true;
        //}
        //public Boolean deleteEvent(int UserId, int evenid)
        //{
        //    string sql = "Delete from CalendarEvent WHERE EventID=@evenid and UserID=@UserId";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return false;
        //    }
        //    SqlParameter pUserId = new SqlParameter("UserId", UserId);
        //    SqlParameter pevenid = new SqlParameter("evenid", evenid);
        //    this.DB.Updatedata(sql, pUserId, pevenid);
        //    this.DB.CloseConnection();
        //    return true;
        //}
        //public int addEvent(CalendarEvent cevent)
        //{
        //    int key = 0;
        //    string sql = "INSERT INTO CalendarEvent(CalTitle, CalDescription, Event_start, Event_end, UserID) VALUES(@title, @description, @start, @end, @UserId)";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return 0;
        //    }
        //    SqlParameter pUserId = new SqlParameter("UserId", cevent.UserID);
        //    SqlParameter ptitle = new SqlParameter("title", cevent.CalTitle);
        //    SqlParameter pdescription = new SqlParameter("description", cevent.CalDescription);
        //    SqlParameter pstart = new SqlParameter("start", cevent.Event_start);
        //    SqlParameter pend = new SqlParameter("end", cevent.Event_end);
        //    this.DB.Updatedata(sql, pUserId, ptitle, pdescription, pstart, pend);
        //    key = keyOfInsertedRow(cevent.UserID, cevent.CalTitle, cevent.CalDescription, cevent.Event_start, cevent.Event_end);
        //    return key;
        //}

        ////get primary key of inserted row
        //public int keyOfInsertedRow(int UserId, String title, String description, DateTime start, DateTime end)
        //{
        //    int key = 0;
        //    string sql = "SELECT max(EventID) FROM CalendarEvent where CalTitle=@title AND CalDescription=@description AND Event_start=@start AND Event_end=@end and UserID=@UserId";
        //    if (!this.DB.OpenConnection())
        //    {
        //        return 0;
        //    }
        //    SqlParameter pUserId = new SqlParameter("UserId", UserId);
        //    SqlParameter ptitle = new SqlParameter("title", title);
        //    SqlParameter pdescription = new SqlParameter("description", description);
        //    SqlParameter pstart = new SqlParameter("start", start);
        //    SqlParameter pend = new SqlParameter("end", end);
        //    key = this.DB.GetValues(sql, pUserId, ptitle, pdescription, pstart, pend);
        //    return key;
        //}
    }
}
