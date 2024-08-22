<%@ Page Title="" Language="C#" MasterPageFile="~/Register.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="contact-form">
                    <h2>Free Registration</h2>
                    <div>
                        <span>
                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                        </span>
                    </div>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>First Name</label>
                            </span>
                            <span>
                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="bigTextBox" placeholder="First Name"  ValidateRequestMode="Disabled"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter The First name" ForeColor="Red"
                                    ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Middle Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtMiddleName" CssClass="bigTextBox" placeholder="Middle Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter The middle name" ForeColor="Red"
                                    ControlToValidate="txtMiddleName"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>SurName</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtSurname" CssClass="bigTextBox" placeholder="Surname"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter The surname" ForeColor="Red"
                                    ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>Email id</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="bigTextBox" placeholder="Email Id"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Email ID" ForeColor="Red"
                                    ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Mobile Number</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtMobileNumber" CssClass="bigTextBox" placeholder="Mobile Number"></asp:TextBox>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Phone No 1</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtPhone2" CssClass="bigTextBox" placeholder="Phone 2"></asp:TextBox>
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>Password</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="bigTextBox" placeholder="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter The Password" ForeColor="Red"
                                    ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Confirm Password</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="bigTextBox" placeholder="Confirm Password"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="password and confirm passowrd is not match"
                                    ControlToValidate="txtConfirmpassword" ControlToCompare="txtpassword" ForeColor="Red"></asp:CompareValidator>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>location</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtlocation" CssClass="bigTextBox" placeholder="Location"></asp:TextBox>
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>Gender</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlGender" CssClass="dropDownBox">
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                </asp:DropDownList>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Birthday</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtBirthday" CssClass="bigTextBox" placeholder="Birthday"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBirthday" runat="server"></cc1:CalendarExtender>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Postal Code</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtPostalCode" CssClass="bigTextBox" placeholder="Postal Code"></asp:TextBox>
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <div class="col span_2_of_3" style="width: 92%">
                            <span>
                                <label>Address</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" CssClass="bigTextBox" placeholder="Address"></asp:TextBox>
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>Country</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlCountry" AutoPostBack="true" class="dropDownBox" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span>
                        </div>

                        <div class="col span_1_of_3">
                            <span>
                                <label>State</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlState" class="dropDownBox" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                </asp:DropDownList>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>City</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlCity" class="dropDownBox">
                                </asp:DropDownList>
                            </span>
                        </div>
                    </div>
                    <div class="section group">

                        <asp:Button ID="btnRegister" runat="server" Text="Register" class="submitButton" OnClick="btnRegister_Click"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="cancelButton"></asp:Button>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

