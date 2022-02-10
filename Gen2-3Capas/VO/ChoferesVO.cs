using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.VO
{
    public class ChoferesVO
    {
        private int _IdChofer;
        private String _Nombre;
        private String _ApPaterno;
        private String _ApMaterno;
        private String _Telefono;
        private DateTime _FechaNacimiento;
        private String _Licencia;
        private String _UrlFoto;
        private bool _Disponibilidad;

        public int IdChofer { get => _IdChofer; set => _IdChofer=value; }
        public string Nombre { get => _Nombre; set => _Nombre=value; }
        public string ApPaterno { get => _ApPaterno; set => _ApPaterno=value; }
        public string ApMaterno { get => _ApMaterno; set => _ApMaterno=value; }
        public string Telefono { get => _Telefono; set => _Telefono=value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento=value; }
        public string Licencia { get => _Licencia; set => _Licencia=value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto=value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad=value; }

        public ChoferesVO() //Constructor
        {
            IdChofer = 0;
            Nombre = "";
            ApPaterno = "";
            ApMaterno = "";
            Telefono = "";
            FechaNacimiento = DateTime.Parse("1900-01-01");
            Licencia ="";
            UrlFoto = "";
            Disponibilidad = false;
        }

        public ChoferesVO(DataRow dr)
        {
            IdChofer = int.Parse(dr["id"].ToString());
            Nombre = dr["Nombre"].ToString();
            ApPaterno = dr["ApPaterno"].ToString();
            ApMaterno = dr["ApMaterno"].ToString();
            Telefono = dr["Telefono"].ToString();
            FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
            UrlFoto = dr["UrlFoto"].ToString();
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }
    }

}