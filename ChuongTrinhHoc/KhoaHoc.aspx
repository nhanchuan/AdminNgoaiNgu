<%@ Page Title="Thông tin khóa học" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="KhoaHoc.aspx.cs" Inherits="ChuongTrinhHoc_KhoaHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thông tin khóa học
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../ChuongTrinhHoc/KhoaHoc.aspx">Khóa học</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-grid"></i>Thông tin chương trình đào tạo
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body form">
                <div class="form-horizontal">
                    <div class="form-body">
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Tên khóa học</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTenKhoaHoc" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTenKhoaHoc" ValidationGroup="validNewKhoaHoc" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên khóa học không được để trống !"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Ngày khai giảng</label>
                                    <div class="col-md-8">
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <asp:TextBox ID="txtNgayKG" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Số lượng học viên</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtSoLuong" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- /Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Ngày kết thúc</label>
                                    <div class="col-md-8">
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <asp:TextBox ID="txtNgayKT" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label bold col-md-4">Thời lượng <i>(tiết)</i></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtThoiLuong" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc loại chương trình</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlLoaiChuongTrinh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlLoaiChuongTrinh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Hệ thống chi nhánh</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlHTChiNhanh" AutoPostBack="true" OnSelectedIndexChanged="dlHTChiNhanh_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc chương trình</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlChuongTrinh" AutoPostBack="true" OnSelectedIndexChanged="dlChuongTrinh_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc Cơ Sở</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlCoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Thuộc lớp</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="dlLopHoc" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4"></label>
                                            <div class="col-md-8"></div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="form-actions right">
                        <a class="btn btn-default">Cancel</a>
                        <asp:Button ID="btnSaveNew" CssClass="btn blue" ValidationGroup="validNewKhoaHoc" OnClick="btnSaveNew_Click" runat="server" Text="Lưu thông tin" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="row">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet light">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-paper-plane font-yellow-casablanca"></i>
                    <span class="caption-subject bold font-yellow-casablanca uppercase">Danh sách khóa học </span>
                    <span class="caption-helper">more samples...</span>
                </div>
                <div class="inputs">
                    <div class="portlet-input input-inline input-medium">
                        <div class="input-group">
                            <input id="txtsearch" type="text" class="form-control input-circle-left" placeholder="search..." title="Tìm Mã hoặc Tên khóa học" runat="server" />
                            <span class="input-group-btn">
                                <button id="btnSearchKhoaHoc" class="btn btn-circle-right btn-default" type="submit" onserverclick="btnSearchKhoaHoc_ServerClick" runat="server">Go!</button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="actions">
                    <a class="btn btn-circle btn-icon-only btn-default" title="Xuất danh sách Excel" href="#">
                        <i class="fa fa-file-excel-o"></i>
                    </a>
                    <a id="btnRefreshLstKhoaHoc" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" onserverclick="btnRefreshLstKhoaHoc_ServerClick" runat="server" href="#">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a href="#modalEditKhoa" data-toggle="modal" id="btnEditKhoaHoc" title="Chỉnh sửa thông tin khóa học" runat="server">
                        <i class="icon-wrench"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:GridView ID="gwKhoaHoc" CssClass="table table-condensed" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" 
                    OnRowDataBound="gwKhoaHoc_RowDataBound" OnRowDeleting="gwKhoaHoc_RowDeleting" OnSelectedIndexChanged="gwKhoaHoc_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                <asp:Label ID="lblID" CssClass="display-none" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã khóa học">
                            <ItemTemplate>
                                <asp:Label ID="lblMaKhoaHoc" runat="server" Text='<%# Eval("MaKhoaHoc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên khóa học">
                            <ItemTemplate>
                                <asp:Label ID="lblTenKhoaHoc" runat="server" Text='<%# Eval("TenKhoaHoc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số lượng học viên">
                            <ItemTemplate>
                                <asp:Label ID="lblSoLuong" runat="server" Text='<%# Eval("SoLuong") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày khai giảng">
                            <ItemTemplate>
                                <asp:Label ID="lblNgayKhaiGiang" runat="server" Text='<%# Eval("NgayKhaiGiang","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày kết thúc">
                            <ItemTemplate>
                                <asp:Label ID="lblNgayKetThuc" runat="server" Text='<%# Eval("NgayKetThuc","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thời lượng">
                            <ItemTemplate>
                                <asp:Label ID="lblThoiLuong" runat="server" Text='<%# Eval("ThoiLuong") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thuộc lớp">
                            <ItemTemplate>
                                <asp:Label ID="lblTenLopHoc" runat="server" Text='<%# Eval("TenLopHoc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thuộc Chương trình">
                            <ItemTemplate>
                                <asp:Label ID="lblTenChuongTrinh" runat="server" Text='<%# Eval("TenChuongTrinh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thuộc Loại chương trình">
                            <ItemTemplate>
                                <asp:Label ID="lblTenLoaiChuongTrinh" runat="server" Text='<%# Eval("TenLoaiChuongTrinh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thuộc Cơ Sở">
                            <ItemTemplate>
                                <asp:Label ID="lblTenCoSo" runat="server" Text='<%# Eval("TenCoSo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkBtnDel" CssClass="btn btn-circle btn-icon-only btn-default" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
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
                <div class="form-group">
                    <!-- BEGIN PAGINATOR -->
                    <div class="row">
                        <div class="col-md-4 col-sm-4 items-info">
                        </div>
                        <div class="col-md-8 col-sm-8">
                            <div class="pagination_lst pull-right">
                                <asp:Repeater ID="rptPager" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="rptSearch" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSearch" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="Search_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <!-- END PAGINATOR -->
                </div>
            </div>
        </div>
        <!-- END Portlet PORTLET-->
    </div>


    <%-- Modal Edit Khoa Hoc --%>
    <div id="modalEditKhoa" class="modal fade modal-scroll" tabindex="-1" data-replace="true" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-sliders"></i> Chỉnh sửa thông tin khóa học
                </div>
                <div class="modal-body">

                    <div class="form-horizontal">
                        <div class="form-body">
                            <%-- /Row --%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label bold col-md-4">Tên khóa học</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtETenKhoaHoc" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtETenKhoaHoc" ValidationGroup="validUpdateKhoaHoc" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên khóa học không được để trống !"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%-- /Row --%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label bold col-md-4">Ngày khai giảng</label>
                                        <div class="col-md-8">
                                            <%-- Date picker --%>
                                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                <asp:TextBox ID="txtENgayKhaiGiang" CssClass="form-control" runat="server"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                </span>
                                            </div>
                                            <%-- Date picker --%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label bold col-md-4">Số lượng học viên</label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtESoLuong" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- /Row --%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label bold col-md-4">Ngày kết thúc</label>
                                        <div class="col-md-8">
                                            <%-- Date picker --%>
                                            <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                <asp:TextBox ID="txtENgayKetThuc" CssClass="form-control" runat="server"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                </span>
                                            </div>
                                            <%-- Date picker --%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label bold col-md-4">Thời lượng <i>(tiết)</i></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtEThoiLuong" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Thuộc loại chương trình</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="dlELoaiChuongTrinh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlELoaiChuongTrinh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Hệ thống chi nhánh</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="dlEHTChiNhanh" AutoPostBack="true" OnSelectedIndexChanged="dlEHTChiNhanh_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Thuộc chương trình</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="dlEChuongTrinh" AutoPostBack="true" OnSelectedIndexChanged="dlEChuongTrinh_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Thuộc Cơ Sở</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="dlECoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Thuộc lớp</label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="dlELopHoc" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4"></label>
                                                <div class="col-md-8"></div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn">Close</button>
                    <asp:Button ID="btnSaveEditKhoaHoc" CssClass="btn btn-primary" ValidationGroup="validUpdateKhoaHoc" OnClick="btnSaveEditKhoaHoc_Click" runat="server" Text="Lưu thông tin" />
                </div>
            </div>
        </div>
    </div>
    <%--End Modal --%>
</asp:Content>

