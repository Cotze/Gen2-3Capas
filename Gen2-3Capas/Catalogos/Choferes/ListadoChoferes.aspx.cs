using Gen2_3Capas.BLL;
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
    }
}