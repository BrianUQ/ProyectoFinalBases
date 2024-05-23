using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProyectoFinalBases.Conexion
{
    internal class UsuarioConsultas
    {
        private ConexionMysql conexionMysql;


        public UsuarioConsultas()
        {
            conexionMysql = new ConexionMysql();
        }

        public int verificarUsuario(string login, string clave)
        {
            int rol = 0;
            string QUERY = "SELECT tipoUsuario FROM usuario WHERE login = @login AND clave = @clave;";
            try
            {
                MySqlConnection connection = conexionMysql.GetConnection();
                using (MySqlCommand mCommand = new MySqlCommand(QUERY, connection))
                {
                    mCommand.Parameters.AddWithValue("@login", login);
                    mCommand.Parameters.AddWithValue("@clave", clave);

                    var result = mCommand.ExecuteScalar();
                    if (result != null)
                    {
                        rol = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return rol;
        } 
    }
}
