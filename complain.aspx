<%@ Page Title="" Language="C#" MasterPageFile="~/Home.master" AutoEventWireup="true" CodeFile="complain.aspx.cs" Inherits="COMPLAIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="col span_2_of_3">
                    <div class="contact-form">
                        <h2>Complain</h2>
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
                                <label>Your Complain</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtFeedback" TextMode="MultiLine" ToolTip="Your Complain" CssClass="bigTextBox" placeholder="Your Complain"></asp:TextBox>
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

