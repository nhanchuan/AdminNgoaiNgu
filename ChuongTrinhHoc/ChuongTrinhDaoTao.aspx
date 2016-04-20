<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="ChuongTrinhDaoTao.aspx.cs" Inherits="ChuongTrinhHoc_ChuongTrinhDaoTao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Chương trình đào tạo
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
                <a href="../ChuongTrinhHoc/ChuongTrinhDaoTao.aspx">Chương trình đào tạo</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <h3 style="color: #0078D7;">Thông tin chương trình đào tạo</h3>
            <div class="form-group">
                <label class="control-label bold">Mã chương trình <span class="required">(*)</span></label>
                <asp:TextBox ID="txtMaChuongTrinh" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMaChuongTrinh" ValidationGroup="validNewChuongTrinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Mã chương trình không được để trống !"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMaChuongTrinh" ValidationGroup="validNewChuongTrinh" ValidationExpression="^[\sa-zA-Z0-9_-]{0,100}" Display="Dynamic" ForeColor="Red" ErrorMessage="Mã chương trình chỉ được nhập chữ cái và số. Tối đa 100 ký tự !"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label class="control-label bold">Tên chương trình <span class="required">(*)</span></label>
                <asp:TextBox ID="txtTenChuongTrinh" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTenChuongTrinh" ValidationGroup="validNewChuongTrinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên chương trình không được để trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label bold">Thuộc loại chương trình</label>
                <asp:DropDownList ID="dlLoaiChuongtrinh" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label bold">Mô tả</label>
                <asp:TextBox ID="txtMota" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" ForeColor="Red" runat="server" Text="(*) Các thông tin cần phải nhập"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddNew" CssClass="btn btn-primary" ValidationGroup="validNewChuongTrinh" OnClick="btnAddNew_Click" runat="server" Text="Thêm" />
            </div>
        </div>
        <div class="col-lg-8">
            <a id="btnEditChuongTrinhDaoTao" href="#modalEditChuongTrinhDaoTao" data-toggle="modal" runat="server"><i class="fa fa-edit"></i> Sửa Thông tin chương trình đào tạo</a>
            <asp:GridView ID="gwChuongTrinhDaoTao" CssClass="table table-condensed" runat="server"
                AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="gwChuongTrinhDaoTao_RowDataBound" OnRowDeleting="gwChuongTrinhDaoTao_RowDeleting" OnSelectedIndexChanged="gwChuongTrinhDaoTao_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mã chương trình">
                        <ItemTemplate>
                            <asp:Label ID="lblID" CssClass="display-none" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            <asp:Label ID="lblMaChuongTrinh" runat="server" Text='<%# Eval("MaChuongTrinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên chương trình">
                        <ItemTemplate>
                            <asp:Label ID="lblTenChuongTrinh" runat="server" Text='<%# Eval("TenChuongTrinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Loại chương trình">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("TenLoaiChuongTrinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbtnUp" CommandArgument='<%# Eval("ID") %>' OnClick="lkbtnUp_Click" runat="server"><i class="fa fa-caret-square-o-up" style="font-size:20px;"></i></asp:LinkButton>
                            <asp:LinkButton ID="lkbtnDown" CommandArgument='<%# Eval("ID") %>' OnClick="lkbtnDown_Click" runat="server"><i class="fa fa-caret-square-o-down" style="font-size:20px;"></i></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="60px" />
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
    <div id="modalEditChuongTrinhDaoTao" class="modal fade modal-scroll" tabindex="-1" data-replace="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-pagelines"></i>Chỉnh sửa thông tin chương trình đào tạo
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="control-label bold">Mã chương trình <span class="required">(*)</span></label>
                        <asp:TextBox ID="txtEMaChuongTrinh" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEMaChuongTrinh" ValidationGroup="validEditChuongTrinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Mã chương trình không được để trống !"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEMaChuongTrinh" ValidationGroup="validEditChuongTrinh" ValidationExpression="^[\sa-zA-Z0-9_-]{0,100}" Display="Dynamic" ForeColor="Red" ErrorMessage="Mã chương trình chỉ được nhập chữ cái và số. Tối đa 100 ký tự !"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Tên chương trình <span class="required">(*)</span></label>
                        <asp:TextBox ID="txtETenChuongTrinh" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtETenChuongTrinh" ValidationGroup="validEditChuongTrinh" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên chương trình không được để trống !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Thuộc loại chương trình</label>
                        <asp:DropDownList ID="dlELoaiChuongTrinh" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Mô tả</label>
                        <asp:TextBox ID="txtEMota" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" ForeColor="Red" runat="server" Text="(*) Các thông tin cần phải nhập"></asp:Label>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn">Close</button>
                    <asp:Button ID="btnSaveEdit" CssClass="btn btn-primary" ValidationGroup="validEditChuongTrinh" OnClick="btnSaveEdit_Click" runat="server" Text="Lưu thông tin" />
                </div>
            </div>
        </div>
    </div>
    <%--End Modal --%>
</asp:Content>

