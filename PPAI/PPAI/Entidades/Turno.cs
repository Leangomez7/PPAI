using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class Turno
    {
        private DateTime fechaGeneracion;
        private Dia diaSemana;
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;

        public Turno(Dia dia, DateTime ini, DateTime fin)
        {
            fechaGeneracion = DateTime.Now;
            diaSemana = dia;
            fechaHoraInicio = ini;
            fechaHoraFin = fin;
        }
    }
}
