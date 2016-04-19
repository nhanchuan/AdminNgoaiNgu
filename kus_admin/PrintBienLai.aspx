<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintBienLai.aspx.cs" Inherits="kus_admin_PrintBienLai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous" />
    <style>
        body {
            font-size: 12px;
        }

        .title {
            margin-bottom: 0.5%;
            font-size: 14px;
            margin-top: 0;
            font-weight: bold;
        }

        .sample {
            padding: 0 5%;
        }

        #TilteBL1 {
            margin-bottom: 1%;
        }
        #TilteBL2 {
            margin-bottom: 1%;
        }

        td {
            padding: 0.5% 0;
        }

        address {
            line-height: 180%;
        }

        table {
            margin-bottom: 0%;
        }

        .thutien {
            margin-bottom: 7%;
        }

        hr {
            border-color: black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <%-- LIÊN 1 --%>
        <div class="row" style="margin-bottom:0%!important;">
            <div class="col-md-6 col-sm-6 col-xs-6">
                <h6 class="title">Anh Văn Hội Anh Mỹ</h6>
                <address>
                    230 phan huy ích, phường 12, gò vấp<br />
                    Tel: 0999 888 777<br />
                    Email: <a href="#"> </a><br />
                    Website: www.kus.edu.vn
                </address>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-6 text-center sample">
                <strong>Mẫu số: 01 - TT</strong><br />
                <strong>(Ban hành theo QĐ số 48/2006/QĐ - BTC ngày 18/03/2016 của BỘ trưởng BTC)</strong>
            </div>
        </div>
        <div class="text-center" id="TilteBL">
            <h6 class="title">BIÊN LAI THU TIỀN</h6>
            Ngày <asp:Label ID="lbldayLien1" runat="server" Text="Label"></asp:Label> tháng <asp:Label ID="lblmonthLien1" runat="server" Text="Label"></asp:Label> năm <asp:Label ID="lblyearLien1" runat="server" Text="Label"></asp:Label><br />
            <strong>SỐ: <asp:Label ID="lblBienLaicodeLien1" runat="server" Text="Label"></asp:Label> (Liên 1)</strong>
        </div>
        <table border="0" style="width:100%;">
            <tr>
                <td style="width:20%;">Mã ghi danh:</td>
                <td style="width:35%;"><strong>
                    <asp:Label ID="lblMaGhiDanhLien1" runat="server" Text="Label"></asp:Label></strong>
                </td>
                <td style="width:18%;">Họ và tên: </td>
                <td style="width:22%;">
                    <asp:Label ID="lblHoTenHVLien1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Lớp học: </td>
                <td>
                    <strong><asp:Label ID="lblLopHocLien1" runat="server" Text="Label"></asp:Label></strong>
                </td>
                <td>Thời lượng đăng ký :</td>
                <td>
                    <asp:Label ID="lblthoiluongLien1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Nhân viên ghi danh: </td>
                <td>
                    <strong>
                        <asp:Label ID="NVGhiDanhLien1" runat="server" Text="Label"></asp:Label>
                    </strong>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Địa chỉ :</td>
                <td>
                    <asp:Label ID="lblDiaChiLien1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Điện thoại</td>
                <td>
                    <asp:Label ID="lblDienthoaiLien1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Lý do</td>
                <td colspan="3">
                    <asp:Label ID="lblLyDoThuLien1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Thành tiền :</td>
                <td colspan="3">
                    <asp:Label ID="lblThanhTienLien1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Viết bằng chữ :</td>
                <td colspan="3"><strong>
                    <asp:Label ID="lblThanhTienChuLien1" runat="server" Text="Label"></asp:Label>
                                </strong></td>
            </tr>
        </table>
        <div class="row thutien">
            <div class="col-md-4 col-xs-4 text-center">
                <strong>Người nộp tiền</strong><br />
                <strong>(Ký, họ tên)</strong>
            </div>
            <div class="col-md-4 col-xs-4 text-center">
                <strong>Người thu tiền</strong><br />
                <strong>(Ký, họ tên)</strong>
            </div>
            <div class="col-md-4 col-xs-4 text-center">
                <strong>Thủ quỹ</strong><br />
                <strong>(Ký, họ tên)</strong>
            </div>
        </div>
        <i style="font-size:10px;">Ghi chú : Trung tâm sẽ không giải quyết mọi khiếu nại nếu Biên Lai Thu Phí, Lệ Phí bị mất.</i>
        <%-- END LIÊN1 --%>
        <hr style="margin-bottom:2%; margin-top:2%;" />
        <%-- BEGIN LIÊN 2 --%>
        <div class="row">
            <div class="col-md-6 col-sm-6 col-xs-6">
                <h6 class="title">Anh Văn Hội Anh Mỹ</h6>
                <address>
                    230 phan huy ích, phường 12, gò vấp<br />
                    Tel: 0999 888 777<br />
                    Email: <a href="#"> </a><br />
                    Website: www.kus.edu.vn
                </address>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-6 text-center sample">
                <strong>Mẫu số: 01 - TT</strong><br />
                <strong>(Ban hành theo QĐ số 48/2006/QĐ - BTC ngày 18/03/2016 của BỘ trưởng BTC)</strong>
            </div>
        </div>
        <div class="text-center" id="TilteBL2">
            <h6 class="title">BIÊN LAI THU TIỀN</h6>
            Ngày <asp:Label ID="lbldayLien2" runat="server" Text="Label"></asp:Label> tháng <asp:Label ID="lblmonthLien2" runat="server" Text="Label"></asp:Label> năm <asp:Label ID="lblyearLien2" runat="server" Text="Label"></asp:Label><br />
            <strong>SỐ: <asp:Label ID="lblBienLaicodeLien2" runat="server" Text="Label"></asp:Label> (Liên 2)</strong>
        </div>
        <table border="0" style="width:100%;">
            <tr>
                <td style="width:20%;">Mã ghi danh:</td>
                <td style="width:40%;">
                    <strong>
                        <asp:Label ID="lblMaGhiDanhLien2" runat="server" Text="Label"></asp:Label>
                    </strong>
                </td>
                <td style="width:18%;">Họ và tên: </td>
                <td style="width:22%;">
                    <asp:Label ID="lblHoTenHVLien2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Lớp học: </td>
                <td><strong>
                    <asp:Label ID="lblLopHocLien2" runat="server" Text="Label"></asp:Label>
                    </strong></td>
                <td>Thời lượng đăng ký</td>
                <td>
                    <asp:Label ID="lblthoiluongLien2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Nhân viên ghi danh: </td>
                <td><strong>
                    <asp:Label ID="NVGhiDanhLien2" runat="server" Text="Label"></asp:Label>
                    </strong></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Địa chỉ</td>
                <td>
                    <asp:Label ID="lblDiaChiLien2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Điện thoại</td>
                <td>
                    <asp:Label ID="lblDienthoaiLien2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Lý do</td>
                <td colspan="3">
                    <asp:Label ID="lblLyDoThuLien2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Thành tiền</td>
                <td colspan="3">
                    <asp:Label ID="lblThanhTienLien2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Viết bằng chữ </td>
                <td colspan="3"><strong>
                    <asp:Label ID="lblThanhTienChuLien2" runat="server" Text="Label"></asp:Label>
                                </strong></td>
            </tr>
        </table>
        <div class="row thutien">
            <div class="col-md-4 col-xs-4 text-center">
                <strong>Người nộp tiền</strong><br />
                <strong>(Ký, họ tên)</strong>
            </div>
            <div class="col-md-4 col-xs-4 text-center">
                <strong>Người thu tiền</strong><br />
                <strong>(Ký, họ tên)</strong>
            </div>
            <div class="col-md-4 col-xs-4 text-center">
                <strong>Thủ quỹ</strong><br />
                <strong>(Ký, họ tên)</strong>
            </div>
        </div>
        <i style="font-size:10px;">Ghi chú : Trung tâm sẽ không giải quyết mọi khiếu nại nếu Biên Lai Thu Phí, Lệ Phí bị mất.</i>
        <%-- END LIÊN 2 --%>
    </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
</body>
</html>
