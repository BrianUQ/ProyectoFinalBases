using MySql.Data.MySqlClient;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class BitacoraConsulta
    {
        private ConexionMysql conexionMysql;
        private List<Bitacora> bitacoras;
        public BitacoraConsulta() {
            conexionMysql = new ConexionMysql();
            bitacoras = new List<Bitacora>();
        }

        public int obtenerCodigoMaximo()
        {
            int codigoMaximo = 0;
            
            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT MAX(idBitacora) From Bitacora;";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                object result = mCommand.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    codigoMaximo = Convert.ToInt32(result);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return codigoMaximo;
        }

        internal bool RegistrarEntrada(int idBitacora, int idUsuario)
        {
            string INSERT = "INSERT INTO bitacora (idBitacora, fechaEntrada, usuarioBitacora) " +
                "values (@id,@entrada, @usuario);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", idBitacora));
            mCommand.Parameters.Add(new MySqlParameter("@entrada", DateTime.Now));
            mCommand.Parameters.Add(new MySqlParameter("@usuario", idUsuario));


            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool RegistrarSalida(int idBitacora)
        {
            string UPDATE = "UPDATE bitacora SET fechaSalidad = @salida WHERE idBitacora = @id";
            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", idBitacora));
            mCommand.Parameters.Add(new MySqlParameter("@salida", DateTime.Now));


            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}
