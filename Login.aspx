<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../assets/global/plugins/jquery.min.js"></script>
    <link href="App_Themes/admin/login.css" rel="stylesheet" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <link href="../assets/global/css/components.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/layout/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="../assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div class="col-lg-4"></div>
        <div id="panelLogin" class="col-lg-4">
            <div style="text-align:center;">
                <img src="../images/logo/logo-kus-edu-vn-3.png" style="width:300px; height:200px; " />
                <h2><%=Resources.Resource.dashboardlogin %></h2>
            </div>
                <div id="panelinput" class="panel-default">
                    <div class="panel-body">
                        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="validLoginform" DisplayMode="BulletList" ForeColor="Red" Font-Bold="true" Font-Size="Medium" ShowMessageBox="false" ShowSummary="true" runat="server" />
                        <asp:Label ID="lblFalalseLogin" runat="server" Font-Size="Medium" Font-Bold="true" ForeColor="Red"></asp:Label>
                        <div class="form-group">
                            <label><span><%=Resources.Resource.username %></span></label>
                            <asp:TextBox ID="txtusername" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtusername" ValidationGroup="validLoginform" runat="server" ErrorMessage='<%$Resources:Resource, RequiredFieldUserName %>' Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtusername" Display="None" ValidationGroup="validLoginform" ValidationExpression="^[\sa-zA-Z0-9_-]{4,100}$" runat="server" ErrorMessage='<%$Resources:Resource, usernamelimit %>'></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label><span><%=Resources.Resource.password %></span></label>
                            <asp:TextBox ID="txtpasswords" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtpasswords" ValidationGroup="validLoginform" runat="server" ErrorMessage='<%$Resources:Resource, RequiredFieldPassword %>' Display="None"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtpasswords" Display="None" ValidationGroup="validLoginform" ValidationExpression="^[\sa-zA-Z0-9_-]{4,100}$" runat="server" ErrorMessage='<%$Resources:Resource, passwordlimit %>'></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="chkRememberMe" runat="server"  Text='<%$Resources:Resource, rememberme %>'/>
                        </div>
                        <div class="clearfix"></div>
                        <asp:Button ID="btnloginform" CssClass="btn btn-primary pull-right" ValidationGroup="validLoginform" OnClick="btnloginform_Click" runat="server" Text='<%$Resources:Resource, login %>' />
                    </div>
                </div>
        </div>
        <div class="col-lg-4"></div>
        <div id="linkSocial">
            <div class="col-lg-3"></div>
            <div class="col-lg-6">
                <div style="padding-top: 10px;">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-2 text-center">
                        <a href="https://www.facebook.com/pages/Du-H%E1%BB%8Dc-%C4%90%E1%BB%89nh-Cao-Ch%C3%A2u-M%E1%BB%B9/1473000939658905" class="btn btn-circle btn-primary">
                            <i class="fa fa-facebook"></i>
                        </a>
                    </div>
                    <div class="col-lg-2 text-center">
                        <a class="btn btn-circle btn-icon-only red">
                            <i class="fa fa-google-plus"></i>
                        </a>
                    </div>
                    <div class="col-lg-2 text-center">
                        <a class="btn btn-circle btn-icon-only blue">
                            <i class="fa fa-twitter"></i>
                        </a>
                    </div>
                    <div class="col-lg-2 text-center">
                        <a class="btn btn-circle btn-icon-only bg-danger">
                            <i class="fa fa-instagram"></i>
                        </a>
                    </div>
                </div>
            </div>
            <div class="col-lg-3"></div>
            <div class="dllLanguages" style="margin-top:10px; margin-right:0;">
                <div class="input-group">
                    <span class="input-group-addon">
                        <img src="../images/logo/English-Language-Flag-1-icon.png" width="20" height="20" />
                    </span>
                    <asp:DropDownList ID="ddlLanguages" CssClass="form-control input-small" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged" runat="server">
                        <asp:ListItem Value="en-US">English</asp:ListItem>
                        <asp:ListItem Value="vi-VN">Vietnamese</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </form>
    <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
