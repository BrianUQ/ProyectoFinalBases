using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ProyectoFinalBases.Conexion;

namespace ProyectoFinalBases
{
    public partial class Form1 : Form
    {
        private BitacoraConsulta bitacoraC;
        int bitacora;
        public Form1(int codigoBitacora)
        {
            //prueba
            InitializeComponent();
            bitacoraC = new BitacoraConsulta();
            bitacora = codigoBitacora;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            bitacoraC.RegistrarSalida(bitacora);
            Application.Exit();
        }

        private void btmMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btmMaximizar.Visible = false;
            btmRestaurar.Visible = true;
        }

        private void btmMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btmRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btmMaximizar.Visible = true;
            btmRestaurar.Visible = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btmEntidades_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = true;
            subMenuAyudas.Visible = false;
            subMenuReporte.Visible = false;
            subMenuTransaccion.Visible = false;
            subMenuUtilidades.Visible = false;
        }

        private void btmDepartamento_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            CrudDepartamento crud = new CrudDepartamento();
            abrirFormularioHija(crud);
        }

        private void btmTMunicipio_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            CrudPrioridad crud = new CrudPrioridad();
            abrirFormularioHija(crud);
        }

        private void btmMunicipio_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            CrudMunicipio crud = new CrudMunicipio();
            abrirFormularioHija(crud);
        }

        private void btmSucursales_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            CrudSucursal crud = new CrudSucursal();
            abrirFormularioHija(crud);
        }

        private void btmCargo_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            CrudCargo crud = new CrudCargo();
            abrirFormularioHija(crud);
        }

        private void btmProfesiones_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            CrudProfesion crud = new CrudProfesion();
            abrirFormularioHija(crud);
        }

        private void btmEmpleados_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            CrudEmpleado crud = new CrudEmpleado();
            abrirFormularioHija(crud);
        }

        private void btmTransacciones_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            subMenuAyudas.Visible = false;
            subMenuReporte.Visible = false;
            subMenuTransaccion.Visible = true;
            subMenuUtilidades.Visible = false;
        }

        private void btmContratos_Click(object sender, EventArgs e)
        {
            subMenuTransaccion.Visible = false;
            ListaContrato lista = new ListaContrato();
            abrirFormularioHija(lista);
        }

        private void btmAyuda_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            subMenuAyudas.Visible = true;
            subMenuReporte.Visible = false;
            subMenuTransaccion.Visible = false;
            subMenuUtilidades.Visible = false;
        }

        private void btmAyudasApp_Click(object sender, EventArgs e)
        {
            subMenuAyudas.Visible=false;
        }

        private void btmAcercaDe_Click(object sender, EventArgs e)
        {
            subMenuAyudas.Visible = false;
        }

        private void btmUtilidades_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            subMenuAyudas.Visible = false;
            subMenuReporte.Visible = false;
            subMenuTransaccion.Visible = false;
            subMenuUtilidades.Visible = true;
        }

        private void btmUsuarios_Click(object sender, EventArgs e)
        {
            subMenuUtilidades.Visible = false;
            CrudUsuario crud = new CrudUsuario();
            abrirFormularioHija(crud);
        }

        private void btmBitacora_Click(object sender, EventArgs e)
        {
            subMenuUtilidades.Visible = false;
        }

        private void btmCalculadora_Click(object sender, EventArgs e)
        {
            subMenuUtilidades.Visible = false;
        }

        private void btmFecha_Click(object sender, EventArgs e)
        {
            subMenuUtilidades.Visible = false;
        }

        private void btmReportes_Click(object sender, EventArgs e)
        {
            subMenuEntidades.Visible = false;
            subMenuAyudas.Visible = false;
            subMenuReporte.Visible = true;
            subMenuTransaccion.Visible = false;
            subMenuUtilidades.Visible = false;
        }

        private void btmListarSucursales_Click(object sender, EventArgs e)
        {
            subMenuReporte.Visible = false;
        }

        private void btmInformeEmpleados_Click(object sender, EventArgs e)
        {
            subMenuReporte.Visible = false;
        }

        private void abrirFormularioHija(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {

                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formhija as Form;
            if(fh != null)
            {
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(fh);
                this.panelContenedor.Tag = fh;
                fh.Show();
            }
            
        }
    }
}
