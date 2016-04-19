<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrMyCalendar.ascx.cs" Inherits="Controls_ctrMyCalendar" %>
<%-- My Calendar --%>
<li>
    <a id="btnMycalendar" onclick="calendar_click()" runat="server">
        <i class="icon-calendar"></i><%=Resources.Resource.myCalendar %> </a>
</li>
<script>
    function calendar_click()
    {
        var url = "../CalendarEvent/CalendarEVENT.aspx";
        window.open(url, "myWindow", "width=1024, height=768,resizable=yes");
    }
</script>
<%-- End My Calendar --%>