using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalBases
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login login = new Login();  

            if(login.ShowDialog() == DialogResult.OK)
            {
                int idUsuario = login.idUsuario;
                int idBitacora = login.idBitacora;
                Application.Run(new Form1(idBitacora, idUsuario));
            }
            
        }
    }
}
