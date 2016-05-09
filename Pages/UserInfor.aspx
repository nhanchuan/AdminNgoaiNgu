<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="UserInfor.aspx.cs" Inherits="Pages_UserInfor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../assets/admin/pages/css/profile-old.css" rel="stylesheet" />
    <style type="text/css">
        .VeryPoorStrength {
            background: Red;
            color: White;
            font-weight: bold;
        }

        .WeakStrength {
            background: Gray;
            color: White;
            font-weight: bold;
        }

        .AverageStrength {
            background: orange;
            color: black;
            font-weight: bold;
        }

        .GoodStrength {
            background: blue;
            color: White;
            font-weight: bold;
        }

        .ExcellentStrength {
            background: Green;
            color: White;
            font-weight: bold;
        }

        .BarBorder {
            border-style: solid;
            border-width: 1px;
            width: 180px;
            padding: 2px;
        }
    </style>
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông tin Thành Viên
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Users.aspx">Users Manager</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/UserInfor.aspx">User Info</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row profile">
        <div class="col-md-12">
            <!--BEGIN TABS-->
            <div class="tabbable tabbable-custom tabbable-full-width">
                <ul class="nav nav-tabs">
                    <li class="active">
                        <a href="#tab_1_1" data-toggle="tab">Overview </a>
                    </li>
                    <li>
                        <a href="#tab_1_3" data-toggle="tab">Account </a>
                    </li>
                    <%--<li>
                        <a href="#tab_1_4" data-toggle="tab">Projects </a>
                    </li>
                    <li>
                        <a href="#tab_1_6" data-toggle="tab">Help </a>
                    </li>--%>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="tab_1_1">
                        <div class="row">
                            <div class="col-md-3">
                                <ul class="list-unstyled profile-nav">
                                    <li>
                                        <img src="../images/default_images.jpg" class="img-responsive" id="imgUserAvatar" runat="server" alt="" />
                                        <a href="#" class="profile-edit">
                                            <i class="fa fa-edit"></i></a>
                                    </li>
                                    <%--<li>
                                        <a href="#">Projects </a>
                                    </li>
                                    <li>
                                        <a href="#">Messages <span>3 </span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">Friends </a>
                                    </li>
                                    <li>
                                        <a href="#">Settings </a>
                                    </li>--%>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <div class="row">
                                    <div class="col-md-12 profile-info">
                                        <h1>
                                            <asp:Label ID="lblUserFullName" runat="server" Text="Label"></asp:Label>
                                        </h1>
                                        <asp:Label ID="lbladminlevel" CssClass="control-label label-default" Text="Administrator" runat="server"></asp:Label>
                                        <p>
                                            <asp:Label ID="lblabout" runat="server" Text="Label"></asp:Label>
                                        </p>
                                        <p>
                                            <i class="fa fa-globe" style="color: dodgerblue;"></i>
                                            <a href="#">
                                                <asp:Label ID="lblmywebsite" runat="server" Text="Label"></asp:Label>
                                            </a>
                                        </p>
                                        <ul class="list-inline">
                                            <li>
                                                <i class="fa fa-map-marker"></i>
                                                <asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label>
                                            </li>
                                            <li>
                                                <i class="fa fa-calendar"></i>
                                                <asp:Label ID="lblBirthday" runat="server" Text="Label"></asp:Label>
                                            </li>
                                            <li>
                                                <i class="fa fa-briefcase"></i>
                                                <asp:Label ID="lblOccupation" runat="server" Text="Label"></asp:Label>
                                            </li>
                                            <li>
                                                <i class="fa fa-star"></i>Top Seller
                                            </li>
                                            <li>
                                                <i class="fa fa-heart"></i>BASE Jumping
                                            </li>
                                        </ul>
                                    </div>
                                    <!--end col-md-8-->
                                    <%-- Col Sales Summary --%>
                                    <%--<div class="col-md-4">
                                        <div class="portlet sale-summary">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    Sales Summary
                                                </div>
                                                <div class="tools">
                                                    <a class="reload" href="javascript:;"></a>
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <ul class="list-unstyled">
                                                    <li>
                                                        <span class="sale-info">TODAY SOLD <i class="fa fa-img-up"></i>
                                                        </span>
                                                        <span class="sale-num">23 </span>
                                                    </li>
                                                    <li>
                                                        <span class="sale-info">WEEKLY SALES <i class="fa fa-img-down"></i>
                                                        </span>
                                                        <span class="sale-num">87 </span>
                                                    </li>
                                                    <li>
                                                        <span class="sale-info">TOTAL SOLD </span>
                                                        <span class="sale-num">2377 </span>
                                                    </li>
                                                    <li>
                                                        <span class="sale-info">EARNS </span>
                                                        <span class="sale-num">$37.990 </span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>--%>
                                    <%-- End col Sales Summary --%>
                                    <!--end col-md-4-->
                                </div>
                                <!--end row-->
                               
                                <asp:GridView ID="gwPermisstion" runat="server" CssClass="table table-bordered"
                                    AutoGenerateColumns="false" OnSelectedIndexChanged="gwPermisstion_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Permission for Authentication">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPermissFuncID" CssClass="display-none" runat="server" Text='<%# Eval("PermissFuncID") %>'></asp:Label>
                                                <asp:Label ID="lblFunctionName" runat="server" Text='<%# Eval("FunctionName") %>'></asp:Label>
                                                <asp:Label ID="lblPermisstionNumber" CssClass="display-none" runat="server" Text='<%# Eval("PermisstionNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <%--<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                                    <RowStyle BackColor="#A1DCF2"></RowStyle>--%>
                                    <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                </asp:GridView>
                                        <!--end profile-settings-->
                                <div class="margin-top-10">
                                    <a href="#modalChangePermission" id="btnchangespermisswion" data-toggle="modal" class="btn green" runat="server"><i class="fa fa-cogs"></i>Permission Setting </a>
                                    <%--<a href="#" class="btn default">Cancel </a>--%>
                                </div>
                                    
                            </div>
                        </div>
                    </div>
                    <!--tab_1_2-->
                    <div class="tab-pane" id="tab_1_3">
                        <div class="row profile-account">
                            <div class="col-md-3">
                                <ul class="ver-inline-menu tabbable margin-bottom-10">
                                    <li class="active">
                                        <a data-toggle="tab" href="#tab_1-1">
                                            <i class="fa fa-cog"></i>Personal info </a>
                                        <span class="after"></span>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_2-2">
                                            <i class="fa fa-picture-o"></i>Change Avatar </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_3-3">
                                            <i class="fa fa-envelope"></i>Change Email Register</a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_3-4">
                                            <i class="fa fa-lock"></i>Change Password </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_4-5">
                                            <i class="fa fa-eye"></i>Privacity Settings </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <div class="tab-content">
                                    <div id="tab_1-1" class="tab-pane active">
                                        <div class="form-group">
                                            <label class="control-label">First Name</label>
                                            <asp:TextBox ID="txtfirtname" CssClass="form-control" ToolTip="Edit first name" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtfirtname" Display="None" ValidationGroup="validPersonalinfo" ValidationExpression="(.){1,200}" runat="server" ErrorMessage="<%$Resources:Resource, firstnamelimit %>" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Last Name</label>
                                            <asp:TextBox ID="txtlastname" CssClass="form-control" ToolTip="Edit last name" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtlastname" Display="None" ValidationGroup="validPersonalinfo" ValidationExpression="(.){1,200}" runat="server" ErrorMessage="<%$Resources:Resource, lastnamelimit %>" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Birthday</label>
                                            <asp:TextBox ID="txtBirthday" CssClass="form-control input-xlarge" runat="server"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBirthday" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Giới tính</label>
                                            <div class="radio-list">
                                                <label class="radio-inline">
                                                    <input type="radio" name="optionsRadios" id="rdnam" value="option1" runat="server" />
                                                    Nam
                                                </label>
                                                <label class="radio-inline">
                                                    <input type="radio" name="optionsRadios" id="rdnu" value="option2" runat="server" />
                                                    Nữ
                                                </label>
                                            </div>
                                        </div>

                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <label class="control-label">Quốc Gia</label>
                                                    <asp:DropDownList ID="dlCountry" CssClass="form-control input-xlarge" AutoPostBack="true" OnSelectedIndexChanged="dlCountry_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label">Tỉnh Thành</label>
                                                    <asp:DropDownList ID="dlProvices" CssClass="form-control input-xlarge" AutoPostBack="true" OnSelectedIndexChanged="dlProvices_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label">Quận / Huyện</label>
                                                    <asp:DropDownList ID="dlDistrict" CssClass="form-control input-xlarge" runat="server"></asp:DropDownList>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <div class="form-group">
                                            <label class="control-label">Địa chỉ Nhà</label>
                                            <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Mobile Number</label>
                                            <asp:TextBox ID="txtphone" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                ControlToValidate="txtphone"
                                                ValidationGroup="validPersonalinfo"
                                                ValidationExpression="\(?([0-9]{3,4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"
                                                ErrorMessage="<%$Resources:Resource, incorectphonenumber %>"
                                                ForeColor="Red"
                                                Display="Dynamic">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Interests</label>
                                            <asp:TextBox ID="txtInterests" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Occupation</label>
                                            <asp:TextBox ID="txtOccupation" CssClass="form-control" ToolTip="Web Developer" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">About</label>
                                            <asp:TextBox ID="txtAbout" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Website Url</label>
                                            <asp:TextBox ID="txtwebsite" CssClass="form-control" ToolTip="http://www.mywebsite.com" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="margiv-top-10">
                                            <asp:Button ID="btnSavePersonalInfo" CssClass="btn green" ValidationGroup="validPersonalinfo" OnClick="btnSavePersonalInfo_Click" runat="server" Text="Save Changes" />
                                            <a href="#" class="btn default">Cancel </a>
                                        </div>

                                    </div>
                                    <div id="tab_2-2" class="tab-pane">
                                        <p>
                                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod.
                                        </p>
                                        <%-- Change Avatar --%>
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-4">
                                            <asp:Image ID="imgTabAvatar" CssClass="img-responsive" ImageUrl="~/images/default_images.jpg" runat="server" />
                                        </div>
                                        <div class="col-lg-4"></div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-4 pull-right">
                                            <a href="#modallibraryImg" data-toggle="modal" class="icon-btn">
                                                <img src="../images/icon/Library-Windows-icon.png" width="25" height="25" />
                                                <div>
                                                    Library
                                                </div>
                                            </a>
                                            <a href="#modalUploadImg" data-toggle="modal" class="icon-btn">
                                                <img src="../images/icon/picture-arrow-up-icon.png" width="25" height="25" />
                                                <div>
                                                    Upload
                                                </div>
                                            </a>
                                        </div>
                                        <%-- Change Avatar --%>
                                    </div>
                                    <div id="tab_3-3" class="tab-pane">

                                        <div class="form-group">
                                            <label class="control-label">Current Email</label>
                                            <asp:TextBox ID="txtCurrentEmail" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">New Email</label>
                                            <asp:TextBox ID="txtNewEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                ControlToValidate="txtNewEmail"
                                                ValidationGroup="validNewEmail"
                                                ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                Display="Dynamic" ForeColor="Red"
                                                ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Re-type New Email</label>
                                            <asp:TextBox ID="txtreEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtreEmail" ControlToCompare="txtNewEmail" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Re-type New Email Incorrect"></asp:CompareValidator>
                                        </div>
                                        <div class="margin-top-10">
                                            <asp:Button ID="btnChangeEmail" CssClass="btn green" ValidationGroup="validNewEmail" OnClick="btnChangeEmail_Click" runat="server" Text="Change Email" />
                                            <a href="#" class="btn default">Cancel </a>
                                        </div>
                                    </div>
                                    <div id="tab_3-4" class="tab-pane">

                                        <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="validChangePass" ForeColor="Red" ShowMessageBox="false" ShowSummary="true" DisplayMode="BulletList" runat="server" />
                                        <div class="form-group">
                                            <label class="control-label">Current Password</label>
                                            <asp:TextBox ID="txtCurrrentPassword" CssClass="form-control input-medium" TextMode="Password" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCurrrentPassword" ValidationGroup="validChangePass" runat="server" Display="None" ErrorMessage="Current Password RequiredFieldValidator"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">New Password</label>
                                            <asp:TextBox ID="txtNewPassword" CssClass="form-control input-medium" TextMode="Password" runat="server"></asp:TextBox>
                                            <asp:PasswordStrength ID="PasswordStrength3" TargetControlID="txtNewPassword"
                                                StrengthIndicatorType="BarIndicator"
                                                PrefixText="Strength: "
                                                PreferredPasswordLength="8"
                                                MinimumNumericCharacters="1"
                                                MinimumSymbolCharacters="1"
                                                BarBorderCssClass="BarBorder"
                                                TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength; AverageStrength;GoodStrength;ExcellentStrength" runat="server">
                                            </asp:PasswordStrength>
                                            <br />
                                            <asp:PasswordStrength ID="PasswordStrength2" TargetControlID="txtNewPassword" StrengthIndicatorType="Text" PrefixText="Strength: " runat="server"></asp:PasswordStrength>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewPassword" ValidationGroup="validChangePass" runat="server" Display="None" ErrorMessage="New Password RequiredFieldValidator"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label">Re-type New Password</label>
                                            <asp:TextBox ID="txtRepassword" CssClass="form-control input-medium" TextMode="Password" runat="server"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtRepassword" ValidationGroup="validChangePass" runat="server" Display="None" ErrorMessage="Re-type New Password RequiredFieldValidator"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtRepassword" ControlToCompare="txtNewPassword" ValidationGroup="validChangePass" runat="server" Display="None" ErrorMessage="Re-type New Password CompareValidator"></asp:CompareValidator>

                                        </div>

                                        <div class="margin-top-10">
                                            <asp:Button ID="btnChangePassword" CssClass="btn green" ValidationGroup="validChangePass" OnClick="btnChangePassword_Click" runat="server" Text="Change Password" />
                                            <a href="#" class="btn default">Cancel </a>
                                        </div>

                                    </div>
                                    <div id="tab_4-5" class="tab-pane">
                                        
                                    </div>
                                </div>
                            </div>
                            <!--end col-md-9-->
                        </div>
                    </div>
                    <!--end tab-pane-->
                    <div class="tab-pane" id="tab_1_4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="add-portfolio">
                                    <span>502 Items sold this week </span>
                                    <a href="#" class="btn icn-only green">Add a new Project <i class="m-icon-swapright m-icon-white"></i>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <!--end add-portfolio-->
                        <div class="row portfolio-block">
                            <div class="col-md-5">
                                <div class="portfolio-text">
                                    <img src="../../assets/admin/pages/media/profile/logo_metronic.jpg" alt="" />
                                    <div class="portfolio-text-info">
                                        <h4>Metronic - Responsive Template</h4>
                                        <p>
                                            Lorem ipsum dolor sit consectetuer adipiscing elit.
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5 portfolio-stat">
                                <div class="portfolio-info">
                                    Today Sold <span>187 </span>
                                </div>
                                <div class="portfolio-info">
                                    Total Sold <span>1789 </span>
                                </div>
                                <div class="portfolio-info">
                                    Earns <span>$37.240 </span>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="portfolio-btn">
                                    <a href="#" class="btn bigicn-only">
                                        <span>Manage </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <!--end row-->
                        <div class="row portfolio-block">
                            <div class="col-md-5 col-sm-12 portfolio-text">
                                <img src="../../assets/admin/pages/media/profile/logo_azteca.jpg" alt="" />
                                <div class="portfolio-text-info">
                                    <h4>Metronic - Responsive Template</h4>
                                    <p>
                                        Lorem ipsum dolor sit consectetuer adipiscing elit.
                                    </p>
                                </div>
                            </div>
                            <div class="col-md-5 portfolio-stat">
                                <div class="portfolio-info">
                                    Today Sold <span>24 </span>
                                </div>
                                <div class="portfolio-info">
                                    Total Sold <span>660 </span>
                                </div>
                                <div class="portfolio-info">
                                    Earns <span>$7.060 </span>
                                </div>
                            </div>
                            <div class="col-md-2 col-sm-12 portfolio-btn">
                                <a href="#" class="btn bigicn-only">
                                    <span>Manage </span>
                                </a>
                            </div>
                        </div>
                        <!--end row-->
                        <div class="row portfolio-block">
                            <div class="col-md-5 portfolio-text">
                                <img src="../../assets/admin/pages/media/profile/logo_conquer.jpg" alt="" />
                                <div class="portfolio-text-info">
                                    <h4>Metronic - Responsive Template</h4>
                                    <p>
                                        Lorem ipsum dolor sit consectetuer adipiscing elit.
                                    </p>
                                </div>
                            </div>
                            <div class="col-md-5 portfolio-stat">
                                <div class="portfolio-info">
                                    Today Sold <span>24 </span>
                                </div>
                                <div class="portfolio-info">
                                    Total Sold <span>975 </span>
                                </div>
                                <div class="portfolio-info">
                                    Earns <span>$21.700 </span>
                                </div>
                            </div>
                            <div class="col-md-2 portfolio-btn">
                                <a href="#" class="btn bigicn-only">
                                    <span>Manage </span>
                                </a>
                            </div>
                        </div>
                        <!--end row-->
                    </div>
                    <!--end tab-pane-->
                    <div class="tab-pane" id="tab_1_6">
                        <div class="row">
                            <div class="col-md-3">
                                <ul class="ver-inline-menu tabbable margin-bottom-10">
                                    <li class="active">
                                        <a data-toggle="tab" href="#tab_1">
                                            <i class="fa fa-briefcase"></i>General Questions </a>
                                        <span class="after"></span>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_2">
                                            <i class="fa fa-group"></i>Membership </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_3">
                                            <i class="fa fa-leaf"></i>Terms Of Service </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_1">
                                            <i class="fa fa-info-circle"></i>License Terms </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_2">
                                            <i class="fa fa-tint"></i>Payment Rules </a>
                                    </li>
                                    <li>
                                        <a data-toggle="tab" href="#tab_3">
                                            <i class="fa fa-plus"></i>Other Questions </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-9">
                                <div class="tab-content">
                                    <div id="tab_1" class="tab-pane active">
                                        <div id="accordion1" class="panel-group">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_1">1. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion1_1" class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_2">2. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion1_2" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_3">3. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion1_3" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-warning">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_4">4. Wolf moon officia aute, non cupidatat skateboard dolor brunch ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion1_4" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-danger">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_5">5. Leggings occaecat craft beer farm-to-table, raw denim aesthetic ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion1_5" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_6">6. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion1_6" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#accordion1_7">7. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion1_7" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab_2" class="tab-pane">
                                        <div id="accordion2" class="panel-group">
                                            <div class="panel panel-warning">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_1">1. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion2_1" class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        <p>
                                                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                        </p>
                                                        <p>
                                                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-danger">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_2">2. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion2_2" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_3">3. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion2_3" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_4">4. Wolf moon officia aute, non cupidatat skateboard dolor brunch ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion2_4" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_5">5. Leggings occaecat craft beer farm-to-table, raw denim aesthetic ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion2_5" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_6">6. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion2_6" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#accordion2_7">7. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion2_7" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="tab_3" class="tab-pane">
                                        <div id="accordion3" class="panel-group">
                                            <div class="panel panel-danger">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_1">1. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion3_1" class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        <p>
                                                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
                                                        </p>
                                                        <p>
                                                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
                                                        </p>
                                                        <p>
                                                            Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_2">2. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion3_2" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_3">3. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion3_3" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_4">4. Wolf moon officia aute, non cupidatat skateboard dolor brunch ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion3_4" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_5">5. Leggings occaecat craft beer farm-to-table, raw denim aesthetic ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion3_5" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_6">6. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion3_6" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">
                                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#accordion3_7">7. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft ? </a>
                                                    </h4>
                                                </div>
                                                <div id="accordion3_7" class="panel-collapse collapse">
                                                    <div class="panel-body">
                                                        3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tab-pane-->
                </div>
            </div>
            <!--END TABS-->
        </div>
    </div>
    <!-- END PAGE CONTENT-->
    <%-- Modal chose Images --%>
    <div class="modal fade" id="modallibraryImg" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Select Images</h4>
                </div>
                <div class="modal-body">
                    <div class="col-lg-9">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="dlImgCategory" CssClass="form-control input-large pull-right" AutoPostBack="true" OnSelectedIndexChanged="dlImgCategory_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Value="1">Avatar Library</asp:ListItem>
                                    <asp:ListItem Value="2">History Upload</asp:ListItem>
                                </asp:DropDownList>
                                <div class="clearfix"></div>
                                <br />
                                <div class="clearfix"></div>
                                <div class="form-control height-auto">
                                    <div style="height: 380px; overflow: auto;">
                                        <asp:Repeater ID="rpchangeAvatar" runat="server">
                                            <ItemTemplate>
                                                <div class="col-lg-3">
                                                    <a href='<%# "../" + Eval("ImagesUrl") %>' onclick="return showanh(this.href)">
                                                        <img src='<%# "../" + Eval("ImagesUrl") %>' class="img-circle img-responsive" /></a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dlImgCategory" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-lg-3">
                        <asp:Image ID="imgSelectAvatar" ImageUrl="~/images/No_image.png" CssClass="img-responsive" runat="server" />
                        <asp:HiddenField ID="HiddenimgSelect" runat="server" />
                        <asp:TextBox ID="txtImgUrl" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtImgUrl" ValidationGroup="validSelectImg" ForeColor="Red" runat="server" ErrorMessage="Please Select Image !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnchangeAvatar" CssClass="btn btn-primary pull-right" ValidationGroup="validSelectImg" OnClick="btnchangeAvatar_Click" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal chose Images --%>
    <%-- Modal Upload Images --%>
    <div class="modal fade" id="modalUploadImg" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Upload Images</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <p>
                                You can upload JPG, GIF, or PNG file. 
Maximum file size is 4MB.
                            </p>
                            <asp:FileUpload ID="FileImgUpload" CssClass="form-control" onchange="previewFile()" runat="server" />
                            <asp:RequiredFieldValidator ErrorMessage="Required"
                                ControlToValidate="FileImgUpload" ValidationGroup="validFileImgUpload"
                                runat="server" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.jpg|.gif|.png)$"
                                ControlToValidate="FileImgUpload"
                                ValidationGroup="validFileImgUpload"
                                runat="server" ForeColor="Red"
                                ErrorMessage="Please select a valid Images file !"
                                Display="Dynamic" />
                            <div class="clearfix"></div>
                            <div class="col-lg-4"></div>
                            <div class="col-lg-4">
                                <asp:Image ID="imgUpload" CssClass="img-responsive" runat="server" />
                            </div>
                            <div class="col-lg-4"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Hủy</a>
                    <asp:Button ID="btnUploadFile" ValidationGroup="validFileImgUpload" CssClass="btn btn-primary pull-right" OnClick="btnUploadFile_Click" runat="server" Text="Save !" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Upload Images  --%>


    <%-- Modal Changes pẻmission --%>
    <div class="modal fade" id="modalChangePermission" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Select Images</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <label class="inline">
                                <asp:CheckBox ID="chkAddnew" Text="Add New" runat="server" />
                            </label>
                            <label class="inline">
                                <asp:CheckBox ID="chkEdit" Text="Edit" runat="server" />
                            </label>
                            <label class="uniform-inline">
                                <asp:CheckBox ID="chkDelete" Text="Delete" runat="server" />
                            </label>
                            <label class="uniform-inline">
                                <asp:CheckBox ID="chkView" Text="View" runat="server" />
                            </label>
                        </div>
                    </div>
                    
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnsavechangePermiss" CssClass="btn btn-primary" OnClick="btnsavechangePermiss_Click" runat="server" Text="Confirm" />
                    <a class="btn btn-default" data-dismiss="modal">Cancel</a>
                </div>
            </div>
        </div>
    </div>
    <%-- End modal changes permission --%>
    <script>
        function showanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=imgSelectAvatar.ClientID %>').src = url;
            document.getElementById('<%=HiddenimgSelect.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrl.ClientID %>').value = url;
            return false;
        }
    </script>
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=imgUpload.ClientID %>');
            var file = document.querySelector('#<%=FileImgUpload.ClientID %>').files[0];
            var reader = new FileReader();
            <%--document.getElementById('<%=HiddenUploadimg.ClientID %>').value = "";
            document.getElementById('<%=txtTenAnh.ClientID %>').value = "Image tag name";--%>
            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
</asp:Content>

