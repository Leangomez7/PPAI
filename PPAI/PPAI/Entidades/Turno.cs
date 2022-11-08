using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public struct DatosTurno
    {
        public DateTime fechaHoraInicio;
        public DateTime fechaHoraFin;
        public DateTime fechaGeneracion;
        public string estado;
        public Turno turno;

        public DatosTurno(DateTime fecini, DateTime fecfin, DateTime fecgen, string est, Turno tur)
        {
            fechaHoraInicio = fecini;
            fechaHoraFin = fecfin;
            fechaGeneracion = fecgen;
            estado = est;
            turno = tur;
        }
    }
    public class Turno
    {
        [Key]
        public int id { get; set; }
        public DateTime fechaGeneracion { get; set; } = DateTime.Now;
        public DayOfWeek diaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; } = DateTime.Now;
        public DateTime fechaHoraFin { get; set; } = DateTime.Now;
        public List<CambioEstadoTurno> cambioEstadoTurno = new List<CambioEstadoTurno>();

        /// <summary>
        /// Crea un turno con todos sus datos
        /// </summary>
        /// <param name="dia">Dia de la semana del Turno</param>
        /// <param name="ini">Fecha y hora de Inicio del Turno</param>
        /// <param name="fin">Fecha y hora de Fin del Turno</param>
        public Turno(DayOfWeek dia, DateTime ini, DateTime fin)
        {
            fechaGeneracion = DateTime.Now;
            diaSemana = dia;
            fechaHoraInicio = ini;
            fechaHoraFin = fin;
            cambioEstadoTurno.Add(new CambioEstadoTurno(Estado.TurnoDisponible));
        }

        /// <summary>
        /// Marca el Turno como reservado
        /// </summary>
        /// <param name="res">Estado reservado</param>
        public void Reservar(Estado? res)
        {
            foreach (CambioEstadoTurno cambioEstado in cambioEstadoTurno)
            {
                if (cambioEstado.esActual())
                {
                    cambioEstado.SetFechaHoraHasta(DateTime.Now);
                }
            }
            cambioEstadoTurno.Add(new CambioEstadoTurno(res));
        }

        /// <summary>
        /// Devuelve un struct con los Datos del Turno
        /// </summary>
        /// <returns>Struct con inicio, fin, generación y estado del Turno</returns>
        public DatosTurno MostrarTurno()
        {
            DatosTurno datos = new DatosTurno(fechaHoraInicio, fechaHoraFin, fechaGeneracion, buscarEstadoActual(), this);
            return datos;
        }

        /// <summary>
        /// Devuelve si el Turno es posterior a una fecha pasada como parámetro
        /// </summary>
        /// <param name="fec">Fecha a comprobar</param>
        /// <returns>true si es posterior a la fecha, false si no</returns>
        public bool esPosteriorAFecha(DateTime fec)
        {
            if (fec < fechaHoraInicio)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Devuelve una representación como string del Turno, con dia de la semana, fecha y hora de inicio y fin
        /// </summary>
        /// <returns>String con datos del Turno</returns>
        public string getStringHorarios()
        {
            string str = "";
            var culture = new System.Globalization.CultureInfo("es-ES");
            string diasem = culture.DateTimeFormat.GetDayName(diaSemana);
            string inicio, fin;
            if (fechaHoraInicio.DayOfYear == fechaHoraFin.DayOfYear) {
                inicio = fechaHoraInicio.ToString("dd/MM/yyyy") + " " + fechaHoraInicio.ToString("HH:mm");
                fin = fechaHoraFin.ToString("HH:mm");
            }
            else
            {
                inicio = fechaHoraInicio.ToString("dd/MM/yyyy") + " " + fechaHoraInicio.ToString("HH:mm");
                fin = fechaHoraFin.ToString("dd/MM/yyyy") + " " + fechaHoraFin.ToString("HH:mm");
            }
            str += diasem + " " + inicio + " - " + fin;
            return str;
        }

        /// <summary>
        /// Devuelve el estado actual como string
        /// </summary>
        /// <returns>string con el Estado actual</returns>
        public string? buscarEstadoActual()
        {
            foreach(CambioEstadoTurno cambioEstado in cambioEstadoTurno)
            {
                if (cambioEstado.esActual())
                {
                    return cambioEstado.mostrarEstado();
                }
            }
            return null;
        }

        /// <summary>
        /// Devuelve si el Turno está en un Estado reservable.
        /// </summary>
        /// <returns>true si el Turno está en algún Estado reservable, false si no</returns>
        public bool esReservable()
        {
            foreach(CambioEstadoTurno cambioEstado in cambioEstadoTurno)
            {
                if (cambioEstado.esActual())
                {
                    return cambioEstado.EsReservable();
                }
            }
            return false;
        }
    }
}
