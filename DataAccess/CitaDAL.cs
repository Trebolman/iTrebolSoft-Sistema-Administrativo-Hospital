using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class CitaDAL:Conexion
    {
        // CITAS
        public async Task<List<Cita>> GetCitasAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from citas";
            try
            {
                List<Cita> ListaCitas = null;
                if (MiConexion != null)
                {
                    ListaCitas = (await MiConexion.QueryAsync<Cita>(sql)).ToList();
                }
                return ListaCitas;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (MiConexion.State == System.Data.ConnectionState.Open)
                {
                    MiConexion.Close();
                }
            }
        }
        public async Task<int> GenerarCitaAsync(Cita cita)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into citas (IdCita, Dni, Nombre, Apellido, CodEspecialidad, CMP, TipoCita, EstadoCita) values (@IdCita, @Dni, @Nombre, @Apellido, @CodEspecialidad, @CMP, @TipoCita, @EstadoCita)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new {IdCita = cita.IdCita, Dni = cita.Dni, Nombre = cita.Nombre, Apellido = cita.Apellido, CodEspecialidad = cita.CodEspecialidad, CMP = cita.CMP, TipoCita = cita.TipoCita, EstadoCita = cita.EstadoCita });
                }
                return FilasAfectadas;
            }
            catch
            {
                return FilasAfectadas;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open) { conexion.Close(); }
            }
        }
        public async Task<int> EliminarCitaAsync(string IdCita)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "Delete from citas where IdCita = @IdCita";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { IdCita = IdCita });
                }
                return FilasAfectadas;
            }
            catch
            {
                return FilasAfectadas;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open) { conexion.Close(); }
            }
        }
    }
}
