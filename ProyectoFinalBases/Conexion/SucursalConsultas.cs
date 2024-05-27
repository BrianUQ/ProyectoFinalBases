using MySql.Data.MySqlClient;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class SucursalConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Sucursal> sucursales;
        private List<ConsultaP1> consultasP1;
        private List<ConsultaE2> consultasE2;
        public SucursalConsultas()
        {
            conexionMysql = new ConexionMysql();
            sucursales = new List<Sucursal>();
            consultasP1 = new List<ConsultaP1>();
            consultasE2 = new List<ConsultaE2>();
        }
        public List<Sucursal> GetSucursal(string filtro)
        {
            string QUERY = "SELECT * FROM sucursal ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idSucursal LIKE '%" + filtro + "%' OR " +
                        "nombreSucursal LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Sucursal sucursal = null;

                while (mReader.Read())
                {
                    sucursal = new Sucursal();
                    sucursal.idSucursal = mReader.GetInt16("idSucursal");
                    sucursal.nombreSucursal = mReader.GetString("nombreSucursal");
                    sucursal.direccionSucursal = mReader.GetString("direccionSucursal");
                    sucursal.presupuestoAnual = mReader.GetFloat("presupuestoAnual");
                    sucursal.ubicacionSucrusal = mReader.GetInt16("ubicacionSucursal");
                    sucursales.Add(sucursal);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return sucursales;
        }

        internal bool actualizarSucursal(Sucursal sucursal)
        {
            string UPDATE = "UPDATE sucursal SET " +
                "idSucursal = @id, " +
                "nombreSucursal = @nombre, " +
                "direccionSucursal = @direccion, " +
                "presupuestoAnual = @presupuesto, " +
                "ubicacionSucursal = @ubicacion " +
                "WHERE idSucursal = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", sucursal.idSucursal));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", sucursal.nombreSucursal));
            mCommand.Parameters.Add(new MySqlParameter("@direccion", sucursal.direccionSucursal));
            mCommand.Parameters.Add(new MySqlParameter("@presupuesto", sucursal.presupuestoAnual));
            mCommand.Parameters.Add(new MySqlParameter("@ubicacion", sucursal.ubicacionSucrusal));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarSucursal(Sucursal sucursal)
        {
            string INSERT = "INSERT INTO sucursal (idSucursal, nombreSucursal, direccionSucursal, presupuestoAnual, ubicacionSucursal) " +
                "values (@id,@nombre,@direccion, @presupuesto, @ubicacion);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", sucursal.idSucursal));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", sucursal.nombreSucursal));
            mCommand.Parameters.Add(new MySqlParameter("@direccion", sucursal.direccionSucursal));
            mCommand.Parameters.Add(new MySqlParameter("@presupuesto", sucursal.presupuestoAnual));
            mCommand.Parameters.Add(new MySqlParameter("@ubicacion", sucursal.ubicacionSucrusal));


            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarSucursal(Sucursal sucursal)
        {
            string DELETE = "DELETE FROM sucursal WHERE idSucursal=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", sucursal.idSucursal));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal int GetMunicipio(int id)
        {
            int idDepartamento = -1;
            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT ubicacionSucursal FROM sucursal WHERE idSucursal = @id";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                mCommand.Parameters.Add(new MySqlParameter("@id", id));
                mReader = mCommand.ExecuteReader();

                if (mReader.Read())
                {
                    idDepartamento = mReader.GetInt16("ubicacionSucursal");
                }
                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return idDepartamento;
        }

        public List<Sucursal> GetSucursalMunicipio(int idMunicipio)
        {

            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT * FROM sucursal WHERE ubicacionSucursal = @id";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                mCommand.Parameters.Add(new MySqlParameter("@id", idMunicipio));
                mReader = mCommand.ExecuteReader();

                Sucursal sucursal = null;

                while (mReader.Read())
                {
                    sucursal = new Sucursal();
                    sucursal.idSucursal = mReader.GetInt16("idSucursal");
                    sucursal.nombreSucursal = mReader.GetString("nombreSucursal");
                    sucursal.direccionSucursal = mReader.GetString("direccionSucursal");
                    sucursal.presupuestoAnual = mReader.GetFloat("presupuestoAnual");
                    sucursal.ubicacionSucrusal = mReader.GetInt16("ubicacionSucursal");
                    sucursales.Add(sucursal);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return sucursales;
        }

        public List<ConsultaP1> GetSucursalDepartamento(int idMunicipio)
        {

            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT s.nombreSucursal AS Sucursal, s.direccionSucursal AS Direccion, m.nombreMunicipio AS Municipio, d.nombreDepartamento AS Deparatamento " +
                    "FROM sucursal s " +
                    "JOIN municipio m ON s.ubicacionSucursal = m.idMunicipio " +
                    "JOIN departamento d ON m.departamentoMunicipio = d.idDepartamento " +
                    "WHERE d.idDepartamento = @id";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                mCommand.Parameters.Add(new MySqlParameter("@id", idMunicipio));
                mReader = mCommand.ExecuteReader();

                ConsultaP1 consultaP1 = null;

                while (mReader.Read())
                {
                    consultaP1 = new ConsultaP1();
                    consultaP1.Sucursal = mReader.GetString("Sucursal");
                    consultaP1.Direccion = mReader.GetString("Direccion");
                    consultaP1.Municipio = mReader.GetString("Municipio");
                    consultaP1.Departamento = mReader.GetString("Deparatamento");
                    consultasP1.Add(consultaP1);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return consultasP1;
        }

        public List<ConsultaE2> GetSucursalEmpleados()
        {

            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT s.nombreSucursal, COUNT(DISTINCT e.idEmpleado) AS Empleados " +
                    "FROM sucursal s " +
                    "JOIN contrato c ON s.idSucursal = c.sucursalContrato " +
                    "JOIN empleado e ON c.empleadoContrato = e.idEmpleado " +
                    "GROUP BY s.nombreSucursal";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());
                mReader = mCommand.ExecuteReader();

                ConsultaE2 consulta = null;

                while (mReader.Read())
                {
                    consulta = new ConsultaE2();
                    consulta.Sucursal = mReader.GetString("nombreSucursal");
                    consulta.CantidadEmpleados = mReader.GetInt16("Empleados");
                    consultasE2.Add(consulta);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return consultasE2;
        }


    }

    public class ConsultaP1
    {
        public string Sucursal;
        public string Direccion;
        public string Municipio;
        public string Departamento;
    }

    public class ConsultaE2
    {
        public string Sucursal;
        public int CantidadEmpleados;
    }
}
