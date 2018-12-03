using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Diagnostico
    {
        public string IdDiagnostico { get; set; }
        public string CodMedicamento { get; set; }
        public string CodEnfermedad { get; set; }
        public string CMP { get; set; }
        // CONSTRUCTOR
        public Diagnostico(string IdDiagnostico, string CodMedicamento, string CodEnfermedad, string CMP)
        {
            this.IdDiagnostico = IdDiagnostico;
            this.CodMedicamento = CodMedicamento;
            this.CodEnfermedad = CodEnfermedad;
            this.CMP = CMP;
        }
        public Diagnostico() { }

        // METODOS
        public override string ToString()
        {
            return string.Format("IDDIAGNOSTICO = {0}, CODMEDICAMENTO = {1}, CODENFERMEDAD = {2}, CMP = {3}", IdDiagnostico, CodMedicamento, CodEnfermedad, CMP);
        }
    }
}
