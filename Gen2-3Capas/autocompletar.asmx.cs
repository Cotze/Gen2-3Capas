using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Gen2_3Capas
{
    /// <summary>
    /// Descripción breve de autocompletar
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class autocompletar : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string[] GetDirecciones(string prefixText)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("buscaDireccion", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Prefijo", prefixText);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsDirecciones = new DataSet();
            adapter.Fill(dsDirecciones);
            string[] direcciones = new string[dsDirecciones.Tables[0].Rows.Count];

            int registro = 0;
            //recoremos el dataset para obtener la direccion
            foreach (DataRow dr in dsDirecciones.Tables[0].Rows)
            {
                direcciones.SetValue(dr["direccioncompleta"].ToString(), registro);
                registro++;
            }
            return direcciones;
        }
    }
}
