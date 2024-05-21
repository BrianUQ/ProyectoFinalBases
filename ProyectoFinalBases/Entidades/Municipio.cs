using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Entidades
{
    internal class Municipio
    {
        public int idMunicipio {  get; set; }
        public string nombreMunicipio { get; set; }
        public int poblacionMunicipio { get; set; }
        public int departamentoMunicipio { get; set; }
        public int prioridadMunicipio { get; set; }

    }
}
