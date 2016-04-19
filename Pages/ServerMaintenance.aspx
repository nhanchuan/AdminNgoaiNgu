﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServerMaintenance.aspx.cs" Inherits="Pages_ServerMaintenance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta http-equiv="Content-type" content="text/html" charset="utf-8" />
<meta content="" name="description"/>
<meta content="" name="author"/>
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="../../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="../../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="../../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="../../assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<link href="../../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="../../assets/admin/pages/css/coming-soon.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN THEME STYLES -->
<link href="../../assets/global/css/components.css" rel="stylesheet" type="text/css"/>
<link href="../../assets/global/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="../../assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css"/>
<link id="style_color" href="../../assets/admin/layout/css/themes/default.css" rel="stylesheet" type="text/css"/>
<link href="../../assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="favicon.ico"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
	<div class="row">
		<div class="col-md-12 coming-soon-header">
			<a class="brand" href="https://www.facebook.com">
			<img src="../images/logo/logoCoke.png" alt="logo"/>
			</a>
		</div>
	</div>
	<div class="row">
		<div class="col-md-6 coming-soon-content">
			<h1>Server Maintenance</h1>
			<h3>
				 Dev đang làm ngày đêm không ngủ để hoàn thành hệ thống. Xin đừng làm phiền! Cám ơn !
			</h3>
			<br />
			<div class="form-inline">
				<div class="input-group input-large">
					<input type="text" class="form-control" />
					<span class="input-group-btn">
					<button class="btn blue" type="button">
					<span>
					Subscribe </span>
					<i class="m-icon-swapright m-icon-white"></i></button>
					</span>
				</div>
			</div>
			<ul class="social-icons margin-top-20">
				<li>
					<a href="#" data-original-title="Feed" class="rss">
					</a>
				</li>
				<li>
					<a href="#" data-original-title="Facebook" class="facebook">
					</a>
				</li>
				<li>
					<a href="#" data-original-title="Twitter" class="twitter">
					</a>
				</li>
				<li>
					<a href="#" data-original-title="Goole Plus" class="googleplus">
					</a>
				</li>
				<li>
					<a href="#" data-original-title="Pinterest" class="pintrest">
					</a>
				</li>
				<li>
					<a href="#" data-original-title="Linkedin" class="linkedin">
					</a>
				</li>
				<li>
					<a href="#" data-original-title="Vimeo" class="vimeo">
					</a>
				</li>
			</ul>
		</div>
		<div class="col-md-6 coming-soon-countdown">
			<div id="defaultCountdown">
			</div>
		</div>
	</div>
	<!--/end row-->
	<div class="row">
		<div class="col-md-12 coming-soon-footer">
			 2016 &copy; Nguyễn Nhân Chuẩn. Developer !.
		</div>
	</div>
</div>
    </form>
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
<!-- BEGIN CORE PLUGINS -->
<!--[if lt IE 9]>
<script src="../../assets/global/plugins/respond.min.js"></script>
<script src="../../assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
<script src="../../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
<!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
<script src="../../assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="../../assets/global/plugins/countdown/jquery.countdown.min.js" type="text/javascript"></script>
<script src="../../assets/global/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="../../assets/global/scripts/metronic.js" type="text/javascript"></script>
<script src="../../assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
<script src="../../assets/admin/layout/scripts/quick-sidebar.js" type="text/javascript"></script>
<script src="../../assets/admin/layout/scripts/demo.js" type="text/javascript"></script>
<script src="../../assets/admin/pages/scripts/coming-soon.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->
<script>
jQuery(document).ready(function() {     
  Metronic.init(); // init metronic core components
Layout.init(); // init current layout
QuickSidebar.init(); // init quick sidebar
Demo.init(); // init demo features
  ComingSoon.init();
  // init background slide images
    $.backstretch([
            "../../assets/admin/pages/media/bg/1.jpg",
            "../../assets/admin/pages/media/bg/2.jpg",
            "../../assets/admin/pages/media/bg/3.jpg",
    "../../assets/admin/pages/media/bg/4.jpg"
        ], {
        fade: 1000,
        duration: 10000
   });
});
$('#defaultCountdown').countdown({ since: new Date(2016, 0, 0) });
</script>
<!-- END JAVASCRIPTS -->
</body>

</html>
