<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="Pages_NewUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
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
    <h1 class="page-title">Thêm thành viên mới
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Users.aspx">User Manager</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/NewUser.aspx">New User</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-5">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <i>
                        <label>Tạo một người sử dụng mới và thêm vào hệ thống này.</label>
                    </i><br />
                    <div class="form-group">
                        <label class="control-label">Tên đăng nhập <span class="required">*</span></label>
                        <asp:TextBox ID="txtUsername" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUsername_TextChanged" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator1" 
                            ControlToValidate="txtUsername" 
                            ValidationGroup="validNewUser" 
                            ForeColor="Red" 
                            Display="Dynamic" 
                            runat="server" 
                            ErrorMessage="Tên đăng nhập không để trống !">
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="lblcheckusername" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Thư điện tử <span class="required">*</span></label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                            ControlToValidate="txtEmail"
                            ValidationGroup="validNewUser"
                            ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            Display="Dynamic" ForeColor="Red"
                            ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" ValidationGroup="validNewUser" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Email không để trống !"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblCheckEmail" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Tên : </label>
                        <asp:TextBox ID="txtFirstname" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Họ : </label>
                        <asp:TextBox ID="txtLastname" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Mật khẩu : </label>
                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:PasswordStrength ID="PasswordStrength3" TargetControlID="txtPassword"
                            StrengthIndicatorType="BarIndicator"
                            PrefixText="Strength: "
                            PreferredPasswordLength="8"
                            MinimumNumericCharacters="1"
                            MinimumSymbolCharacters="1"
                            BarBorderCssClass="BarBorder"
                            TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength; AverageStrength;GoodStrength;ExcellentStrength" runat="server">
                        </asp:PasswordStrength>
                        <br />
                        <asp:PasswordStrength ID="PasswordStrength2" TargetControlID="txtPassword" StrengthIndicatorType="Text" PrefixText="Strength: " runat="server"></asp:PasswordStrength>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" ValidationGroup="validNewUser" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="New Password Required !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Nhập lại mật khẩu : </label>
                        <asp:TextBox ID="txtPrePassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPrePassword" ValidationGroup="validNewUser" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Re-type New Password Required !"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtPrePassword" ControlToCompare="txtPassword" ValidationGroup="validNewUser" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Re-type Password incorect !"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Phòng ban : </label>
                        <asp:DropDownList ID="dlDepartments" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnNewUser" CssClass="btn btn-primary" ValidationGroup="validNewUser" OnClick="btnNewUser_Click" runat="server" Text="Thêm Người Dùng Mới" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtUsername" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="txtEmail" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="col-lg-7"></div>
    </div>
</asp:Content>

