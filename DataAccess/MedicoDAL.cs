using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class MedicoDAL : Conexion
    {
        public async Task<List<Medico>> GetMedicosAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from medicos";
            try
            {
                List<Medico> ListaMedicos = null;
                if (MiConexion != null)
                {
                    ListaMedicos = (await MiConexion.QueryAsync<Medico>(sql)).ToList();
                }
                return ListaMedicos;
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
        public async Task<int> InsertarMedicoAsync(Medico medico)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into medicos (CMP, CodEspecialidad, Dni, Nombre, Apellido) values (@CMP, @CodEspecialidad, @Dni, @Nombre, @Apellido)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CMP = medico.CMP, CodEspecialidad = medico.CodEspecialidad, Dni = medico.Dni, Nombre = medico.Nombre, Apellido = medico.Apellido });
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
        public async Task<int> ActualizarMedicoAsync(Medico medico)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "UPDATE medicos SET CMP = @CMP, CodEspecialidad = @CodEspecialidad, Dni = @Dni, Nombre = @Nombre, Apellido = @Apellido WHERE CMP = @CMP";
            //string sql = "UPDATE medicos SET (CMP, CodEspecialidad, Dni, Nombre, Apellido) values (@CMP, @CodEspecialidad, @Dni, @Nombre, @Apellido) WHERE CMP = @CMP";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CMP = medico.CMP, CodEspecialidad = medico.CodEspecialidad, Dni = medico.Dni, Nombre = medico.Nombre, Apellido = medico.Apellido });
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
        public async Task<int> EliminarMedicoAsync(string CMPAEliminar)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "delete from medicos where CMP = @CMPAEliminar";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CMP = CMPAEliminar });
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
