﻿using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProyectoFinalBases.Conexion
{
    internal class UsuarioConsultas
    {
        private ConexionMysql conexionMysql;
        private List<Usuario> usuarios;

        public UsuarioConsultas()
        {
            conexionMysql = new ConexionMysql();
            usuarios = new List<Usuario>();
        }

        public Usuario verificarUsuario(string login, string clave)
        {
            Usuario usuario = new Usuario();
            MySqlDataReader mReader = null;
            try
            {
                MySqlConnection connection = conexionMysql.GetConnection();
                string QUERY = "SELECT * FROM usuario WHERE login = @login AND clave = @clave;";
                MySqlCommand mCommand = new MySqlCommand(QUERY, conexionMysql.GetConnection());

                mCommand.Parameters.Add(new MySqlParameter("@login", login));
                mCommand.Parameters.Add(new MySqlParameter("@clave", clave));
                mReader = mCommand.ExecuteReader();

                if (mReader.Read())
                {
                    usuario.idUsuario = mReader.GetInt32("idUsuario");
                    usuario.login = mReader.GetString("login");
                    usuario.clave = mReader.GetString("clave");
                    usuario.tipoUsuario = mReader.GetInt16("tipoUsuario");
                }
                mReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return usuario;
        }

        public List<Usuario> GetUsuario(string filtro)
        {
            string QUERY = "SELECT * FROM usuario ";
            MySqlDataReader mReader = null;
            try
            {
                if (filtro != "")
                {
                    QUERY += "WHERE " +
                        "idUsuario LIKE '%" + filtro + "%' OR " +
                        "login LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Usuario usuario = null;

                while (mReader.Read())
                {
                    usuario = new Usuario();
                    usuario.idUsuario = mReader.GetInt16("idUsuario");
                    usuario.login = mReader.GetString("login");
                    usuario.clave = mReader.GetString("clave");
                    usuario.tipoUsuario = mReader.GetInt16("tipoUsuario");
                    usuarios.Add(usuario);
                }
                mReader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        internal bool actualizarUsuario(Usuario usuario)
        {
            string UPDATE = "UPDATE usuario SET " +
                "idUsuario = @id, " +
                "login = @nombre, " +
                "clave = @clave, " +
                "tipoUsuario = @tipo " +
                "WHERE idUsuario = @id;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", usuario.idUsuario));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", usuario.login));
            mCommand.Parameters.Add(new MySqlParameter("@clave", usuario.clave));
            mCommand.Parameters.Add(new MySqlParameter("@tipo", usuario.tipoUsuario));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool agregarUsuario(Usuario usuario)
        {
            string INSERT = "INSERT INTO usuario (idUsuario, login, clave, tipoUsuario) " +
                "values (@id,@nombre,@clave, @tipo);";
            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", usuario.idUsuario));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", usuario.login));
            mCommand.Parameters.Add(new MySqlParameter("@clave", usuario.clave));
            mCommand.Parameters.Add(new MySqlParameter("@tipo", usuario.tipoUsuario));


            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarUsuario(Usuario usuario)
        {
            string DELETE = "DELETE FROM usuario WHERE idUsuario=@id;";
            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@id", usuario.idUsuario));

            return mCommand.ExecuteNonQuery() > 0;
        }

        
    }
}
