<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Pages_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thành Viên
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Users.aspx">New User</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-12">
            <asp:Button ID="btnAddNew" CssClass="btn green" OnClick="btnAddNew_Click" runat="server" Text="Thêm Mới Thành Viên" />
        </div>

        <div class="clearfix"></div>
        <div class="col-lg-12">
            <div class="panel panel-info">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <a id="btnViewDetail" class="btn btn-info" runat="server"><i class="fa fa-info"></i>Thông tin chi tiết</a>
                            <a id="btnChangeFunction" class="btn btn-warning" href="#modalSetFunction" data-toggle="modal" runat="server"><i class="fa fa-cog"></i>Phân quyền chức năng</a>
                        </div>
                    </div>
                    <asp:GridView ID="gwListUsers" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwListUsers_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="Tên đăng nhập">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" CssClass="display-none" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên">
                                <ItemTemplate>
                                    <a href='<%#"../Pages/UserInfor.aspx?Userid="+Eval("UserID") %>' class="bold"><i class="fa fa-edit"></i> <asp:Label ID="lblFullname" runat="server" Text='<%# Eval("LastName") +" "+ Eval("FirstName") %>'></asp:Label></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thư điện tử">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vai trò">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegency" runat="server" Text='<%# Eval("Regency") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phòng ban">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <i>
                                        <asp:Label ID="lblUserStatus" runat="server" Text='<%# (Eval("UserStatus").ToString()=="1")?"Active":"Deactive" %>'></asp:Label></i>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
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
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <!-- END PAGINATOR -->
                    </div>
                </div>
            </div>

        </div>
    </div>
    <%-- Modal Phân Quyền --%>
    <div class="modal fade" id="modalSetFunction" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Actions-im-ban-user-icon.png" width="35" height="35" />
                        Phân Quyền chức năng
                    </h4>
                </div>
                <div class="modal-body background">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="control-label">Nhóm/Phòng ban : </label>
                                        <asp:DropDownList ID="dlDepartments" AutoPostBack="true" OnSelectedIndexChanged="dlDepartments_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="col-lg-12">
                                    <div style="height: 500px; overflow: auto;">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlSystemall" AutoPostBack="true" OnCheckedChanged="chlSystemall_CheckedChanged" runat="server" />
                                            <label class="control-label">Hệ thống</label>
                                            <asp:CheckBoxList ID="chlSystem" AutoPostBack="true" OnSelectedIndexChanged="chlSystem_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlUsermanagerall" AutoPostBack="true" OnCheckedChanged="chlUsermanagerall_CheckedChanged" runat="server" />
                                            <label class="control-label">Users Manager</label>
                                            <asp:CheckBoxList ID="chlUsermanager" AutoPostBack="true" OnSelectedIndexChanged="chlUsermanager_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlFileManagerall" AutoPostBack="true" OnCheckedChanged="chlFileManagerall_CheckedChanged" runat="server" />
                                            <label class="control-label">File Manager</label>
                                            <asp:CheckBoxList ID="chlFileManager" AutoPostBack="true" OnSelectedIndexChanged="chlFileManager_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlmediaall" AutoPostBack="true" OnCheckedChanged="chlmediaall_CheckedChanged" runat="server" />
                                            <label class="control-label">Media Library</label>
                                            <asp:CheckBoxList ID="chlmedia" AutoPostBack="true" OnSelectedIndexChanged="chlmedia_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlFileall" AutoPostBack="true" OnCheckedChanged="chlFileall_CheckedChanged" runat="server" />
                                            <label class="control-label">QUẢN LÝ HỒ SƠ</label>
                                            <asp:CheckBoxList ID="chlFile" AutoPostBack="true" OnSelectedIndexChanged="chlFile_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlCenterall" AutoPostBack="true" OnCheckedChanged="chlCenterall_CheckedChanged" runat="server" />
                                            <label class="control-label">TRUNG TÂM ANH NGỮ</label>
                                            <asp:CheckBoxList ID="chlCenter" AutoPostBack="true" OnSelectedIndexChanged="chlCenter_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlAdvall" AutoPostBack="true" OnCheckedChanged="chlAdvall_CheckedChanged" runat="server" />
                                            <label class="control-label">MỤC TƯ VẤN</label>
                                            <asp:CheckBoxList ID="chlAdv" AutoPostBack="true" OnSelectedIndexChanged="chlAdv_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                        <div class="form-group">
                                            <asp:CheckBox ID="chlWeball" AutoPostBack="true" OnCheckedChanged="chlWeball_CheckedChanged" runat="server" />
                                            <label class="control-label">WebSite</label>
                                            <asp:CheckBoxList ID="chlWeb" AutoPostBack="true" OnSelectedIndexChanged="chlWeb_SelectedIndexChanged" CssClass="checkbox-list" Style="margin-left: 35px;" runat="server"></asp:CheckBoxList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnSaveFuntion" CssClass="btn btn-primary" OnClick="btnSaveFuntion_Click" runat="server" Text="Save" />
                </div>
            </div>
        </div>
    </div>
    <%-- End modal --%>
</asp:Content>

