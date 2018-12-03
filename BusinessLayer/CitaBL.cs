using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;
using System;

namespace BusinessLayer
{
    public class CitaBL
    {
        public static List<Cita> ListaCitas;
        public async Task<List<Cita>> GetCitasAsync()
        {
            CitaDAL dal = new CitaDAL();
            ListaCitas = await dal.GetCitasAsync();
            return ListaCitas;
        }

        public async Task<int> GenerarCitaAsync(Cita cita)
        {
            CitaDAL dal = new CitaDAL();
            //ListaCitas = await dal.GetCitasAsync();
             
            return await dal.GenerarCitaAsync(cita);

        }

        public async Task<int> EliminarCitaAsync(string IdCita)
        {
            var dal = new CitaDAL();
            return await dal.EliminarCitaAsync(IdCita);
        }
        public async Task<Cita> BuscarCita(string dni)
        {
            CitaDAL dal = new CitaDAL();
            Cita c = new Cita();
            ListaCitas = await dal.GetCitasAsync();
            bool flag = false;
            foreach (var item in ListaCitas)
            {
                if (item.Dni == dni)
                {
                    flag = true;
                    c = item;
                    break;
                }
            }
            if (flag)
                return c;
            else
                c = null;
            return c;
        }
        
    }
}
