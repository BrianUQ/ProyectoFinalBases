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
    public partial class CrudCargo : Form
    {
        private List<Cargo> cargos;
        private CargoConsultas cargoC;
        private Cargo cargo;
        public CrudCargo()
        {
            InitializeComponent();
            cargoC = new CargoConsultas();
            cargos = new List<Cargo>();
            cargo = new Cargo();
            cargarCargos();
        }

        private void cargarCargos(string filtro="")
        {
            dataCargo.Rows.Clear();
            dataCargo.Refresh();
            cargos.Clear();
            cargos = cargoC.getCargos(filtro);

            for (int i = 0; i < cargos.Count; i++)
            {
                dataCargo.RowTemplate.Height = 50;
                dataCargo.Rows.Add(
                    cargos[i].idCargo,
                    cargos[i].nombreCargo,
                    cargos[i].salarioCargo);

            }
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarCargo();

            if (cargoC.agregarCargo(cargo))
            {
                MessageBox.Show("Se agrego el cargo con exito");
                cargarCargos();
                limpiarCampos();
            }
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
            if (txtSalario.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Salario");
                return false;
            }

            return true;
        }

        private void guardarCargo()
        {
            cargo.idCargo = int.Parse(txtCodigo.Text.Trim());
            cargo.nombreCargo = txtNombre.Text.Trim();
            cargo.salarioCargo = float.Parse(txtSalario.Text.Trim());

        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtSalario.Text = "";

        }

        private void btmEliminar_Click(object sender, EventArgs e)
        {
            if (idVacio() == -1)
            {
                return;
            }

            if (MessageBox.Show("Desea eliminar el cargo?", "Eliminar cargo",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                guardarCargo();
                if (cargoC.eliminarCargo(cargo))
                {
                    MessageBox.Show("Se elimino el cargo con exito");
                    cargarCargos();
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

        private void dataCargo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataCargo.Rows[e.RowIndex];
            txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtSalario.Text = Convert.ToString(fila.Cells["Salario"].Value);
        }

        private void btmActualizar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarCargo();

            if (cargoC.actualizarCargo(cargo))
            {
                MessageBox.Show("Se actualizo el cargo con exito");
                cargarCargos();
                limpiarCampos();
            }

        }

        private void btmLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarCargos(txtBusqueda.Text.Trim());
        }
    }
}
