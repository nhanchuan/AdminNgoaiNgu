<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="LoaiHinhDaoTao.aspx.cs" Inherits="ChuongTrinhHoc_LoaiHinhDaoTao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Loại hình đào tạo
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Trung tâm anh ngữ</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../ChuongTrinhHoc/LoaiHinhDaoTao.aspx">Loại hình đào tạo</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-5">
            <h3 style="color: #0078D7;">Thông tin Loại hình đào tạo</h3>
            <div class="form-group">
                <label class="control-label bold">Mã Loại hình đào tạo <span class="required">(*)</span></label>
                <asp:TextBox ID="txtMaLoaiHinh" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMaLoaiHinh" ValidationGroup="validNewLoaiHinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Mã Loại Hình không được để trống !"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMaLoaiHinh" ValidationGroup="validNewLoaiHinh" ValidationExpression="^[\sa-zA-Z0-9_-]{0,100}" Display="Dynamic" ForeColor="Red" ErrorMessage="Mã Loại Hình chỉ được nhập chữ cái và số. Tối đa 100 ký tự !"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label class="control-label bold">Tên Loại hình đào tạo <span class="required">(*)</span></label>
                <asp:TextBox ID="txtTenLoaiHinh" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTenLoaiHinh" ValidationGroup="validNewLoaiHinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên Loại Hình không được để trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" ForeColor="Red" runat="server" Text="(*) Các thông tin cần phải nhập"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddNew" CssClass="btn btn-primary" ValidationGroup="validNewLoaiHinh" OnClick="btnAddNew_Click" runat="server" Text="Thêm" />
            </div>
        </div>
        <div class="col-lg-7">
            <a id="btnEditLoaiHinhDT" href="#modalEditLoaiHinhDaoTao" data-toggle="modal" runat="server"><i class="fa fa-edit"></i> Sửa Thông tin Loại hình đào tạo</a>
            <asp:GridView ID="gwLoaiHinhDaoTao" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="gwLoaiHinhDaoTao_RowDataBound" OnRowDeleting="gwLoaiHinhDaoTao_RowDeleting" OnSelectedIndexChanged="gwLoaiHinhDaoTao_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mã Loại hình đào tạo">
                        <ItemTemplate>
                            <asp:Label ID="lblID" CssClass="display-none" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            <asp:Label ID="lblMaLoaiHinh" runat="server" Text='<%# Eval("MaLoaiHinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Loại hình đào tạo">
                        <ItemTemplate>
                            <asp:Label ID="lblTenLoaiHinh" runat="server" Text='<%# Eval("TenLoaiHinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkBtnDel" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="20" height="20" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkSelect" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#FAF3DF"></RowStyle>
            </asp:GridView>
        </div>
    </div>

    <%-- Modal Edit Loại hình đào tạo --%>
    <div id="modalEditLoaiHinhDaoTao" class="modal fade modal-scroll" tabindex="-1" data-replace="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-pagelines"></i>Chỉnh sữa Thông tin Loại hình đào tạo
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <label class="control-label bold">Mã Loại hình đào tạo <span class="required">(*)</span></label>
                        <asp:TextBox ID="txtEMaLoaiHinh" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEMaLoaiHinh" ValidationGroup="validEditLoaiHinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Mã Loại Hình không được để trống !"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEMaLoaiHinh" ValidationGroup="validEditLoaiHinh" ValidationExpression="^[\sa-zA-Z0-9_-]{0,100}" Display="Dynamic" ForeColor="Red" ErrorMessage="Mã Loại Hình chỉ được nhập chữ cái và số. Tối đa 100 ký tự !"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Tên Loại hình đào tạo <span class="required">(*)</span></label>
                        <asp:TextBox ID="txtETenLoaiHinh" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtETenLoaiHinh" ValidationGroup="validEditLoaiHinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên Loại Hình không được để trống !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="(*) Các thông tin cần phải nhập"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn">Close</button>
                    <asp:Button ID="btnSaveEdit" CssClass="btn btn-primary" ValidationGroup="validEditLoaiHinh" OnClick="btnSaveEdit_Click" runat="server" Text="Lưu thông tin" />
                </div>
            </div>
        </div>
    </div>
    <%--End Modal --%>
</asp:Content>

