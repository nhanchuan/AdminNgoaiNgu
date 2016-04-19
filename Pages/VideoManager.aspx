<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="VideoManager.aspx.cs" Inherits="Pages_VideoManager" %>

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
    <h3 class="page-title">Thư viện Video <small>Video Manager</small>
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
                <a href="../VideoManager.aspx">Videos Manager</a>
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
        <a class="btn green" href="../Pages/VideoUpload.aspx">Thêm Video</a>
        <hr />
        <div class="clearfix"></div>
        <div class="col-lg-12">
            <!-- BEGIN USERS TABLE PORTLET-->
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-edit"></i>Thư viện Video
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <button id="btnreload" class="btn green" onserverclick="btnreload_ServerClick" runat="server"><i class="fa fa-refresh"></i></button>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body background">
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:DropDownList ID="dlVideotype" CssClass="form-control input-medium" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-lg-5 pull-right">
                            <div class="input-group">
                                <div class="input-icon">
                                    <i class="fa fa-search"></i>
                                    <input id="txtsearchVideo" class="form-control" type="text" placeholder="Search Video" runat="server" />
                                </div>
                                <span class="input-group-btn">
                                    <button id="btnsearchVideo" class="btn btn-success" type="button" onserverclick="btnsearchVideo_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Search</button>
                                </span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:GridView ID="gwvideomanager" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwvideomanager_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VideoID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("VideoID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("TypeName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label><a class="popovers pull-right" data-trigger="hover" data-container="body" data-placement="top" data-content="<%# Eval("TypeDescription") %>"><i class="fa fa-question"></i></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Video Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("VideoName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <a style="font-size: 16px;" href='<%# "../Pages/VideoEditInfo.aspx?VideoID=" + Eval("VideoID") %>'>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("VideoName") %>'></asp:Label></a>
                                    <br />
                                    <div class="form-inline  pull-right">
                                        <i class="fa fa-upload"></i><i><%# Eval("DateOfCreate","{0:dd/MM/yyyy hh:mm:ss tt}") %></i>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File Type">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ContentType") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("ContentType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mô tả ngắn">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ShortDecsription") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ShortDecsription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Copy Link">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div class="btn-group dropup">
                                        <button class="btn green dropdown-toggle" type="button" data-toggle="dropdown">
                                            <i class="fa fa-link"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right" role="menu">
                                            <li>
                                                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text='<%# "http://www.hollywood.edu.vn/"+ Eval("VideoUrl") %>'></asp:TextBox>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="btn-group dropup">
                                        <button class="btn orange dropdown-toggle" type="button" data-toggle="dropdown">
                                            <i class="fa fa-share-alt"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right" role="menu">
                                            <li>
                                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" Text='<%# "http://www.hollywood.edu.vn/"+ Eval("VideoUrl") %>'></asp:TextBox>
                                            </li>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <a class="btn green" href='<%# "../Pages/VideoEditInfo.aspx?VideoID=" + Eval("VideoID") %>' title="View Video"><i class="fa fa-video-camera"></i></a>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

                        <RowStyle BackColor="#A1DCF2"></RowStyle>
                    </asp:GridView>
                </div>
            </div>

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
                            <asp:Label ID="lbltotalAudio" runat="server"></asp:Label>
                            total
                        </div>
                        <div id="divsearch" runat="server">
                            Items
                                    <asp:Label ID="lblsearchstart" runat="server"></asp:Label>
                            to
                                    <asp:Label ID="lblsearchend" runat="server"></asp:Label>
                            of
                            <asp:Label ID="lbltotalSearchAudio" runat="server"></asp:Label>
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
                            <asp:Repeater ID="Repeatersearch" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSearchPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                        CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                        OnClick="Page_SearchChanged" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <!-- END PAGINATOR -->
            </div>
        </div>
    </div>

</asp:Content>

