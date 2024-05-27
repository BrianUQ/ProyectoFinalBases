using MySql.Data.MySqlClient;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Conexion
{
    internal class EmpleadoConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Empleado> empleados;
        private List<ConsultaA1> consultasA1;
        private ConsultaE1 consultaE1;

        public EmpleadoConsultas()
        {
            conexionMysql = new ConexionMysql();
            empleados = new List<Empleado>();
            consultasA1 = new List<ConsultaA1>();
            consultaE1 = new ConsultaE1();
        }

        public List<Empleado> getEmpleados(string filtro)
        {
            string QUERY = "SELECT * FROM empleado ";
            MySqlDataReader mReader = null;
            try
            {
                if(filtro != "")
                {
                    QUERY += "WHERE " +
                        "idEmpleado LIKE '%" + filtro + "%' OR " +
                        "nombreEmpleado LIKE '%" + filtro + "%' OR " +
                        "cedulaEmpleado LIKE '%" + filtro + "%' OR " +
                        "direccionEmpleado LIKE '%" + filtro + "%' OR " +
                        "telefonoEmpleado LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Empleado empleado = null;

                while (mReader.Read())
                {
                    empleado = new Empleado();
                    empleado.idEmpleado = mReader.GetInt16("idEmpleado");
                    empleado.nombreEmpleado = mReader.GetString("nombreEmpleado");
                    empleado.cedulaEmpleado = mReader.GetString("cedulaEmpleado");
                    empleado.direccionEmpleado = mReader.GetString("direccionEmpleado");
                    empleado.telefonoEmpleado = mReader.GetString("telefonoEmpleado");
                    empleados.Add(empleado);
                }
                mReader.Close();
            }catch (Exception)
            {
                throw;
            }

            return empleados;
        }

        internal bool actualizarEmpleado(Empleado empleado)
        {
            string UPDATE = "UPDATE empleado SET " +
                "idEmpleado = @codigo, " +
                "nombreEmpleado = @nombre, " +
                "cedulaEmpleado = @cedula, " +
                "direccionEmpleado = @direccion, " +
                "telefonoEmpleado = @telefono " +
                "WHERE idEmpleado = @codigo;";
                
            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@codigo", empleado.idEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", empleado.nombreEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@cedula", empleado.cedulaEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@direccion", empleado.direccionEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@telefono", empleado.telefonoEmpleado));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarEmpleado(Empleado empleado)
        {
            string INSERT = "INSERT INTO empleado (idEmpleado, nombreEmpleado, cedulaEmpleado, direccionEmpleado, telefonoEmpleado) " +
                "values (@codigo,@nombre,@cedula,@direccion,@telefono);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@codigo", empleado.idEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", empleado.nombreEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@cedula", empleado.cedulaEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@direccion", empleado.direccionEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@telefono", empleado.telefonoEmpleado));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarEmpleado(Empleado empleado)
        {
            string DELETE = "DELETE FROM empleado WHERE idEmpleado=@codigo;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@codigo", empleado.idEmpleado));
         
            return mCommand.ExecuteNonQuery() > 0;
        }

        public List<ConsultaA1> GetEmpleadoSueldo()
        {
            MySqlDataReader mReader = null;
            try
            {
                string QUERY = "SELECT e.nombreEmpleado, c.salarioCargo " +
                    "FROM empleado e " +
                    "JOIN contrato co ON e.idEmpleado = co.empleadoContrato " +
                    "JOIN cargo c ON co.cargoContrato = c.idCargo; ";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());
                
                mReader = mCommand.ExecuteReader();

                ConsultaA1 consulta = null;

                while (mReader.Read())
                {
                    consulta = new ConsultaA1();
                    consulta.Empleado = mReader.GetString("nombreEmpleado");
                    consulta.Sueldo = mReader.GetFloat("salarioCargo");
                    consultasA1.Add(consulta);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return consultasA1;
        }

        public ConsultaE1 GetEmpleadoCodigo(int id)
        {
            MySqlDataReader mReader = null;
            ConsultaE1 consulta = null;
            try
            {
                string QUERY = "SELECT s.nombreSucursal, s.direccionSucursal, m.nombreMunicipio " +
                    "FROM empleado e " +
                    "JOIN contrato co ON e.idEmpleado = co.empleadoContrato " +
                    "JOIN sucursal s ON co.sucursalContrato = s.idSucursal " +
                    "JOIN municipio m ON s.ubicacionSucursal = m.idMunicipio " +
                    "WHERE e.idEmpleado = @id";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());
                mCommand.Parameters.Add(new MySqlParameter("@id", id));
                mReader = mCommand.ExecuteReader();

                

                if (mReader.Read())
                {
                    consulta = new ConsultaE1();
                    consulta.Sucursal = mReader.GetString("nombreSucursal");
                    consulta.Direccion = mReader.GetString("direccionSucursal");
                    consulta.Municipio = mReader.GetString("nombreMunicipio");
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return consulta;
        }
    }

    public class ConsultaA1
    {
        public string Empleado;
        public float Sueldo;
    }

    public class ConsultaE1
    {
        public string Sucursal;
        public string Direccion;
        public string Municipio;
    }
}

