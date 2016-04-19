<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="HoSoKhachHang.aspx.cs" Inherits="QuanLyHoSo_HoSoKhachHang" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <link href="../../assets/admin/pages/css/blog.css" rel="stylesheet" type="text/css"/>
    <link href="../assets/admin/pages/css/news.css" rel="stylesheet" type="text/css"/>
    <link href="../assets/admin/pages/css/profile-old.css" rel="stylesheet" />
    <h1 class="page-title">Hồ Sơ Khách Hàng <small>Customer Profile</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../QuanLyHoSo/HoSoKhachHang.aspx">Hồ sơ khách hàng</a>
                <i class="fa fa-angle-right"></i>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <div class="tabbable-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#tabThongke" data-toggle="tab">Thống kê</a></li>
                    <li><a href="#tabHoatDong" data-toggle="tab">Hoạt động</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="tabThongke">
                        <div id="chart_7" class="chart"></div>
                        <div class="well margin-top-20">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label class="text-left">Angle:</label>
                                    <input class="chart_7_chart_input" data-property="angle" type="range" min="0" max="89" value="30" step="1" />
                                </div>
                                <div class="col-sm-6">
                                    <label class="text-left">Depth:</label>
                                    <input class="chart_7_chart_input" data-property="depth3D" type="range" min="1" max="120" value="30" step="1" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="tabHoatDong">

                    </div>
                </div>
            </div>
            <%-- Info --%>
            <div class="panel panel-info background">
                <div class="panel-body">
                    <div class="col-md-4 blog-img blog-tag-data">
                        <img id="imgavatarCus" src="../images/default_images.jpg" alt="" class="img-responsive" runat="server" />
                    </div>
                    <div class="col-md-8 blog-article">
                        <li class="list-group-item bg-blue" id="liTypeStyle" runat="server"><label class="bold uppercase">Hồ Sơ <asp:Label ID="lblBagProfileType" runat="server" Text="Label"></asp:Label></label></li>
                        <br />
                        <div class="form-group">
                            <label class="control-label">Mã Hồ Sơ : </label>
                            <asp:Label ID="lblProfilecode" CssClass="bold" runat="server" Text="0154653"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Đơn vị : </label>
                            <asp:Label ID="lblUnitCopyright" CssClass="bold" runat="server" Text="Label"></asp:Label>
                        </div>
                        
                        <hr style="border:1px solid black;" />
                        <h3>
                            <asp:Label ID="lblFullName" runat="server" Text="Nguyễn Van A"></asp:Label>
                        </h3>
                        <div class="form-group">
                             <%--<span class="label label-primary"><i class="fa fa-pencil-square-o"></i>
                            <label>Hồ Sơ Du Học</label></span>--%>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label">Địa chỉ : </label>
                            <asp:Label ID="lblPermanentAddress" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Điện Thoại : </label>
                            <asp:Label ID="lblCellPhone" runat="server" Text="0164755889"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Email : </label>
                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="form-group text-right">
                            <a class="btn green" href="#" id="btnreadmore" onclick="readmore_click()" >View more <i class="m-icon-swapright m-icon-white"></i></a>
                        </div>
                    </div>
                </div>
            </div>
            <%-- End Info --%>
        </div>
        <div class="col-lg-8">
            <div class="panel panel-info">
                <div class="panel-body">
                    <h2>BỔ SUNG HỒ SƠ</h2>
                    <hr />
                    <%-- Row 1 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Tên giấy tờ / Hồ sơ :</label>
                                <asp:TextBox ID="txtDocName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- End row 1 --%>
                   
                    <%-- Row --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Ghi chú :</label>
                                <CKEditor:CKEditorControl ID="CKDocNote" Toolbar="Basic" runat="server"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                    </div>
                    <%-- End row --%>
                    <div class="row">
                        <div class="col-lg-12 text-right">
                            <a class="btn btn-default" id="btnaddnewDoc" onserverclick="btnaddnewDoc_ServerClick" runat="server"><img src="../images/icon/add-icon.png" width="35" height="35" /> Add New</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div><br />
    <%-- Collapse Upload BagAttachments --%>
    <div class="col-lg-4 panel-collapse collapse" id="collapBagAttachments">
        <div class="row">
            <div class="form-group">
                <div class="input-group">
                    <div class="input-icon">
                        <i class="fa fa-file"></i>
                        <asp:FileUpload ID="fileUploadBagAttachments" AllowMultiple="true" CssClass="form-control" runat="server" />
                    </div>
                    <span class="input-group-btn">
                        <button id="btnBagAttachments" class="btn btn-success" type="button" validationgroup="validfileUploadBagAttachments" onserverclick="btnBagAttachments_Click" runat="server"><i class="fa fa-upload"></i>Upload</button>
                        <%--<asp:Button ID="btnBagAttachments" CssClass="btn btn-success" runat="server" validationgroup="validfileUploadBagAttachments" OnClick="btnBagAttachments_Click" Text="Upload" />--%>
                    </span>
                </div>
                <asp:RequiredFieldValidator ErrorMessage="Required"
                    ControlToValidate="fileUploadBagAttachments" ValidationGroup="validfileUploadBagAttachments"
                    runat="server" Display="Dynamic" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="(.)+(.doc|.DOC|.docx|.DOCX|.txt|.TXT|.xlsx|.XLSX|.xlsm|.XLSM|.xls|.XLS|.xlt|.XLT|.XLT|.ppt|.PPT|.pptx|.PPTX|.pdf|.PDF|.jpg|.JPG|.png|.PNG)$"
                    ControlToValidate="fileUploadBagAttachments"
                    ValidationGroup="validfileUploadBagAttachments"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Please select a valid file !"
                    Display="Dynamic" />
            </div>
            <label>* File đính kèm ( file Pdf | Word | Images )</label>
        </div>
    </div>
   <%-- End Collapse Upload BagAttachments --%>
     <%-- Collapse Upload BagFileTranslate --%>
    <div class="col-lg-4 panel-collapse collapse" id="collapBagFileTranslate">
        <div class="row">

            <div class="form-group">
                <div class="input-group">
                    <div class="input-icon">
                        <i class="fa fa-file"></i>
                        <asp:FileUpload ID="fileBagFileTranslate" AllowMultiple="true" CssClass="form-control" runat="server" />
                    </div>
                    <span class="input-group-btn">
                        <button id="btnBagFileTranslate" class="btn btn-success" type="button" validationgroup="validfileUploadBagFileTranslate" onserverclick="btnBagFileTranslate_ServerClick" runat="server"><i class="fa fa-upload"></i>Upload</button>
                    </span>
                </div>
                <asp:RequiredFieldValidator ErrorMessage="Required"
                    ControlToValidate="fileBagFileTranslate" ValidationGroup="validfileUploadBagFileTranslate"
                    runat="server" Display="Dynamic" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="(.)+(.doc|.DOC|.docx|.DOCX|.txt|.TXT|.xlsx|.XLSX|.xlsm|.XLSM|.xls|.XLS|.xlt|.XLT|.XLT|.ppt|.PPT|.pptx|.PPTX|.pdf|.PDF|.jpg|.JPG|.png|.PNG)$"
                    ControlToValidate="fileBagFileTranslate"
                    ValidationGroup="validfileUploadBagFileTranslate"
                    runat="server" ForeColor="Red"
                    ErrorMessage="Please select a valid file !"
                    Display="Dynamic" />
            </div>
            <label>* Bản dịch hồ sơ đính kèm ( file Pdf | Word | Images )</label>
        </div>
    </div>
    <%-- End Collapse Upload BagFileTranslate --%>
    <div class="clearfix"></div>
    <asp:Label ID="lblSuccess" CssClass="label label-success" runat="server" Text="Label"></asp:Label>
    <%-- Danh sach ho so --%>
    <div class="row">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-edit"></i>Danh sách giấy tờ hồ sơ
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <button id="btnreloadmodal" class="btn green" runat="server"><i class="fa fa-refresh"></i></button>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body background">
                        <%-- Control --%>
                        <div class="row">
                            <div class="col-lg-1">
                                <a class="btn red"><i class="fa fa-remove"></i> Remove</a>
                            </div>
                            <div class="col-lg-3">
                                <a class="btn btn-default" href="#collapBagAttachments" data-toggle="collapse"><i class="fa fa-paperclip"></i> File đính kèm</a>
                                <a class="btn btn-default" href="#collapBagFileTranslate" data-toggle="collapse"><i class="fa fa-language"></i> Bản dịch hồ sơ</a>
                                <a class="btn btn-info" href="#modalViewFilel" data-toggle="modal"><i class="fa fa-database"> View File</i></a>
                            </div>
                            <div class="col-lg-5">
                                <div class="input-group">
                                    <div class="input-icon">
                                        <i class="fa fa-search"></i>
                                        <input id="txtsearchbagfile" class="form-control" type="text" placeholder="Tìm kiếm hồ sơ" runat="server" />
                                    </div>
                                    <span class="input-group-btn">
                                        <button id="btnSearchKey" class="btn btn-success" type="button" onserverclick="btnSearchKey_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i> Search</button>
                                    </span>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="input-icon">
                                    <i class="fa fa-filter"></i>
                                    <asp:DropDownList ID="dlFilter" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlFilter_SelectedIndexChanged" runat="server">
                                        <asp:ListItem Value="0">-- Sắp xếp --</asp:ListItem>
                                        <asp:ListItem Value="1">Sắp xếp A-Z</asp:ListItem>
                                        <asp:ListItem Value="2">Sắp xếp Z-A</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%-- End control --%>
                        
                        
                        <div class="clearfix"></div>
                        <br />
                        <%-- Gridview --%>
                        <asp:GridView ID="gwBagProfileManager" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="gwBagProfileManager_SelectedIndexChanged">

                            <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên giấy tờ / Hồ sơ">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DocName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" CssClass="bold" runat="server" Text='<%# Bind("DocName") %>'></asp:Label>
                                        <asp:Label ID="lblBagProfileID" CssClass="display-none" runat="server" Text='<%# Eval("BagProfileID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ghi chú">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DocNote") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DocNote") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tạo lúc">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("DateOfCreate") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DateOfCreate","{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                            <HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
                            <RowStyle BackColor="#A1DCF2"></RowStyle>
                        </asp:GridView>
                        <%-- End gridview --%>
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
                                <asp:Repeater ID="RpSearchKey" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnksearchPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="SearchKeyPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="RpOrderBy" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkOrderByPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="OrderByPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <!-- END PAGINATOR -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <%-- End Danh sach ho so --%>

    <%-- Modal View file --%>
    <div class="modal fade" id="modalViewFilel" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title uppercase">
                        <img src="../images/icon/folder-documents-icon.png" width="35" height="35" />
                        Danh sách file thuộc bộ hồ sơ
                        <asp:Label ID="txtlistfile" CssClass="bold" runat="server" Text="Label"></asp:Label></h4>
                </div>
                <div class="modal-body background">

                    <div class="tabbable-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tabFileAttachment" data-toggle="tab">File đính kèm</a></li>
                            <li><a href="#tabFileTranlater" data-toggle="tab">File dịch hồ sơ</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tabFileAttachment">
                                <%-- Gw File Attachment --%>
                                <asp:GridView ID="gwFileAttachment" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Tên Giấy Tờ">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("DocName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tên File Uplopad">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("AttachmentName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Thời gian Upload">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("DateOfCreate","{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btbDeleteAtt" runat="server" CssClass="text-danger" CausesValidation="False" CommandArgument='<%# Eval("AttachmentID") %>' OnClick="btbDeleteAtt_Click" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="false">
                                            <ItemTemplate>
                                                <a class="text-primary" href='<%# "../Handler/DownloadAttachment.ashx?attachmentId="+Eval("AttachmentID") %>'><i class="fa fa-download"></i>Download</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                    <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                                    <RowStyle BackColor="#FAF3DF"></RowStyle>
                                </asp:GridView>
                                <%-- End Gw File Attachment --%>
                            </div>
                            <div class="tab-pane" id="tabFileTranlater">
                                <%-- Gw File Attachment --%>
                                <asp:GridView ID="gwFileTranslate" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Tên Giấy Tờ">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("DocName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tên File Uplopad">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("FileTranslateName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Thời gian Upload">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("DateOfCreate","{0:dd/MM/yyyy hh:mm:ss tt}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDeleteTrans" runat="server" CssClass="text-danger" CausesValidation="False" CommandArgument='<%# Eval("FileTranslateID") %>' OnClick="btnDeleteTrans_Click" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="false">
                                            <ItemTemplate>
                                                <a class="text-primary" href='<%# "../Handler/DownloadFileTrans.ashx?TranslateId="+Eval("FileTranslateID") %>'><i class="fa fa-download"></i>Download</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                    <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                                    <RowStyle BackColor="#FAF3DF"></RowStyle>
                                </asp:GridView>
                                <%-- End Gw File Attachment --%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal View file --%>

<script src="../assets/global/plugins/amcharts/amcharts/amcharts.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/serial.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/pie.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/radar.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/themes/light.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/themes/patterns.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amcharts/themes/chalk.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/ammap/ammap.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/ammap/maps/js/worldLow.js" type="text/javascript"></script>
<script src="../assets/global/plugins/amcharts/amstockcharts/amstock.js" type="text/javascript"></script>
    <script>
    function readmore_click()
    {
        var urlParams;
        (window.onpopstate = function () {
            var match,
                pl = /\+/g,  // Regex for replacing addition symbol with a space
                search = /([^&=]+)=?([^&]*)/g,
                decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
                query = window.location.search.substring(1);

            urlParams = {};
            while (match = search.exec(query))
                urlParams[decode(match[1])] = decode(match[2]);
        })();
        var url = "../QuanLyHoSo/ThongTinKhachHang.aspx?FileCode=" + urlParams["FileCode"];
        window.open(url, "myWindow", "width=1366, height=768,resizable=yes");
    }
</script>
</asp:Content>

