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

        public CambioEstadoTurno(Estado est)
        {
            fechaHoraDesde = DateTime.Now;
            estado = est;
        }
        public CambioEstadoTurno mostrarCambioEstadoTurno()
        {
            return this;
        }
        public bool esActual()
        {
            if (fechaHoraDesde < DateTime.Now && DateTime.Now < fechaHoraHasta)
            {
                return true;
            }
            return false;
        }
        public Estado mostrarEstado()
        {
            return estado;
        }
        public void setFechaHoraHasta(DateTime fechaHasta)
        {
            fechaHoraHasta = fechaHasta;
        }
        public DateTime getFechaHoraHasta()
        {
            return fechaHoraHasta;
        }
        public DateTime getFechaHoraDesde()
        {
            return fechaHoraDesde;
        }
    }
}
