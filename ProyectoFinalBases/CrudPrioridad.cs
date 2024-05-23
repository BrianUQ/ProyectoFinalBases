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
    public partial class CrudPrioridad : Form
    {
        private List<Prioridad> prioridades;
        private PrioridadConsultas prioridadC;
        private Prioridad prioridad;
        public CrudPrioridad()
        {
            InitializeComponent();
            prioridadC = new PrioridadConsultas();
            prioridades = new List<Prioridad>();
            prioridad = new Prioridad();
            cargarPrioridades();
        }

        private void cargarPrioridades(string filtro="")
        {
            dataPrioridad.Rows.Clear();
            dataPrioridad.Refresh();
            prioridades.Clear();
            prioridades = prioridadC.GetPrioridad(filtro);

            for (int i = 0; i < prioridades.Count; i++)
            {
                dataPrioridad.RowTemplate.Height = 50;
                dataPrioridad.Rows.Add(
                    prioridades[i].idPrioridad,
                    prioridades[i].nombrePrioridad,
                    prioridades[i].descripcionPrioridad);

            }
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarPrioridad();

            if (prioridadC.agregarPrioridad(prioridad))
            {
                MessageBox.Show("Se agrego con exito");
                cargarPrioridades();
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        private void guardarPrioridad()
        {
            prioridad.idPrioridad = int.Parse(txtCodigo.Text.Trim());
            prioridad.nombrePrioridad = txtNombre.Text.Trim();
            prioridad.descripcionPrioridad = txtDescripcion.Text.Trim();
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
            if (txtDescripcion.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Descripcion");
                return false;
            }

            return true;
        }

        private void btmEliminar_Click(object sender, EventArgs e)
        {
            if (idVacio() == -1)
            {
                return;
            }

            if (MessageBox.Show("Desea eliminar el seleccionado?", "Eliminar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                guardarPrioridad();
                if (prioridadC.eliminarPrioridad(prioridad))
                {
                    MessageBox.Show("Se elimino con exito");
                    cargarPrioridades();
                    limpiarCampos();
                }
            }
        }

        private int idVacio()
        {
            if (!txtCodigo.Text.Trim().Equals(""))
            {
                if (int.TryParse(txtCodigo.Text.Trim(), out int id))
                {
                    return id;
                }
                else return -1;
            }
            else return -1;
        }

        private void btmActualizar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarPrioridad();

            if (prioridadC.actualizarPrioridad(prioridad))
            {
                MessageBox.Show("Se actualizo con exito");
                cargarPrioridades();
                limpiarCampos();
            }
        }

        private void btmLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarPrioridades(txtBusqueda.Text.Trim());    
        }

        private void dataPrioridad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataPrioridad.Rows[e.RowIndex];
            txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtDescripcion.Text = Convert.ToString(fila.Cells["Descripcion"].Value);
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
