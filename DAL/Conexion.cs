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
        public SqlConnection mostrarConeccion()
        {
            // Se declara una variable para almacenar la conexión SQL
            SqlConnection miConexion = new SqlConnection();

            // Variable para almacenar el estado de la conexión o un mensaje de error
            string estado = "";

            // Try para capturar algun error
            try
            {
                // Se establece la cadena de conexión a la base de datos
                /* server: El enlace al servidor de azure
                 * database: Nombre de nuestra base de datos
                 * uid: Nombre del usuario creado, en nuestro caso todos tendremos usuario
                 * pwd: La contraseña, en nuestro caso todos tendremos LaCamapana123
                 * trustServerCertificate: Siempre True
                 */
                miConexion.ConnectionString = "server=daniel-nervion-db.database.windows.net;database=DanielDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";

                // Se intenta abrir la conexión a la base de datos
                miConexion.Open();
            }
            catch (Exception e)
            {
                throw;
            }
            //Devolvemos estado
            return miConexion;
        }

        public void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
