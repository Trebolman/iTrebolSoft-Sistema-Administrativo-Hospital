using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MedicamentoBL
    {
        public static List<Medicamento> ListaMedicamentos;

        // METODOS
        public async Task<List<Medicamento>> GetListaMedicamentosAsync()
        {
            MedicamentoDAL dal = new MedicamentoDAL();
            ListaMedicamentos = await dal.GetMedicamentosAsync();
            return ListaMedicamentos;
        }

        public async Task<Medicamento> BuscarMedicamentoAsync(string CodMedicamento)
        {
            MedicamentoDAL dal = new MedicamentoDAL();
            Medicamento medicamento = new Medicamento();
            ListaMedicamentos = await dal.GetMedicamentosAsync();
            bool flag = false;
            foreach (var item in ListaMedicamentos)
            {
                if (item.CodMedicamento == CodMedicamento)
                {
                    flag = true;
                    medicamento = item;
                    break;
                }
            }
            if (flag)
                return medicamento;
            else
                medicamento = null;
            return medicamento;
        }
        public async Task<int> InsertarMedicamentoAsync(Medicamento medicamento)
        {
            MedicamentoDAL dal = new MedicamentoDAL();
            return await dal.InsertarMedicamentoAsync(medicamento);
        }
        public async Task<int> UpdateMedicamentoAsync(Medicamento medicamento)
        {
            MedicamentoDAL dal = new MedicamentoDAL();
            return await dal.UpdateMedicamentoAsync(medicamento);
            //return alumno;
        }
        public async Task<int> EliminarMedicamentoAsync(string CodMedicamento)
        {
            MedicamentoDAL dal = new MedicamentoDAL();
            return await dal.EliminarMedicamentoAsync(CodMedicamento);
            //return alumno;
        }
    }
}
