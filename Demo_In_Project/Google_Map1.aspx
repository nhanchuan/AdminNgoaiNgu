<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Google_Map1.aspx.cs" Inherits="Demo_In_Project_Google_Map1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&signed_in=true&libraries=places" type="text/javascript"></script>
        <input type="text" value="Lat:" id="latbox" />
        <input type="text" value="Lng:" id="lngbox" />
        <br />
        <input id="searchbox" type="text" placeholder="Search Box" />
        <div id="map-canvas" style="width: 480px; height: 320px;"></div>
    </form>
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
</body>
    
</html>
