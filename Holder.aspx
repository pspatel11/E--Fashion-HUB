<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Holder.aspx.cs" Inherits="Holder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="contact-form">
                    <h2>Holder Registration</h2>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>Name</label>
                            </span>
                            <span>
                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="bigTextBox" placeholder="First Name" ValidateRequestMode="Disabled"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter The name" ForeColor="Red"
                                    ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Contact Person Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtPersonName" CssClass="bigTextBox" placeholder="Middle Name"></asp:TextBox>

                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Contact no.</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtContactNo" CssClass="bigTextBox" placeholder="Surname"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter The contact no" ForeColor="Red"
                                    ControlToValidate="txtContactNo"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <div class="col span_2_of_3" style="width: 92%">
                            <span>
                                <label>Short Info</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtShortInfo" TextMode="MultiLine" CssClass="bigTextBox" placeholder="Short information"></asp:TextBox>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Country" ForeColor="Red"
                                    ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                            </span>
                        </div>

                        <div class="col span_1_of_3">
                            <span>
                                <label>State</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlState" class="dropDownBox" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter state" ForeColor="Red"
                                    ControlToValidate="ddlState"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>City</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlCity" class="dropDownBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter city" ForeColor="Red"
                                    ControlToValidate="ddlCity"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div class="section group">
                            <div class="col span_1_of_3">
                                <span>
                                    <label>Website</label></span>
                                <span>
                                    <asp:TextBox runat="server" ID="txtWebsite" CssClass="bigTextBox" placeholder="Website"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Website" ForeColor="Red"
                                        ControlToValidate="txtWebsite"></asp:RequiredFieldValidator>
                                </span>
                            </div>
                            <div class="col span_1_of_3">
                                <span>
                                    <label>Service Email id</label></span>
                                <span>
                                    <asp:TextBox runat="server" ID="txtServiceEmailId" CssClass="bigTextBox" placeholder="Service Email id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Service Email Id" ForeColor="Red"
                                        ControlToValidate="txtServiceEmailId"></asp:RequiredFieldValidator>
                                </span>
                            </div>
                            <div class="col span_1_of_3">
                                <span>
                                    <label>Information Email id</label></span>
                                <span>
                                    <asp:TextBox runat="server" ID="txtInformation" CssClass="bigTextBox" placeholder="Information Email id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Information Email Id" ForeColor="Red"
                                        ControlToValidate="txtInformation"></asp:RequiredFieldValidator>
                                </span>
                            </div>
                        </div>
                        <div class="section group">
                            <div class="col span_1_of_3">
                                <span>
                                    <label>Office No.</label></span>
                                <span>
                                    <asp:TextBox runat="server" ID="texOfficeNo" CssClass="bigTextBox" placeholder="Office No."></asp:TextBox>

                                </span>
                            </div>
                            <div class="col span_1_of_3">
                                <span>
                                    <label>Extention NO.</label></span>
                                <span>
                                    <asp:TextBox runat="server" ID="txtExtentionNo" CssClass="bigTextBox" placeholder="Extention No."></asp:TextBox>
                                </span>
                            </div>
                            <div class="col span_1_of_3">
                                <span>
                                    <label>Fax No.</label></span>
                                <span>
                                    <asp:TextBox runat="server" ID="txtFaxNo" CssClass="bigTextBox" placeholder="Fax No."></asp:TextBox>
                                </span>
                            </div>
                        </div>
                        <div class="section group">
                            <div class="col span_1_of_3">
                                <span>
                                    <label>Postal Code</label></span>
                                <span>
                                    <asp:TextBox runat="server" ID="txtPostalCode" CssClass="bigTextBox" placeholder="Postal Code"></asp:TextBox>
                                </span>
                            </div>
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
                            <div class="section group">
                                <div class="col span_1_of_3">
                                    <span>
                                        <label>location</label></span>
                                    <span>
                                        <asp:TextBox runat="server" ID="txtlocation" CssClass="bigTextBox" placeholder="Location"></asp:TextBox>
                                    </span>
                                </div>
                            </div>
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

