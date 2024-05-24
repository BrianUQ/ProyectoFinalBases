using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class MunicipioConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Municipio> municipios;

        public MunicipioConsultas()
        {
            conexionMysql = new ConexionMysql();
            municipios = new List<Municipio>();
        }
        public List<Municipio> GetMunicipio(string filtro)
        {
            string QUERY = "SELECT * FROM municipio ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idMunicipio LIKE '%" + filtro + "%' OR " +
                        "nombreMunicipio LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Municipio municipio = null;

                while (mReader.Read())
                {
                    municipio = new Municipio();
                    municipio.idMunicipio = mReader.GetInt16("idMunicipio");
                    municipio.nombreMunicipio = mReader.GetString("nombreMunicipio");
                    municipio.poblacionMunicipio = mReader.GetInt16("poblacionMunicipio");
                    municipio.departamentoMunicipio = mReader.GetInt16("departamentoMunicipio");
                    municipio.prioridadMunicipio = mReader.GetInt16("prioridadMunicipio");
                    municipios.Add(municipio);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return municipios;
        }

        internal bool actualizarMunicipio(Municipio municipio)
        {
            string UPDATE = "UPDATE municipio SET " +
                "idMunicipio = @id, " +
                "nombreMunicipio = @nombre, " +
                "poblacionMunicipio = @poblacion, " +
                "departamentoMunicipio = @departamento, " +
                "prioridadMunicipio = @prioridad " +
                "WHERE idMunicipio = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", municipio.idMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", municipio.nombreMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@poblacion", municipio.poblacionMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@departamento", municipio.departamentoMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@prioridad", municipio.prioridadMunicipio));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarMunicipio(Municipio municipio)
        {
            string INSERT = "INSERT INTO municipio (idMunicipio, nombreMunicipio, poblacionMunicipio, departamentoMunicipio, prioridadMunicipio) " +
                "values (@id,@nombre,@poblacion, @departamento, @prioridad);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", municipio.idMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", municipio.nombreMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@poblacion", municipio.poblacionMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@departamento", municipio.departamentoMunicipio));
            mCommand.Parameters.Add(new MySqlParameter("@prioridad", municipio.prioridadMunicipio));


            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarMunicipio(Municipio municipio)
        {
            string DELETE = "DELETE FROM municipio WHERE idMunicipio=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", municipio.idMunicipio));

            return mCommand.ExecuteNonQuery() > 0;
        }

        public List<Municipio> GetMunicipioDepatamento(int idDepartamento)
        {
            
            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT * FROM municipio WHERE departamentoMunicipio = @id";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                mCommand.Parameters.Add(new MySqlParameter("@id", idDepartamento));
                mReader = mCommand.ExecuteReader();

                Municipio municipio = null;

                while (mReader.Read())
                {
                    municipio = new Municipio();
                    municipio.idMunicipio = mReader.GetInt16("idMunicipio");
                    municipio.nombreMunicipio = mReader.GetString("nombreMunicipio");
                    municipio.poblacionMunicipio = mReader.GetInt16("poblacionMunicipio");
                    municipio.departamentoMunicipio = mReader.GetInt16("departamentoMunicipio");
                    municipio.prioridadMunicipio = mReader.GetInt16("prioridadMunicipio");
                    municipios.Add(municipio);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return municipios;
        }

        public int GetDepartamento(int id)
        {
            int idDepartamento = -1;
            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT departamentoMunicipio FROM municipio WHERE idMunicipio = @id";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                mCommand.Parameters.Add(new MySqlParameter("@id", id));
                mReader = mCommand.ExecuteReader();

                if(mReader.Read()) {
                    idDepartamento = mReader.GetInt16("departamentoMunicipio");
                }
                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return idDepartamento;
        }
    }
}
