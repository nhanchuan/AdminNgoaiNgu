<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="AuthenticationGroups.aspx.cs" Inherits="Pages_AuthenticationGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Authentication Groups
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/UserGroups.aspx">Users Groups</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/AuthenticationGroups.aspx">Authentication Groups</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12">
            <asp:GridView ID="gwAuthenticationGroups" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="gwAuthenticationGroups_RowDataBound" OnSelectedIndexChanged="gwAuthenticationGroups_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblPermissFuncID" CssClass="display-none" runat="server" Text='<%# Eval("PermissFuncID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#FAF3DF"></RowStyle>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

