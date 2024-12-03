using BL;
using DAL;
using ENT;

namespace ASP.VM
{
    public class ListadoPersonaConNombreDepartVM
    {
        List<PersonaConNombreDepart> lista = new List<PersonaConNombreDepart>();
        List<Personas> personas;
        List<Departamentos> departamentos;
        //public List<PersonaConNombreDepart> Lista { get { return lista; } }

        public ListadoPersonaConNombreDepartVM()
        {

            personas = ManejadoraPersonasBL.listadoCompletoPersonasBL();
            departamentos = ListadoBD.listadoDepartamentosDAL();
            foreach (Personas persona in personas)
            {
                PersonaConNombreDepart personaDepart = new PersonaConNombreDepart(persona,departamentos);
                lista.Add(personaDepart);
            }

        }
    }
}
