using Gen2_3Capas.BLL;
using Gen2_3Capas.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen2_3Capas.Catalogos.Choferes
{
    public partial class AltaChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            //Validar que el usuario haya sleccionado un archivo
            if (SubeImagen.Value != "")
            {
                //asignar a una variable el nombre del archivo seleccionado
                string FileName = 
                    Path.GetFileName(SubeImagen.PostedFile.FileName);

                //validar que el archivo sea .jpg o .png
                string FileExt = 
                    Path.GetExtension(FileName).ToLower();

                if ((FileExt != ".jpg") && (FileExt != ".png"))
                {
                    //mensaje de error
                    UtilControls.SweetBox("Error!", "Seleccione un archivo valido de imagen", "error", this.Page, this.GetType());
                }
                else
                {
                    //Verifivamos que el directorio deonde vamos
                    //guardar el archivo exista
                    string pathDir =
                        Server.MapPath("~/Imagenes/Choferes/");
                    if (!Directory.Exists(pathDir))
                    {
                        //Crea el arbol completo
                        Directory.CreateDirectory(pathDir);
                    }
                    //Guardamos la imagen en el directorio correspondiente
                    SubeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Choferes/" + FileName;
                    urlFoto.InnerText = urlfoto;
                    imgFotoChofer.ImageUrl = urlfoto;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                //Enviar mensaje de que no se puede ser vacio
                //mensaje de error
                UtilControls.SweetBox("Error!", "Debes subir un archivo", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apPaterno = txtApPaterno.Text;
                string apMaterno = txtApMaterno.Text;
                string telefono = txtTelefono.Text;
                DateTime fNacimiento = DateTime.Parse(fechaNacimiento.Value);
                string licencia = txtLicencia.Text;
                string urlfoto = urlFoto.InnerText;
                BLLChoferes.InsChoferes(licencia, telefono, fNacimiento, nombre, apPaterno, apMaterno, urlfoto);
                UtilControls.SweetBoxConfirm("Exito!", "Chofer agregado exitosamente", "success", "ListadoChoferes.aspx", this.Page, this.GetType());
            }catch (Exception ex)
            {
                UtilControls.SweetBox("Error!", ex.ToString(), "error", this. Page, this.GetType());
            }
        }
    }
}