using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace DataAccess
{
    public class EnfermedadDAL:Conexion
    {
        public async Task<List<Enfermedad>> GetEnfermedadesAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from enfermedades";
            try
            {
                List<Enfermedad> ListaEnfermedades = null;
                if (MiConexion != null)
                {
                    ListaEnfermedades = (await MiConexion.QueryAsync<Enfermedad>(sql)).ToList();
                }
                return ListaEnfermedades;
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
        public async Task<int> InsertarEnfermedadAsync(Enfermedad enfermedad)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into enfermedades (CodEnfermedad, Descripcion) values (@CodEnfermedad, @Descripcion)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CodEnfermedad = enfermedad.CodEnfermedad, Descripcion = enfermedad.Descripcion });
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
        public async Task<int> UpdateEnfermedadAsync(Enfermedad enfermedad)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "UPDATE enfermedades SET  CodEnfermedad = @CodEnfermedad, Descripcion = @Descripcion WHERE CodEnfermedad = @CodEnfermedad";
            int NroFilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    NroFilasAfectadas = await conexion.ExecuteAsync(sql, new
                    {
                        CodEnfermedad = enfermedad.CodEnfermedad,
                        Descripcion = enfermedad.Descripcion
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
        public async Task<int> DeleteEnfermedadAsync(string CodEnfermedad)
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "delete from enfermedades WHERE CodEnfermedad = @CodEnfermedad;";
            int FilasAfectadas = 0;
            try
            {
                if (MiConexion != null)
                {
                    FilasAfectadas = await MiConexion.ExecuteAsync(sql, new { CodEnfermedad = CodEnfermedad });
                }
                return FilasAfectadas;

            }
            catch
            {
                return FilasAfectadas;
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
