<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateSHAHash.aspx.cs" Inherits="Demo_In_Project_CreateSHAHash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtinput" runat="server"></asp:TextBox>
        <asp:Button ID="btnCreateSHAHash" OnClick="btnCreateSHAHash_Click" runat="server" Text="Create" />
        <asp:TextBox ID="txtoutput" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
