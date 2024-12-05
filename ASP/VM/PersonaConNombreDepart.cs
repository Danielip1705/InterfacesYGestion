using BL;
using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ASP.VM
{
    public class PersonaConNombreDepart : Personas
    {
        #region Atributos
        private string nombreDepart;
        #endregion

        #region Propiedades
        public string NombreDepart
        {
            get { return nombreDepart; }
            set { nombreDepart = value; }
        }
        #endregion

        public PersonaConNombreDepart(Personas per,List<Departamentos> listaDepart)
        {
            string nombreDept = "";

            this.Id = per.Id;
            this.Nombre = Nombre;
            this.Apellidos = per.Apellidos;
            this.Telefono = per.Telefono;
            this.Direccion = per.Direccion;
            this.Foto = per.Foto;
            this.FechaNac = per.FechaNac;
            this.IdDepart = per.IdDepart;

            nombreDept = listaDepart.FirstOrDefault(dept => dept.Id == per.IdDepart).Nombre;
            nombreDepart = nombreDept;
            

        }
        public PersonaConNombreDepart(int idpersona)
        {

            Personas per = ManejadoraPersonasBL.buscarPersonaPorIdBL(idpersona);
            string nombreDept = "";

            this.Id = per.Id;
            this.Nombre = Nombre;
            this.Apellidos = per.Apellidos;
            this.Telefono = per.Telefono;
            this.Direccion = per.Direccion;
            this.Foto = per.Foto;
            this.FechaNac = per.FechaNac;
            this.IdDepart = per.IdDepart;


            Departamentos depart = ManejadoraDepartamentosDAL.buscarDepartamentoPorId(IdDepart);
            nombreDepart = depart.Nombre;


        }
    }
}
