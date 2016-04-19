<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="kus_admin_Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Danh Mục Sách
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                Quản lý học tập
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/Books.aspx">Books</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-edit"></i>Danh mục quản lý sách và giáo trình đào tạo
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <asp:Button ID="btnreload" CssClass="btn green" runat="server" Text="refresh" />
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body background">
                <div class="row">
                    <div class="col-lg-12">
                        <%-- Gridview Books --%>
                        <asp:GridView ID="gvBook" runat="server" CssClass="table table-condensed" AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="gvBook_RowCancelingEdit" OnRowDeleting="gvBook_RowDeleting" OnRowEditing="gvBook_RowEditing" OnRowUpdating="gvBook_RowUpdating" OnRowDataBound="gvBook_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBook_ID" runat="server" Text='<%# Bind("BookID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("BookCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên Sách  - Giáo Trình">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Text='<%# Bind("BookName") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tên Sách chưa nhập !" ForeColor="Red"
                                            ControlToValidate="txtName" Display="Dynamic" ValidationGroup="validUpdateBook"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("BookName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddName" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tên Sách chưa nhập !" ForeColor="Red"
                                            ControlToValidate="txtAddName" Display="Dynamic" ValidationGroup="validAddBook"></asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tác giả">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAuthor" CssClass="form-control" runat="server" Text='<%# Bind("Author") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nhà Xuất Bản">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPublisher" CssClass="form-control" runat="server" Text='<%# Bind("Publisher") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Publisher") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddPublisher" runat="server" CssClass="form-control"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày Xuất Bản">
                                    <EditItemTemplate>
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <asp:TextBox ID="txtNgayXB" CssClass="form-control" Text='<%# Eval("NgayXB", "{0:dd-MM-yyyy}") %>' runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("NgayXB", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <asp:TextBox ID="txtAddNXB" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </FooterTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SốTrang">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSoTrang" CssClass="form-control" runat="server" Text='<%# Bind("SoTrang") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                            ControlToValidate="txtSoTrang" ValidationGroup="validUpdateBook" ValidationExpression="^[0-9]+$" ForeColor="Red" runat="server" ErrorMessage="Số trang chỉ được nhập số !"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("SoTrang") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddSoTrang" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                            ControlToValidate="txtAddSoTrang" ValidationGroup="validAddBook" ValidationExpression="^[0-9]+$" ForeColor="Red" runat="server" ErrorMessage="Số trang chỉ được nhập số !"></asp:RegularExpressionValidator>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hình thức">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtHinhThuc" CssClass="form-control" runat="server" Text='<%# Bind("HinhThuc") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("HinhThuc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddHinhThuc" runat="server" CssClass="form-control"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngôn ngữ">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLanguages" CssClass="form-control" runat="server" Text='<%# Bind("Languages") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Languages") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddLanguage" runat="server" CssClass="form-control"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblSelectBook" runat="server" CausesValidation="False" CommandName="Select" ToolTip="Select" Text="Select"><img src="../images/icon/Cursor-Select-icon.png" width="28" height="28" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="validUpdateBook" CausesValidation="True" CommandName="Update" ToolTip="Confirm Update" Text="Update"><img src="../images/icon/ok-icon.png" width="25" height="25" /></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update" Text="Cancel"><img src="../images/icon/Actions-dialog-close-icon.png" width="25" height="25" /></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" ToolTip="Edit" Text="Edit"><img src="../images/icon/Gear-icon.png" width="28" height="28" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBtnDel" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="28" height="28" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Button ID="btnAddNew" runat="server" Text="Thêm" CssClass="btn green" ToolTip="New" OnClick="btnAddNew_Click" ValidationGroup="validAddBook" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                            <RowStyle BackColor="#A1DCF2"></RowStyle>
                            <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                        </asp:GridView>
                        <%-- End Gridview Books --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

