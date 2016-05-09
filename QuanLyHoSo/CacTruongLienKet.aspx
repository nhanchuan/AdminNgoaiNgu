<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="CacTruongLienKet.aspx.cs" Inherits="QuanLyHoSo_CacTruongLienKet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/admin/category.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Các Trường Liên Kết
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../ChuongTrinhHoc/CacTruongLienKet.aspx">Các Trường Liên Kết</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="icon-grid"></i>Thông tin Trường liên kết
               
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
                        <%-- /Update panel --%>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Tên Trường</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtSchoolName" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSchoolName_TextChanged" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSchoolName" ValidationGroup="validNewtxtSchool" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên trường không được để trống !"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblSchoolNameExist" ForeColor="Red" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Năm thành lập</label>
                                            <div class="col-md-8">
                                                <%-- Date picker --%>
                                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                    <asp:TextBox ID="txtEstablish" CssClass="form-control" runat="server"></asp:TextBox>
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
                                            <label class="control-label bold col-md-4">WebSite Trường (http://www.schoool.edu.com)</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtWebSite" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Địa Chỉ</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Số Điện Thoại</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                    <label class="control-label bold col-md-4">Quốc Gia</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="dlCountry" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlCountry_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label bold col-md-4">Cấp Độ Trường</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="dlSchoollvl" AutoPostBack="true" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="0">-- Chọn cấp độ trường --</asp:ListItem>
                                                            <asp:ListItem Value="1">Cấp 2 , 3</asp:ListItem>
                                                            <asp:ListItem Value="2">Cao Đẳng</asp:ListItem>
                                                            <asp:ListItem Value="3">Đại Học</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- /Row --%>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label bold col-md-4">Tỉnh / Thành  - Tiểu Bang</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="dlProvinces" AutoPostBack="true" OnSelectedIndexChanged="dlProvinces_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label bold col-md-4">About Link</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtAboutLink" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label bold col-md-4">Quận  - Huyện / (* TP Thuộc Tiểu Bang)</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="dlDistrict" CssClass="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label bold col-md-4">Google Map Link(API)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtGooGleMap" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <h4><i>More Information</i></h4>
                                <hr />
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Học Phí (USD/Năm)</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtHocPhi" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Phí Khác (USD/Năm)</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPhiKhac" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Đặt Cọc (USD/Năm)</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtDatCoc" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Học Bổng</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtHocBong" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Điều kiện nhập học</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtDieuKiennhaphoc" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Chuyên ngành nổi bật</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtChuyenNganh" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- End update panel --%>
                        <asp:Label ID="lblExceptionNew" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                    <div class="form-actions right">
                        <a class="btn btn-default">Cancel</a>
                        <asp:Button ID="btnSaveNew" CssClass="btn blue" ValidationGroup="validNewtxtSchool" OnClick="btnSaveNew_Click" runat="server" Text="Thêm Trường" />
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
                    <span class="caption-subject bold font-yellow-casablanca uppercase">Danh sách trường liên kết </span>
                    <span class="caption-helper">Có
                        <asp:Label ID="lblSumSchools" runat="server" Text="Label"></asp:Label>
                        trường...</span>
                </div>
                <div class="inputs">
                    <div class="portlet-input input-inline input-medium">
                        <div class="input-group">
                            <input id="txtsearchSchool" type="text" class="form-control input-circle-left" placeholder="search..." title="Tìm Trường" runat="server" />
                            <span class="input-group-btn">
                                <button id="btnSearchSchools" class="btn btn-circle-right btn-default" type="submit" onserverclick="btnSearchSchools_ServerClick" runat="server">Go!</button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="actions">
                    <a id="btnchangeImg" title="Thay đổi ảnh đại diện" href="#modalselectimages" data-toggle="modal" runat="server">
                        <i class="fa fa-file-image-o"></i>
                    </a>
                    <%--<a class="btn btn-circle btn-icon-only btn-default" title="Xuất danh sách Excel" href="#">
                        <i class="fa fa-file-excel-o"></i>
                    </a>--%>
                    <a href="#modalEditShool" data-toggle="modal" id="btnEditTruong" title="Chỉnh sửa thông tin Trường" runat="server">
                        <i class="icon-wrench"></i>
                    </a>
                    <a id="btnRefreshLstKhoaHoc" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" runat="server" href="#">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:GridView ID="gwInternationalSchool" CssClass="table table-condensed" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" 
                    OnSelectedIndexChanged="gwInternationalSchool_SelectedIndexChanged" OnRowDataBound="gwInternationalSchool_RowDataBound" OnRowDeleting="gwInternationalSchool_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                <asp:Label ID="lblSchoolID" CssClass="display-none" runat="server" Text='<%# Eval("SchoolID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên Trường">
                            <HeaderTemplate>
                                Tên Trường: 
                                                   
                                                    <asp:DropDownList ID="dlSchoolName" CssClass="text-info" AppendDataBoundItems="true" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-lg-1">
                                        <img src='<%# string.IsNullOrEmpty(Eval("ImagesUrl").ToString())?"../images/default_images.jpg": "../" + Eval("ImagesUrl") %>' style="width: 85px; height: auto;" />
                                    </div>
                                    <div class="col-lg-11" style="padding-left: 45px;">
                                        <asp:Label ID="lblSchoolName" CssClass="bold uppercase" runat="server" Text='<%# Bind("SchoolName") %>'></asp:Label>
                                        <div class="col-md-12">
                                            <i class="fa fa-building"></i>
                                            <asp:Label ID="lblSchoolAddress" runat="server" Text='<%# Bind("SchoolAddress") %>'></asp:Label><br />
                                            <i class="fa fa-phone"></i>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Học Phí">
                            <ItemTemplate>
                                <asp:Label ID="lblHocPhi" ForeColor="Red" runat="server" Text='<%# "$"+ Eval("HocPhi") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phí khác">
                            <ItemTemplate>
                                <asp:Label ID="lblPhiKhac" runat="server" Text='<%# "$"+ Eval("PhiKhac","{0:0,0.0}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Điều kiện nhập học">
                            <ItemTemplate>
                                <asp:Label ID="lblDieuKienNhapHoc" runat="server" Text='<%# Eval("DieuKienNhapHoc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cấp bậc">
                            <HeaderTemplate>
                                Cấp bậc:
                               
                                <asp:DropDownList ID="dlSchoolLvl" CssClass="text-info" AppendDataBoundItems="true" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("SchoolLvl") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quốc Gia">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href='<%# Eval("WebSite") %>' target="_blank"><i class="fa fa-globe"></i>WebSite</a>
                            </ItemTemplate>
                            <ItemStyle Width="90px" />
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
                                        <asp:LinkButton ID="lnksearchPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="Page_SearchChanged" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
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

    <%-- Modal Edit School --%>
    <div id="modalEditShool" class="modal fade modal-scroll" tabindex="-1" data-replace="true" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-sliders"></i>Chỉnh sửa thông tin Trường
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-body">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Tên Trường</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtESchoolName" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtESchoolName_TextChanged" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtESchoolName" ValidationGroup="validUpdateSchool" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên trường không được để trống !"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblESchoolNameExist" ForeColor="Red" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Năm thành lập</label>
                                                <div class="col-md-8">
                                                    <%-- Date picker --%>
                                                    <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                        <asp:TextBox ID="txtEEstablish" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                <label class="control-label bold col-md-4">WebSite Trường</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEWebsite" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Địa Chỉ</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtESchoolAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Số Điện Thoại</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEphone" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                        <label class="control-label bold col-md-4">Quốc Gia</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="dlECountry" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlECountry_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label bold col-md-4">Cấp Độ Trường</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtESchoolLvl" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- /Row --%>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label bold col-md-4">Tỉnh / Thành  - Tểu Bang</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="dlEProvince" AutoPostBack="true" OnSelectedIndexChanged="dlEProvince_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label bold col-md-4">About Link</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtEAboutLink" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label bold col-md-4">Quận  - Huyện</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="dlEDistrict" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label class="control-label bold col-md-4">Google Map Link(API)</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txtEGoogleMap" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dlECountry" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <h4><i>More Information</i></h4>
                                    <hr />
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Học Phí (USD/Năm)</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEHocPhi" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Phí Khác (USD/Năm)</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEPhikhac" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Đặt Cọc (USD/Năm)</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEDatCoc" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Học Bổng</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEHocBong" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- /Row --%>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label bold col-md-4">Điều kiện nhập học</label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEdiuKienHocTap" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                            <label class="control-label bold col-md-4">Chuyên ngành nổi bật</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtEChuyennganh" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%-- End update panel --%>
                            <asp:Label ID="lblExeptionEditSchool" ForeColor="Red" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn">Close</button>
                    <asp:Button ID="btnSaveEditSchool" CssClass="btn btn-primary" ValidationGroup="validUpdateSchool" OnClick="btnSaveEditSchool_Click" runat="server" Text="Lưu thông tin" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal --%>


    <%-- Modal Select Category Images --%>
    <div class="modal fade" id="modalselectimages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">
                        <img src="../images/icon/add-icon.png" width="28" height="28" />
                        Ảnh chức năng cho chuyên mục</h4>
                </div>
                <div class="modal-body">
        <div class="panel-default">
            <div class="panel-body">
                <div class="col-lg-9">
                    <div class="col-lg-12">
                        <div style="height: 700px; overflow: auto;">
                            <div class="grid-container">
                                <ul class="rig columns-5">
                                    <asp:Repeater ID="rpLstImg" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <a href='<%#"../"+Eval("ImagesUrl") %>' onclick="return showanh(this.href)"">
                                                                        <img src='<%#"../"+Eval("ImagesUrl") %>' />
                                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
                                                                        <p><i class="fa fa-clock-o"></i><%# Eval("DateOfStart") %></p>
                                                  </a>
                                              </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <%-- info --%>
                    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="vlidSelectImage" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" runat="server" />
                    <asp:Image ID="ImagesSelect" CssClass="img-responsive" runat="server" />
                    <br />
                    <asp:HiddenField ID="HiddenimgSelect" runat="server" />
                    <label>Url Image:</label>
                    <asp:TextBox ID="txtImgUrl" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImgUrl" ValidationGroup="vlidSelectImage" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                    <%-- end info --%>
                </div>
            </div>
        </div>

    </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal"> Cancel</a>
                    <asp:Button ID="btnselectimages" CssClass="btn btn-primary pull-right" ValidationGroup="vlidSelectImage" OnClick="btnselectimages_Click" runat="server" Text="Chọn ảnh tiêu biểu" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Select Category Images --%>
    <script type="text/javascript">
        function showanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesSelect.ClientID %>').src = url;
            document.getElementById('<%=HiddenimgSelect.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrl.ClientID %>').value = url;
            return false;
        }
    </script>
</asp:Content>

