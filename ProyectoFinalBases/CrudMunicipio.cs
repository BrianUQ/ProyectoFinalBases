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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinalBases
{
    public partial class CrudMunicipio : Form
    {
        private DepartamentoConsultas departamentoC;
        private List<Departamento> departamentos;
        private List<Prioridad> prioridades;
        private PrioridadConsultas prioridadC;
        private List<Municipio> municipios;
        private MunicipioConsultas municipioC;
        private Municipio municipio;

        public CrudMunicipio()
        {
            InitializeComponent();
            departamentoC = new DepartamentoConsultas();
            departamentos = new List<Departamento>();
            prioridades = new List<Prioridad>();
            prioridadC = new PrioridadConsultas();
            municipioC = new MunicipioConsultas();
            municipio = new Municipio();
            municipios = new List<Municipio>();
            cargarMunicipios();
            llenarcbDepartamento();
            llenarcbPrioridad();
        }

        private void llenarcbPrioridad()
        {
            cbPrioridad.Items.Clear();
            cbPrioridad.Refresh();
            prioridades.Clear();
            prioridades = prioridadC.GetPrioridad("");
            for (int i = 0; i < prioridades.Count; i++)
            {
                int id = prioridades[i].idPrioridad;
                string nombre = prioridades[i].nombrePrioridad;

                cbPrioridad.Items.Add(new CmbPrioridad { Id = id, Nombre = nombre });
            }
        }

        private void cargarMunicipios(string filtro = "")
        {
            dataMunicipio.Rows.Clear();
            dataMunicipio.Refresh();
            municipios.Clear();
            municipios = municipioC.GetMunicipio(filtro);

            for (int i = 0; i < municipios.Count; i++)
            {
                dataMunicipio.RowTemplate.Height = 50;
                dataMunicipio.Rows.Add(
                    municipios[i].idMunicipio,
                    municipios[i].nombreMunicipio,
                    municipios[i].poblacionMunicipio,
                    municipios[i].departamentoMunicipio,
                    municipios[i].prioridadMunicipio);

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
                    int selectedId = selectedItem.Id;
                    MessageBox.Show("ID seleccionado: " + selectedId);
                }
            }
        }


        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarMunicipio();

            if (municipioC.agregarMunicipio(municipio))
            {
                MessageBox.Show("Se agrego con exito");
                cargarMunicipios();
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPoblacion.Text = "";
            cbDepartamento.SelectedItem = null;
            cbPrioridad.SelectedItem = null;
        }

        private void guardarMunicipio()
        {
            CmbDepartamento departamento = cbDepartamento.SelectedItem as CmbDepartamento;
            CmbPrioridad prioridad = cbPrioridad.SelectedItem as CmbPrioridad;
            municipio.idMunicipio = int.Parse(txtCodigo.Text.Trim());
            municipio.nombreMunicipio = txtNombre.Text.Trim();
            municipio.poblacionMunicipio = int.Parse(txtPoblacion.Text.Trim());
            municipio.departamentoMunicipio = departamento.Id;
            municipio.prioridadMunicipio = prioridad.Id;

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
            if(cbDepartamento.SelectedItem == null)
            {
                MessageBox.Show("Escoja departamento");
                return false;
            }
            if(cbPrioridad.SelectedItem == null)
            {
                MessageBox.Show("Escoja prioridad");
                return false;
            }

            return true;
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
                guardarMunicipio();
                if (municipioC.eliminarMunicipio(municipio))
                {
                    MessageBox.Show("Se elimino con exito");
                    cargarMunicipios();
                    limpiarCampos();
                }
            }
        }

        private void btmActualizar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarMunicipio();

            if (municipioC.actualizarMunicipio(municipio))
            {
                MessageBox.Show("Se actualizo con exito");
                cargarMunicipios();
                limpiarCampos();
            }
        }



        private void dataMunicipio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataMunicipio.Rows[e.RowIndex];
            txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtPoblacion.Text = Convert.ToString(fila.Cells["Poblacion"].Value);
            int departamento = Convert.ToInt32(fila.Cells["Departamento"].Value);
            foreach (CmbDepartamento item in cbDepartamento.Items)
            {
                if (item.Id == departamento)
                {
                    cbDepartamento.SelectedItem = item;
                    break;
                }
            }
            int prioridad = Convert.ToInt32(fila.Cells["Prioridad"].Value);
            foreach (CmbPrioridad item in cbPrioridad.Items)
            {
                if (item.Id == prioridad)
                {
                    cbPrioridad.SelectedItem = item;
                    break;
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

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class CmbDepartamento
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class CmbPrioridad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
