using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
