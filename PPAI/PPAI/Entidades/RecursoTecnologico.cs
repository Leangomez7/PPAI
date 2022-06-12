using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class RecursoTecnologico
    {
        private int numeroRT;
        private DateTime fechaAlta;
        private List<string> imagenes;
        private int periodicidadMantenimientoPrev;
        private int duracionMantenimientoPrev;
        private int FraccionHorarioTurnos;
        private List<CambioEstadoRT> cambioEstadoRT;
        private List<Turno> turnos;
        private TipoRT tipoRT;
        private Modelo modelo;
        public bool esDeTipoRT(TipoRT tipoRecTec)
        {
            if (tipoRecTec == tipoRT)
            {
                return true;
            }
            return false;
        }
        public Estado? pedirEstado()
        {
            foreach (CambioEstadoRT cambioEstado in cambioEstadoRT)
            {
                if (DateTime.Now < cambioEstado.getFechaHoraHasta())
                {
                    return cambioEstado.getEstado();
                }
            }
            return null;
        }
        public int pedirNroInventario()
        {
            return numeroRT;
        }
        public Marca pedirMarca()
        {
            return 
        }
        public Modelo pedirModelo()
        {
            return modelo;
        }
    }
}
