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
        private List<Municipio> municipios;
        private MunicipioConsultas municipioC;
        private Municipio municipio;

        public CrudMunicipio()
        {
            InitializeComponent();
            departamentoC = new DepartamentoConsultas();
            departamentos = new List<Departamento>();
            municipioC = new MunicipioConsultas();
            municipio = new Municipio();
            municipios = new List<Municipio>();
            cargarMunicipios();
            llenarcbDepartamento();
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

        public class CmbDepartamento
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name; 
            }
        }
    }
}
