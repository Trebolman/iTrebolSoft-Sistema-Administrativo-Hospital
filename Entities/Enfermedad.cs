using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Enfermedad
    {
        public string CodEnfermedad { get; set; }
        public string Descripcion { get; set; }
        public Enfermedad(string CodEnfermedad, string Descripcion)
        {
            this.CodEnfermedad = CodEnfermedad;
            this.Descripcion = Descripcion;
        }
        public Enfermedad() { }
        public override string ToString()
        {
            return string.Format("COD_ENFERMEDAD = {0}, DESCRIPCION = {1}", CodEnfermedad, Descripcion);
        }
    }
}
