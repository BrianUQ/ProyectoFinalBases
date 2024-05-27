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
    public partial class ConsultasAdmin : Form
    {
        private EmpleadoConsultas empleadoC;
        private List<ConsultaA1> consultasA1;
        private List<ConsultaA2> consultasA2;
        private SucursalConsultas sucursalC;
        public ConsultasAdmin()
        {
            InitializeComponent();
            empleadoC = new EmpleadoConsultas();
            consultasA1 = new List<ConsultaA1>();
            consultasA2 = new List<ConsultaA2>();
            sucursalC = new SucursalConsultas();
        }

        private void btmBuscar_Click(object sender, EventArgs e)
        {
            consultasA1 = empleadoC.GetEmpleadoSueldo();
            consultas.Columns.Clear();
            consultas.DataSource = null;
            consultas.DataSource = consultasA1.Select(s => new { s.Empleado, s.Sueldo }).ToList();
            consultas.AutoResizeColumns();
        }

        private void btmBuscarSucursales_Click(object sender, EventArgs e)
        {
            consultasA2 = sucursalC.GetSucursalEmpleados();
            consultas.Columns.Clear();
            consultas.DataSource = null;
            consultas.DataSource = consultasA2.Select(s => new { s.Sucursal, s.CantidadEmpleados }).ToList();
            consultas.AutoResizeColumns();
        }
    }
}
