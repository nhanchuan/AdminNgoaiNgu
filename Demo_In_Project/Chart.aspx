<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Chart.aspx.cs" Inherits="Demo_In_Project_Chart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../App_Themes/admin/StylePortlet.css" rel="stylesheet" />
    <link href="../assets/admin/pages/css/profile-old.css" rel="stylesheet" />
    <div class="row">
        <%-- Begin chart --%>
        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-edit"></i>Biểu đồ thống kê
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <button id="btnreloadmodal" class="btn green" runat="server"><i class="fa fa-refresh"></i></button>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body background">
                <%-- Begin chart --%>
                
                <div class="panel panel-info">
                    <div class="panel-body">
                        <div id="chart_5at" class="chart" style="height: 400px;">
                        </div>
                    </div>
                </div>

                <%-- End chart --%>
            </div>
        </div>
        <%-- End chart --%>
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

    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <asp:HiddenField ID="HiddenField6" runat="server" />
    <asp:HiddenField ID="HiddenField7" runat="server" />
    <asp:HiddenField ID="HiddenField8" runat="server" />
    <asp:HiddenField ID="HiddenField9" runat="server" />
    <asp:HiddenField ID="HiddenField10" runat="server" />
    <asp:HiddenField ID="HiddenField11" runat="server" />
    <asp:HiddenField ID="HiddenField12" runat="server" />
    <asp:HiddenField ID="HiddenField13" runat="server" />
    <asp:HiddenField ID="HiddenField14" runat="server" />
    <asp:HiddenField ID="HiddenField15" runat="server" />
    <asp:HiddenField ID="HiddenField16" runat="server" />
    <asp:HiddenField ID="HiddenField17" runat="server" />

    <script type="text/javascript">
            var chart = AmCharts.makeChart("chart_5at", {
                "theme": "light",
                "type": "serial",
                "startDuration": 2,
                "fontFamily": 'Open Sans',
                "color": '#888',
                "dataProvider": [{
                    "country": "USA",
                    "visits": document.getElementById('<%=HiddenField1.ClientID %>').value,
                    "color": "#FF0F00"
                }, {
                    "country": "Australia",
                    "visits": document.getElementById('<%=HiddenField2.ClientID %>').value,
                    "color": "#999999"
                }, {
                    "country": "Canada",
                    "visits": document.getElementById('<%=HiddenField3.ClientID %>').value,
                    "color": "#CD0D74"
                }, {
                    "country": "UK",
                    "visits": document.getElementById('<%=HiddenField4.ClientID %>').value,
                    "color": "#F8FF01"
                }, {
                    "country": "Thụy Sỹ",
                    "visits": document.getElementById('<%=HiddenField5.ClientID %>').value,
                    "color": "#FF6600"
                }, {
                    "country": "Singapore",
                    "visits": document.getElementById('<%=HiddenField6.ClientID %>').value,
                    "color": "#0D8ECF"
                }, {
                    "country": "New Zealand",
                    "visits": document.getElementById('<%=HiddenField7.ClientID %>').value,
                    "color": "#04D215"
                }, {
                    "country": "Taiwan",
                    "visits": document.getElementById('<%=HiddenField8.ClientID %>').value,
                    "color": "#008000"
                }, {
                    "country": "Netherlands",
                    "visits": document.getElementById('<%=HiddenField9.ClientID %>').value,
                    "color": "#0D52D1"
                }, {
                    "country": "Germany",
                    "visits": document.getElementById('<%=HiddenField10.ClientID %>').value,
                    "color": "#FCD202"
                }, {
                    "country": "South Korea",
                    "visits": document.getElementById('<%=HiddenField11.ClientID %>').value,
                    "color": "#8A0CCF"
                }, {
                    "country": "Hungary",
                    "visits": document.getElementById('<%=HiddenField12.ClientID %>').value,
                    "color": "#2A0CD0"
                }, {
                    "country": "Malaysia",
                    "visits": document.getElementById('<%=HiddenField13.ClientID %>').value,
                    "color": "#754DEB"
                }, {
                    "country": "Japan",
                    "visits": document.getElementById('<%=HiddenField14.ClientID %>').value,
                    "color": "#FF9E01"
                }, {
                    "country": "France",
                    "visits": document.getElementById('<%=HiddenField15.ClientID %>').value,
                    "color": "#B0DE09"
                }, {
                    "country": "Philippines",
                    "visits": document.getElementById('<%=HiddenField16.ClientID %>').value,
                    "color": "#DDDDDD"
                }, {
                    "country": "Phần Lan",
                    "visits": document.getElementById('<%=HiddenField17.ClientID %>').value,
                    "color": "#000000"
                }],
                "valueAxes": [{
                    "position": "left",
                    "axisAlpha": 0,
                    "gridAlpha": 0
                }],
                "graphs": [{
                    "balloonText": "[[category]]: <b>[[value]]</b>",
                    "colorField": "color",
                    "fillAlphas": 0.85,
                    "lineAlpha": 0.1,
                    "type": "column",
                    "topRadius": 1,
                    "valueField": "visits"
                }],
                "depth3D": 40,
                "angle": 30,
                "chartCursor": {
                    "categoryBalloonEnabled": false,
                    "cursorAlpha": 0,
                    "zoomable": false
                },
                "categoryField": "country",
                "categoryAxis": {
                    "gridPosition": "start",
                    "axisAlpha": 0,
                    "gridAlpha": 0

                },
                "exportConfig": {
                    "menuTop": "20px",
                    "menuRight": "20px",
                    "menuItems": [{
                        "icon": '../images/export.png',
                        "format": 'png'
                    }]
                }
            }, 0);

            $('#chart_5at').closest('.portlet').find('.fullscreen').click(function () {
                chart.invalidateSize();
            });
        </script>
</asp:Content>

