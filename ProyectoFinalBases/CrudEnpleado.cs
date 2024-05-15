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
    public partial class CrudEnpleado : Form
    {
        DataTable tabla;
        public CrudEnpleado()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void btmEliminar_Click(object sender, EventArgs e)
        {

        }

        private void llenarTabla()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Codigo");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Cedula");
            tabla.Columns.Add("Direccion");
            tabla.Columns.Add("Telefono");
            data.DataSource = tabla;
        }
    }
}
