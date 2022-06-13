using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private DateTime fechaGeneracion;
        private DayOfWeek diaSemana;
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private List<CambioEstadoTurno> cambioEstadoTurno = new List<CambioEstadoTurno>();


        public Turno(DayOfWeek dia, DateTime ini, DateTime fin)
        {
            fechaGeneracion = DateTime.Now;
            diaSemana = dia;
            fechaHoraInicio = ini;
            fechaHoraFin = fin;
            cambioEstadoTurno.Add(new CambioEstadoTurno(Estado.TurnoDisponible));
        }
        public DatosTurno MostrarTurno()
        {
            DatosTurno datos = new DatosTurno(fechaHoraInicio, fechaHoraFin, fechaGeneracion, buscarEstadoActual(), this);
            return datos;
        }
        public bool esPosteriorAFecha(DateTime fec)
        {
            if (fec < fechaHoraInicio)
            {
                return true;
            }
            return false;
        }

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
