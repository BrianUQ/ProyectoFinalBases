using ProyectoFinalBases.Conexion;
using ProyectoFinalBases.Entidades;
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

            if (empleadoC.agregarEmpleado(empleado))
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
            if(idVacio() == -1)
            {
                return;
            }

            if(MessageBox.Show("Desea eliminar el producto?", "Eliminar producto",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                guardarEmpleado();
                if (empleadoC.eliminarEmpleado(empleado))
                {
                    MessageBox.Show("Se elimino el empleado con exito");
                    cargarEmpleados();
                    limpiarCampor();
                }
            }
        }

        private int idVacio()
        {
            if (!txtCodigo.Text.Trim().Equals(""))
            {
                if(int.TryParse(txtCodigo.Text.Trim(), out int id))
                {
                    return id;  
                }
                else return -1;
            }
            else return -1;
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

 

        private void btmActualizar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarEmpleado();

            if (empleadoC.actualizarEmpleado(empleado))
            {
                MessageBox.Show("Se actualizo el empleado con exito");
                cargarEmpleados();
                limpiarCampor();
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampor();
        }

        private void dataEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataEmpleado.Rows[e.RowIndex];
            txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtCedula.Text = Convert.ToString(fila.Cells["Cedula"].Value);
            txtDireccion.Text = Convert.ToString(fila.Cells["Direccion"].Value);
            txtTelefono.Text = Convert.ToString(fila.Cells["Telefono"].Value);
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
