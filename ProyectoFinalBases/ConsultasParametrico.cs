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
    public partial class ConsultasParametrico : Form
    {
        private List<ConsultaP1> consultasP1;
        private SucursalConsultas sucursalC;
        private List<Departamento> departamentos;
        private DepartamentoConsultas departamentoC;
        private List<ConsultaP2> consultasP2;
        public ConsultasParametrico()
        {
            InitializeComponent();
            sucursalC = new SucursalConsultas();
            consultasP1 = new List<ConsultaP1>();
            departamentos = new List<Departamento>();   
            departamentoC = new DepartamentoConsultas();
            consultasP2 = new List<ConsultaP2>();
            llenarcbDepartamento();
        }

        private void btmBuscar_Click(object sender, EventArgs e)
        {
            if (cbDepartamento.SelectedItem != null)
            {
                CmbDepartamento departamento = cbDepartamento.SelectedItem as CmbDepartamento;
                consultasP1 = sucursalC.GetSucursalDepartamento(departamento.Id);
                consultas.Columns.Clear();
                consultas.DataSource = null;
                consultas.DataSource = consultasP1.Select(s => new {s.Sucursal, s.Direccion, s.Municipio, s.Departamento}).ToList();
                consultas.AutoResizeColumns();
            }
            else
            {
                MessageBox.Show("Escoja departamento");
                return;
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

        private void btmBuscarSucursales_Click(object sender, EventArgs e)
        {
            consultasP2 = departamentoC.GetCantidadSucursales();
            consultas.Columns.Clear();
            consultas.DataSource = null;
            consultas.DataSource = consultasP2.Select(s => new {s.Departamento, s.CantidadSucursales }).ToList();
            consultas.AutoResizeColumns();
        }
    }
}
