using Gen2_3Capas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.BLL
{
    public class BLLRuta
    {
        //Insertar
        public static long InsRuta(int IdCamion, int IdChofer, int IdOrigen, int IdDestino, double Distancia, DateTime FSalida, DateTime FLlegadaE)
        {
            DALCamiones.UpdCamion(IdCamion, null, null, null, null, null, null, false, null);
            DALChoferes.UpdChofer(IdChofer, null, null, null, null, null, null, null, false);
            return DALRuta.InsRuta(IdCamion, IdChofer, IdOrigen, IdDestino, Distancia, FSalida, FLlegadaE);

        }
    }
}