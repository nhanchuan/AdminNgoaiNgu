<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeCategory.aspx.cs" Inherits="Demo_In_Project_TreeCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="treeboxCategory" OnTreeNodePopulate="treeboxCategory_TreeNodePopulate" runat="server" ShowExpandCollapse="true" PopulateNodesFromClient="true" ShowLines="true" ExpandDepth="2" ShowCheckBoxes="All"></asp:TreeView>
    </div>
    </form>
</body>
</html>
