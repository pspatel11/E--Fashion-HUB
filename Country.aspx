<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Country.aspx.cs" Inherits="Country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="col span_2_of_3">
                    <div class="contact-form">
                        <h2>COUNTRY</h2>
                        <div>
                            <span>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="hdnCountryId" runat="server" />
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtName" ToolTip="Enter country Name" CssClass="bigTextBox" placeholder="Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter name" ForeColor="Red" ValidationGroup="SaveData"
                                    ControlToValidate="txtName"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>Code</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtCountryCode" ToolTip="Enter country Code" CssClass="bigTextBox" placeholder="Code"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter code" ForeColor="Red" ValidationGroup="SaveData"
                                    ControlToValidate="txtCountryCode"></asp:RequiredFieldValidator>
                            </span>
                        </div>

                        <div>
                            <span>
                                <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save county " class="submitButton" OnClick="btnSubmit_Click" ValidationGroup="SaveData"></asp:Button>
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
                            <asp:GridView ID="grdCountry" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="7"
                                OnPageIndexChanging="grdCountry_PageIndexChanging" AutoGenerateSelectButton="true"
                                DataKeyNames="country_id" OnSelectedIndexChanged="grdCountry_SelectedIndexChanged" PagerStyle-CssClass="content-pagenation">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No" >
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Name" DataField="country_name" />
                                    <asp:BoundField HeaderText="Code" DataField="country_code" />
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

