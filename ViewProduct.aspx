<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="content_top">
                <div class="heading">
                    <h3>
                        <asp:Label runat="server" ID="lblCategoryName" />
                    </h3>

                </div>
                <div class="see">
                    <p><a href="#">See all Products</a></p>
                </div>
                <div class="clear"></div>
            </div>
            <div class="section group">
                <asp:Repeater ID="rptProducts" runat="server">
                    <ItemTemplate>
                        <div class="grid_1_of_4 images_1_of_4">
                            <a href="ViewProductDetailPage.aspx?productId=<%#Eval("PlantId") %>">
                                 <img src="<%#Eval("image1") %>"  alt="<%#Eval("PlantName") %>"   height="170" width="170"/></a>
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
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

