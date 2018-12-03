using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Paciente:Persona
    {
        public string FechaNacimiento { get; set; }
        public string TipoSeguro { get; set; }
        public string EstadoPaciente { get; set; }
        public string IdHistoria { get; set; }

        // CONSTRUCTOR
        public Paciente()
        {
            //this.Tipo = enumTipoPaciente.Asegurado;
            //HistClinica = new HistoriaClinica();
        }
        public Paciente(string Dni, string Nombre, string Apellido, string FechaNacimiento, string TipoSeguro, string EstadoPaciente, string IdHistoria)
        :base(Dni, Nombre, Apellido)
        {
            this.FechaNacimiento = FechaNacimiento;
            this.TipoSeguro = TipoSeguro;
            this.EstadoPaciente = EstadoPaciente;
            this.IdHistoria = IdHistoria;
            //HistClinica = new HistoriaClinica();
        }

        // METODOS
        public override string ToString()
        {
            return string.Format("DNI = {0}, NOMBRE = {1}, APELLIDO = {2}, FNACIMIENTO = {3}, TIPO SEGURO = {4}, ESTADO = {5}, IDHISTORIA = {6}", Dni, Nombre, Apellido, FechaNacimiento, TipoSeguro, EstadoPaciente, IdHistoria );
        }
    }
}
