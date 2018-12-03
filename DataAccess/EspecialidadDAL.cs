using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class EspecialidadDAL:Conexion
    {
        public async Task<List<Especialidad>> GetEspecialidades()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from especialidades";
            try
            {
                List<Especialidad> ListaEspecialidades = null;
                if (MiConexion != null)
                {
                    ListaEspecialidades = (await MiConexion.QueryAsync<Especialidad>(sql)).ToList();
                }
                return ListaEspecialidades;
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

        public async Task<int> InsertarEspecialidadAsync (Especialidad especialidad)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into especialidades (CodEspecialidad, IdEspecialidad) values (@CodEspecialidad, @IdEspecialidad)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CodEspecialidad = especialidad.CodEspecialidad, IdEspecialidad = especialidad.IdEspecialidad });
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

        public async Task<int> UpdateEspecialidadAsync (Especialidad newEspecialidad)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "UPDATE especialidades SET  CodEspecialidad = @CodEspecialidad, IdEspecialidad = @IdEspecialidad WHERE CodEspecialidad = @CodEspecialidad";
            //string sql = "UPDATE talumnos SET  Nombre = @Nombre, Apellido = @Apellido, Dni = @Dni, Email = @Email WHERE idAlumno = @idAlumno";
            int NroFilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    NroFilasAfectadas = await conexion.ExecuteAsync(sql, new
                    {
                        CodEspecialidad = newEspecialidad.CodEspecialidad,
                        IdEspecialidad = newEspecialidad.IdEspecialidad
                    });
                };
                return NroFilasAfectadas;
            }
            catch (Exception ex)
            {
                return NroFilasAfectadas;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }

        public async Task<int> DeleteEspecialidadAsync(string CodEspecialidad)
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "delete from especialidades WHERE CodEspecialidad = @CodEspecialidadAEliminar;";
            int FilasAfectadas = 0;
            try
            {
                if(MiConexion != null)
                {
                    FilasAfectadas = await MiConexion.ExecuteAsync(sql, new { CodEspecialidadAEliminar = CodEspecialidad});
                }
                return FilasAfectadas;
                
            }
            catch
            {
                return FilasAfectadas;
            }
            finally
            {
                if(MiConexion.State == System.Data.ConnectionState.Open)
                {
                    MiConexion.Close();
                }
            }
        }
    }
}
