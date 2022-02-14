<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EdicionCamion.aspx.cs" Inherits="Gen2_3Capas.Catalogos.Camiones.EdicionCamion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>EDICIÓN CAMION</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="<%=txtMatricula %>">Matricula</label>
                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" placeholder="XXX-0000" MaxLength="8"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RequiredFieldValidator ControlToValidate="txtMatricula" ID="RFV1" runat="server" CssClass="text-danger" ErrorMessage="Matricula es obligatoria"></asp:RequiredFieldValidator>
                        </div>
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RegularExpressionValidator ErrorMessage="El formato de matricula es XXX-0000" ID="RegularExpressionValidator1" runat="server" CssClass="text-danger" ValidationExpression="^[a-zA-Z]{3}-[0-9]{4}$" ControlToValidate="txtMatricula"></asp:RegularExpressionValidator>
                        </div> 
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtCapacidad %>">Capacidad</label>
                    <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RequiredFieldValidator ControlToValidate="txtCapacidad" ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Capacidad es obligatoria"></asp:RequiredFieldValidator>
                        </div>
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RegularExpressionValidator ErrorMessage="Capacidad debe ser numerica" ID="RegularExpressionValidator2" runat="server" CssClass="text-danger" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ControlToValidate="txtCapacidad"></asp:RegularExpressionValidator>
                        </div> 
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=txtKilometraje %>">Kilometraje</label>
                    <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control"></asp:TextBox>
                    <div class="col-md-12" style="margin-bottom: 30px;">
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RequiredFieldValidator ControlToValidate="txtKilometraje" ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Kilometraje es obligatoria"></asp:RequiredFieldValidator>
                        </div>
                        <div style="position: absolute; top: 0; left: 0">
                            <asp:RegularExpressionValidator ErrorMessage="Kilometraje debe ser numerico" ID="RegularExpressionValidator3" runat="server" CssClass="text-danger" ValidationExpression="^[0-9]*\.?[0-9]+$" ControlToValidate="txtKilometraje"></asp:RegularExpressionValidator>
                        </div> 
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=DDLTipoCamion %>">Kilometraje</label>
                    <asp:DropDownList ID="DDLTipoCamion" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="DDLTipoCamion" ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ErrorMessage="Selecciona un tipo de camion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="<%=DDLModelo %>">Modelo camion</label>
                    <asp:DropDownList ID="DDLModelo" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="DDLModelo" ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ErrorMessage="Selecciona un modelo de camion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="<%=DDLMarca %>">Marca</label>
                    <asp:DropDownList ID="DDLMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ControlToValidate="DDLMarca" ID="RequiredFieldValidator5" runat="server" CssClass="text-danger" ErrorMessage="Selecciona una marca de camion"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <div class="checkbox" style="margin: 30px">
                        <label>
                            <asp:CheckBox ID="chkDisponibilidad" runat="server"/>
                        </label>
                    </div>
                </div>
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
                <div class="form-group">
                    <label>Foto</label>
                    <asp:Image ID="imgFotoCamion" Width="150" Height="100" runat="server"/>
                    <label id="urlFoto" runat="server"></label>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
