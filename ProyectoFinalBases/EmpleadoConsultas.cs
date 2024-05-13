using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalBases
{
    internal class EmpleadoConsultas
    {
        private ConexionMysql conexionMysql;

        public EmpleadoConsultas()
        {
            conexionMysql = new ConexionMysql();
        }
    }
}
