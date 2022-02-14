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

namespace Gen2_3Capas.Catalogos.Camiones
{
    public partial class EdicionCamion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UtilControls.EnumToListBox(typeof(Tipo), DDLTipoCamion, false);

                UtilControls.EnumToListBox(typeof(Marca), DDLMarca, false);

                LlenarModelo();

                DDLMarca.Items.Insert(0, new ListItem("Selecciona una Marca", ""));
                DDLModelo.Items.Insert(0, new ListItem("Selecciona unn Modelo", ""));
                DDLTipoCamion.Items.Insert(0, new ListItem("Selecciona un tipo de camion", ""));

                DDLMarca.SelectedIndex = 0;
                DDLModelo.SelectedIndex = 0;
                DDLTipoCamion.SelectedIndex = 0;
                //Obtenemos la información del camion
                string id = Request.QueryString["idCamion"];
                if ((id == null) || (!IsNumeric(id)))
                {
                    Response.Redirect("ListadoCamiones.aspx");
                }
                else
                {
                    CamionesVO Camion = BLLCamiones.getCamionByID(int.Parse(id));
                    if (Camion.IdCamion == int.Parse(id))
                    {
                        //Desplegamos la informacion
                        txtMatricula.Text =Camion.Matricula;
                        txtCapacidad.Text = Camion.Capacidad.ToString();
                        txtKilometraje.Text = Camion.Kilometraje.ToString();
                        DDLTipoCamion.SelectedValue = Camion.TipoCamion;
                        DDLMarca.SelectedValue = Camion.Marca;
                        DDLModelo.SelectedValue = Camion.Modelo.ToString();
                        imgFotoCamion.ImageUrl = Camion.UrlFoto;
                        urlFoto.InnerText = Camion.UrlFoto;
                        chkDisponibilidad.Checked = Camion.Disponibilidad;
                    }
                    else
                    {
                        Response.Redirect("ListadoCamiones.aspx");
                    }
                }
            }
        }

        private bool IsNumeric(string id)
        {
            float output;
            return float.TryParse(id, out output);
        }

        private void LlenarModelo()
        {
            int Minimo = DateTime.Now.Year - 20;
            int Maximo = DateTime.Now.Year + 2;
            var Rango = Enumerable.Range(Minimo, Maximo - Minimo);
            DDLModelo.DataSource = Rango;
            DDLModelo.DataBind();
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
                int idCamiones = int.Parse(Request.QueryString["id"].ToString());
                string Matricula = txtMatricula.Text;
                string TipoCamion = DDLTipoCamion.SelectedValue;
                int Modelo = int.Parse(DDLModelo.SelectedValue);
                string Marca = DDLMarca.SelectedValue;
                int Capacidad = int.Parse(txtCapacidad.Text);
                double Kilometraje = double.Parse(txtKilometraje.Text);
                string UrlFoto = urlFoto.InnerText;
                bool Disponibilidad = chkDisponibilidad.Checked;

                string resultado = BLLCamiones.UpdCamion(Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, UrlFoto, idCamiones, Disponibilidad);

                if (resultado.IndexOf("Camion agregado") > 1)
                {
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