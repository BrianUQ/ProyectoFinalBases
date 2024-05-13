using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBases
{
    internal class ConexionMysql : Conexion

    {
        private MySqlConnection connection;
        private string cadenaConexion;

        public ConexionMysql()
        {
            cadenaConexion = "Database=" + database +
                "; DataSource=" + server +
                "; User id= " + user +
                "; Password" + password;

            connection = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                if(connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch(System.Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return connection;
        }
    }
}
