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
        private CentroInvestigacion? centroInvestigacion;
        public bool esActivo()
        {
            foreach (CambioEstadoRT cambioEstado in cambioEstadoRT)
            {
                if (cambioEstado.esActual())
                {
                    if (cambioEstado.enEstadoActualReservable())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public List<object> mostrarRT(CambioEstadoRT cambioEstadoRecurso)
        {
            List<object> listaAtributosRT = new List<object>();
            listaAtributosRT.Add(mostrarNroInventario());
            listaAtributosRT.Add(cambioEstadoRecurso.mostrarEstado());
            listaAtributosRT.Add(mostrarCentroInvestigacion());
            listaAtributosRT.Add(mostrarMarcaYModelo());
        }
        public string mostrarCentroInvestigacion()
        {
            return centroInvestigacion.getNombre();
        }
        public List<string> mostrarMarcaYModelo()
        {
            return modelo.mostrarMarcaYModelo();
        }
        public bool esDeTipoRT(TipoRT tipoRecTec)
        {
            if (tipoRecTec == tipoRT)
            {
                return true;
            }
            return false;
        } 
        public int mostrarNroInventario()
        {
            return numeroRT;
        } 
        } 
    }
}
