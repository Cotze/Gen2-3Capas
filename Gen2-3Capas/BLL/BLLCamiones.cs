using Gen2_3Capas.DAL;
using Gen2_3Capas.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.BLL
{
    public class BLLCamiones
    {
        //Listar
        public static List<CamionesVO> GetLstCamiones(bool? Disponibilidad)
        {
            return DALCamiones.GetLstsCamiones(Disponibilidad);
        }
        //Inertar
        public static string insCamion(string Matricula, string TipoCamion, int Modelo, string Marca, int Capacidad, double Kilometraje, string UrlFoto)
        {
            //No se puede repetir la matricula
            try
            {
                List<CamionesVO> LstCamiones = DALCamiones.GetLstsCamiones(null);
                bool Existe = false;
                foreach (CamionesVO item in LstCamiones)
                {
                    if (item.Matricula == Matricula)
                    {
                        Existe = true;
                    }
                }
                if (Existe)
                {
                    return "La matricula del camion ya fue utilizada con anterioridad";
                }
                else
                {
                    DALCamiones.InsCamion(Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, UrlFoto);
                    return "Camion agregado";
                }
            }
            catch (Exception ex)
            {

                return ex.Message; 
            }
        }
        //Actualizar
        public static string UpdCamion(string Matricula, string TipoCamion, int Modelo, string Marca, int Capacidad, double Kilometraje, string URLFoto, int id, bool disponibilidad)
        {
            //Nose puede repetir la matricula
            try
            {
                List<CamionesVO> LstCamiones = DALCamiones.GetLstsCamiones(null);
                bool Existe = false;
                foreach (CamionesVO item in LstCamiones)
                {
                    if ((item.Matricula == Matricula) && (item.IdCamion != id))
                    {
                        Existe = true;
                    }
                }
                if (Existe)
                {
                    return "La matricula del camión ya fue utilizada con anterioridad";
                }
                else
                {
                    DALCamiones.UpdCamion(id, Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, disponibilidad, URLFoto);
                    return "Camion actualizado";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        //Eliminar
        public static string DelCamion(int IdCamion)
        {
            //Borrar solo si el camion esta disponible
            try
            {
                CamionesVO CamionVo = DALCamiones.GetCamionById(IdCamion);
                if (CamionVo.Disponibilidad)
                {
                    DALCamiones.DelCamion(IdCamion);
                    return "Camion eliminado";
                }
                else
                {
                    return "El camion se encuentra en una ruta o no esta disponible";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
        //GetByID
        public static CamionesVO getCamionByID(int IdCamion)
        {
            try
            {
                return DALCamiones.GetCamionById(IdCamion);
            }
            catch (Exception)
            {
                return new CamionesVO();
            }
        }
    }
}