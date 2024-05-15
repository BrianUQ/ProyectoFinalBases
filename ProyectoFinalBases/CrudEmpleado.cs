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
    public partial class CrudEmpleado : Form
    {
        private List<Empleado> empleados;
        private EmpleadoConsultas empleadoC;
        public CrudEmpleado()
        {
            InitializeComponent();
            empleadoC = new EmpleadoConsultas();
            empleados = new List<Empleado>();
            cargarEmpleados();
        }

        private void cargarEmpleados(string filtro = "")
        {
            dataEmpleado.Rows.Clear();
            dataEmpleado.Refresh(); 
            empleados.Clear();
            empleados = empleadoC.getEmpleados(filtro);

            for (int i = 0; i < empleados.Count; i++)
            {
                dataEmpleado.RowTemplate.Height = 50;
                dataEmpleado.Rows.Add(
                    empleados[i].idEmpleado,
                    empleados[i].nombreEmpleado,
                    empleados[i].cedulaEmpleado,
                    empleados[i].direccionEmpleado,
                    empleados[i].telefonoEmpleado);

            }
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void btmEliminar_Click(object sender, EventArgs e)
        {

        }

    }
}
