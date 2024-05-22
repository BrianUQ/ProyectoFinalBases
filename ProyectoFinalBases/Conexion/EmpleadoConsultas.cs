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

        public EmpleadoConsultas()
        {
            conexionMysql = new ConexionMysql();
            empleados = new List<Empleado>();
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
    }
}
