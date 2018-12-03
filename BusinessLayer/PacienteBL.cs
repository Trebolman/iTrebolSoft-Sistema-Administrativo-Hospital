using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PacienteBL
    {
        public static List<Paciente> ListaPacientes;
        public async Task<List<Paciente>> GetPacientesAsync()
        {
            PacienteDAL dal = new PacienteDAL();
            ListaPacientes = await dal.GetPacientesAsync();
            return ListaPacientes;
        }
        public async Task<Paciente> BuscarPacienteAsync(string dni)
        {
            PacienteDAL dal = new PacienteDAL();
            Paciente paciente = new Paciente();
            ListaPacientes = await dal.GetPacientesAsync();
            bool flag = false;
            foreach (var item in ListaPacientes)
            {
                if (item.Dni == dni)
                {
                    flag = true;
                    paciente = item;
                    break;
                }
            }
            if (flag)
                return paciente;
            else
                paciente = null;
            return paciente;
        }
        public async Task<int> InsertarPacienteAsync(Paciente paciente)
        {
            PacienteDAL dal = new PacienteDAL();
            return await dal.InsertarPacienteAsync(paciente);
        }
        public async Task<int> ActualizarPacienteAsync(Paciente paciente)
        {
            var dal = new PacienteDAL();
            return await dal.ActualizarPacienteAsync(paciente);
        }
        public async Task<int> EliminarPacientesTodo()
        {
            var dal = new PacienteDAL();
            return await dal.EliminarPacientesTodo();
        }
        public async Task<int> EliminarPaciente(string dni)
        {
            var dal = new PacienteDAL();
            return await dal.EliminarPaciente(dni);
        }
    }
}
