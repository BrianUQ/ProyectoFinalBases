using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class ContratoConsulta
    {
        private ConexionMysql conexionMysql;
        private List<Contrato> contratos;

        public ContratoConsulta()
        {
            conexionMysql = new ConexionMysql();
            contratos = new List<Contrato>();
        }
        public List<Contrato> GetContratos(string filtro)
        {
            string QUERY = "SELECT * FROM contrato ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idContrato LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Contrato contrato = null;

                while (mReader.Read())
                {
                    contrato = new Contrato();
                    contrato.idContrato = mReader.GetInt16("idContrato");
                    contrato.fechaInicio = mReader.GetDateTime("fechaInicio");
                    contrato.fechaFinal = mReader.GetDateTime("fechaFinal");
                    contrato.cargoContrato = mReader.GetInt16("cargoContrato");
                    contrato.sucursalContrato = mReader.GetInt16("sucursalContrato");
                    contrato.empleadoContrato = mReader.GetInt16("empleadoContrato");
                    contratos.Add(contrato);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return contratos;
        }

        internal bool actualizarContrato(Contrato contrato)
        {
            string UPDATE = "UPDATE contrato SET " +
                "idContrato = @id, " +
                "fechaInicio = @inicio, " +
                "fechaFinal = @final;, " +
                "contratoCargo = @cargo, " +
                "contratoSucursal = @sucursal, " +
                "contratoEmpleado = @empleado " +
                "WHERE idContrato = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", contrato.idContrato));
            mCommand.Parameters.Add(new MySqlParameter("@inicio", contrato.fechaInicio));
            mCommand.Parameters.Add(new MySqlParameter("@final", contrato.fechaFinal));
            mCommand.Parameters.Add(new MySqlParameter("@cargo", contrato.cargoContrato));
            mCommand.Parameters.Add(new MySqlParameter("@sucursal", contrato.sucursalContrato));
            mCommand.Parameters.Add(new MySqlParameter("@empleado", contrato.empleadoContrato));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarContrato(Contrato contrato)
        {
            string INSERT = "INSERT INTO contrato (idContrato, fechaInicio, fechaFinal, cargoContrato, sucursalContrato, empleadoContrato) " +
                "values (@id,@inicio,@final,@cargo,@sucursal,@empleado);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", contrato.idContrato));
            mCommand.Parameters.Add(new MySqlParameter("@inicio", contrato.fechaInicio));
            mCommand.Parameters.Add(new MySqlParameter("@final", contrato.fechaFinal));
            mCommand.Parameters.Add(new MySqlParameter("@cargo", contrato.cargoContrato));
            mCommand.Parameters.Add(new MySqlParameter("@sucursal", contrato.sucursalContrato));
            mCommand.Parameters.Add(new MySqlParameter("@empleado", contrato.empleadoContrato));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarContrato(Contrato contrato)
        {
            string DELETE = "DELETE FROM contrato WHERE idContrato=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", contrato.idContrato));

            return mCommand.ExecuteNonQuery() > 0;
        }

        public Contrato GetContrato(int id)
        {
            MySqlDataReader mReader = null;
            Contrato contrato = new Contrato();
            try
            {
                string QUERY = "SELECT * FROM contrato WHERE idContrato=@id;";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                mCommand.Parameters.Add(new MySqlParameter("@id", id));
                mReader = mCommand.ExecuteReader();
                
                if (mReader.Read())
                {
                    contrato.idContrato = mReader.GetInt16("idContrato");
                    contrato.fechaInicio = mReader.GetDateTime("fechaInicio");
                    contrato.fechaFinal = mReader.GetDateTime("fechaFinal");
                    contrato.cargoContrato = mReader.GetInt16("cargoContrato");
                    contrato.sucursalContrato = mReader.GetInt16("sucursalContrato");
                    contrato.empleadoContrato = mReader.GetInt16("empleadoContrato");

                }
                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }
            return contrato;
        }
    }
}
