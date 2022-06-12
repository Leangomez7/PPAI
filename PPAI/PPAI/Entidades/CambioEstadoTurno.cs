using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class CambioEstadoTurno
    {
        private DateTime fechaHoraDesde = DateTime.Now;
        private DateTime fechaHoraHasta;
        private Estado estado;

        public bool esActual()
        {
            if (DateTime.Now < fechaHoraHasta)
            {
                return true;
            }
            return false;
        }
        public string mostrarEstado()
        {
            return estado.getNombre();
        }
    }
}
