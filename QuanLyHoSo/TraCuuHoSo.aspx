<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="TraCuuHoSo.aspx.cs" Inherits="QuanLyHoSo_TraCuuHoSo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Tra Cứu Hồ Sơ
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/TraCuuHoSo.aspx">Tra cứu hồ sơ</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-8">
            <div class="form-horizontal">
                <h4><i>Bộ Hồ Sơ</i></h4>
                <div class="form-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <%-- /Row --%>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label bold col-md-4">Mã Hồ Sơ : </label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtProfileCode" CssClass="form-control" Text="160400001004" runat="server"></asp:TextBox>
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
        <div class="col-lg-12">
            <h4><i>Thông Tin Hồ Sơ</i></h4>
            <div class="form-horizontal">
                <div class="form-body">
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Loại Hồ Sơ : </label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="dlLoaiHoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6"></div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Họ Tên Khách Hàng : </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">CMND Khách Hàng : </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Địa chỉ Email : </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-4">Số điện thoại : </label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- /Row --%>
                    <div class="row">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6 text-right">

                            <a id="btnRefreshSearch" class="btn btn-default" runat="server"><i class="fa fa-refresh"></i>&nbsp Refresh</a>
                            <a id="btnSearchHocVien" class="btn btn-default" runat="server"><i class="fa fa-search"></i>&nbsp Tìm</a>

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
                    <span class="caption-subject bold font-yellow-casablanca uppercase">Danh sách Hồ Sơ </span>
                    <span class="caption-helper">( Có
                        <asp:Label ID="lblsumketqua" runat="server" Text="0"></asp:Label>
                        kết quả tìm thấy...)</span>
                </div>
                <div class="actions">

                    <a id="btnRefreshListHocVien" class="btn btn-circle btn-icon-only btn-default" title="Làm mới danh sách" runat="server">
                        <i class="fa fa-refresh"></i>
                    </a>
                    <a class="btn btn-circle btn-icon-only btn-default fullscreen" href="#"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:GridView ID="gwListHocVien" CssClass="table table-condensed" runat="server"
                    AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
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

