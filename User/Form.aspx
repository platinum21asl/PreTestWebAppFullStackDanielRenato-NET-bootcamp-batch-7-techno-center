<%@ Page Title="" Language="C#" MasterPageFile="~/assets/MasterPage.master" AutoEventWireup="true" CodeFile="Form.aspx.cs" Inherits="User_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <div class="panel panel-success">
                <div class="panel-body">
                    <asp:Label ID="LabelTitle" runat="server"></asp:Label>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label for="" class="form-label">Name</label>
                                <asp:TextBox ID="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="" class="form-label">Email</label>
                                <asp:TextBox ID="InputEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                          
                        </div>  
                        <div class="row">
                            <div class="col-md-6">
                                <label for="" class="form-label">Telephone</label>
                                <asp:TextBox ID="InputTelephone" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-md-6">
                                <label for="" class="form-label">Role</label>
                                <asp:TextBox ID="InputRole" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                           
                        </div>
                        <div class="row">
                              <div class="col-md-6">
                                <label for="" class="form-label">Company</label>
                                <asp:DropDownList ID="listCompany" CssClass="form-control" runat="server" Width="100%">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label for="" class="form-label">Position</label>
                                <asp:DropDownList ID="listPosition" CssClass="form-control" runat="server" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                         <label for="" class="form-label">Address</label>
                         <asp:TextBox ID="InputAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <asp:Button ID="ButtonOk" CssClass="btn btn-success btn-sm mt-3" runat="server" OnClick="ButtonOk_Click" Text=""/>
                    <asp:Button ID="ButtonKeluar" CssClass="btn btn-danger btn-sm mt-3" runat="server" Text="Cancel" OnClick="ButtonKeluar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderJavascript" Runat="Server">
</asp:Content>

