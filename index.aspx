<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="header_slide">
        <div class="header_bottom_left">
            <div class="categories">
                <ul>
                    <h3>Categories</h3>
                    <asp:repeater id="rptCategories" runat="server">
                        <ItemTemplate>
                            <li><a href="ViewProduct.aspx?categotyId=<%#Eval("Category_Id") %>"><%#Eval("category_name") %></a></li>
                        </ItemTemplate>
                    </asp:repeater>                    
                </ul>
            </div>
        </div>
        <div class="header_bottom_right">
            <div class="slider">
                <div id="slider">
                    <div id="mover">
                        <div id="slide-1" class="slide">
                            <div class="slider-img">
                                <a href="preview.html">
                                    <img src="images/slide-1-image.png" alt="learn more" /></a>
                            </div>
                            <div class="slider-text">
                                <h1>BUY NOW<br>
                                    <span>SALE</span></h1>
                                <h2>UPTo 10% OFF</h2>
                                <div class="features_list">
                                    <h4></h4>
                                </div> 
                               <a href="preview.html" class="button">Shop Now</a> 
                            </div>
                            <div class="clear"></div>
                        </div>
                        <div class="slide">
                            <div class="slider-text">
                                <h1>BUY NOW<br>
                                    <span>SALE</span></h1>
                                <h2>UPTo 40% OFF</h2>
                                <div class="features_list">
                                    <h4></h4>
                                </div>
                                <a href="preview.html" class="button">Shop Now</a>
                            </div>
                            <div class="slider-img">
                                <a href="preview.html">
                                    <img src="images/slide-3-image.png" alt="learn more" /></a>
                            </div>
                            <div class="clear"></div>
                        </div>
                        <div class="slide">
                            <div class="slider-img">
                                <a href="preview.html">
                                    <img src="images/slide-2-image.png" alt="learn more" /></a>
                            </div>
                            <div class="slider-text">
                                <h1>BUY NOW<br>
                                    <span>SALE</span></h1>
                                <h2>UPTo 10% OFF</h2>
                                <div class="features_list">
                                    <h4></h4>
                                </div>
                                <a href="preview.html" class="button">Shop Now</a>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <div class="main">
        <div class="content">
            <div class="content_top">
                <div class="heading">
                    <h3>
                        <asp:label runat="server" id="llab" Text="New Products" />
                    </h3>
                </div>
                <div class="see">
                    <p><a href="#">See all Products</a></p>
                </div>
                <div class="clear"></div>
            </div>
            <div class="section group">
                <asp:repeater id="rptProducts" runat="server">
                    <ItemTemplate>
                        <div class="grid_1_of_4 images_1_of_4" >
                            <a href="ViewProductDetailPage.aspx?productId=<%#Eval("PlantId") %>">
                                 <img src="<%#Eval("image1") %>"  alt="<%#Eval("PlantName") %>"  height="170" width="170"/></a>
                            <h2><%#Eval("PlantName") %></h2>
                            <div class="price-details">
                                <div class="price-number">
                                    <p><span class="rupees">Rs.<%#Eval("price") %></span></p>
                                </div>
                                <div class="add-cart">
                                    <h4><a href="ViewProductDetailPage.aspx?productId=<%#Eval("PlantId") %>">Add to Cart</a></h4>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:repeater>
            </div>
        </div>
    </div>

</asp:Content>





