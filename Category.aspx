<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="content">
            <div class="section group">
                <div class="col span_2_of_3" style="width: 45%">
                    <div class="contact-form">
                        <h2>CATEGORY</h2>
                        <div>
                            <span>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

                                <asp:HiddenField ID="hdnCategoryId" runat="server" />
                            </span>
                         </div>
                        <div>
                            <span>
                                <label>Category Name</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtName" ToolTip="Enter category Name" CssClass="bigTextBox" placeholder="Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter category name" ForeColor="Red"
                                    ControlToValidate="txtName"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>Category Type</label></span>
                            <span>
                                <asp:DropDownList runat="server" ID="ddlCategoryType" CssClass="dropDownBox">
                                    <asp:ListItem Text="----Select Category Type----" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Gents" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </span>
                        </div>
                        <div class="section group">
                            <span>
                                <label>Description</label></span>
                            <span>
                                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" ToolTip="Description" CssClass="TextBox" placeholder="Description"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Description" ForeColor="Red"
                                    ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                            </span>
                        </div>

                        <div>
                            <span>
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" ToolTip="Save Category " class="submitButton" OnClick="btnSubmit_Click"></asp:Button>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update county " class="updateButton" ValidationGroup="SaveData" OnClick="btnUpdate_Click"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete county " class="deleteButton" ValidationGroup="SaveData" OnClick="btnDelete_Click"></asp:Button>
                                <asp:Button ID="Button1" runat="server" Text="Cancel" ToolTip="Cancel" class="cancelButton" OnClick="btnCancel_Click"></asp:Button>

                            </span>
                        </div>
                    </div>
                </div>
                <div class="col span_3_of_3">
                    <div class="grd" style="margin-top: 15px">
                        <span>
                            <asp:GridView ID="grdCategory" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="7"
                                OnPageIndexChanging="grdCategory_PageIndexChanging" AutoGenerateSelectButton="true" 
                                DataKeyNames="Category_Id" OnSelectedIndexChanged="grdCategory_SelectedIndexChanged" PagerStyle-CssClass="content-pagenation">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Category Name" HeaderStyle-Width="150px" DataField="category_name" />
                                    <asp:BoundField HeaderText="Type" DataField="Category_TypeName" HeaderStyle-Width="80px"/>
                                    <asp:BoundField HeaderText="Description" DataField="Category_description" HeaderStyle-Width="120px"/>
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

