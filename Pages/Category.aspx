<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Pages_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/category.css" rel="stylesheet" />
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Chuyên mục <small>Category</small>
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
                <a href="../Pages/Category.aspx">Chuyên mục</a>
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
                <h2>Thêm chuyên mục</h2>
                <div class="form-group">
                    <label class="control-label">Tên</label>
                    <asp:TextBox ID="txtPostCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                    <i>Tên riêng sẽ hiển thị trên trang mạng của bạn.</i><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPostCategoryName" ValidationGroup="validPostCategory" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPostCategoryName" ForeColor="Red" Display="Dynamic" ValidationGroup="validPostCategory" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label class="control-label">Chuỗi cho đường dẫn tĩnh</label>
                    <asp:TextBox ID="txtPCUrl" CssClass="form-control" runat="server"></asp:TextBox>
                    <i>Chuỗi cho đường dẫn tĩnh là phiên bản của tên hợp chuẩn với Đường dẫn (URL). Chuỗi này bao gồm chữ cái thường, số và dấu gạch ngang (-).</i>
                </div>
                <div class="form-group">
                    <label class="control-label">Cha</label>
                    <asp:DropDownList ID="dlPCategory" CssClass="form-control input-medium" runat="server"></asp:DropDownList>
                    <i>Chuyên mục khác với thẻ, bạn có thể sử dụng nhiều cấp chuyên mục. Ví dụ: Trong chuyên mục nhạc, bạn có chuyên mục con là nhạc Pop, nhạc Jazz. Việc này hoàn toàn là tùy theo ý bạn.</i>
                </div>
                <div class="form-group">
                    <label class="control-label">Mô tả</label>
                    <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                    <i>Mô tả bình thường không được sử dụng trong giao diện, tuy nhiên có vài trang hiện thị mô tả này.</i>
                </div>

                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-lg-4">
                            <img src="../images/default_images.jpg" id="ImgPostCategory" class="img-responsive" runat="server"/>
                            <%--<asp:Image ID="" CssClass="img-responsive" ImageUrl="~/images/No_image.png" runat="server" />--%>
                        </div>
                        <div class="col-lg-8">
                            <label class="control-label">Chọn ảnh tiêu biểu</label>
                            <div class="row">
                                <a class="btn red" id="btnrefreshImg" runat="server"><i class="fa fa-refresh">Clear</i></a>
                                <a class="btn green" href="#modaluploadImages" data-toggle="modal"><i class="fa fa-upload"></i> Tải tập tin lên</a>
                                <a class="btn yellow" href="#modalselectimages" data-toggle="modal"><i class="fa fa-bank"></i> Chọn từ thư viện</a>
                            </div>
                            <br />
                            <i>( Ảnh chức năng cho chuyên mục )</i>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <br />
                <asp:Button ID="btnnewPostCategory" CssClass="btn btn-primary" ValidationGroup="validPostCategory" OnClick="btnnewPostCategory_Click" runat="server" Text="Thêm chuyên mục" />
            </div>
            <div class="col-lg-7">
                <%-- Gridview --%>
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-edit"></i>Post Category
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
                            <div class="col-lg-3">
                                <a href="#modaleditPCinfor" data-toggle="modal" title="Chỉnh sửa thông tin Post Category" id="btnshowPanelfix" runat="server"><i class="fa fa-wrench"></i> Chỉnh sửa Danh Mục</a>
                            </div>
                            <div class="col-lg-6">
                                <div class="input-group">
                                    <div class="input-icon">
                                        <i class="fa fa-search"></i>
                                        <%--<input id="" class="form-control" type="text" placeholder="Nhập tên Danh mục tìm kiếm " runat="server" />--%>
                                        <asp:TextBox ID="txtsearchcategory" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <span class="input-group-btn">
                                        <button id="btnsearchCategory" class="btn btn-success" type="button" onserverclick="btnsearchCategory_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i> Search</button>
                                    </span>
                                </div>
                                
                            </div>
                            <div class="col-lg-3">
                                <a href="#SapXepCategory" class="btn btn-info" data-toggle="modal"><i class="fa fa-cubes"></i> Sắp xếp</a>
                                <a class="btn green pull-right" href="#modalTreePostCategory" data-toggle="modal"><i class="fa fa-pagelines"></i></a>
                            </div>
                        </div>
                        <br />
                        <div class="clearfix"></div>
                        <asp:GridView ID="gwCategory" CssClass="table table-condensed table-responsive" runat="server"
                            AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                            OnSelectedIndexChanged="gwCategory_SelectedIndexChanged" OnRowDataBound="gwCategory_RowDataBound" OnRowDeleting="gwCategory_RowDeleting">
                            <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên Danh Mục">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryID" CssClass="display-none" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Môt tả">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Descriptions") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descriptions") %>'></asp:Label>
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
                                <asp:TemplateField HeaderText="Thuộc danh mục">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ParentName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ParentName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hình ảnh">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ImagesName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <img src='<%# "../" + Eval("ImagesUrl") %>' style="width: 60px; height: auto;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBtnDelCategory" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="Delete" Text="Delete"><img src="../images/icon/Actions-edit-delete-icon.png" width="20" height="20" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
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
                            <asp:Label ID="lbltotalAudio" runat="server"></asp:Label>
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
                                <asp:Repeater ID="rptSearchPage" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSearchPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                                            OnClick="SearchPage_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
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
    <%-- Modal Upload Category Images --%>
    <div class="modal fade" id="modaluploadImages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title"><i class="fa fa-upload"></i>Upload Category Images</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <p>
                                You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.
                            </p>
                            <asp:FileUpload ID="FileImgUpload" CssClass="form-control" onchange="previewFile()" runat="server" />
                            <asp:HiddenField ID="HiddenFileImgUpload" runat="server" />
                            <asp:RequiredFieldValidator ErrorMessage="Required"
                                ControlToValidate="FileImgUpload" ValidationGroup="validuploadImages"
                                runat="server" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="(.)+(.jpg|.gif|.png|.JPG|.PNG|.GIF)$"
                                ControlToValidate="FileImgUpload"
                                ValidationGroup="validuploadImages"
                                runat="server" ForeColor="Red"
                                ErrorMessage="Please select a valid Images file !"
                                Display="Dynamic" />
                            <div class="clearfix"></div>
                            <div class="col-lg-4"></div>
                            <div class="col-lg-4">
                                <asp:Image ID="imgUpload" CssClass="img-responsive" runat="server" />
                            </div>
                            <div class="col-lg-4"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn pink" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnuploadImages" CssClass="btn btn-primary" ValidationGroup="validuploadImages" OnClick="btnuploadImages_Click" runat="server" Text="Upload Images" />
                </div>
            </div>
        </div>
    </div>
     <%--End Modal Upload Category Images --%>

    <%-- Modal Select Category Images --%>
    <div class="modal fade" id="modalselectimages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">
                        <img src="../images/icon/add-icon.png" width="28" height="28" />
                        Ảnh chức năng cho chuyên mục</h4>
                </div>
                <div class="modal-body">
        <div class="panel-default">
            <div class="panel-body">
                <div class="col-lg-9">
                    <div class="col-lg-12">
                        <div style="height: 700px; overflow: auto;">
                            <div class="grid-container">
                                <ul class="rig columns-5">
                                    <asp:Repeater ID="rpLstImg" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <a href='<%#"../"+Eval("ImagesUrl") %>' onclick="return showanh(this.href)"">
                                                                        <img src='<%#"../"+Eval("ImagesUrl") %>' />
                                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
                                                                        <p><i class="fa fa-clock-o"></i><%# Eval("DateOfStart") %></p>
                                                  </a>
                                              </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <%-- info --%>
                    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="vlidSelectImage" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" runat="server" />
                    <asp:Image ID="ImagesSelect" CssClass="img-responsive" runat="server" />
                    <br />
                    <asp:HiddenField ID="HiddenimgSelect" runat="server" />
                    <label>Url Image:</label>
                    <asp:TextBox ID="txtImgUrl" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtImgUrl" ValidationGroup="vlidSelectImage" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                    <%-- end info --%>
                </div>
            </div>
        </div>

    </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal"> Cancel</a>
                    <asp:Button ID="btnselectimages" CssClass="btn btn-primary pull-right" ValidationGroup="vlidSelectImage" OnClick="btnselectimages_Click"  runat="server" Text="Chọn ảnh tiêu biểu" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Select Category Images --%>


    <%-- Modal Edit Post Category Information --%>
    <div class="modal fade" id="modaleditPCinfor" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">
                        <i class="fa fa-cog"></i>
                        Chỉnh sửa thông tin</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="control-label">Tên</label>
                                <asp:TextBox ID="txtEditName" CssClass="form-control" runat="server"></asp:TextBox>
                                <i>Tên riêng sẽ hiển thị trên trang mạng của bạn.</i>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEditName" ValidationGroup="validtxtEditName" runat="server" ErrorMessage="Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtEditName" ForeColor="Red" Display="Dynamic" ValidationGroup="validtxtEditName" ValidationExpression="(.){0,200}$" runat="server" ErrorMessage="Tên từ 0-200 ký tự !{Chi gồm các kí tự a-z,A-Z,0-9,-,_}"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Chuỗi cho đường dẫn tĩnh</label>
                                <asp:TextBox ID="txtEditPermalink" CssClass="form-control" runat="server"></asp:TextBox>
                                <i>Chuỗi cho đường dẫn tĩnh là phiên bản của tên hợp chuẩn với Đường dẫn (URL). Chuỗi này bao gồm chữ cái thường, số và dấu gạch ngang (-).</i>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Cha</label>
                                <asp:DropDownList ID="dlEditParent" CssClass="form-control input-xlarge" runat="server"></asp:DropDownList>
                                <i>Chuyên mục khác với thẻ, bạn có thể sử dụng nhiều cấp chuyên mục. Ví dụ: Trong chuyên mục nhạc, bạn có chuyên mục con là nhạc Pop, nhạc Jazz. Việc này hoàn toàn là tùy theo ý bạn.</i>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Mô tả</label>
                                <asp:TextBox ID="txtEditDescription" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                <i>Mô tả bình thường không được sử dụng trong giao diện, tuy nhiên có vài trang hiện thị mô tả này.</i>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="col-lg-4">
                                        <img src="../images/No_image.png" id="ImgEditPC" class="img-responsive" runat="server" />
                                        <%-- HiddenField --%>
                                        <asp:HiddenField ID="hiddentEditImages" runat="server" />
                                        <%-- End HiddenField --%>
                                        <%--<asp:Image ID="" CssClass="img-responsive" ImageUrl="~/images/No_image.png" runat="server" />--%>
                                    </div>
                                    <div class="col-lg-8">
                                        <label class="control-label">Chọn ảnh tiêu biểu</label>
                                        <div class="row">
                                            <a class="btn red" id="clearEditImg" runat="server"><i class="fa fa-refresh">Clear</i></a>
                                            <a class="btn green" href="#coluploadEditImges" data-toggle="collapse"><i class="fa fa-upload"></i>Tải tập tin lên</a>
                                            <a class="btn yellow" href="#modaleditselectimages" data-toggle="modal"><i class="fa fa-bank"></i>Chọn từ thư viện</a>
                                        </div>
                                        <br />
                                        <i>( Ảnh chức năng cho chuyên mục )</i>
                                        <%-- Collapse Upload Images --%>
                                        <div id="coluploadEditImges" class="panel-collapse collapse">
                                            <asp:TextBox ID="txtuploadImgTemp" CssClass="form-control" runat="server"></asp:TextBox>
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <div class="input-icon">
                                                            <i class="fa fa-file"></i>
                                                            <asp:FileUpload ID="fileUploadImgPC" CssClass="form-control" runat="server" />
                                                        </div>
                                                        <span class="input-group-btn">
                                                            <button id="btnuploadEditImg" class="btn btn-success" type="button" validationgroup="validfileUploadImgPC" onserverclick="btnuploadEditImg_ServerClick" runat="server"><i class="fa fa-arrow-left fa-fw"></i>OK</button>
                                                        </span>
                                                    </div>
                                                    <asp:RequiredFieldValidator ErrorMessage="Required"
                                                                ControlToValidate="fileUploadImgPC" ValidationGroup="validfileUploadImgPC"
                                                                runat="server" Display="Dynamic" ForeColor="Red" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="(.)+(.jpg|.gif|.png|.JPG|.GIF|.PNG)$"
                                                                ControlToValidate="fileUploadImgPC"
                                                                ValidationGroup="validfileUploadImgPC"
                                                                runat="server" ForeColor="Red"
                                                                ErrorMessage="Please select a valid Images file !"
                                                                Display="Dynamic" />
                                                </div>
                                                <label>You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.</label>
                                            </div>
                                        </div>
                                    <%-- End Collapse Upload Images --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn pink" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnUpdatePCInfo" CssClass="btn btn-primary" ValidationGroup="validtxtEditName" OnClick="btnUpdatePCInfo_Click" runat="server" Text="Update Info" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal Edit Post Category Information --%>

    <%-- Modal Edit Select Category Images --%>
    <div class="modal fade" id="modaleditselectimages" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-full">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">
                        <img src="../images/icon/add-icon.png" width="28" height="28" />
                        Ảnh chức năng cho chuyên mục</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-default">
                        <div class="panel-body">
                            <div class="col-lg-9">
                                        <div class="col-lg-12">
                                            <div style="height: 700px; overflow: auto;">
                                                <div class="grid-container">
                                                    <ul class="rig columns-5">
                                                        <asp:Repeater ID="rpSelectEditImg" runat="server">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <a href='<%#"../"+Eval("ImagesUrl") %>' onclick="return showanhedit(this.href)"">
                                                                        <img src='<%#"../"+Eval("ImagesUrl") %>' />
                                                                        <h4>Upload by <i style="color: red;"><%# Eval("UserName") %></i></h4>
                                                                        <p><i class="fa fa-clock-o"></i><%# Eval("DateOfStart") %></p>
                                                                    </a>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                            </div>
                            <div class="col-lg-3">
                                <%-- info --%>
                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="vlidEditSelectImage" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" runat="server" />
                                <asp:Image ID="ImageSelectEdit" CssClass="img-responsive" runat="server" />
                                <br />
                                <asp:HiddenField ID="HiddenFieldEditImgesSelect" runat="server" />
                                <label>Url Image:</label>
                                <asp:TextBox ID="txtEditImagesUrl" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEditImagesUrl" ValidationGroup="vlidEditSelectImage" ErrorMessage="No Image Selected !" Display="None"></asp:RequiredFieldValidator>
                                <%-- end info --%>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal"> Cancel</a>
                    <asp:Button ID="btnselectEditImg" CssClass="btn btn-primary pull-right" ValidationGroup="vlidEditSelectImage" OnClick="btnselectEditImg_Click" runat="server" Text="Chọn ảnh tiêu biểu" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Edit Modal Select Category Images --%>

    <%-- Modal Tree Post Category --%>
    <div id="modalTreePostCategory" class="modal fade modal-scroll" tabindex="-1" data-replace="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-pagelines"></i> Cây danh mục
                </div>
                <div class="modal-body">
                    <div class="scroller" style="height: 600px;" data-always-visible="1">
                        <asp:TreeView ID="treePostCategory" ShowExpandCollapse="true" PopulateNodesFromClient="true" ShowLines="true" ExpandDepth="2" OnTreeNodePopulate="treePostCategory_TreeNodePopulate" runat="server"></asp:TreeView>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn">Close</button>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Tree Post Category --%>

    <%-- Modal Sort Category --%>
    <div id="SapXepCategory" class="modal fade modal-scroll" tabindex="-1" data-replace="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-cubes"></i>Sắp xếp chuyên mục
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="control-label bold">Chọn danh mục cha</label>
                                        <asp:DropDownList ID="dlDanhMucCha" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlDanhMucCha_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="col-lg-12">
                                    <%-- Gridview --%>
                                    <asp:GridView ID="gwCategorySapxep" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                        <Columns>
                                            <asp:TemplateField HeaderText="No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tên Danh Mục">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryID" CssClass="display-none" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Môt tả">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Descriptions") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descriptions") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="Hình ảnh">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ImagesName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <img src='<%# "../" + Eval("ImagesUrl") %>' style="width: 60px; height: auto;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbtnUp" CommandArgument='<%# Eval("CategoryID") %>' OnClick="lkbtnUp_Click" runat="server"><i class="fa fa-caret-square-o-up" style="font-size:20px;"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lkbtnDown" CommandArgument='<%# Eval("CategoryID") %>' OnClick="lkbtnDown_Click" runat="server"><i class="fa fa-caret-square-o-down" style="font-size:20px;"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="60px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <SelectedRowStyle BackColor="#79B782" ForeColor="Black" />
                                        <HeaderStyle BackColor="#FFB848" ForeColor="White"></HeaderStyle>
                                        <RowStyle BackColor="#FAF3DF"></RowStyle>
                                    </asp:GridView>

                                    <%-- End Gridview --%>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="dlDanhMucCha" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
                <div class="modal-footer">
                    <a class="btn btn-default" data-dismiss="modal">Close</a>
                </div>
            </div>
        </div>
    </div>
    <%--End Modal Sort Category --%>
   
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=imgUpload.ClientID %>');
            var file = document.querySelector('#<%=FileImgUpload.ClientID %>').files[0];
            var reader = new FileReader();
            reader.onloadend = function () {
                preview.src = reader.result;
            }
            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
        function showanh(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImagesSelect.ClientID %>').src = url;
            document.getElementById('<%=HiddenimgSelect.ClientID %>').value = url;
            document.getElementById('<%=txtImgUrl.ClientID %>').value = url;
            return false;
        }
        function showanhedit(url) {
            var filename = url.substring(url.lastIndexOf('/') + 1);
            document.querySelector('#<%=ImageSelectEdit.ClientID %>').src = url;
            document.getElementById('<%=HiddenFieldEditImgesSelect.ClientID %>').value = url;
            document.getElementById('<%=txtEditImagesUrl.ClientID %>').value = url;
            return false;
        }
    </script> 
    <script type="text/javascript">
        function callButtonClickEvent() {
            document.getElementById('<%=btnshowPanelfix.ClientID %>').click();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_clearEditImg").click(function () {
                var urlNoimg = "../images/No_image.png";
                $("#ContentPlaceHolder1_ImgEditPC").attr("src", urlNoimg);
                $("#ContentPlaceHolder1_txtuploadImgTemp").val("");
            });
        });
    </script>
    <%--<script type="text/javascript">
        window.onload = function callButtonClickEvent() {
            document.getElementById('<%=btnshowPanelfix.ClientID %>').click();
        }
    </script>--%>

</asp:Content>

