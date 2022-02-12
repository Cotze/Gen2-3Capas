<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoCamiones.aspx.cs" Inherits="Gen2_3Capas.Catalogos.Camiones.ListadoCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <h3>LISTADO DE CAMIONES</h3>

                <asp:GridView ID="GVCamiones" runat="server" AutoGenerateColumns="False" CssClass="table table-border table-striped table-condensed" DataKeyNames="IdCamion" OnRowCommand="GVCamiones_RowCommand" OnRowEditing="GVCamiones_RowEditing" OnRowDeleting="GVCamiones_RowDeleting" OnRowCancelingEdit="GVCamiones_RowCancelingEdit" OnRowUpdating="GVCamiones_RowUpdating">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccionar">
                        <ControlStyle CssClass="btn btn-success btn-xs" />
                        </asp:ButtonField>
                        <asp:CommandField ButtonType="Button" ShowEditButton="True">
                        <ControlStyle CssClass="btn btn-primary btn-xs" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                        <ControlStyle CssClass="btn btn-danger btn-xs" />
                        </asp:CommandField>
                        <asp:BoundField DataField="IdCamion" HeaderText="Id" ReadOnly="True">
                        <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" ReadOnly="True">
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="TipoCamion">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblTipoCamion" runat="server" Text='<%#Eval("TipoCamion") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DDLTipoCamion" CssClass="form-control" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modelo">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lblModelo" runat="server" Text='<%#Eval("Modelo") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DDLModelo" CssClass="form-control" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Marca">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblMarca" runat="server" Text='<%#Eval("Marca") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DDLMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Capacidad" HeaderText="Capacidad">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Kilometraje" HeaderText="Kilometraje">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="Disponibilidad" HeaderText="Disponibilidad">
                        <ItemStyle Width="70px" />
                        </asp:CheckBoxField>
                        <asp:ImageField DataImageUrlField="UrlFoto" HeaderText="Foto" ReadOnly="True">
                            <ControlStyle Height="90px" Width="120px" />
                            <ItemStyle Width="120px" />
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>
                <div></div>

            </div>
        </div>
    </div>
</asp:Content>
