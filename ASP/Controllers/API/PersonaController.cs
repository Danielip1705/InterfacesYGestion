using ASP.VM;
using BL;
using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/<PersonaController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaConNombreDepart> lista = new List<PersonaConNombreDepart>();
            ListadoPersonaConNombreDepartVM vm;
            try
            {
            lista = new List<PersonaConNombreDepart> ();
            vm = new ListadoPersonaConNombreDepartVM ();
            lista = vm.Lista;

                if (lista.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(lista);
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            PersonaConNombreDepart persona;
            try
            {
                persona = new PersonaConNombreDepart(id);
                if (persona ==null)
                {
                    salida = NoContent();
                } else
                {
                    salida = Ok(persona);
                }
            } 
            catch(Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }

        // POST api/<PersonaController>
        [HttpPost]
        public IActionResult Post([FromBody] Personas persona)
        {
            PersonaConNombreDepart personaDepart;
            int anyadido;
            IActionResult salida = null;
            try
            {
                persona = new PersonaConNombreDepart(persona);
                anyadido = ManejadoraPersonasBL.insetarPersonaBL(persona);
                if (anyadido != 0)
                {
                    if (persona==null)
                    {
                        salida = NoContent();
                    } else
                    {
                        salida = Ok(persona);
                    }

                }
            }
            catch (Exception ex)
            {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

         //DELETE api/<PersonaController>/5
       [HttpDelete("{id}")]
       public void Delete(int id)
       {
        ManejadoraPersonasBL.borrarPersonasBL(id);
       }
    }
}
