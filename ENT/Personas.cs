namespace ENT
{
    public class Personas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string foto { get; set; }
        public DateTime fechaNac { get; set; }
        public int idDepart { get; set; }

        public Personas() { }
        public Personas(int id, string nombre, string apellido, string telefono, string direccion, string foto, DateTime fechaNac, int idDepart)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellido;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNac = fechaNac;
            this.idDepart = idDepart;
        }
    }
}
