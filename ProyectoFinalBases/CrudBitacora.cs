using ProyectoFinalBases.Conexion;
using ProyectoFinalBases.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBases
{
    
    public partial class CrudBitacora : Form
    {
        private List<Bitacora> bitacoras;
        private BitacoraConsulta bitacoraC;
        public CrudBitacora()
        {
            InitializeComponent();
            bitacoraC = new BitacoraConsulta();
            bitacoras = new List<Bitacora>();
            cargarBitacoras();
        }

        private void cargarBitacoras(string filtro="")
        {
            dataBitacora.Rows.Clear();
            dataBitacora.Refresh();
            bitacoras.Clear();
            bitacoras = bitacoraC.GetBitacoras(filtro);

            for (int i = 0; i < bitacoras.Count; i++)
            {
                dataBitacora.RowTemplate.Height = 50;
                dataBitacora.Rows.Add(
                    bitacoras[i].idBitacora,
                    bitacoras[i].fechaEntrada,
                    bitacoras[i].fechaSalida,
                    bitacoras[i].usuarioBitacora);

            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarBitacoras(txtBusqueda.Text.Trim());
        }

        private void btmFecha_Click(object sender, EventArgs e)
        {
            txtFecha.Text = Calendario.SelectionStart.Date.ToString();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtBusqueda.Text = "";
            txtFecha.Text = "";
        }

        private void btmBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            if (!txtFecha.Text.Trim().Equals(""))
            {
                bool isFechaInicioValid = DateTime.TryParse(txtFecha.Text, out fecha);
                if (isFechaInicioValid)
                {
                    dataBitacora.Rows.Clear();
                    dataBitacora.Refresh();
                    bitacoras.Clear();
                    bitacoras = bitacoraC.buscarFecha(fecha);

                    for (int i = 0; i < bitacoras.Count; i++)
                    {
                        dataBitacora.RowTemplate.Height = 50;
                        dataBitacora.Rows.Add(
                            bitacoras[i].idBitacora,
                            bitacoras[i].fechaEntrada,
                            bitacoras[i].fechaSalida,
                            bitacoras[i].usuarioBitacora);

                    }
                }
                else
                {

                    MessageBox.Show("No es valida la fecha");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ingrese fecha");
                return;
            }
            

        }

        private void btmRecargar_Click(object sender, EventArgs e)
        {
            cargarBitacoras();
        }
    }
}
