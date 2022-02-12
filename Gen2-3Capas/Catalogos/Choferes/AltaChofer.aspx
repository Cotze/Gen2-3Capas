<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaChofer.aspx.cs" Inherits="Gen2_3Capas.Catalogos.Choferes.AltaChofer" %>

<%--Registramos la referencia al ensamblador AjaxControlTookit--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

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
            <div class="col-md-12">
                <div class="form-btn-group">
                    <label for="<%=txtApPaterno.ClientID %>">Apellido paterno</label>
                    <asp:TextBox ID="txtApPaterno" placeholder="Apellido paterno" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApPaterno" CssClass="text-danger" runat="server" ErrorMessage="Apellido paterno de chofer requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-btn-group">
                    <label for="<%=txtApMaterno.ClientID %>">Apellido materno</label>
                    <asp:TextBox ID="txtApMaterno" placeholder="Apellido materno" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtApMaterno" CssClass="text-danger" runat="server" ErrorMessage="Apellido materno de chofer requerido"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-btn-group">
                    <label for="<%=txtLicencia.ClientID %>">Licencia</label>
                    <asp:TextBox ID="txtLicencia" placeholder="X-00000" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;  ">
                        <div style="position: absolute; top: 0px; left: 0;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtLicencia" CssClass="text-danger" runat="server" ErrorMessage="Licencia de chofer es requerida"></asp:RequiredFieldValidator>
                        </div>
                        <div style="position:absolute; top:0; left:0;">
                            <asp:RegularExpressionValidator ID="revtxtLicencia" controlToValidate="txtLicencia" CssClass="text-danger" ValidationExpression="^[a-zA-Z]{1}-[0-9]{5}$" runat="server" ErrorMessage="El formato de licencia es X-00000"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-btn-group">
                    <label for="<%=txtTelefono.ClientID %>">Telefono</label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtTelefono" CssClass="text-danger" runat="server" ErrorMessage="Telefono de chofer es requerido"></asp:RequiredFieldValidator>
                    <%--aca vamos a colocar una mascara--%>
                    <ajaxToolkit:MaskedEditExtender ID="MEEtxtTelefono" TargetControlID="txtTelefono" Mask="(999) 999-9999" ClearMaskOnLostFocus="false" runat="server"/>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-btn-group">
                    <label for="<%=fechaNacimiento.ClientID %>">Fecha de Nacimiento</label>
                    <input type="text" id="fechaNacimiento" name="fechaNacimiento" class="form-control" runat="server"/>
                    <%--aca va el dateTimePicket--%>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=SubeImagen.ClientID%>">Seleccionar</label>
                    <div class="row">
                        <div class="col-md-3">
                            <input type="file" id="SubeImagen" class="btn btn-file" runat="server"/>
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="btnSubeImagen" CssClass="btn btn-primary" runat="server" Text="Subir" OnClick="btnSubeImagen_Click"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <label>Foto</label>
                    <asp:Image ID="imgFotoChofer" Width="150" Height="100" runat="server"/>
                    <label id="urlFoto" runat="server"></label>
                </div>
            </div>
            <div class="col-md-12 col-md-offset-5">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function ()
        {
            //Declarar al time picket en español con momentjs
            $.datetimepicker.setLocale('es');
            $("#<%=fechaNacimiento.ClientID %>").datetimepicker({
                format: 'd/m/Y'
            });
        });
    </script>
</asp:Content>
