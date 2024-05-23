using ProyectoFinalBases.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class DepartamentoConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Departamento> departamentos;

        public DepartamentoConsultas()
        {
            conexionMysql = new ConexionMysql();
            departamentos = new List<Departamento>();
        }
        public List<Departamento> GetDepartamentos(string filtro)
        {
            string QUERY = "SELECT * FROM departamento ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idDepartamento LIKE '%" + filtro + "%' OR " +
                        "nombreDepartamento LIKE '%" + filtro + "%' OR " +
                        "poblacionDepartamento LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Departamento departamento = null;

                while (mReader.Read())
                {
                    departamento = new Departamento();
                    departamento.idDepartamento = mReader.GetInt16("idDepartamento");
                    departamento.nombreDepartamento = mReader.GetString("nombreDepartamento");
                    departamento.poblacionDepartamento = mReader.GetInt16("poblacionDepartamento");
                    departamentos.Add(departamento);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return departamentos;
        }

        internal bool actualizarDepartamento(Departamento departamento)
        {
            string UPDATE = "UPDATE departamento SET " +
                "idDepartamento = @id, " +
                "nombreDepartamento = @nombre, " +
                "poblacionDepartamento = @poblacion, " +
                "WHERE idDepartamento = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", departamento.idDepartamento));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", departamento.nombreDepartamento));
            mCommand.Parameters.Add(new MySqlParameter("@poblacion", departamento.poblacionDepartamento));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarDepartamento(Departamento departamento)
        {
            string INSERT = "INSERT INTO departamento (idDepartamento, nombreDepartamento, poblacionDepartamento) " +
                "values (@id,@nombre,@poblacion);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", departamento.idDepartamento));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", departamento.nombreDepartamento));
            mCommand.Parameters.Add(new MySqlParameter("@poblacion", departamento.poblacionDepartamento));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarDepartamento(Departamento departamento)
        {
            string DELETE = "DELETE FROM departamento WHERE idDepartamento=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", departamento.idDepartamento));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}
