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
    public partial class ListaContrato : Form
    {
        private List<Contrato> contratos;
        private ContratoConsulta contratoC;
        public ListaContrato()
        {
            InitializeComponent();
            contratos = new List<Contrato>();
            contratoC = new ContratoConsulta();
            cargaContratos();
            
        }

        private void cargaContratos(string filtro="")
        {
            dataContrato.Rows.Clear();
            dataContrato.Refresh();
            contratos.Clear();
            contratos = contratoC.GetContratos(filtro);

            for (int i = 0; i < contratos.Count; i++)
            {
                dataContrato.RowTemplate.Height = 50;
                dataContrato.Rows.Add(
                    contratos[i].idContrato,
                    contratos[i].fechaInicio,
                    contratos[i].fechaFinal,
                    contratos[i].cargoContrato,
                    contratos[i].sucursalContrato,
                    contratos[i].empleadoContrato);
            }
        }

        private void btmAgregar_Click(object sender, EventArgs e)
        {
            CrudContrato crud = new CrudContrato(0, 0);
            crud.Show();
        }

        private void dataSucursal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataContrato.Rows[e.RowIndex];
            int contrato = Convert.ToInt16(fila.Cells["Codigo"].Value);
            CrudContrato crud = new CrudContrato(1, contrato);
            crud.FormClosed += new FormClosedEventHandler(crudClosed);
            crud.Show();
        }

        private void crudClosed(object sender, FormClosedEventArgs e)
        {
            cargaContratos();
        }

        private void Recargar_Click(object sender, EventArgs e)
        {
            cargaContratos();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargaContratos(txtBusqueda.Text.Trim());
        }
    }
}
