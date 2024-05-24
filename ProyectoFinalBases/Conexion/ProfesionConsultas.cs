using MySql.Data.MySqlClient;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class ProfesionConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Profesion> profesiones;

        public ProfesionConsultas()
        {
            conexionMysql = new ConexionMysql();
            profesiones = new List<Profesion>();
        }
        public List<Profesion> GetProfesion(string filtro)
        {
            string QUERY = "SELECT * FROM profesion ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idProfesion LIKE '%" + filtro + "%' OR " +
                        "nombreProfesion LIKE '%" + filtro + "%' OR " +
                        "descripcionProfesion LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Profesion profesion = null;

                while (mReader.Read())
                {
                    profesion = new Profesion();
                    profesion.idProfesion = mReader.GetInt16("idProfesion");
                    profesion.nombreProfesion = mReader.GetString("nombreProfesion");
                    profesion.descripcionProfesion = mReader.GetString("descripcionProfesion");
                    profesiones.Add(profesion);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return profesiones;
        }

        internal bool actualizarProfesion(Profesion profesion)
        {
            string UPDATE = "UPDATE profesion SET " +
                "idProfesion = @id, " +
                "nombreProfesion = @nombre, " +
                "descripcionProfesion = @descripcion " +
                "WHERE idProfesion = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", profesion.idProfesion));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", profesion.nombreProfesion));
            mCommand.Parameters.Add(new MySqlParameter("@descripcion", profesion.descripcionProfesion));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarProfesion(Profesion profesion)
        {
            string INSERT = "INSERT INTO profesion (idProfesion, nombreProfesion, descripcionProfesion) " +
                "values (@id,@nombre,@descripcion);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", profesion.idProfesion));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", profesion.nombreProfesion));
            mCommand.Parameters.Add(new MySqlParameter("@descripcion", profesion.descripcionProfesion));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarProfesion(Profesion profesion)
        {
            string DELETE = "DELETE FROM profesion WHERE idProfesion=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", profesion.idProfesion));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}
