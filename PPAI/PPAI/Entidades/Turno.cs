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
        private List<CambioEstadoTurno> cambioEstadoTurno;

        public Turno(Dia dia, DateTime ini, DateTime fin)
        {
            fechaGeneracion = DateTime.Now;
            diaSemana = dia;
            fechaHoraInicio = ini;
            fechaHoraFin = fin;
        }
        public Turno mostrarTurno()
        {
            return this;
        }
        public void estoyDisponible()
        {
        }
        public bool esPosteriorAFecha()
        {
            if (DateTime.Now < fechaHoraInicio)
            {
                return true;
            }
            return false;
        }
        public Estado? buscarEstadoActual()
        {
            foreach (CambioEstadoTurno cambioEstado in cambioEstadoTurno)
            {
                if (cambioEstado.getFechaHoraDesde() < DateTime.Now && cambioEstado.getFechaHoraHasta() > DateTime.Now)
                {
                    return cambioEstado.mostrarEstado();
                }
            }
            return null;
        }
        public void reservar()
        {

        }
    }
}
