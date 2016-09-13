<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="row mt">
        <div class="col-lg-12">
            <div class="form-panel">
                <div class="form-horizontal style-form">
                    <div class="form-group">
                        <div class="col-sm-3">
                            <label class="control-label" for="txtName">
                                Student Name</label>
                            <asp:TextBox ID="txtName" ClientIDMode="Static" class="form-control" placeholder="Student Name"
                                runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label class="control-label" for="txtRoll">
                                Roll
                            </label>
                            <asp:TextBox ID="txtRoll" ClientIDMode="Static" class="form-control" placeholder="Roll Number"
                                runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label class="control-label" for="txtAddress">
                                Address
                            </label>
                            <asp:TextBox ID="txtAddress" ClientIDMode="Static" class="form-control" placeholder="Address"
                                runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label class="control-label" for="txtContact">
                                Contact
                            </label>
                            <asp:TextBox ID="txtContact" ClientIDMode="Static" class="form-control" placeholder="Contact"
                                runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <br />
                            <asp:Button runat="server" ClientIDMode="Static" class="btn btn-success btn-block"
                                Text="Save" ID="btnsave" ValidationGroup="A" OnClick="btnsave_Click" />
                            <asp:Button ID="btnReset" runat="server" formnovalidate class="btn btn-danger btn-block"
                                Text="Reset" onclick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-panel">
            <h4 class="mb">
                <i class="fa fa-angle-right"></i>Student Contact details
            </h4>
            <div class="form-horizontal style-form">
                <asp:GridView runat="server" ID="grdcontact" OnPreRender="grdcontact_PreRender" CssClass="table table-bordered  table-striped table-hover dt-responsive"
                    CellPadding="0" CellSpacing="0" Width="100%" Font-Size="12px" OnRowCommand="grdcontact_RowCommand"
                    AutoGenerateColumns="false" ClientIDMode="Static">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="70px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" CommandArgument='<%#Eval("id") %>' CommandName="conedit"
                                    runat="server" ImageUrl="~/Styles/edit.jpg" Width="24px" Height="24px" />
                                <asp:ImageButton ID="btndelete" CommandArgument='<%#Eval("id") %>' CommandName="condelete"
                                    runat="server" ImageUrl="~/Styles/Close.png" Width="24px" Height="24px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Roll
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblroll" runat="server" Text='<%#Eval("Roll") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Address
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Contact
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("Contact")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
