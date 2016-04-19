<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Tags.aspx.cs" Inherits="Pages_Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .background {
            background: url('../../images/backgrounds/noise_light-grey.jpg');
            font-family: 'Helvetica Neue', arial, sans-serif;
            font-weight: 200;
        }

        .pagination_lst {
            border-radius: 0;
            margin: 0;
        }

            .pagination_lst > a {
                font-size: 18px;
                display: inline-block;
                margin-left: 5px;
                border-radius: 1px !important;
                border: none;
            }

                .pagination_lst > a:active {
                    background: #fb2712;
                }

                .pagination_lst > a:hover {
                    background: #555;
                }

        .page_disabled {
            background: #E85507;
        }
    </style>
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Thẻ <small>Tags</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Post-All.aspx">Bài viết</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/Tags.aspx">Thẻ</a>
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
    <div class="row">


        <div class="col-lg-5">
            <h2>Thêm thẻ</h2>
            <div class="form-group">
                <label class="control-label">Tên</label>
                <asp:TextBox ID="txtTagName" CssClass="form-control" runat="server"></asp:TextBox>
                <i>Tên riêng sẽ hiển thị trên trang mạng của bạn.</i><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTagName" ValidationGroup="validTags" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTagName" ForeColor="Red" Display="Dynamic" ValidationGroup="validTags" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ chỉ 0-200 ký tự !"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label class="control-label">Chuỗi cho đường dẫn tĩnh</label>
                <asp:TextBox ID="txtTagsPermalink" CssClass="form-control" runat="server"></asp:TextBox>
                <i>Chuỗi cho đường dẫn tĩnh là phiên bản của tên hợp chuẩn với Đường dẫn (URL). Chuỗi này bao gồm chữ cái thường, số và dấu gạch ngang (-).</i>
            </div>
            <div class="form-group">
                <label class="control-label">Mô tả</label>
                <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                <i>Mô tả bình thường không được sử dụng trong giao diện, tuy nhiên có vài trang hiện thị mô tả này.</i>
            </div>
            <div class="clearfix"></div>
            <br />
            <asp:Button ID="btnaddTags" CssClass="btn btn-primary" ValidationGroup="validTags" OnClick="btnaddTags_Click" runat="server" Text="Thêm thẻ" />
        </div>
        <div class="col-lg-7">
            <%-- Gridview --%>

            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Tags List
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
                            <a class="btn yellow" href="#modaleditTagsInfo" data-toggle="modal" title="Chỉnh sửa thông tin Tags" id="btnshowPanelfix" runat="server"><i class="fa fa-wrench"></i></a>
                        </div>
                    </div>
                    <br />
                    <div class="clearfix"></div>
                    <asp:GridView ID="gwTagsList" CssClass="table table-condensed table-responsive" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" 
                        HeaderStyle-ForeColor="White" 
                        OnSelectedIndexChanged="gwTagsList_SelectedIndexChanged" OnRowDataBound="gwTagsList_RowDataBound" OnRowDeleting="gwTagsList_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Tags Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TagsName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TagsName") %>'></asp:Label>
                                    <asp:Label ID="lblTagsID" CssClass="display-none" runat="server" Text='<%# Bind("TagsID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descritption">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Descritption") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descritption") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Permalink">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Permalink") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Permalink") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date of create">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DateOfCreate") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("DateOfCreate","{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkBtnDeltag" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="20" height="20" /></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>

                        <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                        <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                        <RowStyle BackColor="#A1DCF2"></RowStyle>
                    </asp:GridView>

                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <!-- BEGIN PAGINATOR -->
                <div class="row">
                    <div class="col-md-4 col-sm-4 items-info">
                        <div id="divrownumber" runat="server">
                            Items
                                    <asp:Label ID="lblstartindex" runat="server"></asp:Label>
                            to
                                    <asp:Label ID="lblendindex" runat="server"></asp:Label>
                            of
                            <asp:Label ID="lbltotalTags" runat="server"></asp:Label>
                            total
                        </div>
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


            <%-- End GridView  --%>
        </div>
    </div>
    <%-- Modal Edit Audio Type --%>
    <div class="modal fade" id="modaleditTagsInfo" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title"><i class="fa fa-cog"></i>Change Tags Information</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="control-label">Tên</label>
                                <asp:TextBox ID="txtEditname" CssClass="form-control" runat="server"></asp:TextBox>
                                <i>Tên riêng sẽ hiển thị trên trang mạng của bạn.</i><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEditname" ValidationGroup="validEditTags" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtEditname" ForeColor="Red" Display="Dynamic" ValidationGroup="validEditTags" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Chuỗi cho đường dẫn tĩnh</label>
                                <asp:TextBox ID="txtEditPermalink" CssClass="form-control" runat="server"></asp:TextBox>
                                <i>Chuỗi cho đường dẫn tĩnh là phiên bản của tên hợp chuẩn với Đường dẫn (URL). Chuỗi này bao gồm chữ cái thường, số và dấu gạch ngang (-).</i>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Mô tả</label>
                                <asp:TextBox ID="txtEditDescription" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                <i>Mô tả bình thường không được sử dụng trong giao diện, tuy nhiên có vài trang hiện thị mô tả này.</i>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn pink" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnupdate" CssClass="btn btn-primary" ValidationGroup="validEditTags" OnClick="btnupdate_Click" runat="server" Text="Update" />
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Edit Audio Type --%>
</asp:Content>

