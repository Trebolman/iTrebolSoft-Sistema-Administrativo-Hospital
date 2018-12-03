using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class HistoriaClinica
    {
        public string IdDiagnostico { get; set; }
        public string CodEspecialidad { get; set; }
        public DateTime FechaApertura { get; set; }
        public string Peso { get; set; }
        public string Talla { get; set; }
        public string Dni { get; set; }
        public string IdHistoria { get; set; }

        //CONSTRUCTOR
        public HistoriaClinica()
        {

        }
        public HistoriaClinica(string IdDiagnostico, string codEspecialidad, DateTime fechaAp, string peso, string talla, string dni, string IdHistoria)
        {
            this.IdDiagnostico = IdDiagnostico;
            CodEspecialidad = codEspecialidad;
            FechaApertura = fechaAp;
            Peso = peso;
            Talla = talla;
            Dni = dni;
            this.IdHistoria = IdHistoria;
        }

        public override string ToString()
        {
            return string.Format("IdHistoria = {0}, CodEspecialidad = {1}, Fecha Apertura = {2}, Peso = {3}, Talla = {4}, Dni = {5}, IdDiagnostico = {6}", IdHistoria, CodEspecialidad, FechaApertura, Peso, Talla, Dni,IdDiagnostico );
        }
    }

}
