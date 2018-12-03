using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;
namespace BusinessLayer
{
    public class EnfermedadBL
    {
        public static List<Enfermedad> ListaEnfermedades;
        public async Task<List<Enfermedad>> GetEnfermedadesAsync()
        {
            var dal = new EnfermedadDAL();
            ListaEnfermedades = await dal.GetEnfermedadesAsync();
            return ListaEnfermedades;
        }
        public async Task<int> InsertarEnfermedadAsync(Enfermedad enfermedad)
        {
            var dal = new EnfermedadDAL();
            return await dal.InsertarEnfermedadAsync (enfermedad);
        }
        public async Task<int> UpdateEnfermedadAsync(Enfermedad enfermedad)
        {
            var dal = new EnfermedadDAL();
            return await dal.UpdateEnfermedadAsync(enfermedad);
        }
        public async Task<int> DeleteEnfermedadAsync(string CodEnfermedad)
        {
            var dal = new EnfermedadDAL();
            return await dal.DeleteEnfermedadAsync(CodEnfermedad);
        }
    }
}
