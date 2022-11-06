using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class CambioEstadoRT
    {
        private DateTime fechaHoraDesde;
        private DateTime? fechaHoraHasta;
        private Estado estado;

        /// <summary>
        /// Constructor de objeto CambioEstadoRT que asigna la fecha y horario actual a fechaHoraDesde y el estado a guardar en la historia
        /// </summary>
        /// <param name="est"></param>
        public CambioEstadoRT(Estado est)
        {
            fechaHoraDesde = DateTime.Now;
            estado = est;
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
        /// Verifica si el estado actual es reservable
        /// </summary>
        /// <returns>
        /// bool
        /// </returns>
        public bool enEstadoActualReservable()
        {
            return estado.getReservable();
        }
        /// <summary>
        /// Muestra el nombre del estado
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
