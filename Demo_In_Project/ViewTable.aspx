<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="ViewTable.aspx.cs" Inherits="Demo_In_Project_ViewTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel-default">
        <div class="panel-body">
            <h2>View Table User Account</h2>
            <asp:GridView ID="gwUserAccount" runat="server"></asp:GridView>
            <hr />
            <h2>View Table User Profile</h2>
            <asp:GridView ID="gwUserProfile" runat="server"></asp:GridView>
            <hr />
            <h2>View Table Images With User Upload</h2>
            <asp:GridView ID="gwImguserupload" runat="server"></asp:GridView>
            <h2>Table Category</h2>
            <asp:GridView ID="gwcatagory" runat="server"></asp:GridView>
            <br />
            <h2>CustomerBasicInfo</h2>
            <asp:GridView ID="gwCustomerBasicInfo" runat="server"></asp:GridView>
            <br />
            <h2>CustomerProfilePrivate</h2>
            <asp:GridView ID="gwCustomerProfilePrivate" runat="server"></asp:GridView>
            <h2>NATIONNALITY</h2>
            <asp:GridView ID="gwNationality" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>

