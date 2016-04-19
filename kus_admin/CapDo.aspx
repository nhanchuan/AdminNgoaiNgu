<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="CapDo.aspx.cs" Inherits="kus_admin_CapDo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Cấp Độ Đào Tạo
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/CapDo.aspx">Khối lớp</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="clearfix"></div>
        <div class="col-lg-6">
            <p class="font-blue bold" style="font-size: 18px;">Danh sách các Cấp độ đào tạo tại trung tâm</p>
            <asp:GridView ID="gvCapDo" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="gvCapDo_RowCancelingEdit" OnRowEditing="gvCapDo_RowEditing" OnRowUpdating="gvCapDo_RowUpdating" OnRowDataBound="gvCapDo_RowDataBound" OnRowDeleting="gvCapDo_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Mã cấp độ">
                        <ItemTemplate>
                            <asp:Label ID="lblCapDoID" runat="server" Text='<%# Bind("CapDoID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Khối Lớp">
                        <EditItemTemplate>
                            <asp:Label ID="lblUpdateCapDoID" CssClass="display-none" runat="server" Text='<%# Eval("CapDoID") %>'></asp:Label>
                            <asp:DropDownList ID="dlKhoiLop" CssClass="form-control" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("TenKhoiLop") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="dlAddKhoiLop" CssClass="form-control" runat="server"></asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cấp độ">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTenCapDo" runat="server" Text='<%# Bind("TenCapDo") %>' CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtTenCapDo" ValidationGroup="validUpdateCapDo" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Tên cấp độ không được để trống !"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TenCapDo") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddTenCapDo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tên cấp độ không được bỏ trống !" ControlToValidate="txtAddTenCapDo" ForeColor="Red"
                                Display="Dynamic" ValidationGroup="ErrorAddnew"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mô Tả">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMoTaNgan" runat="server" Text='<%# Bind("MoTaNgan") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("MoTaNgan") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddMoTa" runat="server" CssClass="form-control"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" ValidationGroup="validUpdateCapDo" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkDelKhoiLop" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAddNew" runat="server" Text="Thêm" ValidationGroup="ErrorAddnew" CssClass="btn btn-success" OnClick="btnAddNew_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#A1DCF2"></RowStyle>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

