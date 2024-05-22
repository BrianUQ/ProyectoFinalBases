using ProyectoFinalBases.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class CargoConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Cargo> cargos;

        public CargoConsultas()
        {
            conexionMysql = new ConexionMysql();
            cargos = new List<Cargo>();
        }
        public List<Cargo> getCargos(string filtro)
        {
            string QUERY = "SELECT * FROM cargo ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idCargo LIKE '%" + filtro + "%' OR " +
                        "nombreCargo LIKE '%" + filtro + "%' OR " +
                        "salarioCargo LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Cargo cargo = null;

                while (mReader.Read())
                {
                    cargo = new Cargo();
                    cargo.idCargo = mReader.GetInt16("idCargo");
                    cargo.nombreCargo = mReader.GetString("nombreCargo");
                    cargo.salarioCargo = mReader.GetFloat("salarioCargo");
                    cargos.Add(cargo);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return cargos;
        }

        internal bool actualizarCargo(Cargo cargo)
        {
            string UPDATE = "UPDATE empleado SET " +
                "idCargo = @id, " +
                "nombreCargo = @nombre, " +
                "salarioCargo = @salario, " +
                "WHERE idEmpleado = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", cargo.idCargo));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", cargo.nombreCargo));
            mCommand.Parameters.Add(new MySqlParameter("@salario", cargo.salarioCargo));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarCargo(Cargo cargo)
        {
            string INSERT = "INSERT INTO cargo (idCargo, nombreCargo, salarioCargo) " +
                "values (@id,@nombre,@salario);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", cargo.idCargo));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", cargo.nombreCargo));
            mCommand.Parameters.Add(new MySqlParameter("@salario", cargo.salarioCargo));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarCargo(Cargo cargo)
        {
            string DELETE = "DELETE FROM cargo WHERE idCargo=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@id", cargo.idCargo));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}
