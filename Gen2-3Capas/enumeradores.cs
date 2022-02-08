using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gen2_3Capas
{
    public enum Marca
    {
        Volvo,
        Alliance,
        Ford,
        [Description("Mercedes Benz")]
        Mercedes,
        Dina
    }

    public enum Tipo
    {
        Trailer,
        Torton,
        [Description("Doble remolque")]
        Doble_Remolque,
        Volteo,
        [Description("Semi remolque")]
        Semi_Remolque
    }

    public enum EstatusC
    {
        [Description("Mercancia OK")]
        ok = 1,
        [Description("Mercancia dañada")]
        Danado = 2,
        [Description("Mercancia Extraviada")]
        Extraviado = 3
    }
}