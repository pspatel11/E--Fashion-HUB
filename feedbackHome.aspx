<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="feedbackHome.aspx.cs" Inherits="feedbackHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="col span_2_of_3">
                    <div class="contact-form">
                        <h2>Feedback</h2>
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
                                <label>Subject</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtSubject" TextMode="MultiLine" ToolTip="Subject" CssClass="bigTextBox" placeholder="Subject"></asp:TextBox>
                            </span>

                        </div>
                        <div>
                            <span>
                                <label>Your Feedback</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtFeedback" TextMode="MultiLine" ToolTip="Your Feedback" CssClass="bigTextBox" placeholder="Your Feedback"></asp:TextBox>
                            </span>

                        </div>


                        <div>
                            <span>
                                <label>Rating</label></span>
                            <span>
                                <asp:RadioButtonList ID="rblRting" runat="server" RepeatDirection="Horizontal" BorderStyle="None" BorderWidth="0px">
                                    <asp:ListItem Text="1" Value="1 "></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3 "></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                </asp:RadioButtonList>

                            </span>

                        </div>
                        <div>
                            <span>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit your Feedback" class="submitButton" OnClick="btnSubmit_Click"></asp:Button>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" class="cancelButton"></asp:Button>
                            </span>
                        </div>

                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>

