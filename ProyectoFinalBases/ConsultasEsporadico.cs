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
    public partial class ConsultasEsporadico : Form
    {
        private ConsultaE1 consultaE1;
        private EmpleadoConsultas empleadoC;
        public ConsultasEsporadico()
        {
            InitializeComponent();
            consultaE1 = new ConsultaE1();
            empleadoC = new EmpleadoConsultas();
        }

        private void btmBuscar_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Trim().Equals(""))
            {
                int codigo  = Convert.ToInt32(txtCodigo.Text.Trim());

                consultaE1 = empleadoC.GetEmpleadoCodigo(codigo);
                if(consultaE1 != null)
                {
                    consultas.Columns.Clear();

                    var data = new List<dynamic>
                    {
                        new { consultaE1.Sucursal, consultaE1.Direccion, consultaE1.Municipio }
                    };
                    consultas.DataSource = null;
                    consultas.DataSource = data;
                    consultas.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show("No existe el empleado");
                }

            }
            else
            {
                MessageBox.Show("Ingrese el empleado");
                return;
            }
        }
    }
}
