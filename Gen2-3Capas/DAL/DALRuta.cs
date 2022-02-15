using Gen2_3Capas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.DAL
{
    public class DALRuta
    {
        //Insertar
        public static long InsRuta(int IdCamion, int IdChofer, int IdOrigen, int IdDestino, double Distancia, DateTime FSalida, DateTime FLlegadaE)
        {
            try
            {
                return
                    DBConnection.ExecuteNonQueryGetIdentitty
                        ("Rutas_Insertar", "@Camion_id", IdCamion,                                   
                                    "@DireccionOrigen_id", IdOrigen,
                                    "@DireccionDestino_id", IdDestino,
                                    "@Distancia", Distancia,
                                    "@FHSalida", FSalida,
                                    "@FHLlegadaEstimada", FLlegadaE,
                                    "@Chofer_id", IdChofer);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}