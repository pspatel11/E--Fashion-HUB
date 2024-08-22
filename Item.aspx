<%@ Page Title="" Language="C#" MasterPageFile="~/Holder.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="plant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content" style="padding-left: 20px;">
            <div class="section group">

                <div class="contact-form">
                    <h2>Gents Items</h2>
                    <asp:HiddenField ID="hdnPlantId" runat="server" />
                    <div>
                        <span>
                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></span>

                    </div>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtPlantName" ToolTip="Enter Name" CssClass="bigTextBox" placeholder="Name"></asp:TextBox></span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Select Category</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlCategory" CssClass="dropDownBox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="select Category" ForeColor="Red"
                                    ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                            </span>
                        </div>

                        <div class="col span_1_of_3">
                            <span>
                                <label>Status Check</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlStatus" CssClass="dropDownBox">
                                    <asp:ListItem Text="Active" Value="True" />
                                    <asp:ListItem Text="In-Active" Value="False" />
                                </asp:DropDownList>
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <span>
                            <label>Description</label></span>
                        <span>
                            <asp:TextBox runat="server" ID="txtDescription" Width="90%" Height="20%" TextMode="MultiLine" ToolTip="Description" CssClass="TextBox" placeholder="Description"></asp:TextBox>
                        </span>
                    </div>
                    <div class="section group">
                        <span>
                            <label>Information</label></span>
                        <span>
                            <asp:TextBox runat="server" ID="txtPlantInfo" Width="90%" Height="20%" TextMode="MultiLine" ToolTip="Enter Information" CssClass="TextBox" placeholder="Information"></asp:TextBox>
                        </span>

                    </div>
                    <div class="section group">
                        <span>
                            <label>Other Info</label></span>
                        <span>
                            <asp:TextBox runat="server" ID="txtCareInfo" Width="90%" Height="20%" TextMode="MultiLine" ToolTip="Enter Other Information " CssClass="TextBox" placeholder="Other Info"></asp:TextBox>
                        </span>

                    </div>
                    <div class="section group">
                        <div class="col span_1_of_3">
                            <span>
                                <label>Price</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtPrice" ToolTip="Enter Price" CssClass="bigTextBox" placeholder="Price"></asp:TextBox></span>
                        </div>
                        <div class="col span_1_of_3">
                            <span>
                                <label>Image 1</label></span>
                            <span>
                                <asp:FileUpload ID="Image1FileUpload" runat="server" CssClass="uploadBox" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="select Category" ForeColor="Red"
                                    ControlToValidate="Image1FileUpload"></asp:RequiredFieldValidator>
                            </span>
                        </div>

                        <div class="col span_1_of_3">
                            <span>
                                <label>Image 2</label></span>
                            <span>
                                <asp:FileUpload ID="Image2FileUpload" runat="server" CssClass="uploadBox" />
                            </span>
                        </div>
                    </div>
                    <div class="section group">
                        <span>
                            <asp:Button ID="btnSave" OnClick="btnSubmit_Click" runat="server" Text="Save" ToolTip="Save State" class="submitButton"></asp:Button>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update county " class="updateButton" ValidationGroup="SaveData" OnClick="btnUpdate_Click"></asp:Button>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete county " class="deleteButton" ValidationGroup="SaveData" OnClick="btnDelete_Click"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" class="cancelButton" OnClick="btnCancel_Click"></asp:Button>
                        </span>
                    </div>
                    <div class="section group">
                        <div class="col span_3_of_3">
                            <div class="grd">
                                <span>
                                    <asp:GridView ID="grdPlant" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="7"
                                        OnPageIndexChanging="grdPlant_PageIndexChanging" AutoGenerateSelectButton="true"
                                        DataKeyNames="plant_Id" OnSelectedIndexChanged="grdPlant_SelectedIndexChanged" PagerStyle-CssClass="content-pagenation">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Name" DataField="plant_name" />
                                            <asp:BoundField HeaderText="Category" DataField="category_name" />
                                            <asp:BoundField HeaderText="Status Check" DataField="Status_check" />
                                            <asp:BoundField HeaderText="price" DataField="price" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img src="<%#Eval("image1") %>" height="100" width="100" alt="image1" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img src="<%#Eval("image2") %>" height="100" width="100" alt="image2" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerSettings NextPageText="next" PreviousPageText="pervious" />
                                    </asp:GridView>

                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

