<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoChoferes.aspx.cs" Inherits="Gen2_3Capas.Catalogos.Choferes.ListadoChoferes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10 col-md-offset-1" style="scroll-margin-left: 40px; top: 0px; left: 0px;">
                <h3>LISTADO DE CHOFERES</h3>
                <asp:GridView ID="GVChoferes" CssClass="table tabble-table-bordered table-stripoed table-condensed" runat="server" AutoGenerateColumns="false" OnRowDeleting="GVChoferes_RowDeleting" OnRowEditing="GVChoferes_RowEditing" DataKeyNames="IdChofer" OnRowCommand="GVChoferes_RowCommand" OnRowUpdating="GVChoferes_RowUpdating" OnRowCancelingEdit="GVChoferes_RowCancelingEdit">
                    <Columns>
                        <asp:ButtonField Text="Seleccionar" CommandName="select" ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs" />
                        <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-xs" />
                        <asp:CommandField ShowEditButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-primary btn-xs" />
                        <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Width="120px" ControlStyle-Height="90px" DataImageUrlField="UrlFoto"></asp:ImageField>

                        <asp:BoundField HeaderText="Chofer" ItemStyle-Width="50px" ReadOnly="true" DataField="idChofer" />
                        <asp:BoundField HeaderText="Nombre" ItemStyle-Width="150px" DataField="Nombre" />
                        <asp:BoundField HeaderText="ApPaterno" ItemStyle-Width="150px" DataField="ApPaterno" />
                        <asp:BoundField HeaderText="ApMaterno" ItemStyle-Width="150px" DataField="ApMaterno" />
                        <asp:BoundField HeaderText="Licencia" ItemStyle-Width="80px" DataField="Licencia" ReadOnly="true" />

                        <asp:TemplateField HeaderText="Disponible" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <div style="width: 100%">
                                    <div style="width: 25%; margin: 0 auto;">
                                        <asp:CheckBox ID="chkDisponible" runat="server" Checked='<%#Eval("Disponibilidad")%>' Enabled="false" />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div style="width: 100%">
                                    <div style="width: 25%; margin: 0 auto;">
                                        <asp:CheckBox ID="chkEditDisponible" runat="server" Checked='<%#Eval("Disponibilidad")%>'/>
                                    </div>
                                </div>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
