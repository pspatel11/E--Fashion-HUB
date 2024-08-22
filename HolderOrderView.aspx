<%@ Page Title="" Language="C#" MasterPageFile="~/Holder.master" AutoEventWireup="true" CodeFile="HolderOrderView.aspx.cs" Inherits="HolderOrderView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content" style="padding-left: 20px;">
            <div class="section group">
                <div class="contact-form">
                    <h2>Users orders</h2>
                    <div class="section group">
                        <div class="col span_3_of_3">
                            <div class="grd">
                                <span>
                                    <asp:GridView ID="grdOrder" runat="server" AutoGenerateColumns="false" DataKeyNames="Order_ID" RowStyle-VerticalAlign="Top">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-VerticalAlign="Top">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="User" DataField="UserName" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Order No" DataField="order_no" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Item" DataField="ItemName" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Quantity" DataField="quantity" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Order Amount" DataField="Order_amount" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Order Date" DataField="orderDate" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Deliver Address" DataField="Deliver_address" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Confirmation Status" DataField="ConfirmMsg" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Shippment Status" DataField="ShippmentMsg" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Delivery Status" DataField="DeliveryMsg" ItemStyle-VerticalAlign="Top" />
                                            <asp:BoundField HeaderText="Payment Status" DataField="PaymentMsg" ItemStyle-VerticalAlign="Top" />
                                            <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img src="<%#Eval("image1") %>" height="100" width="100" alt="image1" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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


