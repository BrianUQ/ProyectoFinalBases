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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProyectoFinalBases
{
    public partial class CrudDepartamento : Form
    {
        private List<Departamento> departamentos;
        private DepartamentoConsultas departamentoC;
        private Departamento departamento;
        public CrudDepartamento()
        {
            InitializeComponent();
            departamentoC = new DepartamentoConsultas();
            departamentos = new List<Departamento>();
            departamento = new Departamento();
            cargarDapartamentos();
        }

        private void cargarDapartamentos(string filtro = "")
        {
            dataDepartamento.Rows.Clear();
            dataDepartamento.Refresh();
            departamentos.Clear();
            departamentos = departamentoC.GetDepartamentos(filtro);

            for (int i = 0; i < departamentos.Count; i++)
            {
                dataDepartamento.RowTemplate.Height = 50;
                dataDepartamento.Rows.Add(
                    departamentos[i].idDepartamento,
                    departamentos[i].nombreDepartamento,
                    departamentos[i].poblacionDepartamento);

            }
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarDepartamento();

            if (departamentoC.agregarDepartamento(departamento))
            {
                MessageBox.Show("Se agrego con exito");
                cargarDapartamentos();
                limpiarCampos();
            }

        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPoblacion.Text = "";
        }

        private void guardarDepartamento()
        {
            departamento.idDepartamento = int.Parse(txtCodigo.Text.Trim());
            departamento.nombreDepartamento = txtNombre.Text.Trim();
            departamento.poblacionDepartamento = int.Parse(txtPoblacion.Text.Trim());
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
            if (txtPoblacion.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Poblacion");
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
                guardarDepartamento();
                if (departamentoC.eliminarDepartamento(departamento))
                {
                    MessageBox.Show("Se elimino con exito");
                    cargarDapartamentos();
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

            guardarDepartamento();

            if (departamentoC.actualizarDepartamento(departamento))
            {
                MessageBox.Show("Se actualizo con exito");
                cargarDapartamentos();
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

        private void dataDepartamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataDepartamento.Rows[e.RowIndex];
            txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtPoblacion.Text = Convert.ToString(fila.Cells["Poblacion"].Value);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarDapartamentos(txtBusqueda.Text.Trim());
        }
    }
}
