<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_data_to_Excel.aspx.cs" Inherits="Demo_In_Project_Export_data_to_Excel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <!-- BUTTON CONTROL TO EXPORT DATA TO EXCEL. -->
            <p><input type="button" onserverclick="ExportToExcel" 
                value="Export data to Excel" runat="server" /></p>

            <!-- SHOW MESSAGE. -->
            <p><asp:Label ID="lblConfirm" Text="" runat="server"></asp:Label></p>

            <div>
                <!-- VIEW BUTTON WILL OPEN THE EXCEL FILE FOR VIEWING. -->
                <div style="float:left;padding-right:10px;">
                    <input type="button" onserverclick="ViewData" 
                        id="btView" value="View Data" runat="server" 
                        style="display:none;" />
                </div>

                <!--DOWNLOAD EXCEL FILE. -->
                <div style="float:left;">
                    <asp:Button ID="btDownLoadFile" Text="Download" 
                        OnClick="DownLoadFile" runat="server" style="display:none;" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
