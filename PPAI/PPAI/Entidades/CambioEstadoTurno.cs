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
        private DateTime? fechaHoraHasta;
        private Estado? estado;

        public CambioEstadoTurno(Estado? est)
        {
            estado = est;
        }

        public void SetFechaHoraHasta(DateTime fecha)
        {
            fechaHoraHasta = fecha;
        }

        public bool esActual()
        {
            if (fechaHoraHasta is null)
            {
                return true;
            }
            return false;
        }

        public bool EsReservable()
        {
            return estado.getReservable();
        }

        public string mostrarEstado()
        {
            return estado.getNombre();
        }
    }
}
