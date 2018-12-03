using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Medicamento
    {
        public string CodMedicamento { get; set; }
        public string NombreProducto { get; set; }
        public string Presentacion { get; set; }
        public int Fracciones { get; set; }

        // CONSTRUCTORES
        public Medicamento(string CodMedicamentos, string NombreProducto, string Presentacion, int Fracciones)
        {
            this.CodMedicamento = CodMedicamentos;
            this.NombreProducto = NombreProducto;
            this.Presentacion = Presentacion;
            this.Fracciones = Fracciones;
        }
        public Medicamento() { }

        // METODOS
        public override string ToString()
        {
            return string.Format("COD_MEDICAMENTO = {0}, NOMBRE_PRODUCTO = {1}, PRESENTACION = {2}, FRACCIONES= {3}", CodMedicamento, NombreProducto, Presentacion, Fracciones);
        }
    }
}
