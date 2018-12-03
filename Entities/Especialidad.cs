using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Especialidad
    {
        public string CodEspecialidad { get; set; }
        public string IdEspecialidad { get; set; }

        public Especialidad()
        {

        }
        public Especialidad(string CodEspecialidad, string IdEspecialidad)
        {
            this.CodEspecialidad = CodEspecialidad;
            this.IdEspecialidad = IdEspecialidad;
        }

        public override string ToString()
        {
            return string.Format("COD.ESPECIALIDAD = {0}, ID.ESPECIALIDAD = {1}", CodEspecialidad, IdEspecialidad);
        }
    }
    
}
