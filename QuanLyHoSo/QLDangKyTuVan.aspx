<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QLDangKyTuVan.aspx.cs" Inherits="QuanLyHoSo_QLDangKyTuVan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản Lý Đăng ký tư vấn <small>Registration Form Advisory Manager</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../QuanLyHoSo/QLDangKyTuVan.aspx">QL Đăng ký tư vấn</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12">
            <a class="btn green" href="../QuanLyHoSo/PhieuDangKyTuVan.aspx">Phiếu Đăng ký Tư Vấn</a>
            <a class="btn btn-primary" href="../QuanLyHoSo/CheckFormAdvisory.aspx">Kiểm tra phiếu chuyển</a>
        </div>
        <hr />
        <div class="clearfix"></div>
        <div class="col-lg-12">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <!-- BEGIN USERS TABLE PORTLET-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-edit"></i>Danh sách Đăng ký tư vấn
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <%--<button id="btnreload" class="btn green" onserverclick="btnreload_ServerClick" runat="server"><i class="fa fa-refresh"></i></button>--%>
                                <asp:Button ID="btnreload" CssClass="btn green" OnClick="btnreload_ServerClick" runat="server" Text="refresh" />
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body background">
                            <div class="row">
                                <div class="col-lg-1">
                                    <asp:Button ID="btnSelectAll" CssClass="btn orange" OnClick="btnSelectAll_Click" runat="server" Text="Select All" />
                                    <asp:Button ID="btnUncheckAll" CssClass="btn orange" OnClick="btnUncheckAll_Click" runat="server" Text="Uncheck All" />
                                </div>
                                <div class="col-lg-1">
                                    <%--<asp:Button ID="btnRemove" CssClass="btn red" OnClick="btnRemove_Click" runat="server" Text="Xóa Phiếu" />--%>
                                    <a href="#modalDelete" class="btn red" data-toggle="modal">Xóa Phiếu</a>
                                </div>
                                <div class="col-lg-4">
                                    <div class="input-group">
                                        <div class="input-icon">
                                            <i class="fa fa-qq"></i>
                                            <asp:DropDownList ID="dlEmployeesAdvisory" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                        <span class="input-group-btn">
                                            <button id="btnSendAdv" class="btn btn-warning" type="button" onserverclick="btnSendAdv_ServerClick" runat="server"><i class="fa fa-send"></i> Chuyển Phiếu</button>
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
                                            <a class="btn btn-info" style="margin-left:5px;" data-toggle="modal" href="#modalSeaarch">Search more</a>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <asp:GridView ID="gwAdvisoryManager" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">

                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkrow" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
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

                                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

                                <RowStyle BackColor="#A1DCF2"></RowStyle>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="form-group">
                        <!-- BEGIN PAGINATOR -->
                        <div class="row">
                            <div class="col-md-4 col-sm-4 items-info">
                                <%--<div id="divrownumber" runat="server">
                            Items
                                    <asp:Label ID="lblstartindex" runat="server"></asp:Label>
                            to
                                    <asp:Label ID="lblendindex" runat="server"></asp:Label>
                            of
                            <asp:Label ID="lbltotalRecord" runat="server"></asp:Label>
                            total
                        </div>
                        <div id="divsearch" runat="server">
                            Items
                                    <asp:Label ID="lblsearchstart" runat="server"></asp:Label>
                            to
                                    <asp:Label ID="lblsearchend" runat="server"></asp:Label>
                            of
                            <asp:Label ID="lbltotalSearchDl" runat="server"></asp:Label>
                            total
                        </div>--%>
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
                                    <asp:Repeater ID="Repeatersearch" runat="server">
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
                                </div>
                            </div>
                        </div>
                        <!-- END PAGINATOR -->
                    </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--<asp:Timer ID="timerReloadGrw" OnTick="timerReloadGrw_Tick" runat="server"></asp:Timer>--%>
            <span class="label label-primary"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Du Học</label></strong></span>
            <span class="label label-default"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Thực Tập</label></strong></span>
            <span class="label label-success"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Du Lịch</label></strong></span>
            <span class="label label-warning"><strong><i class="fa fa-pencil-square-o"></i> <label>Tư Vấn Định Cư</label></strong></span>
        </div>
        
    </div>

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

    <%-- Modal Delete --%>
    <div class="modal fade" id="modalDelete" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title"><i class="fa fa-remove"></i>Xóa Phiếu Tư Vấn</h4>
                </div>
                <div class="modal-body background">
                    <h2 class="label label-danger">Bạn có chắc muốn xóa phiếu tư vấn !</h2>
                </div>
                <div class="modal-header text-right">
                    <asp:Button ID="btnRemove" CssClass="btn red" OnClick="btnRemove_Click" runat="server" Text="Xóa Phiếu" />
                    <a class="btn btn-warning" data-dismiss="modal" aria-hidden="true">Hủy</a>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Delete --%>
   
</asp:Content>

