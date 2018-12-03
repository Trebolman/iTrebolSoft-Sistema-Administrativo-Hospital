using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class Conexion
    {
        //private string MysqlString = "server = 127.0.0.1; uid = root; pwd = admin; database = hospital";
        private string MysqlString = "server = 127.0.0.1; uid = root; pwd = admin; database = hospitaldb";
        public MySqlConnection AbrirConexionSql()
        {
            try
            {
                using (MySqlConnection MiConexion = new MySqlConnection(MysqlString))
                {
                    if(MiConexion.State == System.Data.ConnectionState.Open)
                    {
                        return MiConexion;
                    }
                    else
                    {
                        MiConexion.Open();
                        return MiConexion;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
