using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Medico:Persona
    {
        public string CMP { get; set; }
        public string CodEspecialidad { get; set; }
        public Medico(string Dni, string Nombre, string Apellido, string CMP, string CodEspecialidad)
        :base(Dni, Nombre, Apellido)
        {
            this.CMP = CMP;
            this.CodEspecialidad = CodEspecialidad;
        }
        public Medico(){ }
        public override string ToString()
        {
            return string.Format("DNI = {0}, NOMBRE = {1}, APELLIDO = {2}, CMP = {3}, COD_ESPECIALIDAD = {4}", Dni, Nombre, Apellido, CMP, CodEspecialidad);
        }
    }
}

