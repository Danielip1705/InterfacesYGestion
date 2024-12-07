using ASP.VM;
using BL;
using DAL;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        /// <summary>
        /// Accion que devuelve una lista a la vista principal
        /// Pre: Nada
        /// post: Lista de personas con nombre de departamento
        /// </summary>
        /// <returns>Vista con la lista de personas</returns>
        public ActionResult Index()
        {
            List<PersonaConNombreDepart> lista = new List<PersonaConNombreDepart>();
            ListadoPersonaConNombreDepartVM vm = new ListadoPersonaConNombreDepartVM();
            lista = vm.Lista;
            return View(lista);
        }

        // GET: PersonaController/Details/5
        /// <summary>
        /// Accion que devuelve una persona para ver los detalles de esta
        /// Pre: El usuario elige a la persona
        /// Post: Vista de la persona en la vista de detalles
        /// </summary>
        /// <param name="id">Id de la persona elegida</param>
        /// <returns>Vista detalles con la persona seleccionada</returns>
        public ActionResult Details(int id)
        {
            PersonaConNombreDepart persona = new PersonaConNombreDepart(id);


            return View("Details",persona);
        }

        // GET: PersonaController/Create
        /// <summary>
        /// Accion que devuelve una vista para crear persona
        /// Pre:Nada
        /// Post: Vista de crear persona
        /// </summary>
        /// <returns>Vista de crear persona</returns>
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: PersonaController/Create
        /// <summary>
        /// Accion que recoge mediante post una persona para crear esa persona
        /// Pre: El usuario termina de crear la persona en la vista
        /// Post: El usuario ha sido creado e insertado en la lista
        /// </summary>
        /// <param name="persona">Objeto persona que se ha creado en la vista crear</param>
        /// <returns>Vista indexl</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personas persona)
        {
            try
            {
                ManejadoraPersonasBL.insetarPersonaBL(persona);
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        /// <summary>
        /// Accion que recoge un id de una persona seleccinada y la envia a la vista editar
        /// Pre: El usuario selecciona una persona para editar
        /// Post: Se navega a la vista editar con la persona seleccinada
        /// </summary>
        /// <param name="id">Id de la persona a editar</param>
        /// <returns>Vista editar con la persona a editar</returns>
        public ActionResult Edit(int id)
        {
            Personas persona = ManejadoraPersonasBL.buscarPersonaPorIdBL(id);
            return View("Edit",persona);
        }

        // POST: PersonaController/Edit/5
        /// <summary>
        /// Accion que mediante post recoge una persona y la edita por la persona actual
        /// Pre: El usuario termina de editar la persona
        /// Post: Se cambia los cambios de la persona antiguo por la editada
        /// </summary>
        /// <param name="persona">Objeto persona editado</param>
        /// <returns>Vista Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Personas persona)
        {
            try
            {
                ManejadoraPersonasBL.editarPersonaBL(persona);
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        /// <summary>
        /// Accion que recoge un id para eliminar a la persona
        /// Pre: El usuario selecciona la persona a eliminar
        /// Post: Se navegag a la vista eliminar con la persona a eliminar
        /// </summary>
        /// <param name="id">Id de la persona a editar</param>
        /// <returns>Vista eliminar con la persona a eliminar</returns>
        public ActionResult Delete(int id)
        {
            Personas persona = ManejadoraPersonasBL.buscarPersonaPorIdBL(id);
            return View("Delete",persona);
        }

        // POST: PersonaController/Delete/5
        /// <summary>
        /// Accion que recoge mediante post el id de la persona a eliminar
        /// Pre: El usuario eliminar a la persona
        /// Post: Persona eliminada
        /// </summary>
        /// <param name="id">Id de la persona a eliminar</param>
        /// <param name="a">Variable dummy para poder realizar el action</param>
        /// <returns>Vista index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,int a)
        {
            try
            {
                ManejadoraPersonasBL.borrarPersonasBL(id);
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
