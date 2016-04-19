<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QuanLyGioHoc.aspx.cs" Inherits="kus_admin_QuanLyGioHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css"/>
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản Lý Giờ Học
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QuanLyGioHoc.aspx">Giờ học</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <h1>Giờ học và thi tại trung tâm</h1>
        <div class="clearfix"></div>
        <div class="col-lg-12">
            <p class="font-blue bold" style="font-size: 18px;">1. Giờ học lý thuyết và thực hành các kĩ năng</p>
            
            <asp:GridView ID="gvGioHoc" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvGioHoc_RowCancelingEdit" OnRowEditing="gvGioHoc_RowEditing" OnRowUpdating="gvGioHoc_RowUpdating" OnRowDataBound="gvGioHoc_RowDataBound" OnRowDeleting="gvGioHoc_RowDeleting" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Tiết Học">
                        <EditItemTemplate>
                            <asp:Label ID="lblGioHoc_ID" CssClass="display-none" runat="server" Text='<%# Bind("GioHocID") %>'></asp:Label>
                            <asp:Label ID="lblETietHoc" runat="server" Text='<%# Bind("TietHoc") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TietHoc") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewTietHoc" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewTietHoc" ValidationGroup="validNewGioHoc" ForeColor="Red" Display="Dynamic">Tiết học không được bỏ trống !</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giờ bắt đầu Tiết">
                        <EditItemTemplate>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtEditStartTime" Text='<%# Eval("StartTime","{0:hh:mm:ss tt}") %>' Font-Size="12" CssClass="form-control timepicker timepicker-no-seconds" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                    </span>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" runat="server" Text='<%# Eval("StartTime","{0:hh:mm:ss tt}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtAddStartTime" Font-Size="12" CssClass="form-control timepicker timepicker-no-seconds" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                    </span>
                                </div>
                            </div>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giờ kết thúc Tiết">
                        <EditItemTemplate>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtEditEndTime" Text='<%# Eval("EndTime","{0:hh:mm:ss tt}") %>' Font-Size="12" CssClass="form-control timepicker timepicker-no-seconds" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                    </span>
                                </div>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime" runat="server" Text='<%# Eval("EndTime","{0:hh:mm:ss tt}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtAddEndTime" Font-Size="12" CssClass="form-control timepicker timepicker-no-seconds" runat="server"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                    </span>
                                </div>
                            </div>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buổi Học">
                        <ItemTemplate>
                            <asp:Label ID="lblDelGioHoc_ID" CssClass="display-none" runat="server" Text='<%# Bind("GioHocID") %>'></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("BuoiHocID").ToString()=="1"?"Sáng": Eval("BuoiHocID").ToString()=="2"?"Chiều": Eval("BuoiHocID").ToString()=="3"?"Tối":"" %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="dlNewBuoiHoc" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">------</asp:ListItem>
                                <asp:ListItem Value="1">Sáng</asp:ListItem>
                                <asp:ListItem Value="2">Chiều</asp:ListItem>
                                <asp:ListItem Value="3">Tối</asp:ListItem>
                            </asp:DropDownList>
                        </FooterTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkSelect" runat="server" CausesValidation="False" CommandName="Select" Text="Select"><img src="../images/icon/Cursor-Select-icon.png" width="28" height="28" /></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lkUpdate" runat="server" ValidationGroup="valibUpdateGioHoc" CausesValidation="True" CommandName="Update" Text="Update"><img src="../images/icon/ok-icon.png" width="25" height="25" /></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"><img src="../images/icon/Actions-dialog-close-icon.png" width="25" height="25" /></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"><img src="../images/icon/Gear-icon.png" width="28" height="28" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkDelGiohoc" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="28" height="28" /></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnNewGioHoc" CssClass="btn green" ValidationGroup="validNewGioHoc" runat="server" Text="Thêm" OnClick="btnNewGioHoc_Click" />
                    </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#A1DCF2"></RowStyle>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
            </asp:GridView>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ValidationGroup="valibUpdateGioHoc" ShowSummary="false" DisplayMode="BulletList" HeaderText="Lỗi" />
        </div>
        <div class="col-lg-12">
             <p class="font-blue bold" style="font-size: 18px;">2. Giờ thi lý thuyết và thi trắc nghiệm trực tuyến</p>

            <asp:GridView ID="gvGioThi" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvGioThi_RowCancelingEdit" OnRowEditing="gvGioThi_RowEditing" OnRowUpdating="gvGioThi_RowUpdating" OnRowDataBound="gvGioThi_RowDataBound" OnRowDeleting="gvGioThi_RowDeleting" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Tiết Thi">
                        <EditItemTemplate>
                            <asp:Label ID="lblGioThi_ID" CssClass="display-none" runat="server" Text='<%# Bind("GioThiID") %>'></asp:Label>
                            <asp:TextBox ID="txtTietThi" CssClass="form-control" runat="server" Text='<%# Bind("Tiet") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Tiết thi không được bỏ trống !" ControlToValidate="txtTietThi" ValidationGroup="validUpdategioThi" Display="None"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Tiet") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddTietThi" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                runat="server" 
                                ErrorMessage="Tiết thi không được bỏ trống !" 
                                ControlToValidate="txtAddTietThi"
                                ValidationGroup="validAddGioThi"
                                ForeColor="Red" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Giờ Thi">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGioThi" CssClass="form-control" runat="server" Text='<%# Bind("Gio") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Giờ thi không được bỏ trống & phải là chữ & số" ControlToValidate="txtGioThi" ValidationGroup="validUpdategioThi" Display="None"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDelGioThi_ID" CssClass="display-none" runat="server" Text='<%# Bind("GioThiID") %>'></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Gio") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAddGioThi" CssClass="form-control" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" ValidationGroup="validUpdategioThi" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkDelGioThi" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnAddGioThi" ValidationGroup="validAddGioThi" CssClass="btn green" OnClick="btnAddGioThi_Click" runat="server" Text="Thêm" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                <RowStyle BackColor="#A1DCF2"></RowStyle>
                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
            </asp:GridView>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="true" ValidationGroup="validUpdategioThi" ShowSummary="false" DisplayMode="BulletList" HeaderText="Lỗi" />
        </div>
    </div>
    <script type="text/javascript" src="../assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
</asp:Content>

