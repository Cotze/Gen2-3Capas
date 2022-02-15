using Gen2_3Capas.BLL;
using Gen2_3Capas.Util;
using Gen2_3Capas.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen2_3Capas.Catalogos.Rutas
{
    public partial class AltaRuta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilControls.FillDropDownList(DDLChofer, "IdChofer", "nombreCompleto", BLLChoferes.GetLstChoferes(true), "", "Selecciona un chofer");

                UtilControls.FillDropDownList(DDLCamion, "IdCamion", "camion", BLLCamiones.GetLstCamiones(true), "", "Selecciona un Camion");
            }
        }

        protected void btnAddCarga_Click(object sender, EventArgs e)
        {
            string miCarga = "";
            double CapCamion = double.Parse(txtCapCamion.Text);
            double Peso = double.Parse(txtPeso.Text);
            string Descripcion = txtDescripcion.Text;
            if (Session["CargaRuta"] == null)
            {
                miCarga = "nada";
                //Estamos agregando la primer carga de la ruta
                if (CapCamion >= Peso)
                {
                    //Agregamos la carga
                    DataTable dtCarga = Filldt();
                    dtCarga.Rows.Add(Descripcion, Peso);
                    GVCarga.DataSource = dtCarga;
                    GVCarga.DataBind();
                    Session.Add("CargaRuta", dtCarga);
                    txtCargaTotal.Text = Peso.ToString();
                    txtDescripcion.Text = "";
                    txtPeso.Text = "";
                }
                else
                {
                    UtilControls.SweetBox("Capacidad del camión es menor a la carga", "Utilice un camión de mayor capacidad", "warning",
                        this.Page, this.GetType());
                }
            }
            else
            {
                miCarga = miCarga + Session["CargaRuta"].ToString();
                //Estamos agregando la segunda o más cargas
                double CargaTotal = double.Parse(txtCargaTotal.Text) + Peso;
                if (CapCamion >= CargaTotal)
                {
                    //Agregamos la siguiente carga
                    DataTable dtCarga = (DataTable)Session["CargaRuta"];
                    dtCarga.Rows.Add(Descripcion, Peso);
                    GVCarga.DataSource = dtCarga;
                    GVCarga.DataBind();
                    Session.Add("CargaRuta", dtCarga);
                    txtCargaTotal.Text = CargaTotal.ToString();
                    txtDescripcion.Text = "";
                    txtPeso.Text = "";
                }
                else
                {
                    UtilControls.SweetBox("Capacidad del camión es menor a la carga", "Utilice un camión de mayor capacidad", "warning",
                        this.Page, this.GetType());
                }
            }
        }

        private DataTable Filldt()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2]
                {
                    new DataColumn("Descripcion",typeof(string)),
                    new DataColumn("Peso",typeof(double))
                });

            return dt;
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdChofer = int.Parse(DDLChofer.SelectedValue);
                int IdCamion = int.Parse(DDLCamion.SelectedValue);
                int IdOrigen = 0;
                int IdDestino = 0;
                DateTime fSalida = DateTime.Parse(FSalida.Value);
                DateTime fLlegada = DateTime.Parse(FELlegada.Value);
                double Distancia = double.Parse(txtDistancia.Text);

                if (Session["IdOrigen"] == null)
                {
                    //Origen se seleccionó de la lista
                    IdOrigen = int.Parse(txtOrigen.Text.Split('.').First());
                }
                else
                {
                    //Origen se capturó y se guardó
                    IdOrigen = int.Parse(Session["IdOrigen"].ToString());
                }

                if (Session["IdDestino"] == null)
                {
                    //Destino se seleccionó de la lista
                    IdDestino = int.Parse(txtDestino.Text.Split('.').First());
                }
                else
                {
                    //Destino se capturó y se guardó
                    IdDestino = int.Parse(Session["IdDestino"].ToString());
                }

                //Insertamos la ruta y obtenemos el id de la misma
                long IdRuta = BLLRuta.InsRuta(IdCamion, IdChofer, IdOrigen, IdDestino, Distancia, fSalida, fLlegada);

                InsertarCargaRuta(IdRuta);

                UtilControls.SweetBoxConfirm("Ok!", "Ruta generada", "success", "EnProceso.aspx", this.Page, this.GetType());

            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), "error", this.Page, this.GetType());
            }


        }

        private void InsertarCargaRuta(long idRuta)
        {
            //Instanciamos el webservice para insertar cargamento
            ServicioWeb.WSRutasSoapClient referencia = new ServicioWeb.WSRutasSoapClient();
            foreach (GridViewRow item in GVCarga.Rows)
            {
                string Descripcion = item.Cells[0].Text;
                double Peso = double.Parse(item.Cells[1].Text);
                string Resultado = referencia.InsertarCargamento(idRuta, Descripcion, Peso);
            }

        }

        protected void btnGuardarDir_Click(object sender, EventArgs e)
        {
            try
            {
                string Calle = txtCalle.Text;
                string Numero = txtNumero.Text;
                string Colonia = txtColonia.Text;
                string Ciudad = txtCiudad.Text;
                string Estado = txtEstado.Text;
                string CP = txtCP.Text;

                //aca consumimos el web service
                //WSRutas.InsDirecciones();
                ServicioWeb.WSRutasSoapClient referencia = new ServicioWeb.WSRutasSoapClient();
                int idDireccion  = referencia.insDireccion(Calle, Numero, Colonia, Ciudad, Estado, CP);

                if (txtEsOD.Text == "1")
                {
                    //Estado origen
                    Session["IdOrigen"]= idDireccion.ToString();
                    MPOrigen.Hide();
                }
                else
                {
                    //Estado destino
                    Session["Iddestino"]= idDireccion.ToString();
                    MPDestino.Hide();
                }
                LimpiarDireccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LimpiarDireccion()
        {
            txtEsOD.Text = String.Empty;
            txtCalle.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtColonia.Text = String.Empty;
            txtCiudad.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtCP.Text = String.Empty;
        }

        protected void DDLCamion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtenemos la capacidad del camión seleccionado
            if (DDLCamion.SelectedValue != "")
            {
                //Traemos la capacidad y la asignamos a txtCapCamion
                CamionesVO Camion = BLLCamiones.getCamionByID(int.Parse(DDLCamion.SelectedValue));
                txtCapCamion.Text = Camion.Capacidad.ToString();
            }
            else
            {
                txtCapCamion.Text = "";

            }

        }
    }
}