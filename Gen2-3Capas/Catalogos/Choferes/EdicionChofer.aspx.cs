using Gen2_3Capas.BLL;
using Gen2_3Capas.Util;
using Gen2_3Capas.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gen2_3Capas.Catalogos.Choferes
{
    public partial class EdicionChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListadoChoferes.aspx");
                }
                int IdChofer = int.Parse(Request.QueryString["Id"]);
                ChoferesVO chofer = BLLChoferes.GetChoferByID(IdChofer);
                if (chofer.IdChofer == 0)
                {
                    UtilControls.SweetBoxConfirm("Error", "El chofer no se encuentra en la base de datos", "ListadoChoferes.aspx", "warning", this.Page, this.GetType());
                }
                txtLicencia.Text = chofer.Licencia;
                txtTelefono.Text = chofer.Telefono;
                fechaNacimiento.Value = chofer.FechaNacimiento.ToString("dd/MM/yyyy");
                imgFotoChofer.ImageUrl = chofer.UrlFoto;

            }
        }

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
                        Server.MapPath("~/Imagenes/Choferes/");
                    if (!Directory.Exists(pathDir))
                    {
                        
                        Directory.CreateDirectory(pathDir);
                    }
                   
                    SubeImagen.PostedFile.SaveAs(pathDir + FileName);
                    string urlfoto = "/Imagenes/Choferes/" + FileName;
                    urlFoto.InnerText = urlfoto;
                    imgFotoChofer.ImageUrl = urlfoto;
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
                //RECUPERAR INFORMACION DE LA CAJA DE TEXTO
                string Telefono = txtTelefono.Text;
                DateTime fNacimiento = DateTime.Parse(fechaNacimiento.Value);
                string licencia = txtLicencia.Text;
                string UrlFoto = imgFotoChofer.ImageUrl; //jh

                int id = int.Parse(Request.QueryString["Id"].ToString());
                //string UrlFoto = pathFoto.InnerHtml;
                BLLChoferes.UpdChoferes(id, licencia, Telefono, fNacimiento, null, null, null, UrlFoto,null);
                //redireccione al listado de choferes
                UtilControls.SweetBoxConfirm("Exito", "Chofer actualizado correctamente", "success", "ListadoChoferes.aspx", this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                UtilControls.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
            }
            
        }
    }
}