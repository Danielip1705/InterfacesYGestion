using BL;
using DAL;
using ENT;

namespace ASP.VM
{
    public class ListadoPersonaConNombreDepartVM
    {
       private List<PersonaConNombreDepart> listaConNombreDepart;

        public List<PersonaConNombreDepart> Lista { get; set; }
        public ListadoPersonaConNombreDepartVM()
        {
            Lista = new List<PersonaConNombreDepart> ();
            List<Personas> personas = new List<Personas>();
            List<Departamentos> departamentos = new List<Departamentos>();
            personas = ManejadoraPersonasBL.listadoCompletoPersonasBL();
            departamentos = ListadoBD.listadoDepartamentosDAL();
            foreach (Personas persona in personas)
            {
                PersonaConNombreDepart personaDepart = new PersonaConNombreDepart(persona);
                Lista.Add(personaDepart);
            }

        }
    }
}
