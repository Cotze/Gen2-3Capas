using Gen2_3Capas.DAL;
using Gen2_3Capas.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.BLL
{
    public class BLLChoferes
    {
        //Listar
        public static List<ChoferesVO> GetLstChoferes(bool? paramDisponiilidad)
        {
            return DALChoferes.GetLstChoferes(paramDisponiilidad);
        }

        //Insertar
        public static void InsChoferes(string paramLicencia, string paramTelefono, DateTime paramFechaNacimiento, string paramNombre, string paramApPaterno, string paramApMaterno, string paramUrlFoto)
        {
            try
            {
                DALChoferes.InsChofer(paramLicencia, paramTelefono, paramFechaNacimiento, paramNombre, paramApPaterno, paramApMaterno, paramUrlFoto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Actualizar
        public static void UpdChoferes(int paramIdChofer, string paramLicencia, string paramTelefono, DateTime paramFechaNacimiento, string paramNombre, string paramApPaterno, string paramApMaterno, string paramUrlFoto, bool? paramDisponibilidad)
        {
            DALChoferes.UpdChofer(paramIdChofer, paramLicencia, paramTelefono, paramFechaNacimiento, paramNombre, paramApPaterno, paramApMaterno, paramUrlFoto, paramDisponibilidad);
        }

        //Eliminar
        public static string DalChofer(int paramIdChofer)
        {
            try
            {
                //Verificar la disponibilidad del chofer
                ChoferesVO Chofer = DALChoferes.GetChoferesById(paramIdChofer);
                if (Chofer.Disponibilidad)
                {
                    DALChoferes.DelChofer(paramIdChofer);
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //GetByID
        public static ChoferesVO GetChoferByID(int paramIdChofer)
        {
            return DALChoferes.GetChoferesById(paramIdChofer);
        }
    }
}