<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaChofer.aspx.cs" Inherits="Gen2_3Capas.Catalogos.Choferes.AltaChofer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-col-md-12">
                <h3>Registro de chofer</h3>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-btn-group">
                    <label for="<%=txtNombre.ClientID %>">Nombre</label>
                    <asp:TextBox ID="txtNombre" placeholder="Nombre completo" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNombre" CssClass="text-danger" runat="server" ErrorMessage="Nombre de chofer requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
