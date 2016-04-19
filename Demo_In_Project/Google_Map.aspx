<%@ Page Title="" Language="C#" MasterPageFile="~/GlobalMasterPage.master" AutoEventWireup="true" CodeFile="Google_Map.aspx.cs" Inherits="Demo_In_Project_Google_Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <!-- BEGIN GEOCODING PORTLET-->
        <div class="portlet box red">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-gift"></i>Geocoding
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="javascript:;" class="reload"></a>
                    <a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <div id="gmap_basic" class="gmaps">
                </div>
            </div>
        </div>
        <!-- END GEOCODING PORTLET-->
    </div>
    <script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
   <%-- <script src="../assets/global/plugins/gmaps/gmaps.min.js"></script>--%>
    <script src="../assets/global/plugins/gmaps/gmaps.js"></script>
</asp:Content>

