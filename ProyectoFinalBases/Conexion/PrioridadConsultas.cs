using MySql.Data.MySqlClient;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class PrioridadConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Prioridad> prioridades;

        public PrioridadConsultas()
        {
            conexionMysql = new ConexionMysql();
            prioridades = new List<Prioridad>();
        }
        public List<Prioridad> GetPrioridad(string filtro)
        {
            string QUERY = "SELECT * FROM prioridad ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idPrioridad LIKE '%" + filtro + "%' OR " +
                        "nombrePrioridad LIKE '%" + filtro + "%' OR " +
                        "descripcionPrioridad LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Prioridad prioridad = null;

                while (mReader.Read())
                {
                    prioridad = new Prioridad();
                    prioridad.idPrioridad = mReader.GetInt16("idPrioridad");
                    prioridad.nombrePrioridad = mReader.GetString("nombrePrioridad");
                    prioridad.descripcionPrioridad = mReader.GetString("descripcionPrioridad");
                    prioridades.Add(prioridad);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return prioridades;
        }

        internal bool actualizarPrioridad(Prioridad prioridad)
        {
            string UPDATE = "UPDATE prioridad SET " +
                "idPrioridad = @id, " +
                "nombrePrioridad = @nombre, " +
                "descripcionPrioridad = @descripcion " +
                "WHERE idPrioridad = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", prioridad.idPrioridad));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", prioridad.nombrePrioridad));
            mCommand.Parameters.Add(new MySqlParameter("@descripcion", prioridad.descripcionPrioridad));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarPrioridad(Prioridad prioridad)
        {
            string INSERT = "INSERT INTO prioridad (idPrioridad, nombrePrioridad, descripcionPrioridad) " +
                "values (@id,@nombre,@descripcion);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", prioridad.idPrioridad));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", prioridad.nombrePrioridad));
            mCommand.Parameters.Add(new MySqlParameter("@descripcion", prioridad.descripcionPrioridad));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarPrioridad(Prioridad prioridad)
        {
            string DELETE = "DELETE FROM prioridad WHERE idPrioridad=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", prioridad.idPrioridad));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}
