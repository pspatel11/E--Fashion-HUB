<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="state.aspx.cs" Inherits="STATE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="col span_2_of_3">
                    <div class="contact-form">
                        <h2>STATE</h2>
                        <div>
                            <span>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            </span>

                            <asp:HiddenField ID="hdnStateId" runat="server" />
                        </div>
                        <div>
                            <span>
                                <label>Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtStateName" ToolTip="Enter state name" CssClass="bigTextBox" placeholder="Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter state name" ForeColor="Red"
                                    ControlToValidate="txtStateName"></asp:RequiredFieldValidator>
                            </span>
                        </div>

                        <div>
                            <span>
                                <label>Code</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtStateCode" ToolTip="Enter country Code" CssClass="bigTextBox" placeholder="CountryCode"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter state code" ForeColor="Red"
                                    ControlToValidate="txtStateCode"></asp:RequiredFieldValidator>
                            </span>

                        </div>
                        <div>
                            <span>
                                <label>Search Country</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlCountry" class="dropDownBox" AutoPostBack="false" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select country" ForeColor="Red"
                                    ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div>
                            <span>
                                <asp:Button ID="btnSave" OnClick="btnSubmit_Click" runat="server" Text="Save" ToolTip="Save State" class="submitButton"></asp:Button>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update county " class="updateButton" ValidationGroup="SaveData" OnClick="btnUpdate_Click"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete county " class="deleteButton" ValidationGroup="SaveData" OnClick="btnDelete_Click"></asp:Button>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" class="cancelButton" OnClick="btnCancel_Click"></asp:Button>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col span_3_of_3">
                    <div class="grd">
                        <span>
                            <asp:GridView ID="grdState" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="7"
                                OnPageIndexChanging="grdState_PageIndexChanging" AutoGenerateSelectButton="true"
                                DataKeyNames="state_id" OnSelectedIndexChanged="grdState_SelectedIndexChanged" PagerStyle-CssClass="content-pagenation">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="State Name" DataField="state_name" />
                                    <asp:BoundField HeaderText="State Code" DataField="state_code" />
                                    <asp:BoundField HeaderText="Country" DataField="country_name" />

                                </Columns>
                                <PagerSettings NextPageText="Next" PreviousPageText="Pervious" />
                            </asp:GridView>

                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

