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
            }
        }
    }
}