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
        public static string BD = "server = daniel - nervion - db.database.windows.net; database = DanielDB; uid = usuario; pwd = LaCampana123; trustServerCertificate = true;";
        public int DeletePersona(int id)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = (BD);
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                miConexion.Open();
                miComando.CommandText = ("DELETE FROM PERSONAS WHERE Id=@id");
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }  
    }
    
    public Personas InsertPersona(Personas per)
    {
        int personaAñadida = 0;
        Personas personas = per;
        string nombre = personas.nombre;
        string apellido = personas.apellidos;
        string tele
        SqlConnection miConexion = new SqlConnection();
        SqlCommand miComand = new SqlCommand();
        miConexion.ConnectionString = (BD);
        miComand.Parameters.Add("@per.Id",System.Data.SqlDbType.)
        
    }
}
