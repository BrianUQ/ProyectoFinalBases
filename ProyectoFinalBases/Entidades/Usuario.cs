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
        public string login { get; set; }
        public string clave { get; set; }
        public int tipoUsuario { get; set; }

    }
}
