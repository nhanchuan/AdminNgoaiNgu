<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormTest.aspx.cs" Inherits="Demo_In_Project_FormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label>permistion</label>
        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
