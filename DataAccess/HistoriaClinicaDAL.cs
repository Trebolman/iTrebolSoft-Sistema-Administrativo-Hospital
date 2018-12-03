using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class HistoriaClinicaDAL:Conexion
    {
        public async Task<List<HistoriaClinica>> GetHistoriaClinicaAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from historiasclinicas";
            try
            {
                List<HistoriaClinica> ListaHistoriasClinicas = null;
                if(MiConexion != null)
                {
                    ListaHistoriasClinicas = (await MiConexion.QueryAsync<HistoriaClinica>(sql)).ToList();
                }
                return ListaHistoriasClinicas;
            }
            catch
            {
                return null;
            }
            finally
            {
                if(MiConexion.State == System.Data.ConnectionState.Open)
                {
                    MiConexion.Close();
                }
            }
        }

        public async Task<int> InsertarHistoriaClinicaAsync(HistoriaClinica historia)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into historiasclinicas (IdHistoria, CodEspecialidad, FechaApertura, Peso, Talla, Dni) values (@IdHistoria, @CodEspecialidad, @FechaApertura, @Peso, @Talla, @Dni)";
            string sqlp = "update pacientes set IdHistoria = @IdHistoria where Dni = @Dni;";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { IdHistoria = historia.IdHistoria, CodEspecialidad = historia.CodEspecialidad, FechaApertura = historia.FechaApertura, Peso = historia.Peso, Talla = historia.Talla, Dni = historia.Dni});
                    FilasAfectadas = await conexion.ExecuteAsync(sqlp, new { IdHistoria = historia.IdHistoria, Dni = historia.Dni });
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
        public async Task<int> UpdateHistoriaClinicaAsync(HistoriaClinica historia, string dni)
        {
            MySqlConnection conexion = AbrirConexionSql();
            //string sql = "UPDATE historiasclinicas SET 'CodEspecialidad' = @CodEspecialidad, 'Peso' = @Peso, 'Talla' = @Talla WHERE Dni = @Dni";
            //string sql = "UPDATE talumnos SET  Nombre = @Nombre, Apellido = @Apellido, Dni = @Dni, Email = @Email WHERE idAlumno = @idAlumno";
            string sql = "UPDATE historiasclinicas SET CodEspecialidad = @CodEspecialidad, Peso = @Peso, Talla = @Talla WHERE Dni = @Dni";

            int NroFilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    NroFilasAfectadas = await conexion.ExecuteAsync(sql, new
                    {
                        CodEspecialidad = historia.CodEspecialidad,
                        Peso = historia.Peso,
                        Talla = historia.Talla,
                        Dni = historia.Dni
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
        public async Task<int> EliminarHistoriaClinicaAsync(string dni)
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql =    @"SET FOREIGN_KEY_CHECKS=0;
                            delete from historiasclinicas where Dni = @dniPacienteAEliminar; ";
            int NroFilasAfectadas = 0;
            try
            {
                if (MiConexion != null)
                {
                    NroFilasAfectadas = await MiConexion.ExecuteAsync(sql, new { dniPacienteAEliminar = dni });
                }
                return NroFilasAfectadas;
            }
            catch
            {
                return NroFilasAfectadas;
            }
            finally
            {
                if (MiConexion.State == System.Data.ConnectionState.Open)
                {
                    MiConexion.Close();
                }
            }
        }


    }
}
