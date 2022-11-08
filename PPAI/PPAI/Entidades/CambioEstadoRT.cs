using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class CambioEstadoRT
    {
        [Key]
        public int id { get; set; }
        public DateTime fechaHoraDesde { get; set; } = DateTime.Now;
        public DateTime fechaHoraHasta { get; set; } = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
        public Estado estado { get; set; }

        /// <summary>
        /// Constructor de objeto CambioEstadoRT que asigna la fecha y horario actual a fechaHoraDesde y el estado a guardar en la historia
        /// </summary>
        /// <param name="est"></param>
        public CambioEstadoRT(Estado est)
        {
            fechaHoraDesde = DateTime.Now;
            estado = est;
        }

        public CambioEstadoRT()
        {

        }

        /// <summary>
        /// Verifica si el estado del rt es actual 
        /// </summary>
        /// <returns>
        /// bool
        /// </returns>
        public bool esActual()
        {
            if (fechaHoraHasta == System.Data.SqlTypes.SqlDateTime.MaxValue.Value)
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
