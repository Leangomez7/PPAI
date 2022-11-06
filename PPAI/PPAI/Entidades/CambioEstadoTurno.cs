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

        /// <summary>
        /// Constructor de objeto CambioEstadoTurno asigna estado del turno pasado por parametro al atributo estado
        /// </summary>
        /// <param name="est"></param>
        public CambioEstadoTurno(Estado? est)
        {
            estado = est;
        }
        /// <summary>
        /// Asigna la fecha y hora final pasada por parametro al atributo fechaHoraHasta
        /// </summary>
        /// <param name="fecha"></param>
        public void SetFechaHoraHasta(DateTime fecha)
        {
            fechaHoraHasta = fecha;
        }

        /// <summary>
        /// Verifica si el estado del rt es actual 
        /// </summary>
        /// <returns>
        /// bool
        /// </returns>
        public bool esActual()
        {
            if (fechaHoraHasta is null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si el estado del turno es reservable 
        /// </summary>
        /// <returns>
        /// bool
        /// </returns>
        public bool EsReservable()
        {
            return estado.getReservable();
        }

        /// <summary>
        /// Muestra el nombre del estado asignado al cambioEstadoTurno
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        public string mostrarEstado()
        {
            return estado.getNombre();
        }
    }
}
