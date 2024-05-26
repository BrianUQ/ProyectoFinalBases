using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Entidades
{
    internal class Bitacora
    {
        public int idBitacora {  get; set; }
        public DateTime fechaEntrada { get; set; }
        public DateTime fechaSalida { get; set; }
        public int usuarioBitacora { get; set; }
    }
}
