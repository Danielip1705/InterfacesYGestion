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
        public ActionResult Index()
        {
            List<PersonaConNombreDepart> lista = new List<PersonaConNombreDepart>();
            ListadoPersonaConNombreDepartVM vm = new ListadoPersonaConNombreDepartVM();
            lista = vm.Lista;
            return View(lista);
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            Personas personas = new Personas();
            personas = ManejadoraPersonasBL.buscarPersonaPorIdBL(id);
            return View("Details",personas);
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personas persona)
        {
            try
            {
                ManejadoraPersonasBL.insetarPersonaBL(persona);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            Personas persona = ManejadoraPersonasBL.buscarPersonaPorIdBL(id);
            return View("Edit",persona);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Personas persona)
        {
            try
            {
                ManejadoraPersonasBL.editarPersonaBL(persona);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            Personas persona = ManejadoraPersonasBL.buscarPersonaPorIdBL(id);
            return View("Delete",persona);
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,int a)
        {
            try
            {
                ManejadoraPersonasBL.borrarPersonasBL(id);
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
