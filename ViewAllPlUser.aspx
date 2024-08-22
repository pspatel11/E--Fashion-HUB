<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.master" AutoEventWireup="true" CodeFile="ViewAllPlUser.aspx.cs" Inherits="ViewAllPlantsUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header_slide">
        <div class="header_bottom_left">
            <div class="categories">

                <h3>Categories</h3>
                <br />
                <span>
                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="dropDownBox" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                    </asp:DropDownList>
                </span>
                <br />
            </div>
        </div>
        <div class="header_bottom_right">
            <div class="content">
                <div class="section group">
                    <asp:Repeater ID="rptProducts" runat="server">
                        <ItemTemplate>
                            <div class="grid_1_of_4 images_1_of_4">
                                <a href="PlaceOrder.aspx?Id=<%#Eval("PlantId") %>">
                                    <img src="<%#Eval("image1") %>" alt="<%#Eval("PlantName") %>" height="170" width="170" /></a>
                                <h2><%#Eval("PlantName") %></h2>
                                <div class="price-details">
                                    <div class="price-number">
                                        <p><span class="rupees">Rs.<%#Eval("price") %></span></p>
                                    </div>
                                    <div class="add-cart">
                                        <h4><a href="PlaceOrder.aspx?Id=<%#Eval("PlantId") %>">View</a></h4>
                                    </div>
                                    <div class="clear"></div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>

