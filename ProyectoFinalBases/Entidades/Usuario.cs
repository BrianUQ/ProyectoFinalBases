using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases.Entidades
{
    internal class Usuario
    {
        public int idUsuario {  get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public int tipoUsuario { get; set; }

    }
}
