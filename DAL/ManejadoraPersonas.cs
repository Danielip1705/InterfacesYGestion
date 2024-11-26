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
        public static int borrarPersona(int id)
        {
            int numeroFilasAfectadas = 0;
            Conexion miContector = new Conexion();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miContector.mostrarConeccion();
                miComando.CommandText = "DELETE FROM Personas WHERE ID = @id";
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
        /// <summary>
        /// Funcion que busca en la base de datos una persona por su id
        /// Pre: Recibimos la id de la persona a buscar
        /// Post: devolvemos la persona de la base de datos
        /// </summary>
        /// <param name="id">Id de la persona a buscar</param>
        /// <returns>Persona encontrada</returns>
        public static Personas buscarPersonaPorId(int id)
        {
            Personas persona = new Personas();
            Conexion miContector = new Conexion();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miContector.mostrarConeccion();
                miComando.CommandText = "SELECT * FROM personas WHERE ID = @id";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    persona = new Personas();
                    persona.id = (int)miLector["ID"];
                    persona.nombre = (string)miLector["Nombre"];
                    persona.apellidos = (string)miLector["Apellidos"];
                    if (miLector["FechaNacimiento"] != System.DBNull.Value)
                    { persona.fechaNac = (DateTime)miLector["FechaNacimiento"]; }
                    persona.direccion = (string)miLector["Direccion"];
                    persona.telefono = (string)miLector["Telefono"];
                    persona.idDepart = (int)miLector["IDDepartamento"];
                }
                miLector.Close();
            }
            catch (SqlException ex)
            {

                throw;

            }
            catch (Exception ex)
            {
                throw;

            }

            return persona;
        }

        /// <summary>
        /// Funcion que inserta una persona en la base de datos de azure
        /// </summary>
        /// <param name="persona">Objeto persona con los atributos llenos</param>
        /// <returns>Numero de personas insertadas</returns>
        public static int insertarPersona(Personas persona)
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
                conexion = miConexion.mostrarConeccion();
                miComando.CommandText = "INSERT INTO Personas VALUES (@nombre,@apellidos,@telefono,@direccion,@foto,@fechaNac,@idDepart)";
                miComando.Connection = conexion;
                numeroAfectadasFilas=miComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            return numeroAfectadasFilas;
        }

        /// <summary>
        /// Funcion que edita una persona de la base de datos de azure
        /// </summary>
        /// <param name="persona">Objeto Persona con los atributos llenos</param>
        /// <returns>Numero de persona editada</returns>
        public static int editarPersona(Personas persona)
        {
            int numeroFilaAfectadas = 0;
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
                conexion = miConexion.mostrarConeccion();
                miComando.CommandText = "UPDATE Personas SET Nombre=@nombre,Apellidos=apellidos,FechaNacimiento=@fechaNac,Direccion=@direccion,Telefono=@telefono,IDDepartamento=@idDepart where ID = @id";
                miComando.Connection = conexion;
                numeroFilaAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            return numeroFilaAfectadas;
        }
    }
}