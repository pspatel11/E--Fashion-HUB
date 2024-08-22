<%@ Page Title="" Language="C#" MasterPageFile="~/Register.master" AutoEventWireup="true" CodeFile="resetPassword.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="contact-form">
                    <h2>Reset Your Password</h2>
                    <asp:hiddenfield id="hdnLoginId" runat="server" />
                    <div id="UserNameDiv" runat="server">
                        <span>
                            <label>User Name</label></span>
                        <span>
                            <asp:textbox runat="server" id="txtUserName" tooltip="User name" cssclass="bigTextBox" placeholder="User Name"></asp:textbox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="Enter The UserName" forecolor="Red"
                                controltovalidate="txtUserName"></asp:requiredfieldvalidator>
                        </span>
                    </div>
                    <div id="validateButtonDiv" runat="server">
                        <span>
                            <asp:button id="btnValidateUser" runat="server" text="Validate User" class="submitButton" onclick="btnValidateUser_Click"></asp:button>
                        </span>
                    </div>
                    <div id="newPassDiv" runat="server">
                        <span>
                            <label>New Password</label></span>
                        <span>
                            <asp:textbox runat="server" id="txtNewPassword" textmode="Password" cssclass="bigTextBox" placeholder="New Password"></asp:textbox>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" errormessage="Enter new Password" forecolor="Red"
                                controltovalidate="txtNewPassword" validationgroup="abc"></asp:requiredfieldvalidator>
                        </span>
                    </div>
                    <div id="newPassConfirmDiv" runat="server">
                        <span>
                            <label>Confirm New Password</label></span>
                        <span>
                            <asp:textbox runat="server" id="txtConfirmNewPassword" textmode="Password" cssclass="bigTextBox" placeholder="Confirm New Password"></asp:textbox>
                            <asp:comparevalidator id="CompareValidator1" runat="server" errormessage="new password and confirm new passowrd is not match"
                                controltovalidate="txtConfirmNewPassword" validationgroup="abc" controltocompare="txtNewPassword" forecolor="Red"></asp:comparevalidator>
                        </span>
                    </div>
                    <div id="SavePassDiv" runat="server">
                        <span>
                            <asp:button id="btnSave" runat="server" text="Save" validationgroup="abc" class="submitButton" onclick="btnSave_Click"></asp:button>
                            <asp:button id="btnCancel" runat="server" text="Cancel" class="cancelButton" onclick="btnCancel_Click"></asp:button>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

