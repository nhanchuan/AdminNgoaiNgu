<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="NewInternationalSchool.aspx.cs" Inherits="QuanLyHoSo_NewInternationalSchool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">New International School <small>New International School</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../QuanLyHoSo/NewInternationalSchool.aspx">New International School </a>
                <i class="fa fa-angle-right"></i>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <label class="control-label">School Name</label>
                <asp:TextBox ID="txtSchoolname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">School Address</label>
                <asp:TextBox ID="txtSchoolAddress" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Web Site</label>
                <asp:TextBox ID="txtWebSite" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Cấp trường</label>
                <asp:DropDownList ID="dlSchoolLvl" CssClass="form-control" runat="server">
                    <asp:ListItem Value="1">Cấp 2 , 3</asp:ListItem>
                     <asp:ListItem Value="2">Cao Đẳng</asp:ListItem>
                     <asp:ListItem Value="3">Đại Học</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">About Link</label>
                <asp:TextBox ID="txtAboutLink" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Country</label>
                <asp:DropDownList ID="dlCountry" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Map</label>
                <asp:TextBox ID="txtmap" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Phone</label>
                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class=""></div>
        </div>
        <asp:Button ID="btnSaveInfo" CssClass="btn btn-primary" OnClick="btnSaveInfo_Click" runat="server" Text="Save" />
    </div>

</asp:Content>

