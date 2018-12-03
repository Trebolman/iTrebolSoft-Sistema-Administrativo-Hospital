using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public abstract class Persona
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // CONSTRUCTORES
        public Persona() { }

        public Persona(string Dni, string Nombre, string Apellido)
        {
            this.Dni = Dni;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }
    }
}
