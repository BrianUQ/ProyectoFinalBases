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
    public partial class CrudProfesion : Form
    {
        private List<Profesion> profesiones;
        private ProfesionConsultas profesionC;
        private Profesion profesion;
        public CrudProfesion()
        {
            InitializeComponent();
            profesionC = new ProfesionConsultas();
            profesiones = new List<Profesion>();
            profesion = new Profesion();
            cargarProfesiones();
        }

        private void cargarProfesiones(string filtro="")
        {
            dataProfesion.Rows.Clear();
            dataProfesion.Refresh();
            profesiones.Clear();
            profesiones = profesionC.GetProfesion(filtro);

            for (int i = 0; i < profesiones.Count; i++)
            {
                dataProfesion.RowTemplate.Height = 50;
                dataProfesion.Rows.Add(
                    profesiones[i].idProfesion,
                    profesiones[i].nombreProfesion,
                    profesiones[i].descripcionProfesion);

            }
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarProfesion();

            if (profesionC.agregarProfesion(profesion))
            {
                MessageBox.Show("Se agrego con exito");
                cargarProfesiones();
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        private void guardarProfesion()
        {
            profesion.idProfesion = int.Parse(txtCodigo.Text.Trim());
            profesion.nombreProfesion = txtNombre.Text.Trim();
            profesion.descripcionProfesion = txtDescripcion.Text.Trim();
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
                guardarProfesion();
                if (profesionC.eliminarProfesion(profesion))
                {
                    MessageBox.Show("Se elimino con exito");
                    cargarProfesiones();
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

            guardarProfesion();

            if (profesionC.actualizarProfesion(profesion))
            {
                MessageBox.Show("Se actualizo con exito");
                cargarProfesiones();
                limpiarCampos();
            }
        }

        private void btmLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarProfesiones(txtBusqueda.Text.Trim());
        }

        private void dataProfesion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataProfesion.Rows[e.RowIndex];
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
