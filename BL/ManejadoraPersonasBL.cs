using DAL;
using ENT;

namespace BL
{
    public class ManejadoraPersonasBL
    {
        /// <summary>
        /// Funcion que borrar una persona haciendo usa de borrar persona de la DAL
        /// </summary>
        /// <param name="id">Id de la persona a borrar</param>
        /// <returns>Numero de peron</returns>
        public static int borrarPersonasBL(int id)
        {
            return ManejadoraPersonas.borrarPersona(id);
        }

        /// <summary>
        /// Funcion que busca una persona haciendo uso de buscar persona de la DAL
        /// </summary>
        /// <param name="id">Id de la persona a borrar</param>
        /// <returns>Persona buscada</returns>
        public static Personas buscarPersonaPorIdBL(int id)
        {
            return ManejadoraPersonas.buscarPersonaPorId(id);
        }

        /// <summary>
        /// Funcion que insertar una persona en la base de datos haciendo usa de la funcion de la dal
        /// </summary>
        /// <param name="persona">Objeto persona con los atributos llenos</param>
        /// <returns>Numero de filas afectadas</returns>
        public static int insetarPersonaBL(Personas persona)
        {
            return ManejadoraPersonas.insertarPersona(persona);
        }
        /// <summary>
        /// Funcion que edita una persona de la base de datos de azure haciendo usa de la funcion editar persona de la DAL
        /// </summary>
        /// <param name="persona">Objeto persona con los atributos llenos</param>
        /// <returns>Numero de filas afectadas</returns>
        public static int editarPersonaBL(Personas persona)
        {
            return ManejadoraPersonas.insertarPersona(persona);
        }
    }
}
