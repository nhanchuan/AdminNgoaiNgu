<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="HTCoSo.aspx.cs" Inherits="kus_admin_HTCoSo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Hệ Thống Cơ sở
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/HTCoSo.aspx">HT Cơ Sở</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-edit"></i>Danh Sách Hệ thống Cơ sở đào tạo
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
                        <%-- Gridview HT Cơ sở --%>
                        <asp:GridView ID="gvCoSo" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="gvCoSo_RowCancelingEdit" OnRowDataBound="gvCoSo_RowDataBound" OnRowDeleting="gvCoSo_RowDeleting" OnRowEditing="gvCoSo_RowEditing" OnRowUpdating="gvCoSo_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCoSo_ID" runat="server" Text='<%# Bind("CoSoID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cơ Sở">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCoSo" runat="server" Text='<%# Bind("TenCoSo") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("TenCoSo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddCoSo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Cơ sở không được bỏ trống !"
                                            ControlToValidate="txtAddCoSo" Display="Dynamic" ForeColor="Red" ValidationGroup="ValidAddCoSo"></asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Địa chỉ">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDiaChi" runat="server" Text='<%# Bind("DiaChi") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DiaChi") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Địa chỉ không được bỏ trống"
                                            ControlToValidate="txtAddDiaChi" Display="Dynamic" ValidationGroup="Error"></asp:RequiredFieldValidator>--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fax">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFax" runat="server" Text='<%# Bind("Fax") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Fax") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddFax" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fax không được bỏ trống"
                                            ControlToValidate="txtAddFax" Display="Dynamic" ValidationGroup="Error"></asp:RequiredFieldValidator>--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("Phone") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddPhone" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Phone không được bỏ trống"
                                            ControlToValidate="txtAddPhone" Display="Dynamic" ValidationGroup="Error"></asp:RequiredFieldValidator>--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                        ControlToValidate="txtAddEmail"
                                        ValidationGroup="ValidAddCoSo"
                                        ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ForeColor="Red"
                                        ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                                    </asp:RegularExpressionValidator>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NgayThanhLap">
                                    <EditItemTemplate>
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <asp:TextBox ID="txtNgayThanhLap" CssClass="form-control" Text='<%# Eval("NgayThanhLap", "{0:dd-MM-yyyy}") %>' runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("NgayThanhLap", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <%-- Date picker --%>
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <%--<input type="text" class="form-control" id="txtAddNgayThanhLap" runat="server" />--%>
                                            <asp:TextBox ID="txtAddNgayThanhLap" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                        </div>
                                        <%-- Date picker --%>
                                    </FooterTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ghi chú">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGhiChu" runat="server" Text='<%# Bind("GhiChu") %>' CssClass="form-control"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("GhiChu") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtAddGhiChu" runat="server" CssClass="form-control"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HT Chi Nhánh">
                                    <EditItemTemplate>
                                        <%--<asp:TextBox ID="txthtchinhanhid" runat="server" Text='<%# Eval("TenHTChiNhanh") %>' CssClass="form-control"></asp:TextBox>--%>
                                        <asp:Label ID="lblHTChiNhanhID" CssClass="display-none" runat="server" Text='<%# Eval("HTChiNhanhID") %>'></asp:Label>
                                        <asp:DropDownList ID="dlHTChiNhanh" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("TenHTChiNhanh") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="dlAddHTChiNhanh" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quản lý Cơ Sở">
                                    <EditItemTemplate>
                                        <%--<asp:TextBox ID="txtQLCoSo" runat="server" Text='<%# Bind("QLCoSo") %>' CssClass="form-control"></asp:TextBox>--%>
                                        <asp:Label ID="lblQLCoSo" runat="server" CssClass="display-none" Text='<%# Eval("QLCoSo") %>'></asp:Label>
                                        <asp:DropDownList ID="dlQLCoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("LastName")+" "+Eval("FirstName") %>'></asp:Label><br />
                                        Mã NV :
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmployeesCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="dlAddQLCoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblSelect" runat="server" CausesValidation="False" CommandName="Select" ToolTip="Chọn Cơ sở" Text="Select"><img src="../images/icon/Cursor-Select-icon.png" width="28" height="28" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="validUpdatechinhanh" CausesValidation="True" CommandName="Update" ToolTip="Confirm Update" Text="Update"><img src="../images/icon/ok-icon.png" width="25" height="25" /></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" ToolTip="Cancel Update" Text="Cancel"><img src="../images/icon/Actions-dialog-close-icon.png" width="25" height="25" /></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" ToolTip="Edit" Text="Edit"><img src="../images/icon/Gear-icon.png" width="28" height="28" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkbtnDelete" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Xóa" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="28" height="28" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Button ID="btnAddNew" runat="server" ValidationGroup="ValidAddCoSo" Text="Thêm" CssClass="btn green"  OnClick="btnAddNew_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                            <RowStyle BackColor="#A1DCF2"></RowStyle>
                            <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                        </asp:GridView>
                        <%-- End Gridview Cơ sở --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

