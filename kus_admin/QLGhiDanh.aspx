<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QLGhiDanh.aspx.cs" Inherits="kus_admin_QLGhiDanh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản Lý Học Viên Ghi Danh
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>Quản lý Học phí
               
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QLGhiDanh.aspx">Quản lý Ghi danh</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-3">
            <div class="form-group">
                <asp:DropDownList ID="dlLoaiThongKe" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlLoaiThongKe_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="0">Thống Kê Theo Học Viên</asp:ListItem>
                    <asp:ListItem Value="1">Thống Kê Theo Khóa Học</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div id="formHT_CoSO" class="row" runat="server">
        <div class="col-lg-3">
            <div class="form-group">
                <label class="control-label">Hệ thống chi nhánh</label>
                <asp:DropDownList ID="dlHTChiNhanh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlHTChiNhanh_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-3">
            <div class="form-group">
                <label class="control-label">Chọn cơ sở</label>
                <asp:DropDownList ID="dlCoSo" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="row">
        <div class="col-lg-3">
            <div class="form-group">
                Từ ngày : 
               
                <%-- Date picker --%>
                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                    <asp:TextBox ID="txtStartdate" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                    </span>
                </div>
                <%-- Date picker --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtStartdate" ValidationGroup="validViewGhiDanh" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa chọn ngày bắt đầu !"></asp:RequiredFieldValidator>
                <asp:Label ID="lblstartdateFalse" ForeColor="Red" runat="server"></asp:Label>
            </div>
        </div>
        <div class="col-lg-3">
            <div class="form-group">
                Đến ngày : 
               
                <%-- Date picker --%>
                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                    <asp:TextBox ID="txtEnddate" CssClass="form-control" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                    </span>
                </div>
                <%-- Date picker --%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEnddate" ValidationGroup="validViewGhiDanh" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa chọn ngày kết thúc !"></asp:RequiredFieldValidator>
                <asp:Label ID="lblEnddatefalse" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <div class="col-lg-1">
            <div class="form-group">
                <br />
                <asp:Button ID="btnSunmitGhiDanh" CssClass="btn btn-primary" ValidationGroup="validViewGhiDanh" OnClick="btnSunmitGhiDanh_Click" runat="server" Text="XEM DANH SÁCH" />
            </div>
        </div>
        <div class="col-lg-4 text-right">
            <div class="form-group">
                <h2>TỔNG SỐ:
                       
                    <asp:Label ID="lblSumHocVien" CssClass="bold" runat="server" Text="0"></asp:Label>
                    HỌC VIÊN
                </h2>
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="row">
        <div class="col-lg-12">
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-list font-yellow-casablanca"></i>
                        <span class="caption-subject bold font-yellow-casablanca uppercase">Danh sách học viên ghi danh </span>
                    </div>
                    <div class="actions">
                        <%--<a class="btn btn-circle btn-icon-only btn-default" title="Xuất danh sách Excel" href="#">
                        <i class="fa fa-file-excel-o"></i>
                    </a>--%>
                        <a href="#modalEditGhiDanh" data-toggle="modal" id="btnEditKhoaHoc" title="Chỉnh sửa thông tin ghi danh" runat="server">
                            <i class="icon-wrench"></i>
                        </a>
                        <a id="btnRefreshLstKhoaHoc" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" runat="server" href="#">
                            <i class="fa fa-refresh"></i>
                        </a>
                        <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <a id="btnPhieuGD" class="btn btn-default" onserverclick="btnPhieuGD_ServerClick" runat="server"><i class="fa fa-ticket"></i>Phiếu Ghi Danh Học Viên</a>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:GridView ID="gwGhiDanhHocVien" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwGhiDanhHocVien_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Mã Ghi Danh">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGhiDanhCode" runat="server" Text='<%# Eval("GhiDanhCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tên Học Viên">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHocVienCode" CssClass="display-none" runat="server" Text='<%# Eval("HocVienCode") %>'></asp:Label>
                                            <asp:Label ID="Label1" CssClass="bold" runat="server" Text='<%# Eval("HocVienCode")+ " - "+ Eval("LastName")+ " "+ Eval("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Khóa Học Đăng Ký">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="Label2" runat="server" Text='<%# Eval("MaKhoaHoc")+" - "+ Eval("TenKhoaHoc") +" | " + Eval("TenLopHoc") + " | " + Eval("TenChuongTrinh")%>'></asp:Label>--%>
                                            <asp:Label ID="lblMaKhoaHoc" runat="server" Text='<%# Eval("MaKhoaHoc")+" - "+ Eval("TenKhoaHoc") %>'></asp:Label>
                                            <i class="fa fa-chevron-left"></i>
                                            <asp:Label ID="lblTenLopHoc" runat="server" Text='<%# Eval("TenLopHoc") %>'></asp:Label>
                                            <i class="fa fa-chevron-left"></i>
                                            <asp:Label ID="lblTenChuongTrinh" runat="server" Text='<%# Eval("TenChuongTrinh") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày Đăng Ký">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("NgayDangKy","{0:dd-MM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cơ Sở">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("TenCoSo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Học Phí">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" CssClass="bold" ForeColor="Red" runat="server" Text='<%# Eval("MucHocPhi","{0:0,00}") %>'></asp:Label>
                                            <span class="text-danger">₫</span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Đặt Cọc">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" CssClass="bold" runat="server" Text='<%# Eval("DatCoc","{0:0,00}") %>'></asp:Label>
                                            <span class="bold">₫</span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tình trạng học phí">
                                        <ItemTemplate>
                                            <i>
                                                <asp:Label ID="Label8" CssClass="bold" runat="server" Text='<%# (Eval("BLNum").ToString()=="0")?"chưa đóng":"đã đóng" %>'></asp:Label></i>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tư Vấn">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("EmployeesCode") + " - "+ Eval("LastNameNV")+" "+ Eval("FirstNameNV") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                <RowStyle BackColor="#A1DCF2"></RowStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
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
                            <div class="clearfix"></div>
                            <asp:Repeater ID="rptcoso" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPageCS" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                        CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                        OnClick="CSPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <!-- END PAGINATOR -->
            </div>
        </div>
    </div>
    <%-- Modal Edit ghi danh --%>
    <div id="modalEditGhiDanh" class="modal fade modal-scroll" tabindex="-1" data-replace="true" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-sliders"></i>Chỉnh sửa thông tin Ghi Danh
                </div>
                <div class="modal-body">
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Edit ghi danh --%>
</asp:Content>
