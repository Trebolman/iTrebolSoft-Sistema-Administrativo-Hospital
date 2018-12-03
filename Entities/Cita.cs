using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cita
    {
        //ATRIBUTOS
        public string IdCita { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        //public enumCodEspecialidades CodEspecialidad { get; set; }
        public string CodEspecialidad { get; set; }
        public string CMP { get; set; }
        //public enumTipoCita TipoCita { get; set; }
        public string TipoCita { get; set; }
        //public enumEstadoCita EstadoCita { get; set; }
        public string EstadoCita { get; set; }
        //CONTRUCTOR
        public Cita(string IdCita, string Dni, string Nombre, string Apellido, string CodEspecialidad, string CMP, string TipoCita, string EstadoCita)
        {
            this.IdCita = IdCita;
            this.Dni = Dni;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.CodEspecialidad = CodEspecialidad;
            this.CMP = CMP;
            this.TipoCita = TipoCita;
            this.EstadoCita = EstadoCita;
        }

        public Cita()
        {

        }

        public override string ToString()
        {
            return string.Format("IDCITA = {0}, DNI = {1}, NOMBRE = {2}, APELLIDO = {3}, COD.ESPECIALIDAD = {4}, CMP = {5}, TIPO CITA = {6}, ESTADO CITA = {7}",IdCita, Dni, Nombre, Apellido, CodEspecialidad, CMP, TipoCita, EstadoCita);
        }
    }

}
