using DAL;
using ENT;


namespace BL
{
    public class ManejadoraDepartamentoBL
    {
        /// <summary>
        /// Funcion que hace uso de la funcion dal para conseguir todos los departamentos
        /// Pre: El usuario envia la id del departameto
        /// Post: Se envia el departamento por la id
        /// </summary>
        /// <param name="id">Numero entero que indica el id del departamento</param>
        /// <returns>Departamento con la id a encontrar</returns>
        public static Departamentos getDepartamentosPorIdBL(int id)
        {
            return ManejadoraDepartamentosDAL.buscarDepartamentoPorId(id);
        }

        /// <summary>
        /// Funcion que hace uso de listado en la cual devuelve un listado de departamentos de la base de datos
        /// Pre: Nada
        /// Post: Listado de departamentos
        /// </summary>
        /// <returns>Listado de departamentos</returns>
        public static List<Departamentos> getListadoDepartametosBL(){
        
            return ListadoBD.listadoDepartamentosDAL();

        }
    }
}
