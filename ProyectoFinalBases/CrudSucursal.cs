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
using static ProyectoFinalBases.CrudMunicipio;

namespace ProyectoFinalBases
{
    public partial class CrudSucursal : Form
    {
        private DepartamentoConsultas departamentoC;
        private List<Departamento> departamentos;
        private List<Municipio> municipios;
        private MunicipioConsultas municipioC;
        private Sucursal sucursal;
        private List<Sucursal> sucursales;
        private SucursalConsultas sucursalC;
        public CrudSucursal()
        {
            InitializeComponent();
            departamentoC = new DepartamentoConsultas();
            departamentos = new List<Departamento>();
            municipios = new List<Municipio>();
            municipioC = new MunicipioConsultas();
            sucursal = new Sucursal();
            sucursalC = new SucursalConsultas();
            sucursales = new List<Sucursal>();
            llenarcbDepartamento();
            cargarSucursales();
        }

        private void cargarSucursales(string filtro = "")
        {
            dataSucursal.Rows.Clear();
            dataSucursal.Refresh();
            sucursales.Clear();
            sucursales = sucursalC.GetSucursal(filtro);

            for (int i = 0; i < sucursales.Count; i++)
            {
                dataSucursal.RowTemplate.Height = 50;
                dataSucursal.Rows.Add(
                    sucursales[i].idSucursal,
                    sucursales[i].nombreSucursal,
                    sucursales[i].direccionSucursal,
                    sucursales[i].presupuestoAnual,
                    sucursales[i].ubicacionSucrusal);

            }
        }

        private void llenarcbDepartamento()
        {
            cbDepartamento.Items.Clear();
            cbDepartamento.Refresh();
            departamentos.Clear();
            departamentos = departamentoC.GetDepartamentos("");

            for (int i = 0; i < departamentos.Count; i++)
            {
                int id = departamentos[i].idDepartamento;
                string nombre = departamentos[i].nombreDepartamento;

                cbDepartamento.Items.Add(new CmbDepartamento { Id = id, Name = nombre });
            }
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepartamento.SelectedItem != null)
            {
                CmbDepartamento selectedItem = cbDepartamento.SelectedItem as CmbDepartamento;

                if (selectedItem != null)
                {
                    llenarcbMunicipio();
                    cbMunicipio.Visible = true;
                    labelmunicipio.Visible = true;
                }
            }
        }

        private void llenarcbMunicipio()
        {
            CmbDepartamento selectedItem = cbDepartamento.SelectedItem as CmbDepartamento;
            cbMunicipio.Items.Clear();
            cbMunicipio.Refresh();
            municipios.Clear();
            municipios = municipioC.GetMunicipioDepatamento(selectedItem.Id);

            for (int i = 0; i < municipios.Count; i++)
            {
                int id = municipios[i].idMunicipio;
                string nombre = municipios[i].nombreMunicipio;

                cbMunicipio.Items.Add(new CmbMunicipio { Id = id, Nombre = nombre });
            }
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarSucursal();

            if (sucursalC.agregarSucursal(sucursal))
            {
                MessageBox.Show("Se agrego con exito");
                cargarSucursales();
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtPresupuesto.Text = "";
            cbDepartamento.SelectedItem = null;
            cbMunicipio.SelectedItem = null;
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
            if (txtDireccion.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Direccion");
                return false;
            }
            if (txtPresupuesto.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Presupuesto");
                return false;
            }
            if (cbDepartamento.SelectedItem == null)
            {
                MessageBox.Show("Escoja departamento");
                return false;
            }
            if (cbMunicipio.SelectedItem == null)
            {
                MessageBox.Show("Escoja municipio");
                return false;
            }

            return true;
        }

        private void guardarSucursal()
        {
            CmbMunicipio municipio = cbMunicipio.SelectedItem as CmbMunicipio;
            sucursal.idSucursal = int.Parse(txtCodigo.Text.Trim());
            sucursal.nombreSucursal = txtNombre.Text.Trim();
            sucursal.direccionSucursal = txtDireccion.Text.Trim();
            sucursal.presupuestoAnual = float.Parse(txtPresupuesto.Text.Trim());
            sucursal.ubicacionSucrusal = municipio.Id;
        }

        private void btmLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
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
                guardarSucursal();
                if (sucursalC.eliminarSucursal(sucursal))
                {
                    MessageBox.Show("Se elimino con exito");
                    cargarSucursales();
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

            guardarSucursal();

            if (sucursalC.actualizarSucursal(sucursal))
            {
                MessageBox.Show("Se actualizo con exito");
                cargarSucursales();
                limpiarCampos();
            }
        }

        private void dataSucursal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataSucursal.Rows[e.RowIndex];
            txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtDireccion.Text = Convert.ToString(fila.Cells["Direccion"].Value);
            txtPresupuesto.Text = Convert.ToString(fila.Cells["Presupuesto"].Value);
            int departamento = municipioC.GetDepartamento(Convert.ToInt32(fila.Cells["Municipio"].Value));
            foreach (CmbDepartamento item in cbDepartamento.Items)
            {
                if (item.Id == departamento)
                {
                    cbDepartamento.SelectedItem = item;
                    llenarcbMunicipio();
                    break;
                }
            }
            int municipio = Convert.ToInt32(fila.Cells["Municipio"].Value);
            foreach (CmbMunicipio item in cbMunicipio.Items)
            {
                if (item.Id == municipio)
                {
                    cbMunicipio.SelectedItem = item;
                    break;
                }
            }
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class CmbMunicipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
