<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="MoLopHoc.aspx.cs" Inherits="kus_admin_MoLopHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Mở Lớp Học Mới
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/ListLopHoc.aspx">Quản lý lớp học</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/MoLopHoc.aspx">Mở lớp</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label class="control-label">Hệ thống chi nhánh</label>
                        <asp:DropDownList ID="dlHTChiNhanh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlHTChiNhanh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Chọn cơ sở</label>
                        <asp:DropDownList ID="dlCoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Chương trình học</label>
                        <asp:DropDownList ID="dlKhoiLop" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlKhoiLop_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Cấp độ</label>
                        <asp:DropDownList ID="dlCapDo" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="form-group">
                <label class="control-label bold">Tên lớp học</label>
                <asp:TextBox ID="txtTenLopHoc" CssClass="form-control bold" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTenLopHoc" ValidationGroup="validNewLopHoc" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên lớp học không được trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Ngày khai giảng</label>
                <%-- Date picker --%>
                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                    <asp:TextBox ID="txtNgayKG" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                    </span>
                </div>
                <%-- Date picker --%>
            </div>
            <div class="form-group">
                <label class="control-label">Thời lượng học</label>
                <asp:TextBox ID="txtThoiLuongHoc" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Ngày kết thúc</label>
                <%-- Date picker --%>
                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                    <asp:TextBox ID="txtNgayKT" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                    </span>
                </div>
                <%-- Date picker --%>
            </div>
            <div class="form-group">
                <label class="control-label">Sỉ số tối đa</label>
                <asp:TextBox ID="txtSiSoToiDa" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label bold">Mức Học Phí</label>
                <asp:TextBox ID="txtMucHocPhi" CssClass="form-control bold text-danger" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnLuuThongTin" CssClass="btn btn-primary" ValidationGroup="validNewLopHoc" OnClick="btnLuuThongTin_Click" runat="server" Text="Lưu Thông Tin" />
        </div>
    </div>
</asp:Content>

