using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManejadoraDepartamentosDAL
    {
        /// <summary>
        /// Funcion que toma de una base de datos un departamento por su id
        /// pre: El usuario inserta la id del departamento
        /// Post: Se envia el departamento
        /// </summary>
        /// <param name="id">Numero entero que indica el id del departamento</param>
        /// <returns>Departamento con la id</returns>
        public static Departamentos buscarDepartamentoPorId(int id)
        {
            Departamentos dept = new Departamentos();
            Conexion miConector = new Conexion();
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miConector.mostrarConeccion();
                miComando.CommandText = "SELECT * FROM Departamentos WHERE ID = @id";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                if (miLector.Read())
                {
                    dept.Id = (int)miLector["ID"];
                    dept.Nombre = (string)miLector["Nombre"];
                }
                miLector.Close();
            }
            catch (SqlException ex)
            {
                throw;
            }

            return dept;
        }
    }
}
