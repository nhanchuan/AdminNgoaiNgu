<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="ImagesManager.aspx.cs" Inherits="Pages_ImagesManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <link href="../App_Themes/admin/imgaesmanager.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">Thư viện hình ảnh <small>Images Manager</small>
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
                <a href="../Pages/ImagesManager.aspx">Images Manager</a>
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

    <a class="btn green" data-toggle="collapse" data-parent="#accordion2" href="#panelupload">Thêm hình ảnh</a>
    <hr />
    <div class="clearfix"></div>
    <div id="panelupload" class="col-lg-12 panel-collapse collapse">

        <div id="dZUpload" class="dropzone">
            <div class="dz-default dz-message">
                <img src="../libs/DropzoneJs_scripts/spritemap@2x.png" style="width: 50%; height: 50%;" />
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN USERS TABLE PORTLET-->
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-edit"></i>Thư viện hình ảnh
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <button id="btnreload" class="btn green" onserverclick="btnreload_ServerClick" runat="server"><i class="icon-reload"></i></button>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body background">

                            <div class="table-toolbar">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <asp:DropDownList ID="dlImagestype" CssClass="form-control input-medium" AutoPostBack="true" OnSelectedIndexChanged="dlImagestype_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-5 pull-right">
                                        <div class="input-group">
                                            <div class="input-icon">
                                                <i class="fa fa-search"></i>
                                                <input id="txtsearchImages" class="form-control" type="text" placeholder="Search Images" runat="server" />
                                            </div>
                                            <span class="input-group-btn">
                                                <button id="btnsearchimg" class="btn btn-success" type="button" onserverclick="btnsearchimg_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>Search</button>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="clearfix"></div>
                                <div class="grid-container">
                                    <ul class="rig columns-5">
                                        <asp:Repeater ID="rpLstImg" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <a href='<%#"../"+Eval("ImagesUrl") %>' onclick="return showthumbanh(this.href)">
                                                        <span href="#modalviewImages" data-toggle="modal">
                                                            <img src='<%#"../"+Eval("ImagesUrl") %>' />
                                                            <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
                                                            <p><%# Eval("ImagesName") %></p>
                                                        </span>
                                                    </a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <!--/#five-columns-->
                            </div>

                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="form-group">
                        <!-- BEGIN PAGINATOR -->
                        <div class="row">
                            <div class="col-md-4 col-sm-4 items-info">
                                <%--<div id="divrownumber" runat="server">
                                    Items
                                    <asp:Label ID="lblstartindex" runat="server"></asp:Label>
                                    to
                                    <asp:Label ID="lblendindex" runat="server"></asp:Label>
                                    of
                            <asp:Label ID="lbltotalProduct" runat="server"></asp:Label>
                                    total
                                </div>
                                <div id="divsearch" runat="server">
                                    Items
                                    <asp:Label ID="lblsearchstart" runat="server"></asp:Label>
                                    to
                                    <asp:Label ID="lblsearchend" runat="server"></asp:Label>
                                    of
                            <asp:Label ID="lbltotalSearchProduct" runat="server"></asp:Label>
                                    total
                                </div>--%>
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
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="dlImagestype" EventName="SelectedIndexChanged" />
                    <%--<asp:PostBackTrigger ControlID="btnsearchimg" />--%>
                </Triggers>
            </asp:UpdatePanel>

        </div>
        </div>
    <!-- /.modal view Images -->
    <div class="modal fade" id="modalviewImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">View Images</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="col-lg-2"></div>
                            <div class="col-lg-4">
                                <img src="#" id="imgThumgProduct" runat="server" style="width: 100%; height: auto;" />
                            </div>
                            <div class="col-lg-2"></div>
                            <div class="col-lg-4">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <label class="control-label">Image Url</label>
                                            <asp:TextBox ID="txtImgurl" CssClass="form-control" runat="server"></asp:TextBox>
                                            <%--<input id="txtImgurl" class="form-control" type="text" runat="server" />--%>
                                            <%--<asp:Button ID="btncopylink" runat="server" onclick="btnCopyClicked" Text="Copy link" />--%>
                                            <a id="markup-copy" ><i class="fa fa-copy"></i> Copy link</a>
                                        </div>
                                        <asp:HiddenField ID="HiddenImages" runat="server" />
                                        <a href="#" runat="server"><i class="fa fa-remove">Delete Images</i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../libs/Clipboard_jsmaster/clipboard.min.js"></script>
    <!-- /.end modal view Images -->
    <script type="text/javascript">
        function showthumbanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=imgThumgProduct.ClientID %>').src = url;
            document.getElementById('<%=txtImgurl.ClientID %>').value = url;
            document.getElementById('<%=HiddenImages.ClientID %>').value = filename;
            return false;
        }
        <%-- Copy Link Images to ClipBoards --%>
        document.getElementById('markup-copy').addEventListener('click', function () {
            clipboard.copy({
                'text/plain': document.getElementById('<%=txtImgurl.ClientID %>').value,
            //'text/html': '<i>here</i> is some <b>rich text</b>'
        }).then(
            function () { console.log('success'); },
            function (err) {
                console.log('failure', err);
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            console.log("Hello");
            Dropzone.autoDiscover = true;
            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                url: "/Handler/hn_SimpeFileUploader.ashx",
                maxFiles: 10,
                addRemoveLinks: true,
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgName);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });
        });
    </script>
</asp:Content>

