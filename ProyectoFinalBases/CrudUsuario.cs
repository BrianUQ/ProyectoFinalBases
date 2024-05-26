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
    public partial class CrudUsuario : Form
    {
        private List<Usuario> usuarios;
        private Usuario usuario;
        private UsuarioConsultas usuarioC;
        public CrudUsuario()
        {
            InitializeComponent();
            usuario = new Usuario();
            usuarios = new List<Usuario>();
            usuarioC = new UsuarioConsultas();
            llenarTipo();
            cargarUsuarios();
        }

        private void cargarUsuarios(string filtro="")
        {
            dataUsuario.Rows.Clear();
            dataUsuario.Refresh();
            usuarios.Clear();
            usuarios = usuarioC.GetUsuario(filtro);

            for (int i = 0; i < usuarios.Count; i++)
            {
                dataUsuario.RowTemplate.Height = 50;
                dataUsuario.Rows.Add(
                    usuarios[i].idUsuario,
                    usuarios[i].login,
                    usuarios[i].tipoUsuario);
            }
        }

        private void llenarTipo()
        {
            var tipo = Enum.GetValues(typeof(tipoUsuario)).Cast<tipoUsuario>().ToList();

            cbTipo.Items.Clear();
            cbTipo.Refresh();
            cbTipo.DataSource = tipo;
        }

        private void btmGuardar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }
            guardarUsuario();

            if (usuarioC.agregarUsuario(usuario))
            {
                MessageBox.Show("Se agrego con exito");
                cargarUsuarios();
                limpiarCampos();
            }
        }

        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtContraseña.Text = "";
            txtContraseña2.Text = "";
            cbTipo.SelectedItem = null;
        }

        private void guardarUsuario()
        {
            tipoUsuario tipoSeleccionado = (tipoUsuario)cbTipo.SelectedItem;
            int tipo = (int)tipoSeleccionado + 1;
            usuario.idUsuario = int.Parse(txtCodigo.Text.Trim());
            usuario.login = txtNombre.Text.Trim();
            usuario.clave = txtContraseña2.Text.Trim();
            usuario.tipoUsuario = tipo;
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
            if (txtContraseña.Text.Trim().Equals(""))
            {
                MessageBox.Show("Llene la casilla Contraseña");
                return false;
            }
            if (txtContraseña2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Repita la contraseña");
                return false;
            }
            if (txtContraseña.Text.Trim() != txtContraseña2.Text.Trim())
            {
                MessageBox.Show("Las contraseñas no son iguales");
                return false;
            }
            if (cbTipo.SelectedItem == null)
            {
                MessageBox.Show("Escoja Tipo de usuario");
                return false;
            }

            return true;
        }

        private void btmActualizar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            guardarUsuario();

            if (usuarioC.actualizarUsuario(usuario))
            {
                MessageBox.Show("Se actualizo con exito");
                cargarUsuarios();
                limpiarCampos();
            }
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
                guardarUsuario();
                if (usuarioC.eliminarUsuario(usuario))
                {
                    MessageBox.Show("Se elimino con exito");
                    cargarUsuarios();
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

        private void btmLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void dataUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataUsuario.Rows[e.RowIndex];
            txtCodigo.Text = Convert.ToString(fila.Cells["Codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            int tipo = Convert.ToInt32(fila.Cells["Tipo"].Value)-1;
            foreach (tipoUsuario item in cbTipo.Items)
            {
                if ((int)item == tipo)
                {
                    cbTipo.SelectedItem = item;
                    break;
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarUsuarios(txtBusqueda.Text.Trim());
        }

        private void btmCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum tipoUsuario
    {
        Administrador,
        Parametrico,
        Esporadico
    }
}
