using Gen2_3Capas.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Gen2_3Capas.DAL
{
    public class DALCamiones
    {
        //Propiedades
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        //Listar
        public static List<CamionesVO> GetLstsCamiones(bool? paramDisponibilidad)
        {
            try
            {
                //Comando
                SqlCommand cmd = new SqlCommand("Camiones_Listar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dsCamiones = new DataSet();

                //Parametros
                if (paramDisponibilidad == null)
                {
                    adapter.Fill(dsCamiones);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Disponibilidad", paramDisponibilidad);
                    adapter.Fill(dsCamiones);
                }
                List<CamionesVO> LstCamiones = new List<CamionesVO>();
                foreach (DataRow dr in dsCamiones.Tables[0].Rows) 
                {
                    LstCamiones.Add(new CamionesVO(dr));
                }
                return LstCamiones;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //Inseratr
        public static void InsCamion(string Matricula, string TipoCamion, int Modelo, string Marca, int Capacidad, double Kilometraje, string UrlFoto)
        {
            try
            {
                string Query = "Camiones_Insertar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Matricula", Matricula);
                cmd.Parameters.AddWithValue("@TipoCamion", TipoCamion);
                cmd.Parameters.AddWithValue("@Modelo", Modelo);
                cmd.Parameters.AddWithValue("@Marca", Marca);
                cmd.Parameters.AddWithValue("@Capacidad", Capacidad);
                cmd.Parameters.AddWithValue("@Kilometraje", Kilometraje);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                conn.Open();
                cmd.ExecuteNonQuery(); //Ejecuta sin requerir valor de retorno
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        //Actualizar
        public static void UpdCamion(int IdCamion, string Matricula, string TipoCamion, int? Modelo, string Marca, int? Capacidad, double? Kilometraje, bool? Disponibilidad, string UrlFoto)
        {
            try
            {
                string Query = "Camiones_ACtualizar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Matricula", Matricula);
                cmd.Parameters.AddWithValue("@TipoCamion", TipoCamion);
                cmd.Parameters.AddWithValue("@Modelo", Modelo);
                cmd.Parameters.AddWithValue("@Marca", Marca);
                cmd.Parameters.AddWithValue("@Capacidad", Capacidad);
                cmd.Parameters.AddWithValue("@Kilometraje", Kilometraje);
                cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                cmd.Parameters.AddWithValue("@id", IdCamion);
                cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                conn.Open();
                cmd.ExecuteNonQuery(); //Ejecuta sin requerir valor de retorno
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
        //Eliminar
        public static void DelCamion(int idCamion)
        {
            try
            {
                string Query = "Camion_Eliminar";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idCamion);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close ();
            }
        }
        //GetByID
        public static CamionesVO GetCamionById(int IdCamion)
        {
            try
            {
                string Query = "Camiones_GetByID";
                SqlCommand cmd = new SqlCommand (Query, conn);
                cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", IdCamion);

                DataSet dsCamion = new DataSet();
                adapter.Fill(dsCamion); //Llenar
                if (dsCamion.Tables[0].Rows.Count > 0)
                {
                    //Encontró un registro
                    DataRow dr = dsCamion.Tables[0].Rows[0];
                    CamionesVO camion = new CamionesVO();
                    return camion;
                }
                else
                {
                    //La tabla esta vacia
                    CamionesVO camion = new CamionesVO ();
                    return camion;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}