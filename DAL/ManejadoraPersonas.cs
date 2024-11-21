using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManejadoraPersonas
    {
        /// <summary>
        /// Recibe numero entero en el cual es el id del jugador en el cual lo borra de la base de datos
        /// </summary>
        /// <param name="id">Numero entero que indica el id del jugador</param>
        /// <returns></returns>
        public static int borrarJugador(int id)
        {
            int numeroFilasAfectadas = 0;
            Conexion miContector = new Conexion();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miContector.mostrarConeccion();
                miComando.CommandText = "DELETE FROM Jugadores WHERE IDPersona = @id";
                miComando.Connection = conexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw;

            }
            catch (Exception ex)
            {
                throw;

            }

            return numeroFilasAfectadas;
        }


        public static int editarJugador(Personas persona)
        {
            int numeroAfectadasFilas = 0;
            Conexion miConexion = new Conexion();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
            miComando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.foto;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.fechaNac;
            miComando.Parameters.Add("@idDepart", System.Data.SqlDbType.Int).Value = persona.idDepart;

            try
            {
                miComando
            }
            catch (SqlException ex)
            {
                throw;
            }

        }
    }
}