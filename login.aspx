<%@ Page Title="" Language="C#" MasterPageFile="~/Register.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="contact-form">
                    <h2>Login</h2>
                    <div>
                        <span>
                            <asp:Label ID="lblError" runat="server" ForeColor="Red"    ></asp:Label></span>
                        <asp:HiddenField runat ="server" ID="hdnType" />
                        <asp:HiddenField runat ="server" ID="hdnPlantId" />
                    </div>
                    <div>
                        <span>
                            <label>User Name</label></span>
                        <span>
                            <asp:TextBox runat="server" ID="txtUserName"   ToolTip="User name" CssClass="bigTextBox" placeholder="User Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter The UserName" ForeColor="Red"
                                ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="expression is not valid"
                                ControlToValidate="txtUserName" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-z])*@([0-9a-zA-Z][-.\w]*)+[a-zA-z]{2,9})$"></asp:RegularExpressionValidator>--%>
                            <%--ValidationExpression="^[0-9]{10}$"(10degit phone number)--%>
                            <%--ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"(Email Validation)--%>
                            <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Range is not valid" ControlToValidate="txtpassword" MaximumValue="10" MinimumValue="1"></asp:RangeValidator>--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter The UserName" ForeColor="Red"
                                ControlToValidate="txtUserName"></asp:RequiredFieldValidator>--%>
                        </span>
                    </div>
                    <div>
                        <span>
                            <label>Password</label></span>
                        <span>
                            <asp:TextBox runat="server" ID="txtPassword"    CssClass="bigTextBox" TextMode="Password" placeholder="Password"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter The Password" ForeColor="Red"
                                ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="password and confirm passowrd is not match"
                                ControlToValidate="txtConfirmpassword" ControlToCompare="txtpassword" ForeColor="Red"></asp:CompareValidator>--%>
                        </span>
                    </div>
                    <div>
                        <span>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" class="submitButton" OnClick="btnLogin_Click"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="cancelButton"></asp:Button>
                            <a href="resetPassword.aspx" style="text-decoration: underline;margin-left:5px">Forgot Password.?</a>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

