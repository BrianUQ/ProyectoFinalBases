using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases
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
    }
}
