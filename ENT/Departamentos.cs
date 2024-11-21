using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Departamentos
    {
        private int _id;
        private string _nombre;


        public int ID { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }

        public Departamentos()
        {

        }

        public Departamentos(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
    }
}
