<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaRuta.aspx.cs" Inherits="Gen2_3Capas.Catalogos.Rutas.AltaRuta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="//maps.googleapis.com/maps/api/js?key=AIzaSyCWeeateTaYGqsHhNcmoDfT7Us-vLDZVPs&amp;sensor=false&amp;language=en"></script>
    <style>
        .modalPanel {
            background: #fff;
        }

        .bgpanel {
            background: #0d0d0d;
            opacity: 0.70;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class=" col-md-12">
                <h3>Alta ruta</h3>
            </div>
            <div style="display: block">
                <asp:TextBox ID="txtEsOD" Text="Aca vendra una bandera" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <%--izquierdo--%>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="<%=DDLChofer.ClientID %>">Chofer</label>
                    <asp:DropDownList ID="DDLChofer" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <label for="<%=txtOrigen.ClientID %>">Origen</label>
                            <asp:TextBox ID="txtOrigen" CssClass="form-control" runat="server"></asp:TextBox>
                            <%--Aca vamos a meter la funcion del autocompletado--%>
                            <ajaxToolkit:AutoCompleteExtender runat="server" ID="ACtxtOrigen" TargetControlID="txtOrigen" MinimumPrefixLength="2" ServicePath="~/autocompletar.asmx" ServiceMethod="GetDirecciones"></ajaxToolkit:AutoCompleteExtender>
                        </div>
                        <div class="col-md-5">
                            <asp:Button ID="btnAddOrigen" CssClass="btn btn-primary btn-xs" runat="server" Text="Obtener Datos" Style="margin-top: 30px;" OnClientClick="getDireccion(1)" />
                            <%--Cuando se presiona eñ boton mostrar el modal con la información que me recupera la api de google--%>

                            <%--aca vamos a llamar al modal--%>
                            <ajaxToolkit:ModalPopupExtender ID="MPOrigen" TargetControlID="btnAddOrigen" PopupControlID="PnlOrigenDestino" CancelControlID="btnCancelar" BackgroundCssClass="bgpanel" runat="server"></ajaxToolkit:ModalPopupExtender>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=FSalida.ClientID %>">Fecha salida</label>
                    <input type="text" id="FSalida" name="FSalida" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label for="<%=txtDistancia.ClientID %>">Distancia</label>
                    <asp:TextBox ID="txtDistancia" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <%--derecho--%>
            <%--aca vamos a copiar y pegar el izquierdo--%>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="<%=DDLCamion.ClientID %>">Camión</label>
                    <asp:DropDownList ID="DDLCamion" CssClass="form-control" runat="server" OnSelectedIndexChanged="DDLCamion_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <label for="<%=txtDestino.ClientID %>">Destino</label>
                            <asp:TextBox ID="txtDestino" CssClass="form-control" runat="server"></asp:TextBox>
                            <%--Aca vamos a meter la funcion del autocompletado--%>
                            <ajaxToolkit:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtDestino" MinimumPrefixLength="2" ServicePath="~/autocompletar.asmx" ServiceMethod="GetDirecciones"></ajaxToolkit:AutoCompleteExtender>
                        </div>
                        <div class="col-md-5">
                            <asp:Button ID="btnAddDestino" CssClass="btn btn-primary btn-xs" runat="server" Text="Obtener Datos" Style="margin-top: 30px;" OnClientClick="getDireccion(2)" />
                            <%--Cuando se presiona el boton mostrar el modal con la información que me recupera la api de google--%>

                            <%--aca vamos a llamar al modal--%>
                            <ajaxToolkit:ModalPopupExtender ID="MPDestino" TargetControlID="btnAddDestino" PopupControlID="PnlOrigenDestino" CancelControlID="btnCancelar" BackgroundCssClass="bgpanel" runat="server"></ajaxToolkit:ModalPopupExtender>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="<%=FELlegada.ClientID %>">Fecha estimada llegada</label>
                    <input type="text" id="FELlegada" name="FELlegada" class="form-control" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h4>Cargamento</h4>
            </div>
        </div>
        <div class="row" id="FormaCarga">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtDescripcion.ClientID %>">Descripcion</label>
                    <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtPeso.ClientID %>">Peso</label>
                    <asp:TextBox ID="txtPeso" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Button ID="btnAddCarga" CssClass="btn btn-success" runat="server" Text="Agregar Carga" Style="margin-top: 25px;" OnClick="btnAddCarga_Click" />
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="<%=txtCapCamion.ClientID %>">Capacidad Camión</label>
                    <asp:TextBox ID="txtCapCamion" CssClass="form-control" runat="server" ></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4 col-md-offset-4">
                <div class="form-control">
                    <label for="<%=txtCargaTotal.ClientID %>">Carga Total</label>
                    <asp:TextBox ID="txtCargaTotal" CssClass="form-control" runat="server" ></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <asp:GridView ID="GVCarga" CssClass="table table-striped" runat="server"></asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Iniciar Ruta" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>

        <%--aca vamos a copiar el script 1--%>
        <script>
            $(document).ready(function () {
                //Declarar al time picker en español con momentjs
                $.datetimepicker.setLocale('es');
                //Asignamos el calendario a los input de fecha
                $("#<%=FSalida.ClientID%>").
                    datetimepicker({
                        format: 'd/m/Y H:i',
                        minDate: '0'
                    });
                $("#<%=FELlegada.ClientID%>").
                    datetimepicker({
                        format: 'd/m/Y H:i',
                        minDate: '0'
                    });

                $("#<%=FSalida.ClientID%>").change(function () {
                    CalcularDistancia();
                });

                if ($("#<%=DDLCamion.ClientID%>").val() != "") {
                    $("#FormaCarga").show();
                }
                else {
                    //$("#FormaCarga").hide();
                }
            });
        </script>

        <script>
            function getDireccion(fuente) {
                var direccion = "";
                if (fuente == 1) //La dirección es un Origen
                {

                    direccion = $("#<%=txtOrigen.ClientID%>").val();
                    //11 sur 305
                }
                else //La dirección es un Destino
                {
                    direccion = $("#<%=txtDestino.ClientID%>").val();
                }
                //guardar del lado del servidor si el usuario
                //dio click en origen o en destino
                $("#<%=txtEsOD.ClientID%>").val(fuente);

                if (direccion != "") {
                    //Llamamos a la api de google maps
                    //para obtener los datos completos de la dirección
                    var geocoder = new google.maps.Geocoder();

                    geocoder.geocode({ 'address': direccion }, function (results, status) {
                        if (status == google.maps.GeocoderStatus.OK) {
                            //Traemos los datos completos de la dirección
                            console.log(results);
                            console.log("El conteinente es: ");
                            console.log(results[0].address_components[0].long_name);
                            $("#origen").val(results[0].address_components[0].long_name);
                            console.log(status);
                            var numresults = results[0].address_components.length;
                            //Recorremos cada una de las propiedades de address_components
                            for (var indice = 0; indice < numresults; indice++) {
                                var numresultstypes =
                                    results[0].address_components[indice].types.length;
                                //Recorremos los tipos de cada componente de la dirección
                                for (var propiedad = 0; propiedad < numresultstypes; propiedad++) {
                                    //Declarar una variable que nos permita saber ell tipo
                                    // de propiedad que estamos recorriendo
                                    var Tipo = results[0].address_components[indice].types[propiedad]; // ""route""
                                    //Descripcion va a contener el valor de la propiedad // street_number
                                    var Descripcion =
                                        results[0].address_components[indice].long_name; // "Avenida 10 Oriente"
                                    //Validamos cada propiedad para escribirla en el textbox
                                    //que corresponda

                                    switch (Tipo) {

                                        case "route": //Calle
                                            $("#<%=txtCalle.ClientID%>").val(Descripcion);
                                            break;
                                        case "street_number": //Número
                                            $("#<%=txtNumero.ClientID%>").val(Descripcion);
                                            break;
                                        case "sublocality_level_1": //Colonia
                                            $("#<%=txtColonia.ClientID%>").val(Descripcion);
                                            break;
                                        case "locality": //Ciudad
                                            $("#<%=txtCiudad.ClientID%>").val(Descripcion);
                                            break;
                                        case "administrative_area_level_1": //Estado
                                            $("#<%=txtEstado.ClientID%>").val(Descripcion);
                                            break;
                                        case "postal_code": //C.P.
                                            $("#<%=txtCP.ClientID%>").val(Descripcion);
                                            break;

                                    }

                                }
                            }

                            //Asignamos a txtorigen o destino la dirección formateada
                            if (results[0].address_components.length > 0) {
                                if (fuente == 1) //es origen
                                {
                                    $("#<%=txtOrigen.ClientID%>").val(results[0].formatted_address);
                            }
                            else {
                                console.log("cambiando");
                                $("#<%=txtDestino.ClientID%>").val(results[0].formatted_address);
                                }
                            }


                        }
                        else {
                            swal("Error de Google", "Google no obtuvo datos", "warning");
                        }
                    });
                }
                else {
                    //Avisamos al usuario que tendrá que capturar
                    //todos los datos
                    swal({
                        title: "¿Estás seguro?",
                        text: "No podemos obtener datos sino proporciona una dirección",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonClass: "btn-warning",
                        confirmButtonText: "Si, quiero capturar la información",
                        cancelButtonText: "Cancelar",
                        closeOnConfirm: true,
                        closeOnCancel: true
                    }, function (isConfirm) {
                        if (!isConfirm) {
                            $(".modalPanel").hide();
                            $(".bgpanel").hide();

                        }

                    });

                }
            }

            function prueba() {
                var calle = $("#<%=txtCalle.ClientID%>").val();
                var numero = $("#<%=txtNumero.ClientID%>").val();
                var colonia = $("#<%=txtColonia.ClientID%>").val();
                var ciudad = $("#<%=txtCiudad.ClientID%>").val();
                var estado = $("#<%=txtEstado.ClientID%>").val();
                var cp = $("#<%=txtCP.ClientID%>").val();

                var dirCompleta = calle + " " + numero + " " + colonia + " " + ciudad + " " + estado + " " + cp;

                var band = $("#<%=txtEsOD.ClientID%>").val();
                if (band == 1) {
                    $("#<%=txtOrigen.ClientID%>").val(dirCompleta);
                }
                else {
                    $("#<%=txtDestino.ClientID%>").val(dirCompleta);
                }

            }

            function LimpiarDatos() {
                $(".mpanel").val("");
            }

            function CalcularDistancia() {
                var Origen = $("#<%=txtOrigen.ClientID%>").val();
                var Destino = $("#<%=txtDestino.ClientID%>").val();
                var Salida = $("#<%=FSalida.ClientID%>").val();

                if ((Origen != "") && (Destino != "") && (Salida != "")) {
                    //Solicitamos el directionservice de google
                    var directionService =
                        new google.maps.DirectionsService;

                    var solicitud =
                    {
                        origin: Origen,
                        destination: Destino,
                        travelMode: google.maps.TravelMode.DRIVING
                    };

                    directionService.route(solicitud, function (results, status) {
                        if (status == google.maps.DirectionsStatus.OK) {
                            //Obtener los datos de la ruta
                            var Duracion =
                                results.routes[0].legs[0].duration.value; //Segundos
                            var Distancia =
                                results.routes[0].legs[0].distance.value; //Metros

                            $("#<%=txtDistancia.ClientID%>")
                                .val((Distancia / 1000).toFixed(2));

                            //Calcular la fecha estimada de llegada
                            //28/02/2018 11:14
                            //dividir fecha y hora
                            var partSalida = Salida.split(" ");
                            //dividimos la fecha dia/mes/año
                            var partDate = partSalida[0].split("/");
                            //dividir el tiempo en horas y minutos
                            var partTime = partSalida[1].split(":");

                            var FechaSalida =
                                new Date(partDate[2], partDate[1] - 1, partDate[0],
                                    partTime[0], partTime[1]);
                            var FechaEstimadaLlegada =
                                new Date(FechaSalida.getTime() + Duracion * 1000);
                            $("#<%=FELlegada.ClientID%>").
                                val(moment(FechaEstimadaLlegada).format("DD/MM/YYYY HH:mm"));
                        }
                        else {
                            swal("Error de Google", "Google no obtuvo datos", "warning");
                        }

                    });

                }
                else {
                    swal("Datos insuficientes", "Es imposible calcular tiempo y distancia", "warning");
                }
            }



        </script>

        <%--aca vamos a pintar el modal--%>
        <asp:Panel ID="PnlOrigenDestino" Width="500" CssClass="modalPanel" runat="server">
            <div style="width: 90%; margin: 0 auto; margin-top: 20px">
                <asp:UpdatePanel ID="UPOrigenDestino" UpdateMode="Always" runat="server">
                    <ContentTemplate>
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12">
                                    <h4>Guardar Direccion</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="<%=txtCalle.ClientID %>">Calle</label>
                                        <asp:TextBox ID="txtCalle" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFtxtCalle" CssClass="text-danger" ControlToValidate="txtCalle" runat="server" ErrorMessage="Calle Rquerida" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="<%=txtNumero.ClientID %>">Numero</label>
                                        <asp:TextBox ID="txtNumero" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" ControlToValidate="txtNumero" runat="server" ErrorMessage="Numero Rquerido" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="<%=txtColonia.ClientID %>">Colonia</label>
                                        <asp:TextBox ID="txtColonia" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" ControlToValidate="txtColonia" runat="server" ErrorMessage="Colonia Rquerida" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="<%=txtCiudad.ClientID %>">Ciudad</label>
                                        <asp:TextBox ID="txtCiudad" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" ControlToValidate="txtCiudad" runat="server" ErrorMessage="Ciudad Rquerida" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="<%=txtEstado.ClientID %>">Estado</label>
                                        <asp:TextBox ID="txtEstado" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" ControlToValidate="txtEstado" runat="server" ErrorMessage="Estado Rquerido" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="<%=txtCP.ClientID %>">Código Postal</label>
                                        <asp:TextBox ID="txtCP" CssClass="mpanel form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" ControlToValidate="txtCP" runat="server" ErrorMessage="Codigo Postal Rquerido" ValidationGroup="POD"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnGuardarDir" CssClass="btn btn-success" runat="server" Text="Guardar" ValidationGroup="POD" formnovalidate="" OnClick="btnGuardarDir_Click" OnClientClick="prueba()" />
                                    </div>
                                    <div class="">
                                        <asp:Button ID="btnCancelar" CssClass="btn btn-danger" formnovalidate="" runat="server" Text="Cancelar" OnClientClick="limpiarDatos()" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
