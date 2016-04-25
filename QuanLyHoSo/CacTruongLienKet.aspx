<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="CacTruongLienKet.aspx.cs" Inherits="QuanLyHoSo_CacTruongLienKet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <a href="#">Trung tâm anh ngữ</a>
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
                                                <asp:TextBox ID="txtSchoolName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSchoolName" ValidationGroup="validNewtxtSchool" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="Tên trường không được để trống !"></asp:RequiredFieldValidator>
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
                                            <label class="control-label bold col-md-4">WebSite Trường</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtWebSite" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                <asp:TextBox ID="txtPhone" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                        <asp:DropDownList ID="dlSchoollvl" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
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
                                                    <label class="control-label bold col-md-4">Quận  - Huyện</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="dlDistrict" CssClass="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label bold col-md-4">Google Map Link(API)</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Phí Khác (USD/Năm)</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Học Bổng</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /Row --%>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label bold col-md-4">Điều nhập học</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- End update panel --%>
                    </div>
                    <div class="form-actions right">
                        <a class="btn btn-default">Cancel</a>
                        <asp:Button ID="btnSaveNew" CssClass="btn blue" ValidationGroup="validNewtxtSchool" runat="server" Text="Thêm Trường" />
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
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        trường...</span>
                </div>
                <div class="inputs">
                    <div class="portlet-input input-inline input-medium">
                        <div class="input-group">
                            <input id="txtsearch" type="text" class="form-control input-circle-left" placeholder="search..." title="Tìm Trường" runat="server" />
                            <span class="input-group-btn">
                                <button id="btnSearchKhoaHoc" class="btn btn-circle-right btn-default" type="submit" runat="server">Go!</button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="actions">

                    <a class="btn btn-circle btn-icon-only btn-default" title="Xuất danh sách Excel" href="#">
                        <i class="fa fa-file-excel-o"></i>
                    </a>
                    <a id="btnRefreshLstKhoaHoc" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" runat="server" href="#">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:GridView ID="gwKhoaHoc" CssClass="table table-condensed" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
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
                                <%--<asp:Repeater ID="rptPager" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>--%>
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

