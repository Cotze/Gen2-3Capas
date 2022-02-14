using Gen2_3Capas.BLL;
using Gen2_3Capas.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen2_3Capas.Catalogos.Camiones
{
    public partial class AltaCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilControls.EnumToListBox(typeof(Tipo), DDLTipoCamion, false);

                UtilControls.EnumToListBox(typeof(Marca), DDLMarca, false);

                LlenarModelo();
            }
        }

        private void LlenarModelo()
        {
            int Minimo = DateTime.Now.Year - 20;
            int Maximo = DateTime.Now.Year + 2;
            var Rango = Enumerable.Range(Minimo, Maximo - Minimo);
            DDLModelo.DataSource = Rango;
            DDLModelo.DataBind();
        } //del LlenarModelo

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            if (SubeImagen.Value != "")
            {
                
                string FileName =
                    Path.GetFileName(SubeImagen.PostedFile.FileName);

               
                string FileExt =
                    Path.GetExtension(FileName).ToLower();

                if ((FileExt != ".jpg") && (FileExt != ".png"))
                {
                    
                    UtilControls.SweetBox("Error!", "Seleccione un archivo valido de imagen", "error", this.Page, this.GetType());
                }
                else
                {
                   
                    string pathDir =
                        Server.MapPath("~/Imagenes/Camiones/");
                    if (!Directory.Exists(pathDir))
                    {
                        
                        Directory.CreateDirectory(pathDir);
                    }
                    
                    SubeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Camiones/" + FileName;
                    urlFoto.InnerText = urlfoto;
                    imgFotoCamion.ImageUrl = urlfoto;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                UtilControls.SweetBox("Error!", "Debes subir un archivo", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Matricula = txtMatricula.Text;
                string TipoCamion = DDLTipoCamion.SelectedValue;
                int Modelo = int.Parse(DDLModelo.SelectedValue);
                string Marca = DDLMarca.SelectedValue;
                int Capacidad = int.Parse(txtCapacidad.Text);
                double Kilometraje = double.Parse(txtKilometraje.Text);
                string UrlFoto = urlFoto.InnerText;

                string resultado = BLLCamiones.insCamion(Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, UrlFoto);

                if (resultado.IndexOf("Camion agregado") > 1){
                    UtilControls.SweetBoxConfirm("OK!", resultado, "success", "ListadoCamiones.aspx", this.Page, this.GetType());
                }
                else
                {
                    UtilControls.SweetBox("Error!", "El camion no se agrego correctamente", "error", this.Page, this.GetType());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}