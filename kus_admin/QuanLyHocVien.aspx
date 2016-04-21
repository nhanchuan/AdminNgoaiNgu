<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QuanLyHocVien.aspx.cs" Inherits="kus_admin_QuanLyHocVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản lý học viên
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Mục tư vấn</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QuanLyHocVien.aspx">Lớp học</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-8">
            <div class="form-horizontal">
                <h4><i>Trung Tâm</i></h4>
                <div class="form-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <%-- /Row --%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-5">Hệ thống chi nhánh</label>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="dlHTChiNhanh" AutoPostBack="true" OnSelectedIndexChanged="dlHTChiNhanh_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">Cơ sở thuộc hệ thống</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="dlCoso" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4">
            <div class="form-horizontal">
                <h4><i>Tìm học viên</i></h4>
                <div class="form-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <%-- /Row --%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-md-5">Thuộc loại chương trình</label>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="dlLoaiChuongTrinh" AutoPostBack="true" OnSelectedIndexChanged="dlLoaiChuongTrinh_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <%-- /Row --%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-md-5">Thuộc chương trình</label>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="dlChuongTrinh" AutoPostBack="true" OnSelectedIndexChanged="dlChuongTrinh_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <%-- /Row --%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-md-5">Thuộc lớp</label>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="dlLopHoc" AutoPostBack="true" OnSelectedIndexChanged="dlLopHoc_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <%-- /Row --%>
                            <div class="row">
                                <div class="form-group">
                                    <label class="control-label col-md-5">Thuộc khóa</label>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="dlKhoaHoc" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="col-lg-8">
            <h4><i>Thông tin cá nhân</i></h4>
            <div class="form-horizontal">
                <div class="form-body">
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Mã học viên</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtMaHocVien" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Tên học viên</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtTenHocVien" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Email</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Điện thoại</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDienThoai" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Số CMND</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtCMND" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Họ tên Phụ huynh</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtHoTenPhuHuynh" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-12 text-right">
                            <a class="btn btn-default"><i class="fa fa-bar-chart"></i>&nbsp Thống kê đóng học phí</a>
                            <a id="btnRefreshSearch" class="btn btn-default" onserverclick="btnRefreshSearch_ServerClick" runat="server"><i class="fa fa-refresh"></i>&nbsp Refresh</a>
                            <a class="btn btn-default"><i class="fa fa-file-excel-o"></i>&nbsp Excel</a>
                            <a id="btnSearchHocVien" class="btn btn-default" onserverclick="btnSearchHocVien_ServerClick" runat="server"><i class="fa fa-search"></i>&nbsp Tìm</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <!-- BEGIN Portlet PORTLET-->
        <div class="portlet light">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-list font-yellow-casablanca"></i>
                    <span class="caption-subject bold font-yellow-casablanca uppercase">Danh sách học viên </span>
                    <span class="caption-helper"> ( Có <asp:Label ID="lblsumketqua" runat="server" Text="0"></asp:Label> kết quả tìm thấy...)</span>
                </div>
                <div class="actions">
                    <a href="#" id="btnEditHocVienInfor" title="Chỉnh sửa thông tin học viên" onserverclick="btnEditHocVienInfor_ServerClick" runat="server">
                        <i class="icon-wrench"></i>
                    </a>
                    <a id="btnRefreshListHocVien" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" onserverclick="btnRefreshListHocVien_ServerClick" runat="server">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:GridView ID="gwListHocVien" CssClass="table table-condensed" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwListHocVien_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mã học viên">
                            <ItemTemplate>
                                <asp:Label ID="lblHocVienCode" runat="server" Text='<%# Eval("HocVienCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Họ Tên học viên">
                            <ItemTemplate>
                                <i class='<%# Eval("SumHocVien").ToString()=="1"?"fa fa-tag font-yellow-casablanca":"fa fa-tags font-yellow-casablanca" %>'></i> <asp:Label ID="lblHocVienName" runat="server" Text='<%# Eval("LastName")+" "+ Eval("FirstName") %>'></asp:Label> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giới tính">
                            <ItemTemplate>
                                <asp:Label ID="lblSex" runat="server" Text='<%# Eval("Sex").ToString()=="1"?"Nam":"Nữ" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày sinh">
                            <ItemTemplate>
                                <asp:Label ID="lblBirthday" runat="server" Text='<%# Eval("Birthday","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Điện thoại">
                            <ItemTemplate>
                                <asp:Label ID="lblDienThoai" runat="server" Text='<%# Eval("DienThoai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Họ tên phụ huynh">
                            <ItemTemplate>
                                <asp:Label ID="lblHoTenPH" runat="server" Text='<%# Eval("HoTenPH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Khóa Học Đăng Ký">
                            <ItemTemplate>
                                <asp:Label ID="lblTenKhoaHoc" runat="server" Text='<%# Eval("TenKhoaHoc")+" - "+Eval("MaKhoaHoc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thuộc Lớp">
                            <ItemTemplate>
                                <asp:Label ID="lblTenLopHoc" runat="server" Text='<%# Eval("TenLopHoc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thuộc Chương trình">
                            <ItemTemplate>
                                <asp:Label ID="lblTenChuongTrinh" runat="server" Text='<%# Eval("TenChuongTrinh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Học phí">
                            <ItemTemplate>
                                <i>
                                    <asp:Label ID="Label8" CssClass="bold" runat="server" Text='<%# (Eval("NumBLGhiDanh").ToString()=="0")?"chưa đóng":"đã đóng" %>'></asp:Label></i><br />
                                <a class="label label-success pull-right <%# Eval("NumBLGhiDanh").ToString() == "0" ? "display-none":"" %>"
                                    href='<%# "../kus_admin/BienLaiHocPhi.aspx?BienLaiCode="+ Eval("BienLaiCode") %>'>
                                    <i class="fa fa-credit-card">Xem biên lai</i>
                                </a>
                            </ItemTemplate>
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

                            </div>
                        </div>
                    </div>
                    <!-- END PAGINATOR -->
                </div>
            </div>
        </div>
        <!-- END Portlet PORTLET-->
    </div>
</asp:Content>

