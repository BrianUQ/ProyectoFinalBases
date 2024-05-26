using ProyectoFinalBases.Conexion;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBases
{
    public partial class Login : Form
    {
        private Usuario usuario;
        public int idUsuario;
        public int idBitacora;
        private UsuarioConsultas usuarioC;
        private BitacoraConsulta bitacoraC;
        public Login()
        {
            InitializeComponent();
            usuario = new Usuario();
            usuarioC = new UsuarioConsultas();
            bitacoraC = new BitacoraConsulta(); 
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void button1_Click(object sender, EventArgs e)
        {
            int rol;
            if (!datosCorretos())
            {
                return;
            }

            string login = txtUser.Text;
            string clave = txtClave.Text;

            usuario = usuarioC.verificarUsuario(login, clave);
            idUsuario = usuario.idUsuario;
            rol = usuario.tipoUsuario;

            if (rol != 0)
            {
                abrirVentana(rol);
            }

        }

        private void abrirVentana(int rol)
        {
            idBitacora = bitacoraC.obtenerCodigoMaximo();
            switch (rol)
            {
                case 1:
                    if(idBitacora == 0)
                    {
                        bitacoraC.RegistrarEntrada(100, usuario.idUsuario);
                        idBitacora = 100;
                    }
                    else
                    {
                        bitacoraC.RegistrarEntrada(idBitacora + 1, usuario.idUsuario);
                        idBitacora++;
                    }
                    break;
                default:
                    MessageBox.Show("No se conose el rol");
                    return;

            }
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private bool datosCorretos()
        {
            if (txtUser.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese el usuario");
                return false;
            }
            if (txtClave.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese la clave");
                return false;
            }

            return true;
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btmMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
