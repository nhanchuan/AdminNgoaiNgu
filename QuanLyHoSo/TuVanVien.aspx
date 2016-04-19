<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="TuVanVien.aspx.cs" Inherits="QuanLyHoSo_TuVanVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../assets/admin/pages/css/profile-old.css" rel="stylesheet" />
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Mục Tư Vấn Viên<small> Counsellor</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../QuanLyHoSo/TuVanVien.aspx">Mục Tư Vấn Viên</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-md-8 profile-info">
            <h1>
                <asp:Label ID="lblUserFullName" runat="server" Text="Nguyễn Nhân Chuẩn"></asp:Label>
            </h1>
            <asp:Label ID="lblregency" CssClass="control-label label-default" Text="Nhân Viên Tư Vấn" runat="server"></asp:Label><br />
            <asp:Label ID="lblMaNV" CssClass="bold" runat="server" Text="Label"></asp:Label>
            <p>
                <i class="fa fa-globe" style="color: dodgerblue;"></i>
                <a href="#">
                    <asp:Label ID="lblmywebsite" runat="server" Text="Label"></asp:Label>
                </a>
            </p>
            <ul class="list-inline">
                <li>
                    <i class="fa fa-map-marker"></i>
                    <asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label>
                </li>
                <li>
                    <i class="fa fa-calendar"></i>
                    <asp:Label ID="lblBirthday" runat="server" Text="Label"></asp:Label>
                </li>
                <li>
                    <i class="fa fa-briefcase"></i>
                    <asp:Label ID="lblOccupation" runat="server" Text="Label"></asp:Label>
                </li>
                <li>
                    <i class="fa fa-star"></i>Top Seller
                </li>
                <li>
                    <i class="fa fa-heart"></i>BASE Jumping
                </li>
            </ul>
        </div>
        <!--end col-md-8-->
        <div class="col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="portlet sale-summary">
                        <div class="portlet-title">
                            <div class="caption bold">
                                Tóm tắt tư vấn
                            </div>
                            <div class="tools">
                                <a class="reload" href="javascript:;" onclick="reloadclick()"></a>
                            </div>
                        </div>
                        <div class="portlet-body">

                            <ul class="list-unstyled">
                                <li>
                                    <span class="sale-info">Trong ngày <i class="fa fa-img-up"></i>
                                    </span>
                                    <span class="sale-num">
                                        <asp:Label ID="lblDaySum" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </li>
                                <li>
                                    <span class="sale-info">Trong tháng <i class="fa fa-img-down"></i>
                                    </span>
                                    <span class="sale-num">
                                        <asp:Label ID="lblMonthSum" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </li>
                                <li>
                                    <span class="sale-info">Tổng số </span>
                                    <span class="sale-num">
                                        <asp:Label ID="lblTotalSum" runat="server" Text="Label"></asp:Label>
                                    </span>
                                </li>
                            </ul>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!--end col-md-4-->
    </div>
    <%-- END ROW --%>
    <div class="clearfix"></div>
     <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-edit"></i>Danh Sách Khách Hàng Tư Vấn
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <%--<button id="btnreload" class="btn green" runat="server"><i class="fa fa-refresh"></i></button>--%>
                                <asp:Button ID="btnreload" CssClass="btn green" OnClick="btnreload_Click" runat="server" Text="refresh" />
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body background">
                            <div class="row">
                                <%--<div class="col-lg-1">
                                    <asp:Button ID="btnSelectAll" CssClass="btn orange" OnClick="btnSelectAll_Click" runat="server" Text="Select All" />
                                    <asp:Button ID="btnUncheckAll" CssClass="btn orange" OnClick="btnUncheckAll_Click" runat="server" Text="Uncheck All" />
                                </div>--%>
                                <div class="col-lg-1">
                                    <a class="btn red" data-toggle="modal" href="#modalDelete"><i class="fa fa-remove"></i> Xóa Phiếu</a>
                                </div>
                                <div class="col-lg-3">
                                    <div class="input-group">
                                        <div class="input-icon">
                                            <i class="fa fa-tasks"></i>
                                            <asp:DropDownList ID="dlEmployeesAdvisory" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0">-- Chọn hành động --</asp:ListItem>
                                                <asp:ListItem Value="1">KÊ KHAI THÔNG TIN KHÁCH HÀNG</asp:ListItem>
                                                <asp:ListItem Value="2">XEM BẢNG KÊ KHAI THÔNG TIN</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <span class="input-group-btn">
                                            <a href="#" id="btnAction" class="btn btn-primary" onserverclick="btnAction_ServerClick" runat="server"><i class="fa fa-terminal"></i>Áp dụng</a>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-lg-5">
                                    <div class="input-group">
                                        <div class="input-icon">
                                            <i class="fa fa-search"></i>
                                            <input id="txtsearchAdv" class="form-control" type="text" placeholder="Tìm kiếm phiếu tư vấn" runat="server" />
                                        </div>
                                        <span class="input-group-btn">
                                            <button id="btnsearchAdv" class="btn btn-success" type="button" onserverclick="btnsearchAdv_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Search</button>
                                            <a style="margin-left:5px;" class="btn btn-info" data-toggle="modal" href="#modalSeaarch">Search more</a>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="input-icon">
                                        <i class="fa fa-filter"></i>
                                        <asp:DropDownList ID="dlProgressForm" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlProgressForm_SelectedIndexChanged" runat="server">
                                            <asp:ListItem Value="-1">-- Tình trạng --</asp:ListItem>
                                            <asp:ListItem Value="0">Chờ xử lý</asp:ListItem>
                                            <asp:ListItem Value="1">Đang tư vấn</asp:ListItem>
                                            <asp:ListItem Value="2">Đang làm hồ sơ</asp:ListItem>
                                            <asp:ListItem Value="3">Hoàn thành hồ sơ</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <%-- Begin content --%>
                            <asp:GridView ID="gwAdvisoryManager" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwAdvisoryManager_SelectedIndexChanged">
                                <Columns>
                                    <%--<asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkrow" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Họ và Tên">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FullName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <a style="font-size: 16px;" href='<%# "../QuanLyHoSo/PhieuDangKyTuVan_Info.aspx?FormID=" + Eval("RegistrationID") %>'>
                                                <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label></a>
                                            <asp:Label ID="lblRegistrationID" CssClass="display-none" runat="server" Text='<%# Bind("RegistrationID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số điện thoại">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phiếu Đăng Ký">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TypeName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <span class='<%# Eval("TypeName").ToString() == "Tư Vấn Du Học" ? "label label-primary" : Eval("TypeName").ToString() == "Tư Vấn Thực Tập" ? "label label-default" : Eval("TypeName").ToString() == "Tư Vấn Du Lịch" ? "label label-success" :"label label-warning" %>'>
                                                <strong><i class="fa fa-pencil-square-o"></i>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label></strong></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trình độ học vấn">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("NAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tư vấn du học">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("CountryName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ngày đăng ký">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("DateOfCreate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("DateOfCreate","{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFFStatus" runat="server" Text='<%# Bind("FFStatus") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFFStatus" runat="server" Text='<%# Bind("FFStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tình trạng">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ProgressForm") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <span class='<%# Eval("ProgressForm").ToString()=="0"?"btn default btn-xs red-stripe": Eval("ProgressForm").ToString()=="1"?"btn default btn-xs blue-stripe": Eval("ProgressForm").ToString()=="2"?"btn default btn-xs yellow-stripe":"btn default btn-xs green-stripe" %>'>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProgressForm").ToString()=="0"?"Chờ xử lý": Eval("ProgressForm").ToString()=="1"?"Đang tư vấn": Eval("ProgressForm").ToString()=="2"?"Đang làm hồ sơ":"Hoàn thành hồ sơ" %>'></asp:Label>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                <RowStyle BackColor="#A1DCF2"></RowStyle>
                            </asp:GridView>
                            <%-- End Content --%>
                        </div>
                    </div>
                    </ContentTemplate>
</asp:UpdatePanel>
    <!-- END TABLE PORTLET-->
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
                    <asp:Repeater ID="RpSearchMore" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSearchPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="DLPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="RepeaterKeySearch" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkKeySearch" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="KeySearchPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="RepeaterFilterProgess" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFilterProgess" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                OnClick="FilterProgessPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <!-- END PAGINATOR -->
    </div>
    <span class="label label-primary"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Du Học</label></strong></span>
            <span class="label label-default"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Thực Tập</label></strong></span>
            <span class="label label-success"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Du Lịch</label></strong></span>
            <span class="label label-warning"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Định Cư</label></strong></span>
    <%-- Modal Search --%>
    <div class="modal fade" id="modalSeaarch" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Select Options</h4>
                </div>
                <div class="modal-body background">
                    <div class="row">
                        <div class="col-lg-3">
                            <asp:DropDownList ID="dlRegistration_Type" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="dlEducationLV" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="dlCountryAdvisory" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-lg-2">
                            <asp:Button ID="btnSearchMore" CssClass="btn btn-primary" OnClick="btnSearchMore_Click" runat="server" Text="SEARCH" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Search --%>
    <script>
        function reloadclick() {
            window.location.reload();
        }
    </script>
</asp:Content>

