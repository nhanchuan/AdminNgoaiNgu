<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="HTChiNhanh.aspx.cs" Inherits="kus_admin_HTChiNhanh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Hệ Thống Chi Nhánh
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/HTChiNhanh.aspx">HT Chi Nhánh</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="clearfix"></div>
        <div class="col-lg-6">
            <p class="font-blue bold" style="font-size: 18px;">Danh sách Hệ thống chi nhánh trung tâm Anh ngữ</p>
            <asp:GridView ID="gvChiNhanh" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="gvChiNhanh_RowCancelingEdit" OnRowDataBound="gvChiNhanh_RowDataBound" OnRowDeleting="gvChiNhanh_RowDeleting" OnRowEditing="gvChiNhanh_RowEditing" OnRowUpdating="gvChiNhanh_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblChiNhanh_ID" runat="server" Text='<%# Bind("HTChiNhanhID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chi Nhánh">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtChiNhanh" CssClass="form-control" runat="server" Text='<%# Bind("TenHTChiNhanh") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtChiNhanh" ValidationGroup="validUpdatechinhanh" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Tên Chi Nhánh không để trống !"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TenHTChiNhanh") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddChiNhanh" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Chi nhánh không được bỏ trống" ControlToValidate="txtAddChiNhanh"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="validAddnew"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ghi Chú">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGhiChu" CssClass="form-control" runat="server" Text='<%# Bind("GhiChu") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("GhiChu") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddGhiChu" runat="server" CssClass="form-control"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giám Đốc Chi Nhánh">
                        <EditItemTemplate>
                            <asp:Label ID="lblGiamDocCN_ID" CssClass="display-none" runat="server" Text='<%# Eval("GDChiNHanh") %>'></asp:Label>
                            <asp:DropDownList ID="dlGDChiNhanh" CssClass="form-control" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%--<asp:Label ID="lblGiamDocCN_ID" runat="server" Text='<%# Bind("GDChiNHanh") %>'></asp:Label>--%>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("LastName")+" "+Eval("FirstName") %>'></asp:Label><br />
                            Mã NV : <asp:Label ID="Label4" runat="server" Text='<%# Eval("EmployeesCode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%--<asp:TextBox ID="txtAddGiamDoc" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>--%>
                            <asp:DropDownList ID="dlAddGiamDoc" CssClass="form-control" runat="server"></asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnselectchinhanh" runat="server" CausesValidation="False" CommandName="Select" Text="Select"><img src="../images/icon/Cursor-Select-icon.png" width="28" height="28" /></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="validUpdatechinhanh" CausesValidation="True" CommandName="Update" Text="Update"><img src="../images/icon/ok-icon.png" width="25" height="25" /></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"><img src="../images/icon/Actions-dialog-close-icon.png" width="25" height="25" /></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"><img src="../images/icon/Gear-icon.png" width="28" height="28" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="28" height="28" /></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAddNew" runat="server" ValidationGroup="validAddnew" Text="Thêm" CssClass="btn green" OnClick="btnAddNew_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#A1DCF2"></RowStyle>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
            </asp:GridView>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" DisplayMode="BulletList" ValidationGroup="Error" />

        </div>
    </div>
</asp:Content>

