using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class MedicamentoDAL:Conexion
    {
        public async Task<List<Medicamento>> GetMedicamentosAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from medicamentos";
            try
            {
                List<Medicamento> ListaMedicamentos = null;
                if (MiConexion != null)
                {
                    ListaMedicamentos = (await MiConexion.QueryAsync<Medicamento>(sql)).ToList();
                }
                return ListaMedicamentos;
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
        public async Task<int> InsertarMedicamentoAsync (Medicamento medicamento)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into medicamentos (CodMedicamento, NombreProducto, Presentacion, Fracciones) values (@CodMedicamento, @NombreProducto, @Presentacion, @Fracciones)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CodMedicamento = medicamento.CodMedicamento, NombreProducto = medicamento.NombreProducto, Presentacion = medicamento.Presentacion, Fracciones = medicamento.Fracciones });
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
        public async Task<int> UpdateMedicamentoAsync(Medicamento medicamento)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "UPDATE medicamentos SET  CodMedicamento = @CodMedicamento, NombreProducto = @NombreProducto, Presentacion = @Presentacion, Fracciones = @Fracciones WHERE CodMedicamento = @CodMedicamento";
            //string sql = "UPDATE talumnos SET  Nombre = @Nombre, Apellido = @Apellido, Dni = @Dni, Email = @Email WHERE idAlumno = @idAlumno";
            int NroFilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    NroFilasAfectadas = await conexion.ExecuteAsync(sql, new
                    {
                        CodMedicamento = medicamento.CodMedicamento,
                        NombreProducto = medicamento.NombreProducto,
                        Presentacion = medicamento.Presentacion,
                        Fracciones = medicamento.Fracciones
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
        public async Task<int> EliminarMedicamentoAsync(string CodMedicamento)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "delete from medicamentos where CodMedicamento = @CodMedicamentoAEliminar;";
            int NroFilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    NroFilasAfectadas = await conexion.ExecuteAsync(sql, new
                    {
                        CodMedicamentoAEliminar = CodMedicamento
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
    }
}
