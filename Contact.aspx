<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="col span_2_of_3">
                    <div class="contact-form">
                        <h2>Contact Us</h2>
                        <div>
                            <span>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></span>
                        </div>
                        <div>
                            <span>
                                <label>Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtName" ToolTip="Name" CssClass="bigTextBox" placeholder="Name"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>E-mail</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtEmail" ToolTip="E-mail" CssClass="bigTextBox" placeholder="E-mail"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>Phone</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtPhoneNo" ToolTip="Phone No" CssClass="bigTextBox" placeholder="Phone No"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>Product Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtProductName" ToolTip="Product Name" CssClass="bigTextBox" placeholder="Product Name"></asp:TextBox>
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>Subject</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtSubject" TextMode="MultiLine" ToolTip="Subject" CssClass="bigTextBox" placeholder="Subject"></asp:TextBox>
                            </span>

                        </div>
                        <div>
                            <span>
                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" ToolTip="Submit your details. We will contact you as soon as posibile." class="submitButton"></asp:Button>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" class="cancelButton"></asp:Button>
                            </span>
                        </div>
                          
                    </div>
                </div>
                <div class="col span_1_of_3">
                    <div class="contact_info">
                        <h3>Find Us Here</h3>
                        <div class="map">
                            <iframe width="100%" height="175" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265&amp;output=embed"></iframe>
                            <br>
                            <small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265" style="color: #666; text-align: left; font-size: 12px">View Larger Map</a></small>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

