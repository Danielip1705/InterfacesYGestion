using DAL;
using ENT;


namespace BL
{
    class ManejadoraDepartamentoBL
    {
        /// <summary>
        /// Funcion que hace uso de la funcion dal para conseguir todos los departamentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Departamentos getDepartamentosPorIdBL(int id)
        {
            return ManejadoraDepartamentosDAL.buscarDepartamentoPorId(id);
        }
    }
}
