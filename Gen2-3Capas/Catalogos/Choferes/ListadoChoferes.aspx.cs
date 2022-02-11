using Gen2_3Capas.BLL;
using Gen2_3Capas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen2_3Capas.Catalogos.Choferes
{
    public partial class ListadoChoferes : System.Web.UI.Page
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

        public void RefrescarGrid()
        {
            //Lenar el GVChoferes con al lista ChoferesVO
            GVChoferes.DataSource = BLLChoferes.GetLstChoferes(null);

            //Actualiza el contenido del grid
            GVChoferes.DataBind();
        }

        protected void GVChoferes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string IdChofer = GVChoferes.DataKeys[e.RowIndex].Values["IdChofer"].ToString();
            string Resultado = BLLChoferes.DelChofer(int.Parse(IdChofer));
            if (Resultado == "1")
            {
                UtilControls.SweetBox("Chofer Eliminado con éxito", "", "success", this.Page, this.GetType());
                RefrescarGrid();
            }else if (Resultado == "0")
            {
                UtilControls.SweetBox("Chofer no pudo ser eliminado", "Los choferes NO DISPONIBLES no pueden ser eliminados", "error", this.Page, this.GetType());
            }else if(Resultado == "2")
            {
                UtilControls.SweetBox("Chofer no pudo ser eliminado", "Los choferes QUE ESTAN EN EL HISTORICO DE RUTAS no pueden ser eliminados", "error", this.Page, this.GetType());
            }
        }

        protected void GVChoferes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int index = int.Parse(e.CommandArgument.ToString()); //Referencia al reglonseleccionado
                string IdChofer = GVChoferes.DataKeys[index].Values["IdChofer"].ToString(); //Recupera el valor de la columna Id del reglon seleccionado
                Response.Redirect("EdicionChofer.aspx?Id=" + IdChofer);
            }
            
        }

        protected void GVChoferes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Entrar al modo edicion
            GVChoferes.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVChoferes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //Recuperacion de los datos
                string IdChofer = GVChoferes.DataKeys[e.RowIndex].Values["IdChofer"].ToString();
                string Nombre = e.NewValues["Nombre"].ToString();
                string ApPaterno = e.NewValues["ApPaterno"].ToString();
                string ApMaterno = e.NewValues["ApMaterno"].ToString();

                CheckBox ChkAux = (CheckBox)GVChoferes.Rows[e.RowIndex].FindControl("ChkEditDisponible");
                bool Disponibilidad = ChkAux.Checked;
                BLLChoferes.UpdChoferes(int.Parse(IdChofer), null, null, null, Nombre, ApPaterno, ApMaterno, null, Disponibilidad);

                //Salir del modo edicion
                GVChoferes.EditIndex = -1;
                RefrescarGrid();
                UtilControls.SweetBox("Registro actualizado", "", "success",this.Page, this.GetType());

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void GVChoferes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Salir del modo edicion
            GVChoferes.EditIndex = -1;
            RefrescarGrid();
        }
    }
}