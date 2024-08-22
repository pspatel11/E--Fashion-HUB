<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="city.aspx.cs" Inherits="city" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="col span_2_of_3">
                    <div class="contact-form">
                        <h2>CITY</h2>
                        <div>
                            <span>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></span>


                            <asp:HiddenField ID="hdnCityId" runat="server" />
                        </div>
                    <div>
                        <span>
                            <label>City Name</label></span>
                        <span>
                            <asp:TextBox runat="server" ID="TextBox1" ToolTip="Enter city name" CssClass="bigTextBox" placeholder="Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter city name" ForeColor="Red"
                                ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div>
                        <span>
                            <label>Code</label></span>
                        <span>
                            <asp:TextBox runat="server" ID="txtCityCode" ToolTip="Enter City Code" CssClass="bigTextBox" placeholder="CityCode"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter City code" ForeColor="Red"
                                ControlToValidate="txtCityCode"></asp:RequiredFieldValidator>
                        </span>

                    </div>
                     
                     
                        <div>
                        <span>
                            <label>Select Country</label></span>
                        <span>
                            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="dropDownBox" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="select country" ForeColor="Red"
                                ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                        <div> 
                        <span>
                            <label>Select State</label></span>
                        <span>
                            <asp:DropDownList runat="server" ID="ddlState" CssClass="dropDownBox" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="select state" ForeColor="Red"
                                ControlToValidate="ddlState"></asp:RequiredFieldValidator>
                        </span>
                    </div>
                    <div>
                        <span>
                             <asp:Button ID="btnSubmit" runat="server" Text="Save" ToolTip="Save City" class="submitButton" OnClick="btnSubmit_Click"></asp:Button>
                            
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update city " class="updateButton" ValidationGroup="SaveData" OnClick="btnUpdate_Click"></asp:Button>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete city " class="deleteButton" ValidationGroup="SaveData" OnClick="btnDelete_Click"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" class="cancelButton" OnClick="btnCancel_Click"></asp:Button>
                        </span>
                    </div>
                </div>
            </div>

            <div class="col span_3_of_3">
                <div class="grd">
                    <span>
                        <asp:GridView ID="grdCity" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="7"
                            OnPageIndexChanging="grdCity_PageIndexChanging" AutoGenerateSelectButton="true"
                            DataKeyNames="city_id" OnSelectedIndexChanged="grdCity_SelectedIndexChanged" PagerStyle-CssClass="content-pagenation">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="City Name" DataField="city_name" />
                                <asp:BoundField HeaderText="City Code" DataField="City_code" />
                               
                                <asp:BoundField HeaderText="State" DataField="state_name" />
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

