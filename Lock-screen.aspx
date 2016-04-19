<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lock-screen.aspx.cs" Inherits="Lock_screen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lock Screen</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../assets/admin/pages/css/lock.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="../assets/global/css/components.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/layout/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="../assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-lock">
            <div class="page-logo">
                <a class="brand" href="Default.html">
                    <img src="../images/logo/hollywood.png" width="300" height="220" alt="logo" />
                </a>
            </div>

            <div class="page-body" style="margin-top:0px!important;">
                <div class="lock-head">
                    Locked Screen
                </div>
                <div class="lock-body">
                    <div class="pull-left lock-avatar-block">
                        <img src="../images/upload/adminLBAvatar/hinh-anh-avatar-danh-cho-fa.jpg" id="imgavatar" class="lock-avatar" runat="server" />
                    </div>
                    <div class="lock-form pull-left">
                        <h4><asp:Label ID="lblusername" runat="server" Text="Label"></asp:Label></h4>
                        
                        <div class="form-group">
                            <%--<input class="form-control placeholder-no-fix" type="password" autocomplete="off" placeholder="Password" name="password" />--%>
                            <asp:TextBox ID="txtpasswords" CssClass="form-control  placeholder-no-fix" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtpasswords" ValidationGroup="validLockScreen" runat="server" ErrorMessage='<%$Resources:Resource, RequiredFieldPassword %>' Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtpasswords" Display="None" ValidationGroup="validLockScreen" ValidationExpression="^[\sa-zA-Z0-9_-]{4,100}$" runat="server" ErrorMessage='<%$Resources:Resource, passwordlimit %>'></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-actions">
                            <%--<button type="submit" class="btn btn-success uppercase">Login</button>--%>
                            <asp:Button ID="btnloginform" CssClass="btn btn-success uppercase" ValidationGroup="validLockScreen" OnClick="btnloginform_Click" runat="server" Text='<%$Resources:Resource, login %>' />
                        </div>
                    </div>
                </div>
                <div class="lock-bottom">
                    <a href="#" id="btnNotUser" onserverclick="btnNotUser_ServerClick" runat="server">Not <asp:Label ID="lblisUserName" runat="server"></asp:Label>?</a>
                </div>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="validLockScreen" DisplayMode="BulletList" ForeColor="Red" Font-Bold="true" Font-Size="Medium" ShowMessageBox="false" ShowSummary="true" runat="server" />
                        <asp:Label ID="lblFalalseLogin" runat="server" Font-Size="Medium" Font-Bold="true" ForeColor="Red"></asp:Label>
            <div class="page-footer-custom">
                2015 &copy; Hollywood English. Admin Dashboard Template.
            </div>
        </div>
    </form>

    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
    <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <script src="../assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="../assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
    <script>
        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
</html>
