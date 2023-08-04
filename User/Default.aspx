<%@ Page Title="" Language="C#" MasterPageFile="~/assets/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
        
    <a href="Form.aspx" class="btn btn-success btn-icon-split" role="button" >
        <span class="text-white-50 icon"></span>
        <span class="text-white text">Add New</span>
    </a>
    <table class="table table-dark">
        <thead>
            <tr>
                <th scope="col">No</th>
                <th scope="col">Company</th>
                <th scope="col">Position</th>
                <th scope="col">Name</th>
                <th scope="col">Email</th>
                <th scope="col">Telephone</th>
                <th scope="col">Role</th>
                <th scope="col">Action</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="repeaterUser" runat="server" OnItemCommand="repeaterUser_ItemCommand">
                <ItemTemplate>
              <tr>
                  <td><%# Container.ItemIndex + 1 %></td>

                  <td><%# Eval("NameCompany") %></td>
                  <td><%# Eval("NamePosition") %></td>
                  <td><%# Eval("Name") %></td>
                  <td><%# Eval("Email") %></td>
                  <td><%# Eval("Telephone") %></td>  
                  <td><%# Eval("Role") %></td>  
                  <td>
                       <div class="text-right fitsize">
                           <asp:Button  CssClass="btn btn-info btn-sm" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Eval("UID") %>' />
                           <asp:Button  CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("UID") %>' OnClientClick='<%# "return confirm(\"Apakah anda yakin menghapus data " + Eval("Name") + "\")" %>' />

                    </div>
                  </td>
                </tr>
        </ItemTemplate>
     </asp:Repeater>
  </tbody>
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderJavascript" Runat="Server">
</asp:Content>

