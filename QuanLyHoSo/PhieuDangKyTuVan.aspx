<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="PhieuDangKyTuVan.aspx.cs" Inherits="QuanLyHoSo_PhieuDangKyTuVan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <!-- BEGIN PAGE HEADER-->
    <h1 class="page-title">Phiếu đăng ký tư vấn <small>Registration Form Advisory</small>
    </h1>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li>
                <i class="fa fa-home"></i>
                <a href="../Default.aspx">Home</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="../QuanLyHoSo/PhieuDangKyTuVan.aspx">Phiếu đăng ký tư vấn</a>
            </li>
        </ul>
    </div>
    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-lg-4">
            <div class="panel panel-info">
                <div class="panel-body">
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
            </div>

            <!-- BEGIN GEOCODING PORTLET-->
            <div class="portlet box red">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-globe"></i>Google map
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse"></a>
                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        <a href="javascript:;" class="reload"></a>
                        <a href="javascript:;" class="remove"></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <%--<div id="gmap_basic" class="gmaps"></div>--%>
                    <div class="row">
                        <div class="col-lg-12">
                            <input id="searchbox" class="form-control" type="text" placeholder="Search Box" value="Thành phố Hồ Chí Minh" />
                        </div>
                    </div>
                    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&signed_in=true&libraries=places" type="text/javascript"></script>
                    <input type="text" value="Lat:" id="latbox" />
                    <input type="text" value="Lng:" id="lngbox" />
                    <br />
                    <div id="map-canvas" style="width: 100%; height: 450px;"></div>
                </div>
            </div>
		<!-- END GEOCODING PORTLET-->

        </div>
        <%-- Info --%>
        <div class="col-lg-8">
            <h1>Phiếu Đăng Ký Tư Vấn</h1>
            <div class="panel panel-info">
                <div class="panel-body">
                    <%-- Row 1 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Họ và tên </label><i class="required">*</i>
                                <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFullName" ValidationGroup="validFormAdvisory" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtFullName" Display="Dynamic" ValidationGroup="validFormAdvisory" ValidationExpression="(.){1,200}" runat="server" ErrorMessage="Full Name from 1-200 characters" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <%-- End row 1 --%>
                    <%-- Row 2 --%>
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="control-label">Quốc Gia</label>
                                        <asp:DropDownList ID="dlCountrys" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlCountrys_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="control-label">Tỉnh - Thành Phố</label>
                                        <asp:DropDownList ID="dlProvinces" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dlProvince_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="control-label">Quận / Huyện</label>
                                        <asp:DropDownList ID="dlDistrict" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dlCountrys" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <%-- End row 2 --%>
                    <%-- Row 3 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Phường - Xã / Số nhà - Tên đường</label>
                                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- End row 3 --%>
                    <%-- Row 4 --%>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Ngày sinh</label>
                                <%-- Date picker --%>
                                <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                    <input type="text" class="form-control" id="txtbirthday" runat="server"/>
                                    <span class="input-group-btn">
                                        <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                    </span>
                                </div>
                                <%-- Date picker --%>
                               <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                    runat="server" ControlToValidate="txtbirthday" ValidationGroup="validFormAdvisory" 
                                    ValidationExpression="/^\d{1,2}[\/-]\d{1,2}[\/-]\d{4}$/" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Birthday incorect!">
                                </asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Giới Tính</label>
                                <div class="radio-list">
                                    <label class="radio-inline">
                                        <input type="radio" name="optionsRadios" id="rdnam" value="option1" runat="server" />
                                        Nam
                                    </label>
                                    <label class="radio-inline">
                                        <input type="radio" name="optionsRadios" id="rdnu" value="option2" runat="server" />
                                        Nữ
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- End row 4 --%>
                    <%-- Row 5 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Số điện thoại</label>
                                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                    ControlToValidate="txtPhone"
                                    ValidationGroup="validFormAdvisory"
                                    ValidationExpression="\(?([0-9]{3,4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"
                                    ErrorMessage="<%$Resources:Resource, incorectphonenumber %>"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <%-- End row 5 --%>
                    <%-- Row 6 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Email cá nhân</label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                    ControlToValidate="txtEmail"
                                    ValidationGroup="validFormAdvisory"
                                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                    Display="Dynamic" ForeColor="Red"
                                    ErrorMessage="E-mail không hợp lệ ! { Ví dụ hợp lệ: abc@gmail.com }">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <%-- End row 6 --%>
                    <%-- Row 7--%>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label class="control-label">Phiếu Đăng Ký</label>
                                <asp:DropDownList ID="dlRegistration_Type" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%-- End row 7 --%>
                    <%-- Row 8 --%>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Trình độ học vấn</label>
                                <asp:DropDownList ID="dlEducationLV" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label class="control-label">Quốc Gia Tư Vấn</label>
                                <asp:DropDownList ID="dlCountryAdvisory" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%-- End row 8 --%>
                    <%-- Row 9 --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="control-label">Nội dung tư vấn</label>
                                <CKEditor:CKEditorControl ID="CKContentAdvisory" Toolbar="Basic" runat="server"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                    </div>
                    <%-- End row 9 --%>
                     <div class="clearfix"></div>
                    <asp:Button ID="btnSunmit" CssClass="btn btn-primary pull-right" ValidationGroup="validFormAdvisory" OnClick="btnSunmit_Click" runat="server" Text="Nhập Phiếu Đăng Ký Tư Vấn" />
                </div>
            </div>
        </div>
        <%-- End Info --%>
    </div>
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
       function initialize() {
           var map = new google.maps.Map(document.getElementById('map-canvas'), {
               mapTypeId: google.maps.MapTypeId.ROADMAP
           });
           var input = document.getElementById('searchbox');
           map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
           var searchBox = new google.maps.places.SearchBox(input);
           google.maps.event.addListener(searchBox, 'places_changed', function () {
               var places = searchBox.getPlaces();
               if (places.length == 0) {
                   return;
               }
               //get first place
               var place = places[0];
               var marker = new google.maps.Marker({
                   map: map,
                   title: place.name,
                   position: place.geometry.location
               });
               //var bounds = new google.maps.LatLngBounds();
               //bounds.extend(place.geometry.location);
               //map.fitBounds(bounds);
               map.fitBounds(place.geometry.viewport);
               //save location goes here...
               var lat = place.geometry.location.lat();
               var lng = place.geometry.location.lng();
               document.getElementById('latbox').value = (lat);
               document.getElementById('lngbox').value = (lng);
           });
       }
       initialize();
   </script>
</asp:Content>

