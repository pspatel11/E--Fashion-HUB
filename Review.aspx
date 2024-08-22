<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Review.aspx.cs" Inherits="Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="normalize.css" />
    <link rel="stylesheet" href="style.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript" src="js/jquery.accordion.js"></script>
    <script>
        $(function () {
            var pull = $('#pull');
            menu = $('nav ul');
            menuHeight = menu.height();

            $(pull).on('click', function (e) {
                e.preventDefault();
                menu.slideToggle();
            });

            $(window).resize(function () {
                var w = $(window).width();
                if (w > 320 && menu.is(':hidden')) {
                    menu.removeAttr('style');
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#posts").accordion({
                header: "div.tab",
                alwaysOpen: false,
                autoheight: false
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content" style="padding-left: 20px;">
            <div class="faqs">
                <h2>Our Review</h2>
                <div id="posts">
                    <asp:Repeater ID="rptReviews" runat="server">
                        <ItemTemplate>
                            <div class="tab bar">
                                <h4 class="post-title"><%#Eval("Title") %></h4>
                            </div>
                            <div class="panel margin-lr-7">
                                <p>Post By : <%#Eval("feedBackBy") %> (E-mail : <%#Eval("Email_ID") %>)</p>
                                <p>Review : <%#Eval("msg") %></p>
                                <p>
                                    Rating : <%#Eval("RatingView") %>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

