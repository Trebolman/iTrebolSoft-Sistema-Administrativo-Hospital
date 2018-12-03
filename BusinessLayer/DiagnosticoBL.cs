using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DiagnosticoBL
    {
        public static List<Diagnostico> ListaDiagnosticos;
        public async Task<List<Diagnostico>> GetDiagnosticosAsync()
        {
            var dal = new DiagnosticoDAL();
            ListaDiagnosticos = await dal.GetDiagnosticosAsync();
            return ListaDiagnosticos;
        }
        public async Task<int> InsertarDiagnosticoAsync(Diagnostico diagnostico, string dni)
        {
            var dal = new DiagnosticoDAL();
            return await dal.InsertarDiagnosticoAsync(diagnostico, dni);
        }
        public async Task<int> UpdateDiagnosticoAsync(Diagnostico diagnostico)
        {
            var dal = new DiagnosticoDAL();
            return await dal.UpdateDiagnosticoAsync(diagnostico);
        }
        public async Task<int> DeleteDiagnosticoAsync(string IdDiagnostico)
        {
            var dal = new DiagnosticoDAL();
            return await dal.DeleteDiagnosticoAsync(IdDiagnostico);
        }
    }
}
