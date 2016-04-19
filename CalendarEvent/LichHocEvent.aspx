<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LichHocEvent.aspx.cs" Inherits="CalendarEvent_LichHocEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html" charset="utf-8"/>
    <link href="../css/cupertino/jquery-ui-1.7.3.custom.css" rel="stylesheet" />
    <link href="../fullcalendar/fullcalendar.css" rel="stylesheet" />

    <script src="../jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../jquery/jquery-ui-1.7.3.custom.min.js" type="text/javascript"></script>
    <script src="../jquery/jquery.qtip-1.0.0-rc3.min.js" type="text/javascript"></script>
    <script src="../fullcalendar/fullcalendar.min.js" type="text/javascript" charset="UTF-8"></script>
    <script src="../scripts/calendarLichHocScript.js" type="text/javascript" charset="UTF-8"></script>
    <script src="../jquery/jquery-ui-timepicker-addon-0.6.2.min.js" type="text/javascript"></script>
    <style type='text/css'>
        body
        {
            margin-top: 40px;
            text-align: center;
            font-size: 14px;
            font-family: "Lucida Grande" ,Helvetica,Arial,Verdana,sans-serif;
        }
        #calendar
        {
            width: 900px;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: -25px 0 10px 65px;
        }
        .style1
        {
            width: 100%;
        }
        
        /* table fields alignment*/
        .alignRight
        {
        	text-align:right;
        	padding-right:10px;
        	padding-bottom:10px;
        }
        .alignLeft
        {
        	text-align:left;
        	padding-bottom:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <h1>Lịch Học Tại Cơ Sở : <asp:Label ID="lblcoso" runat="server" Text="Label"></asp:Label></h1>
        <div id="calendar">
        </div>
        <div id="updatedialog" style="font: 80% 'Trebuchet MS', sans-serif; margin: 30px;"
            title="Xem Lịch Học">
            <table cellpadding="0" class="style1">
                <tr>
                    <td class="alignRight">Tiết học:</td>
                    <td class="alignLeft">
                        <input id="eventName" type="text" /><br />
                    </td>
                </tr>
                <tr>
                    <td class="alignRight">Mô tả:</td>
                    <td class="alignLeft">
                        <textarea id="eventDesc" cols="30" rows="3"></textarea></td>
                </tr>
                <tr>
                    <td class="alignRight">Giờ bắt đầu:</td>
                    <td class="alignLeft">
                        <strong>
                            <span id="eventStart"></span>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="alignRight">Giờ kết thúc: </td>
                    <td class="alignLeft">
                        <strong>
                            <span id="eventEnd"></span>
                        </strong>
                        <input type="hidden" id="eventId" />
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="jsonDiv" />
        <input type="hidden" id="hdClient" runat="server" />
    </form>
</body>
</html>
