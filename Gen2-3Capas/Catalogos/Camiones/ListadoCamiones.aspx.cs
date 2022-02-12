using Gen2_3Capas.BLL;
using Gen2_3Capas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen2_3Capas.Catalogos.Camiones
{
    public partial class ListadoCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RefrescarGrid();
                }
                catch (Exception ex)
                {
                    //Poner un mensaje
                    throw;
                }
            }
        }

        private void RefrescarGrid()
        {
            GVCamiones.DataSource = BLLCamiones.GetLstCamiones(null);
            GVCamiones.DataBind();
        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label lblTipoC = (Label)GVCamiones.Rows[e.NewEditIndex].FindControl("lblTipoCamion");
            string tipoC = lblTipoC.Text; //Semi Remolque

            Label lblmarcaC = (Label)GVCamiones.Rows[e.NewEditIndex].FindControl("lblMarca");
            string marcaC = lblmarcaC.Text; //Mercedes Bens

            Label lblmodeloC = (Label)GVCamiones.Rows[e.NewEditIndex].FindControl("lblModelo");
            string modeloC = lblmodeloC.Text; //2010

            //entran en modo edicion del RENGLON seleccionado
            GVCamiones.EditIndex = e.NewEditIndex;

            RefrescarGrid();

            DropDownList DDLTipoCamionAux = (DropDownList)GVCamiones.Rows[e.NewEditIndex].FindControl("DDLTipoCamion");

            UtilControls.EnumToListBox(typeof(Tipo), DDLTipoCamionAux, false);

            DropDownList DDLMarcaCamionAux = (DropDownList)GVCamiones.Rows[e.NewEditIndex].FindControl("DDLMarca");

            UtilControls.EnumToListBox(typeof(Tipo), DDLMarcaCamionAux, false);

            DropDownList DDLModeloCamionAux = (DropDownList)GVCamiones.Rows[e.NewEditIndex].FindControl("DDLModelo");

            int Minimo = DateTime.Now.Year - 20;
            int Maximo = DateTime.Now.Year + 20;
            var Rango = Enumerable.Range(Minimo, Maximo - Minimo);
            DDLModeloCamionAux.DataSource = Rango;
            DDLModeloCamionAux.DataBind();

            DDLTipoCamionAux.SelectedValue = tipoC;
            DDLMarcaCamionAux.SelectedValue = marcaC;
            DDLModeloCamionAux.SelectedValue = modeloC;        
        }


        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVCamiones.EditIndex = -1;
            RefrescarGrid();
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdCamion = GVCamiones.DataKeys[e.RowIndex].Values["IdCamion"].ToString();
            string Resultado = BLLCamiones.DelCamion(int.Parse(IdCamion));
            if (Resultado == "Camion eliminado")
            {
                UtilControls.SweetBox("Camion Eliminado con éxito", "", "success", this.Page, this.GetType());
                RefrescarGrid();
            }
            else
            {

                UtilControls.SweetBox("Camion no pudo ser elimiado", "Los camiones NO DISPONIBLES no pueden ser eliminados", "error", this.Page, this.GetType());
                RefrescarGrid();

              
            }
        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string IdCamion = GVCamiones.DataKeys[e.RowIndex].Values["IdCamion"].ToString();
            DropDownList ModeloCamionAux = (DropDownList)GVCamiones.Rows[e.RowIndex].FindControl("DDLModelo");
            
            string Modelo = ModeloCamionAux.SelectedValue;
            DropDownList MarcaCamionAux = (DropDownList)GVCamiones.Rows[e.RowIndex].FindControl("DDLMarca");

            string Marca = MarcaCamionAux.SelectedValue;
            int Capacidad = int.Parse(e.NewValues["Capacidad"].ToString());
            double kilometraje = double.Parse(e.NewValues["Kilometraje"].ToString());

            DropDownList TipoCamionAux = (DropDownList)GVCamiones.Rows[e.RowIndex].FindControl("DDLTipoCamion");
            string TipoCamion = TipoCamionAux.SelectedValue;

            bool Disponibilidad = bool.Parse(e.NewValues["Disponibilidad"].ToString());

            try
            {
                string resultado = BLLCamiones.UpdCamion(null, TipoCamion, int.Parse(Modelo), Marca, Capacidad, kilometraje, null, int.Parse(IdCamion), Disponibilidad);
                GVCamiones.EditIndex = -1;
                RefrescarGrid();
                UtilControls.SweetBox(resultado, "", "success", this.Page, this.GetType());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}