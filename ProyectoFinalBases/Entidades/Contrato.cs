using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Entidades
{
    internal class Contrato
    {
        public int idContrato {  get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal {  get; set; }
        public int cargoContrato {  get; set; }
        public int sucursalContrato { get; set; }
        public int empleadoContrato { get; set; }

    }
}
