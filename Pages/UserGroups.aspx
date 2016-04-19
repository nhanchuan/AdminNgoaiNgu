<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="UserGroups.aspx.cs" Inherits="Pages_UserGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Nhóm Thành Viên
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/UserGroups.aspx">User Groups</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <h3>Thêm Nhóm Thành Viên</h3>
            <br />
            <div class="form-group">
                <label class="control-label">Nhóm Thành Viên</label>
                <asp:TextBox ID="txtDepGroup" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDepGroup" ValidationGroup="validNewGroups" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Tên nhóm không được để trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Quản lý</label>
                <asp:DropDownList ID="dlManager" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddGroup" CssClass="btn btn-primary" ValidationGroup="validNewGroups" OnClick="btnAddGroup_Click" runat="server" Text="Thêm Nhóm" />
            </div>
        </div>
        <div class="col-lg-8">
            <div class="row">
                <div class="col-lg-12">
                    <a id="btnAuthentication" class="btn btn-danger" href="#modalAuthentication" data-toggle="modal" runat="server"><i class="fa fa-group"></i>Authentication Groups</a>
                </div>
            </div>
            <asp:GridView ID="gwListDepartments" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                OnRowDataBound="gwListDepartments_RowDataBound" OnRowDeleting="gwListDepartments_RowDeleting" OnSelectedIndexChanged="gwListDepartments_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Phòng/Ban">
                        <ItemTemplate>
                            <asp:Label ID="lblDepartmentsID" CssClass="display-none" runat="server" Text='<%# Eval("DepartmentsID") %>'></asp:Label>
                            <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trưởng Phòng/Ban">
                        <ItemTemplate>
                            <asp:Label ID="lblManager" runat="server" Text='<%# Eval("EmployeesCode")+" - "+ Eval("LastName")+" "+Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số lượng thành viên">
                        <ItemTemplate>
                            <asp:Label ID="lblNumEmp" runat="server" Text='<%#Eval("NumEmp") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkBtnDel" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="20" height="20" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
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
        </div>
    </div>
    <%-- Modal Authentication --%>
    <div class="modal fade" id="modalAuthentication" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/Actions-im-ban-user-icon.png" width="35" height="35" />
                        Authentication Groups
                    </h4>
                </div>
                <div class="modal-body background">
                    <div style="height: 500px; overflow: auto;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
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
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnSaveFuntion" CssClass="btn btn-primary" OnClick="btnSaveFuntion_Click" runat="server" Text="Save" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Authentication --%>
</asp:Content>

