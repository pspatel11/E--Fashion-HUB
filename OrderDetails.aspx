<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content" style="padding-left: 20px;">
            <div class="section group">

                <div class="contact-form">
                    <h2>Your orders</h2>
                    <div class="section group">
                        Search by Order No.
                        <asp:TextBox runat="server" ID="txtSearch" ToolTip="Order No" CssClass="bigTextBox" placeholder="Write Your Order No"></asp:TextBox>
                        <asp:Button ID="btnSubmit" runat="server" Text="Search" ToolTip="Search Your Order Details" class="submitButton"></asp:Button>
                    </div>
                    <div class="section group">
                        <div class="col span_3_of_3">
                            <div class="grd">
                                <span>
                                    <asp:GridView ID="grdPlant" runat="server" AutoGenerateColumns="false" DataKeyNames="plant_Id">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="plant name" DataField="plant_name" />
                                            <asp:BoundField HeaderText="Category" DataField="category_name" />
                                            <asp:BoundField HeaderText="Status Check" DataField="Status_check" />
                                            <asp:BoundField HeaderText="price" DataField="price" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img src="<%#Eval("image1") %>" height="100" width="100" alt="image1" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img src="<%#Eval("image2") %>" height="100" width="100" alt="image2" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings NextPageText="next" PreviousPageText="pervious" />
                                    </asp:GridView>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
