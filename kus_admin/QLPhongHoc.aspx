<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="QLPhongHoc.aspx.cs" Inherits="kus_admin_QLPhongHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Quản Lý Phòng Học
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../kus_admin/QLPhongHoc.aspx">QL Phòng Học</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-6">
            <h2>Thêm phòng học</h2>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label class="control-label">Hệ thống chi nhánh</label>
                        <asp:DropDownList ID="dlHTChiNhanh" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlHTChiNhanh_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Chọn cơ sở</label>
                        <asp:DropDownList ID="dlQLCoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dlHTChiNhanh" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="form-group">
                <label class="control-label">Dãy</label>
                <asp:TextBox ID="txtDayPhongHoc" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDayPhongHoc" ValidationGroup="validAddNewPH" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa nhập dãy phòng !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Tầng</label>
                <asp:TextBox ID="txtTangPhongHoc" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTangPhongHoc" ValidationGroup="validAddNewPH" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa nhập tầng phòng !"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Số Phòng</label>
                <asp:TextBox ID="txtSoPhong" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtSoPhong" ValidationGroup="validAddNewPH" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa nhập số phòng !"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="btnAddPhongHoc" CssClass="btn btn-primary" ValidationGroup="validAddNewPH" runat="server" OnClick="btnAddPhongHoc_Click" Text="Thêm Phòng Học" />
        </div>
        <div class="col-lg-6">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Danh sách Phòng học thuộc các Cở sở
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
                        <div class="col-lg-1">
                            <a class="btn yellow" data-toggle="modal" href="#modalEditPhongHoc"><i class="fa fa-gear"></i></a>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:GridView ID="gwListPhongHoc" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwListPhongHoc_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="HT Chi Nhánh">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TenHTChiNhanh") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhongHocID" CssClass="display-none" runat="server" Text='<%# Eval("PhongHocID") %>'></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TenHTChiNhanh") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cơ Sở">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TenCoSo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TenCoSo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dãy Phòng">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DayPhong") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("DayPhong") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tầng">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tang") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Tang") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Số Phòng">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("SoPhong") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("SoPhong") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                
                                <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                                <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                <RowStyle BackColor="#A1DCF2"></RowStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
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
    <div class="modal fade" id="modalEditPhongHoc" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/folder-documents-icon.png" width="35" height="35" />
                        Chỉnh sửa thông tin phòng học
                    </h4>
                </div>
                <div class="modal-body background">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label">Hệ thống chi nhánh</label>
                                <asp:DropDownList ID="dlEditChiNhanh" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Chọn cơ sở</label>
                                <asp:DropDownList ID="dlEditCoSo" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <label class="control-label">Dãy</label>
                        <asp:TextBox ID="txtEditDayPH" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEditDayPH" ValidationGroup="validEditPH" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa nhập dãy phòng !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Tầng</label>
                        <asp:TextBox ID="txtEditTangPH" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtEditTangPH" ValidationGroup="validEditPH" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa nhập tầng phòng !"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Số Phòng</label>
                        <asp:TextBox ID="txtEditSoPhong" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtEditSoPhong" ValidationGroup="validEditPH" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Chưa nhập số phòng !"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnUpdatePhongHoc" CssClass="btn btn-primary" ValidationGroup="validEditPH" OnClick="btnUpdatePhongHoc_Click" runat="server" Text="Update" />
                    <a class="btn yellow" data-dismiss="modal" >Hủy</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

