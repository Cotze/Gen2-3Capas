using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.VO
{
    public class CamionesVO
    {
        private int _idCamion;
        private string _Matricula;
        private string _TipoCamion;
        private int _Modelo;
        private string _Marca;
        private int _Capacidad;
        private double _Kilometraje;
        private bool _Disponibilidad;
        private string _UrlFoto;

        public int IdCamion { get => _idCamion; set => _idCamion=value; }
        public string Matricula { get => _Matricula; set => _Matricula=value; }
        public string TipoCamion { get => _TipoCamion; set => _TipoCamion=value; }
        public int Modelo { get => _Modelo; set => _Modelo=value; }
        public string Marca { get => _Marca; set => _Marca=value; }
        public int Capacidad { get => _Capacidad; set => _Capacidad=value; }
        public double Kilometraje { get => _Kilometraje; set => _Kilometraje=value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad=value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto=value; }
        public string camion { get => "Mat: " + _Matricula + " Modelo: " + _Modelo + " TipoCamion: " + _TipoCamion; set => _Matricula=value; }

        public CamionesVO()
        {
            IdCamion = 0;
            Matricula = String.Empty;
            TipoCamion = String.Empty;
            Modelo = 0;
            Marca = String.Empty;
            Capacidad = 0;
            Kilometraje = 0;
            Disponibilidad = false;
            UrlFoto = String.Empty;
        }

        public CamionesVO(DataRow dr)
        {
            IdCamion = int.Parse(dr["id"].ToString());
            Matricula = dr["Matricula"].ToString();
            TipoCamion = dr["TipoCamion"].ToString();
            Modelo = int.Parse(dr["Modelo"].ToString());
            Marca = dr["Marca"].ToString();
            Capacidad = int.Parse(dr["Capacidad"].ToString());
            Kilometraje = double.Parse(dr["Kilometraje"].ToString());
            Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
            UrlFoto = dr["UrlFoto"].ToString();
        }
    }
}