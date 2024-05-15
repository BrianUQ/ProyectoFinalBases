using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBases
{
    public partial class CrudEmpleado : Form
    {
        private List<Empleado> empleados;
        private EmpleadoConsultas empleadoC;
        private Empleado empleado;
        public CrudEmpleado()
        {
            InitializeComponent();
            empleadoC = new EmpleadoConsultas();
            empleados = new List<Empleado>();
            empleado = new Empleado();
            cargarEmpleados();
        }

        private void cargarEmpleados(string filtro = "")
        {
            dataEmpleado.Rows.Clear();
            dataEmpleado.Refresh(); 
            empleados.Clear();
            empleados = empleadoC.getEmpleados(filtro);

            for (int i = 0; i < empleados.Count; i++)
            {
                dataEmpleado.RowTemplate.Height = 50;
                dataEmpleado.Rows.Add(
                    empleados[i].idEmpleado,
                    empleados[i].nombreEmpleado,
                    empleados[i].cedulaEmpleado,
                    empleados[i].direccionEmpleado,
                    empleados[i].telefonoEmpleado);

            }
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarEmpleado();

            if (empleadoC.agregarProductos(empleado))
            {
                MessageBox.Show("Se agrego el empleado con exito");
                cargarEmpleados();
                limpiarCampor();
            }
        }

        private void limpiarCampor()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private void guardarEmpleado()
        {
            empleado.idEmpleado = int.Parse(txtCodigo.Text.Trim());
            empleado.nombreEmpleado = txtNombre.Text.Trim();
            empleado.cedulaEmpleado = txtCedula.Text.Trim();
            empleado.direccionEmpleado = txtDireccion.Text.Trim();
            empleado.telefonoEmpleado = txtTelefono.Text.Trim();
        }

        private void btmEliminar_Click(object sender, EventArgs e)
        {

        }

        private void txtBusquedaEmpleado_TextChanged(object sender, EventArgs e)
        {
            cargarEmpleados(txtBusquedaEmpleado.Text.Trim());
        }

        private bool datosCorrectos()
        {
            if (txtCodigo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Codigo");
                return false;
            }
            if (txtNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Nombre");
                return false;
            }
            if (txtCedula.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Cedula");
                return false;
            }
            if (txtDireccion.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Direccion");
                return false;
            }
            if (txtTelefono.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Codigo");
                return false;
            }

            return true;
        }
    }
}
