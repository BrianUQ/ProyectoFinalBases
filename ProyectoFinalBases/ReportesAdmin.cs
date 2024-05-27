
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ProyectoFinalBases
{
    public partial class ReportesAdmin : Form
    {
        
        private List<Empleado> empleados;
        private EmpleadoConsultas empleadoC;
        public ReportesAdmin()
        {
            InitializeComponent();
            empleadoC = new EmpleadoConsultas();
            empleados = new List<Empleado>();
        }

        private void btmGenerar2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\brian\source\repos\ProyectoFinalBases", FileMode.Create);
            Document document = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

            document.Open();

            document.AddAuthor("Grupo");
            document.AddTitle("Reporte Empleados");

            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            document.Add(new Paragraph("Reporte de Empleados"));
            document.Add(Chunk.NEWLINE);

            PdfPTable tabla = new PdfPTable(5);
            tabla.WidthPercentage = 60;

            PdfPCell clCodigo = new PdfPCell(new Phrase("Codigo", standarFont));
            clCodigo.BorderWidth = 0;
            clCodigo.BorderWidthBottom = 0.75f;

            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", standarFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clCedula = new PdfPCell(new Phrase("Cedula", standarFont));
            clCedula.BorderWidth = 0;
            clCedula.BorderWidthBottom = 0.75f;

            PdfPCell clDireccion = new PdfPCell(new Phrase("Direccion", standarFont));
            clDireccion.BorderWidth = 0;
            clDireccion.BorderWidthBottom = 0.75f;

            PdfPCell clTelefono = new PdfPCell(new Phrase("Telefono", standarFont));
            clTelefono.BorderWidth = 0;
            clTelefono.BorderWidthBottom = 0.75f;

            tabla.AddCell(clCodigo);
            tabla.AddCell(clNombre);
            tabla.AddCell(clCedula);
            tabla.AddCell(clDireccion);
            tabla.AddCell(clTelefono);

            empleados = empleadoC.getEmpleados("");

            foreach(var empleado in empleados)
            {
                clCodigo = new PdfPCell(new Phrase(empleado.idEmpleado.ToString(), standarFont));
                clCodigo.BorderWidth = 0;

                clNombre = new PdfPCell(new Phrase(empleado.nombreEmpleado, standarFont));
                clNombre.BorderWidth = 0;

                clCedula = new PdfPCell(new Phrase(empleado.cedulaEmpleado, standarFont));
                clCedula.BorderWidth = 0;

                clDireccion = new PdfPCell(new Phrase(empleado.direccionEmpleado, standarFont));
                clDireccion.BorderWidth = 0;

                clTelefono = new PdfPCell(new Phrase(empleado.telefonoEmpleado, standarFont));
                clTelefono.BorderWidth = 0;

                tabla.AddCell(clCodigo);
                tabla.AddCell(clNombre);
                tabla.AddCell(clCedula);
                tabla.AddCell(clDireccion);
                tabla.AddCell(clTelefono);
            }

            document.Add(tabla);

            document.Close();
            pw.Close();

            MessageBox.Show("Documento Generado");
        }
    }
}
