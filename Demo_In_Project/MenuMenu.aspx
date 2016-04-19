<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuMenu.aspx.cs" Inherits="Demo_In_Project_MenuMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous" />
    <style>
        body {
  background-color: #60B9CE;  
}

* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  list-style: none;
  position: relative;
}

button {
  border: none;
  background: none;
  cursor: pointer;
  color: #fff;
  position: fixed;
  height: 3.5em;
  width: 3.5em;
  right: 0;
  bottom: 0;
  z-index: 11;
  padding-bottom: 1.5em;
  padding-left: 0.8em;
  font-size: 1.5em;
  text-align: left;
  background-color: #a8453c;
  border-radius: 50%;
  -webkit-transform: translate(50%, 50%);
  outline: none;
}

button:hover, button:active, button:focus {
  background-color: #893630;
}

.wrapper {
  font-size: 1em;
  position: fixed;
  width: 13em;
  height: 26em;
  bottom: -13em;
  right: 0;
  z-index: 10;
  overflow: hidden;
  margin-left: -13em;
  border-radius: 50% 0 0 0;
  -webkit-transform: scale(0.1);
  -webkit-transition: all 0.3s ease;
  -webkit-transform-origin: 100% 50%;
}

.opened {
  border-radius: 50% 0 0 0;
  -webkit-transform: scale(1);
}

.wrapper li {
  font-size: 1.5em;  
  position: absolute;
  overflow: hidden;
  width: 10em;
  height: 10em;
  right: 0;
  top: 50%;
  margin-top: -1.3em;
  margin-left: -10em;
  -webkit-transform-origin: 100% 100%;
  -webkit-transition: border 0.3s ease;
}

.wrapper li a {
  display: block;
  font-size: 1.18em;
  font-family: 'Open Sans';
  position: absolute;
  height: 14.5em;
  width: 14.5em;
  bottom: -7.25em;
  right: -7.25em;
  padding-top: 0.7em;
  border-radius: 50%;
  color: #fff;
  text-decoration: none;
  text-align: center;
  text-transform: uppercase;
  -webkit-transform: skew(-60deg) rotate(-75deg) scale(1);
  -webkit-transition: background-color 0.3s, color 0.3s;
}

.wrapper li a span {
  position: relative;
  display: block;
  font-size: 0.55em;
  opacity: 0.7;
}
.wrapper li a span i {
  display: block;
  margin-top: 0.8em;
  font-size: 1.7em;
}

.wrapper li:first-child {
  -webkit-transform: rotate(0deg) skew(60deg);
}

.wrapper li:nth-child(2) {
  -webkit-transform: rotate(30deg) skew(60deg);
}

.wrapper li:nth-child(3) {
  -webkit-transform: rotate(60deg) skew(60deg);
}

.wrapper li:nth-child(4) {
  -webkit-transform: rotate(90deg) skew(60deg);
}

.wrapper li:nth-child(5) {
  -webkit-transform: rotate(120deg) skew(60deg);
}

.wrapper li:nth-child(6) {
  -webkit-transform: rotate(150deg) skew(60deg);
}

.wrapper li:nth-child(odd) a {
  background-color: #e74c3c;
}

.wrapper li:nth-child(even) a {
  background-color: #c0392b;
}

.wrapper li a:hover {
  background-color: #ea7064
}

.overlay {
  width: 100%;
  height: 100%;
  background-color: rgba(0,0,0,0.6);
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: 2;
  opacity: 0;
  transition: all 0.3s ease;
  pointer-events: none;
}

.overlay.on-overlay {
  opacity: 1;
  pointer-events: auto;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="corner-menu">
            <button id="expand-navigation">-</button>

            <section class="wrapper opened">
                <ul>
                    <li><a href="/Cinemarine"><span>SİNEMA <i class="fa fa-film"></i></span></a></li>
                    <li><a href="/Stores/category/3"><span>EĞLENCE <i class="fa fa-play-circle"></i></span></a></li>
                    <li><a href="/ulasim"><span>ULAŞIM <i class="fa fa-map-marker"></i></span></a></li>
                </ul>
            </section>

            <div class="overlay on-overlay"></div>
        </div>

    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script type="text/javascript">
        (function () {
            'use strict';

            var isOpen = true,
                button = $('#expand-navigation'),
                wrapper = $('.wrapper'),
                overlay = $('.overlay');

            button.on('click', navigationHandler);
            $(document).on('click', closeNavigation);

            function navigationHandler(event) {
                if (event == null) {
                    event = window.event;
                }

                event.stopPropagation();

                !isOpen ? openNavigation() : closeNavigation();
            }

            function openNavigation() {
                isOpen = true;

                button.html('-');
                wrapper.addClass('opened');
                overlay.addClass('on-overlay');
            }

            function closeNavigation() {
                isOpen = false;

                button.html('+');
                wrapper.removeClass('opened');
                overlay.removeClass('on-overlay');
            }
        })();

    </script>
</body>
</html>
