
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProyectoFinalBases.Conexion
{
    internal class ConexionMysql : Conexion

    {
        private MySqlConnection connection;
        private string cadenaConexion;

        public ConexionMysql()
        {
            cadenaConexion = "server=localhost;port=3306;database=banco;uid=root;password=;";

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
