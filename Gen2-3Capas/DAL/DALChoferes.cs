using Gen2_3Capas.Util;
using Gen2_3Capas.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.DAL
{
    public class DALChoferes
    {
        //Listar
        public static List<ChoferesVO> GetLstChoferes(bool? paramDisponibilidad)
        {
            try
            {
                //Obtener la lista de choferes
                //Declaramos un DataSet
                DataSet dsChoferes;

                //Verificar la disponibilidad
                if (paramDisponibilidad == null)
                {
                    //Obtener todos los Choferes de la BD
                    dsChoferes = DBConnection.ExecuteDataSet("Choferes_Listar");
                }
                else
                {
                    //Obtener los choferes según paramDisponibilidad
                    dsChoferes = DBConnection.ExecuteDataSet("Choferes_Listar", "@Disponibilidad", paramDisponibilidad);
                }

                //Declaramos la lista a retornar
                List<ChoferesVO> ListaChoferes = new List<ChoferesVO>();
                //Recorremos el DataSet para llenar la lista
                foreach (DataRow dr in dsChoferes.Tables[0].Rows)
                {
                    ListaChoferes.Add(new ChoferesVO(dr));
                }
                return ListaChoferes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //insertar
        public static void InsChofer(string paramLicencia, string paramTelefono, DateTime paramFechaNacimiento, string paramNombre, string paramApPaterno, string paramApMaterno, string paramUrlFoto)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Choferes_Insertar", "@Nombre", paramNombre, "@ApPaterno", paramApPaterno, "@ApMaterno", paramApMaterno, "@Telefono", paramTelefono, "@FechaNacimiento", paramFechaNacimiento, "@Licencia", paramLicencia, "@UrlFoto", paramUrlFoto);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Actualizar
        public static void UpdChofer(int paramIdChofer, string paramLicencia, string paramTelefono, DateTime? paramFechaNacimiento, string paramNombre, string paramApPaterno, string paramApMaterno, string paramUrlFoto, bool? paramDisponibilidad)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Choferes_Actualizar", "@id", paramIdChofer, "@Nombre", paramNombre, "@ApPaterno", paramApPaterno, "@ApMaterno", paramApMaterno, "@Licencia", paramLicencia, "@Telefono", paramTelefono, "@FechaNacimienot", paramFechaNacimiento, "@UrlFoto", paramUrlFoto, "@Disponibilidad", paramDisponibilidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Eliminar
        public static void DelChofer(int paramIdChofer)
        {
            try
            {
                DBConnection.ExecuteNonQuery("Choferes_Eliminar", "@id", paramIdChofer);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //GetByID
        public static ChoferesVO GetChoferesById(int paramIdChofer)
        {
            try
            {
                DataSet dsChofer = DBConnection.ExecuteDataSet("Choferes_GetByID", "@id", paramIdChofer);
                if (dsChofer.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsChofer.Tables[0].Rows[0];
                    ChoferesVO Chofer = new ChoferesVO(dr);
                    return Chofer;
                }
                else
                {
                    ChoferesVO chofer = new ChoferesVO();
                    return chofer;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}