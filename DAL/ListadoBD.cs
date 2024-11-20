using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListadoBD
    {
        /// <summary>
        /// Funcion que muestra un listado completo de personas
        /// </summary>
        /// <returns> Listado completo de personas de la base de datos de azure</returns>
        public static List<Personas> ListadoCompletoPersonaDAL()
        {
            //Creamos variable conexion
            SqlConnection miConexion = new SqlConnection();
            //Creamos listado para almacenar personas
            List<Personas> listadoPersonas = new List<Personas>();
            //Creamos comando para realizar comandos de sql server en visual
            SqlCommand miComando = new SqlCommand();
            SqlDataReader lector;
            Personas persona;
            miConexion.ConnectionString = ("server=daniel-nervion-db.database.windows.net;database=DanielDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;");

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = miConexion;
                lector = miComando.ExecuteReader();
                if (lector.Read())
                {
                    while (lector.Read())
                    {
                        persona = new Personas();
                        persona = new Personas();
                        persona.id = (int)lector["ID"];
                        persona.nombre = (string)lector["Nombre"];
                        persona.apellidos = (string)lector["Apellidos"];
                        if (lector["FechaNacimiento"] != System.DBNull.Value)
                        { persona.fechaNac = (DateTime)lector["FechaNacimiento"]; }
                        persona.direccion = (string)lector["Direccion"];
                        persona.telefono = (string)lector["Telefono"];
                        persona.idDepart = (int)lector["IDDepartamento"];
                        listadoPersonas.Add(persona);
                    }
                    lector.Close();
                    miConexion.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoPersonas;
        }


    }
    }
