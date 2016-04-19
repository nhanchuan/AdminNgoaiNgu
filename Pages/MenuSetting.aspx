<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="MenuSetting.aspx.cs" Inherits="Pages_MenuSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Menu Setting
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/MenuSetting.aspx">Menu setting</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-5">
            <h2>Thêm Mục vào Menu Chính</h2>
            <div class="form-group">
                <label class="control-label">Tên Menu : </label>
                <asp:TextBox ID="txtItemname" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtItemname" ValidationGroup="validNewMenu" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên menu không được để trống !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label"> Đường dẫn tĩnh : </label>
                <asp:TextBox ID="txtPermalink" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddMenuItem" CssClass="btn btn-primary" ValidationGroup="validNewMenu" OnClick="btnAddMenuItem_Click" runat="server" Text="Thêm Mục" />
            </div>
        </div>
        <div class="col-lg-7">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Tên Menu</label>
                                        <asp:TextBox ID="txtEditItemname" AutoPostBack="true" OnTextChanged="txtEditItemname_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEditItemname" ValidationGroup="validEditMenu" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Tên menu không được để trống !"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="control-label">Permalink</label>
                                        <asp:TextBox ID="txtEPermalink" AutoPostBack="true" OnTextChanged="txtEPermalink_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <h4><i>Menu Index :
                                        <asp:Label ID="lblEIndex" runat="server" Text="Label"></asp:Label></i></h4>
                                    <asp:Label ID="lblWaringEdit" ForeColor="Red" runat="server"></asp:Label>
                                </div>
                                <div class="col-lg-2">
                                    <br />
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" ValidationGroup="validEditMenu" OnClick="btnSubmit_Click" Enabled="false" runat="server" Text="Submit" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <asp:GridView ID="gwMenuItems" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwMenuItems_SelectedIndexChanged" OnRowDataBound="gwMenuItems_RowDataBound" OnRowDeleting="gwMenuItems_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="DB_ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuID" runat="server" Text='<%# Eval("MenuID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Menu Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Đường dẫn tĩnh">
                                <ItemTemplate>
                                    <asp:Label ID="lblPermalink" runat="server" Text='<%# Eval("Permalink") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnUp" CommandArgument='<%# Eval("MenuID") %>' OnClick="lkbtnUp_Click" runat="server"><i class="fa fa-caret-square-o-up" style="font-size:20px;"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbtnDown" CommandArgument='<%# Eval("MenuID") %>' OnClick="lkbtnDown_Click" runat="server"><i class="fa fa-caret-square-o-down" style="font-size:20px;"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
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

                    <div class="form-group">
                        <h3><i class="fa fa-cubes"></i>Sub Mennu Setting</h3>
                    </div>
                    <div class="form-group">
                        
                        <div class="input-group">
                            <div class="input-icon">
                                <i class="fa fa-search"></i>
                                <asp:DropDownList ID="dlSelectCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                                
                            </div>
                            <span class="input-group-btn">
                                <button id="btnInsertItemtoMenu" class="btn btn-success" type="button" ValidationGroup="validChoseCategory" onserverclick="btnInsertItemtoMenu_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Thêm vào Menu</button>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="dlSelectCategory"
                            ValidationGroup="validChoseCategory"
                            Display="Dynamic"
                            ForeColor="Red"
                            ErrorMessage="Chưa chọn danh mục !"
                            InitialValue="0">
                        </asp:RequiredFieldValidator>
                        <i><asp:Label ID="lblAddSubItemWaring" ForeColor="Red" runat="server"></asp:Label></i>
                    </div>
                    <asp:GridView ID="gwSubMenuItem" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="gwSubMenuItem_RowDataBound" OnRowDeleting="gwSubMenuItem_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="CMenuID">
                                <ItemTemplate>
                                    <asp:Label ID="lblCMenuID" runat="server" Text='<%# Eval("CMenuID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Menu">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thuộc Menu">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbtnSubUp" CommandArgument='<%# Eval("CMenuID") %>' OnClick="lkbtnSubUp_Click" runat="server"><i class="fa fa-caret-square-o-up" style="font-size:20px;"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbtnSubDown" CommandArgument='<%# Eval("CMenuID") %>' OnClick="lkbtnSubDown_Click" runat="server"><i class="fa fa-caret-square-o-down" style="font-size:20px;"></i></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkBtnDelSubItem" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="20" height="20" /></asp:LinkButton>
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
                        <HeaderStyle BackColor="#0099ff" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#FAF3DF"></RowStyle>
                    </asp:GridView>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gwMenuItems" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

