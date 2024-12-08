using DAL;
using ENT;


namespace BL
{
    class ManejadoraDepartamentoBL
    {

        public static Departamentos getDepartamentosPorIdBL(int id)
        {
            return ManejadoraDepartamentosDAL.buscarDepartamentoPorId(id);
        }
    }
}
