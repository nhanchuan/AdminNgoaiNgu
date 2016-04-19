<%@ Page Title="Thông tin lớp học" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="LopHoc.aspx.cs" Inherits="ChuongTrinhHoc_LopHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông tin lớp học
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../ChuongTrinhHoc/LopHoc.aspx">Lớp học</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <h3 style="color: #0078D7;">Thông tin chương trình đào tạo</h3>
            <div class="form-group">
                <label class="control-label bold">Tên lớp học <span class="required">(*)</span></label>
                <asp:TextBox ID="txtTenLopHoc" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTenLopHoc" ValidationGroup="validNewLopHoc" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên lớp không được để trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label bold">Thời lượng (giờ)</label>
                <asp:TextBox ID="txtThoLuong" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label bold">Bằng cấp</label>
                <asp:TextBox ID="txtBangCap" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label class="control-label bold">Thuộc loại chương trình</label>
                        <asp:DropDownList ID="dlLoaiChuongtrinh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlLoaiChuongtrinh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Thuộc chương trình</label>
                        <asp:DropDownList ID="dlChuongtrinh" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="form-group">
                <label class="control-label bold">Mô tả</label>
                <asp:TextBox ID="txtMota" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label bold">Mức học phí</label>
                <asp:TextBox ID="txtHocPhi" CssClass="form-control bold" TextMode="Number" ForeColor="Red" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" ForeColor="Red" runat="server" Text="(*) Các thông tin cần phải nhập"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddNew" CssClass="btn btn-primary" ValidationGroup="validNewLopHoc" OnClick="btnAddNew_Click" runat="server" Text="Thêm" />
            </div>

        </div>
        <div class="col-lg-8">
            <a id="btnEditLopHoc" href="#modalEditLopHoc" data-toggle="modal" runat="server"><i class="fa fa-edit"></i> Sửa Thông tin chương trình đào tạo</a>
            <asp:GridView ID="gwLopHoc" CssClass="table table-condensed" runat="server"
                AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" 
                OnSelectedIndexChanged="gwLopHoc_SelectedIndexChanged" OnRowDataBound="gwLopHoc_RowDataBound" OnRowDeleting="gwLopHoc_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                            <asp:Label ID="lblID" CssClass="display-none" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mã Lớp Học">
                        <ItemTemplate>
                            <asp:Label ID="lblLopHocCode" runat="server" Text='<%# Eval("LopHocCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Lớp Học">
                        <ItemTemplate>
                            <asp:Label ID="lblTenLopHoc" runat="server" Text='<%# Eval("TenLopHoc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thời lượng">
                        <ItemTemplate>
                            <asp:Label ID="lblThoiLuong" runat="server" Text='<%# Eval("ThoiLuong") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bằng Cấp">
                        <ItemTemplate>
                            <asp:Label ID="lblBangCap" runat="server" Text='<%# Eval("BangCap") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Loại chương trình">
                        <ItemTemplate>
                            <asp:Label ID="lblTenLoaiChuongTrinh" runat="server" Text='<%# Eval("TenLoaiChuongTrinh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chương trình">
                        <ItemTemplate>
                            <asp:Label ID="lblTenChuongTrinh" runat="server" Text='<%# Eval("TenChuongTrinh") %>'></asp:Label>
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
    <div id="modalEditLopHoc" class="modal fade modal-scroll" tabindex="-1" data-replace="true" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-pagelines"></i>Chỉnh sửa thông tin lớp học
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="control-label bold">Tên lớp học <span class="required">(*)</span></label>
                        <asp:TextBox ID="txtETenLopHoc" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtETenLopHoc" ValidationGroup="validEditLopHoc" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên lớp không được để trống !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Thời lượng (giờ)</label>
                        <asp:TextBox ID="txtEThoiLuong" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Bằng cấp</label>
                        <asp:TextBox ID="txtEBangCap" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label bold">Thuộc loại chương trình</label>
                                <asp:DropDownList ID="dlELoaiChuongTrinh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlELoaiChuongTrinh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label bold">Thuộc chương trình</label>
                                <asp:DropDownList ID="dlEChuongTrinh" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <label class="control-label bold">Mô tả</label>
                        <asp:TextBox ID="txtEMoTa" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="control-label bold">Mức học phí</label>
                        <asp:TextBox ID="txtEMucHocPhi" CssClass="form-control bold" TextMode="Number" ForeColor="Red" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="(*) Các thông tin cần phải nhập"></asp:Label>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn">Close</button>
                    <asp:Button ID="btnSaveEdit" CssClass="btn btn-primary" ValidationGroup="validEditLopHoc" OnClick="btnSaveEdit_Click" runat="server" Text="Lưu thông tin" />
                </div>
            </div>
        </div>
    </div>
    <%--End Modal --%>
</asp:Content>

