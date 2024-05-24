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

        public SucursalConsultas()
        {
            conexionMysql = new ConexionMysql();
            sucursales = new List<Sucursal>();
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
    }
}
