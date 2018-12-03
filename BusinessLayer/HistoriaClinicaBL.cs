using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HistoriaClinicaBL
    {
        public static List<HistoriaClinica> ListHistoriaClinica;

        // METODOS
        public async Task<List<HistoriaClinica>> GetHistoriaClinicaAsync()
        {
            HistoriaClinicaDAL dal = new HistoriaClinicaDAL();
            ListHistoriaClinica = await dal.GetHistoriaClinicaAsync();
            return ListHistoriaClinica;
        }
        public async Task<HistoriaClinica> BuscarHistoriaClinicaAsync(string dni)
        {
            HistoriaClinicaDAL dal = new HistoriaClinicaDAL();
            var historia = new HistoriaClinica();
            ListHistoriaClinica = await dal.GetHistoriaClinicaAsync();
            bool flag = false;
            foreach (var item in ListHistoriaClinica)
            {
                if (item.Dni == dni)
                {
                    flag = true;
                    historia = item;
                    break;
                }
            }
            if (flag)
                return historia;
            else
                historia = null;
                return historia;
        }
        public async Task<int> InsertarHistoriaClinicaAsync(HistoriaClinica historia)
        {
            HistoriaClinicaDAL dal = new HistoriaClinicaDAL();
            var dalp = new PacienteDAL();
            return await dal.InsertarHistoriaClinicaAsync(historia);
        }
        public async Task<int> UpdateHistoriaClinicaAsync(HistoriaClinica historia, string dni)
        {
            HistoriaClinicaDAL dal = new HistoriaClinicaDAL();
            return await dal.UpdateHistoriaClinicaAsync(historia, dni);
            //return alumno;
        }
        public async Task<int> EliminarHistoriaClinicaAsync(string dni)
        {
            var dal = new HistoriaClinicaDAL();
            return await dal.EliminarHistoriaClinicaAsync(dni);
        }
    }
}
