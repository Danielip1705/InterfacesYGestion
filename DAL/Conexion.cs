using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        /// <summary>
        /// Funcion que devuelve la conexion abierta de la base de datos de azure
        /// pre: Ninguna
        /// post: Conexion abierta de la base de datos
        /// </summary>
        /// <returns>Conexion de la base de datos</returns>
        /// <exception cref="Exception"></exception>
        public static SqlConnection mostrarConexion()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {

                miConexion.ConnectionString = ("server=daniel-nervion-db.database.windows.net;database=DanielDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");
                miConexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return miConexion;
        }

        /// <summary>
        /// Funcion que muestra la desconeccion de la base de datos de azure
        /// </summary>
        /// <returns>La desconexion de la base de datos de azure</returns>
        public static SqlConnection desconectar()
        {
            SqlConnection desconectar = mostrarConexion();
            desconectar.Close();
            return desconectar;
        }
    }
}
