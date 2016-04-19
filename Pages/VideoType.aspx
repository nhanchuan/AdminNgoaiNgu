<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="VideoType.aspx.cs" Inherits="Pages_VideoType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .background {
            background: url('../../images/backgrounds/noise_light-grey.jpg');
            font-family: 'Helvetica Neue', arial, sans-serif;
            font-weight: 200;
        }
    </style>
    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">Video Type <small>Danh mục video</small>
    </h3>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Media Library</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/VideoType.aspx">Video Type</a>
            </li>
        </ul>
        <div class="page-toolbar">
            <div id="dashboard-report-range" class="pull-right tooltips btn btn-fit-height grey-salt" data-placement="top" data-original-title="Change dashboard date range">
                <i class="icon-calendar"></i>&nbsp;
						<span class="thin uppercase visible-lg-inline-block">&nbsp;</span>&nbsp;
						<i class="fa fa-angle-down"></i>
            </div>
        </div>
    </div>
    <!-- END PAGE HEADER-->




    <div class="col-lg-5">
        <h2>Thêm loại Video</h2>
        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="validVideoType" DisplayMode="BulletList" ShowMessageBox="false" ShowSummary="true" ForeColor="Red" runat="server" />
        <div class="form-group">
            <label class="control-label">Tên Loại</label>
            <asp:TextBox ID="txtVideotypeName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtVideotypeName" ValidationGroup="validVideoType" runat="server" ErrorMessage="Required" Display="None"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtVideotypeName" Display="None" ValidationGroup="validVideoType" ValidationExpression="^[\sa-zA-Z0-9_-]{0,100}$" runat="server" ErrorMessage="Tên loại Video từ 0-100 ký tự !{Chi gồm các kí tự a-z,A-Z,0-9,-,_}"></asp:RegularExpressionValidator>
            <i>Tên loại để phân loại Video upload.</i>
        </div>
        <div class="form-group">
            <label class="control-label">Mô tả ngắn</label>
            <asp:TextBox ID="txtshortdescription" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <br />
        <asp:Button ID="btnaddnew" ValidationGroup="validVideoType" CssClass="btn btn-primary" OnClick="btnaddnew_Click" runat="server" Text="Thêm Loại" />
    </div>
    <div class="col-lg-7">
        <%-- Gridview --%>
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-edit"></i>Video Type
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a class="reload" id="btnreloadgw" runat="server"></a>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body background">
                <div class="row">
                    <div class="col-lg-5">
                        <a class="btn yellow" href="#modaleditVideotype" data-toggle="modal"><i class="fa fa-cogs"></i></a>
                        <a class="btn red"><i class="fa fa-remove"></i></a>
                    </div>
                </div>
                <br />
                <div class="clearfix"></div>
                <asp:GridView ID="gwVideotype" CssClass="table table-condensed table-responsive" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwVideotype_SelectedIndexChanged" >

                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VideotypeID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblVideoTypeID" runat="server" Text='<%# Bind("VideotypeID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TypeName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Short Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ShortDesciption") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ShortDesciption") %>'></asp:Label>
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
                    <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>

            </div>
        </div>
        <%-- End GridView  --%>
    </div>

    <%-- Modal Edit Video Type --%>
    <div class="modal fade" id="modaleditVideotype" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title"><i class="fa fa-cog"></i>Change Video Type Information</h4>
                </div>
                <div class="modal-body">
                    <label class="label-warning" id="lblnoselect" runat="server">Please Select a Video type !</label>
                    <div id="pannelEdit" runat="server">
                        <div class="form-group">
                            <label class="control-label">Change Name</label>
                            <asp:TextBox ID="txtMname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Change Short Description</label>
                            <asp:TextBox ID="txtMshortDc" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            <i>Mô tả ngắn cho loại Video (Không quá 200 ký tự)</i>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtMshortDc" Display="Dynamic" ForeColor="Red" ValidationGroup="validVideoTypeEdit" ValidationExpression="(.){0,200}" runat="server" ErrorMessage="Mô tả ngắn không quá 200 ký tự !"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn pink" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnupdate" CssClass="btn btn-primary" ValidationGroup="validVideoTypeEdit" OnClick="btnupdate_Click" runat="server" Text="Update" />
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Edit Video Type --%>
</asp:Content>

