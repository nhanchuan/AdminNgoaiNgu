<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="ImagesCategory.aspx.cs" Inherits="Pages_ImagesCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Danh Mục Hình Ảnh
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../Pages/ImagesCategory.aspx">Images Category</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <h3>Thêm Danh Mục Hình Ảnh</h3><br />
            <div class="form-group">
                <label class="control-label">Danh mục hình ảnh</label>
                <asp:TextBox ID="txtImgCategory" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtImgCategory" ValidationGroup="validImgCategory" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Tên danh mục không được để trống !"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <asp:Button ID="btnAddImgCategory" CssClass="btn btn-primary" ValidationGroup="validImgCategory" OnClick="btnAddImgCategory_Click" runat="server" Text="Thêm Danh Mục" />
            </div>
        </div>
        <div class="col-lg-8">
            <a class="btn btn-default" id="btnfixImagesCT" href="#modalEditIamgeCategory" data-toggle="modal" runat="server"><i class="fa fa-cog"></i> Chỉnh sửa danh mục</a>
            <a class="btn green" id="btnuploadImagse" href="#modalUploadIamge" data-toggle="modal" runat="server"><i class="fa fa-upload"></i> Upload Images</a>
            <asp:Label ID="lblConfirm" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="gwImagesCategory" CssClass="table table-condensed" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2" Font-Names="Arial" Font-Size="10pt"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="gwImagesCategory_RowDataBound" OnRowDeleting="gwImagesCategory_RowDeleting" OnSelectedIndexChanged="gwImagesCategory_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="DB_ID">
                        <ItemTemplate>
                            <asp:Label ID="lblImagesTypeID" runat="server" Text='<%# Eval("ImagesTypeID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Danh Mục Hình Ảnh">
                        <ItemTemplate>
                            <asp:Label ID="lblImagesTypeName" runat="server" Text='<%# Eval("ImagesTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Số Hình Ảnh">
                        <ItemTemplate>
                            <asp:Label ID="lblNunImages" runat="server" Text='<%# Eval("NunImages") %>'></asp:Label>
                        </ItemTemplate>
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
        </div>
    </div>
    <%-- Modal Edit Images Catefory --%>
    <div id="modalEditIamgeCategory" class="modal fade modal-scroll" tabindex="-1" data-replace="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-cog"></i> Edit Images Category
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="control-label">Danh Mục Hình Ảnh</label>
                        <asp:TextBox ID="txtEditImagesCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEditImagesCategory" ValidationGroup="validEImgCategory" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Tên danh mục không được để trống !"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnsave" CssClass="btn btn-primary" ValidationGroup="validEImgCategory" OnClick="btnsave_Click" runat="server" Text="Save" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal --%>

    <%-- Modal Edit Images Catefory --%>
    <div id="modalUploadIamge" class="modal fade modal-scroll" tabindex="-1" data-replace="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <i class="fa fa-upload"></i>Upload Images
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:FileUpload ID="fileUploadImg" CssClass="form-control" onchange="previewFile()" runat="server" />
                                <asp:RequiredFieldValidator ErrorMessage="Required"
                                    ControlToValidate="fileUploadImg" ValidationGroup="validfileUploadImg"
                                    runat="server" Display="Dynamic" ForeColor="Red" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="(.)+(.jpg|.gif|.png|.JPG|.GIF|.PNG)$"
                                    ControlToValidate="fileUploadImg"
                                    ValidationGroup="validfileUploadImg"
                                    runat="server" ForeColor="Red"
                                    ErrorMessage="Please select a valid Images file !"
                                    Display="Dynamic" />
                            </div>
                            <label>You can upload JPG, GIF, or PNG file. Maximum file size is 4MB.</label><br />
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4">
                            <asp:Image ID="imgUpload" CssClass="img-responsive" runat="server" />
                        </div>
                        <div class="col-lg-4"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a class="btn btn-warning" data-dismiss="modal">Cancel</a>
                    <asp:Button ID="btnUploadImages" CssClass="btn btn-primary" ValidationGroup="validfileUploadImg" OnClick="btnUploadImages_Click" runat="server" Text="Save" />
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal --%>
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=imgUpload.ClientID %>');
            var file = document.querySelector('#<%=fileUploadImg.ClientID %>').files[0];
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
    </script> 
</asp:Content>

