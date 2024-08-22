<%@ Page Title="" Language="C#" MasterPageFile="~/Holder.master" AutoEventWireup="true" CodeFile="ProductViewForHolder.aspx.cs" Inherits="ProductViewForHolder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
    <link href="css/easy-responsive-tabs.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="stylesheet" href="css/global.css" />
    <script src="js/slides.min.jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#products').slides({
                preload: true,
                preloadImage: 'img/loading.gif',
                effect: 'slide, fade',
                crossfade: true,
                slideSpeed: 350,
                fadeSpeed: 500,
                generateNextPrev: true,
                generatePagination: false
            });
        });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="content_top">
                <h2 style="margin: 0px; color: #CD1F25;">
                    <asp:Label runat="server" ID="lblProductName" /><asp:HiddenField runat="server" ID="hdnProductId" />
                </h2>
            </div>
            <div class="section group">
                <div class="cont-desc">
                    <div class="product-details">
                        <div class="grid images_1_of_2">
                            <div id="container">
                                <div id="products_example">
                                    <div id="products">
                                        <div class="slides_container" style="height: 275px; width: 365px">
                                            <a href="#" target="_blank">
                                                <asp:Image ID="images1" runat="server" CssClass="productDetailImage" alt=" " /></a>
                                            <a href="#" target="_blank">
                                                <asp:Image ID="images2" runat="server" alt=" " CssClass="productDetailImage" /></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="desc span_3_of_2">
                            Description :<br />
                            <p runat="server" id="lblDescription" style="display: block; text-align: justify; text-transform: capitalize">
                            </p>
                            <br />
                            <div class="price">
                                Price: <span>Rs.<asp:Label runat="server" ID="lblPrice" /></span>
                            </div>
                            <br />
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="product_desc">
                        <div id="horizontalTab">
                            <ul class="resp-tabs-list">
                                <li>Other Info</li>
                                <li>Information</li>
                                <li>Holder Info</li>
                                <div class="clear"></div>
                            </ul>
                            <div class="resp-tabs-container">
                                <div class="product-desc">
                                    <p>
                                        <asp:Label runat="server" ID="lblCareInfo" />
                                    </p>
                                </div>
                                <div class="product-tags">
                                    <p>
                                        <asp:Label runat="server" ID="lblPlantationInfo" />
                                    </p>
                                </div>
                                <div class="product-tags">
                                    <p>
                                        <asp:Label runat="server" ID="lblHDName" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDShortInfo" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDAddress" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDOfficeNo" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDFaxNo" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDWebsite" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDPerson" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDServiceEmailId" />
                                        <br />
                                        <asp:Label runat="server" ID="lblHDInfoEMailId" />"

                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $('#horizontalTab').easyResponsiveTabs({
                                type: 'default', //Types: default, vertical, accordion
                                width: 'auto', //auto or any width like 600px
                                fit: true   // 100% fit in a container
                            });
                        });
                    </script>

                </div>
            </div>
        </div>
    </div>
    <div class="main">
        <div class="content">
            <div class="content_top">
                <div class="heading">
                    <h3>
                        <asp:Label runat="server" ID="llab" Text="Related Products" />
                    </h3>
                </div>
                <div class="clear"></div>
            </div>
            <div class="section group">
                <asp:Repeater ID="rptProducts" runat="server">
                    <ItemTemplate>
                        <div class="grid_1_of_4 images_1_of_4">
                            <a href="ProductViewForHolder.aspx?productId=<%#Eval("PlantId") %>">
                                <img src="<%#Eval("image1") %>" alt="<%#Eval("PlantName") %>" height="170" width="170" /></a>
                            <h2><%#Eval("PlantName") %></h2>
                            <div class="price-details">
                                <div class="price-number">
                                    <p><span class="rupees">Rs.<%#Eval("price") %></span></p>
                                </div>
                                <div class="add-cart">
                                    <h4><a href="ProductViewForHolder.aspx?productId=<%#Eval("PlantId") %>">View</a></h4>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>


