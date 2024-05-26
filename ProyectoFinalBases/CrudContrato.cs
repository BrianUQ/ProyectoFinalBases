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
    public partial class CrudContrato : Form
    {
        private Contrato contrato;
        private ContratoConsulta contratoC;
        private List<Contrato> contratos;
        private SucursalConsultas sucursalC;
        private MunicipioConsultas municipioC;
        private CargoConsultas cargoC;
        private List<Departamento> departamentos;
        private DepartamentoConsultas departamentoC;
        private List<Municipio> municipios;
        private List<Sucursal> sucursales;
        private List<Cargo> cargos;
        public CrudContrato(int mostrar, int actualizar)
        {
            contrato = new Contrato();
            contratoC = new ContratoConsulta();
            contratos = new List<Contrato>();
            sucursalC = new SucursalConsultas();
            municipioC = new MunicipioConsultas();
            cargoC = new CargoConsultas();
            cargos = new List<Cargo>();
            departamentos = new List<Departamento>();
            departamentoC = new DepartamentoConsultas();
            municipios = new List<Municipio>();
            sucursales = new List<Sucursal>();
            InitializeComponent();
            llenarcbDepartamento();
            llenarcbCargo();
            if (mostrar == 0)
            {
                btmActualizar.Visible = false;
                btmEliminar.Visible = false;
                btmGuardar.Visible = true;
            }
            else
            {
                btmActualizar.Visible = true;
                btmGuardar.Visible = false;
            }

            if (actualizar != 0)
            {
                llenarCasillas(actualizar);
            }
            
        }

        private void llenarCasillas(int actualizar)
        {
            contrato = contratoC.GetContrato(actualizar);
            if (contrato != null)
            {
                txtCodigo.Text = Convert.ToString(contrato.idContrato);
                txtInicio.Text = Convert.ToString(contrato.fechaInicio);
                txtFinal.Text = Convert.ToString(contrato.fechaFinal);
                txtEmpleado.Text = Convert.ToString(contrato.empleadoContrato);
                int departamento = municipioC.GetDepartamento(sucursalC.GetMunicipio(contrato.sucursalContrato));
                foreach (CmbDepartamento item in cbDepartamento.Items)
                {
                    if (item.Id == departamento)
                    {
                        cbDepartamento.SelectedItem = item;
                        llenarcbMunicipio();
                        break;
                    }
                }
                int municipio = sucursalC.GetMunicipio(contrato.sucursalContrato);
                foreach (CmbMunicipio item in cbMunicipio.Items)
                {
                    if (item.Id == municipio)
                    {
                        cbMunicipio.SelectedItem = item;
                        llenarSucursal();
                        break;
                    }
                }
                int sucursal = contrato.sucursalContrato;
                foreach (CmbSucursal item in cbSucursal.Items)
                {
                    if (item.Id == sucursal)
                    {
                        cbSucursal.SelectedItem = item;
                        break;
                    }
                }
                int cargo = contrato.cargoContrato;
                foreach (CmbCargo item in cbCargo.Items)
                {
                    if (item.Id == cargo)
                    {
                        cbCargo.SelectedItem = item;
                        break;
                    }
                }
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
                    labelm.Visible = true;

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

        private void cbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMunicipio.SelectedItem != null)
            {
                CmbMunicipio selectedItem = cbMunicipio.SelectedItem as CmbMunicipio;

                if (selectedItem != null)
                {
                    llenarSucursal();
                    cbSucursal.Visible = true;
                    labels.Visible = true;

                }
            }

        }

        private void llenarSucursal()
        {
            CmbMunicipio selectedItem = cbMunicipio.SelectedItem as CmbMunicipio;
            cbSucursal.Items.Clear();
            cbSucursal.Refresh();
            sucursales.Clear();
            sucursales = sucursalC.GetSucursalMunicipio(selectedItem.Id);

            for (int i = 0; i < sucursales.Count; i++)
            {
                int id = sucursales[i].idSucursal;
                string nombre = sucursales[i].nombreSucursal;

                cbSucursal.Items.Add(new CmbSucursal { Id = id, Nombre = nombre });
            }
        }

        private void llenarcbCargo()
        {
            cbCargo.Items.Clear();
            cbCargo.Refresh();
            cargos.Clear();
            cargos = cargoC.getCargos("");

            for (int i = 0; i < cargos.Count; i++)
            {
                int id = cargos[i].idCargo;
                string nombre = cargos[i].nombreCargo;

                cbCargo.Items.Add(new  CmbCargo{ Id = id, Nombre = nombre });
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtInicio.Text = Calendario.SelectionStart.Date.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtFinal.Text = Calendario.SelectionStart.Date.ToString();
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarContrato();

            if (contratoC.agregarContrato(contrato))
            {
                MessageBox.Show("Se agrego con exito");
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtInicio.Text = "";
            txtFinal.Text = "";
            txtEmpleado.Text = "";
            cbDepartamento.SelectedItem = null;
            cbMunicipio.SelectedItem = null;
            cbMunicipio.Visible = false;
            cbSucursal.SelectedItem = null;
            cbSucursal.Visible = false;
            cbCargo.SelectedItem = null;
        }

        private void guardarContrato()
        {
            CmbSucursal sucursal = cbSucursal.SelectedItem as CmbSucursal;
            CmbCargo cargo = cbCargo.SelectedItem as CmbCargo;
            DateTime fechaInicio;
            DateTime fechaFinal;
            contrato.idContrato = int.Parse(txtCodigo.Text.Trim());
            bool isFechaInicioValid = DateTime.TryParse(txtInicio.Text, out fechaInicio);
            bool isFechaFinalValid = DateTime.TryParse(txtFinal.Text, out fechaFinal);
            if (isFechaInicioValid && isFechaFinalValid)
            {
                contrato.fechaInicio = fechaInicio;
                contrato.fechaFinal = fechaFinal;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese fechas válidas.");
            }
            contrato.cargoContrato = cargo.Id;
            contrato.sucursalContrato = sucursal.Id;
            contrato.empleadoContrato = int.Parse((txtEmpleado.Text).Trim());
        }

        private bool datosCorrectos()
        {
            if (txtCodigo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Codigo");
                return false;
            }
            if (txtEmpleado.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla codigo empleado");
                return false;
            }
            if (txtFinal.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ponga fecha de finaliacion del contrato");
                return false;
            }
            if (txtInicio.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ponga fecha de inicio del contrato");
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
            if (cbSucursal.SelectedItem == null)
            {
                MessageBox.Show("Escoja Sucursal");
                return false;
            }
            if (cbCargo.SelectedItem == null)
            {
                MessageBox.Show("Escoja cargo");
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
                guardarContrato();
                if (contratoC.eliminarContrato(contrato))
                {
                    MessageBox.Show("Se elimino con exito");
                    this.Close();
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

            guardarContrato();

            if (contratoC.actualizarContrato(contrato))
            {
                MessageBox.Show("Se actualizo con exito");
                this.Close();
            }
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btmMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public class CmbSucursal
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString()
            {
                return Nombre;
            }
        }

        public class CmbCargo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString()
            {
                return Nombre;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}   

