using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public struct DatosRT
    {
        public int nroInventario;
        public string estado;
        public string ci;
        public string marca;
        public string modelo;

        public DatosRT(int nro, string est, string cenIn, string marc, string mod)
        {
            nroInventario = nro;
            estado = est;
            ci = cenIn;
            marca = marc;
            modelo = mod;
        }
    }
    internal class RecursoTecnologico
    {
        private int numeroRT;
        private DateTime fechaAlta;
        private List<string> imagenes;
        private int periodicidadMantenimientoPrev;
        private int duracionMantenimientoPrev;
        private int fraccionHorarioTurnos;
        private List<CambioEstadoRT> cambioEstadoRT;
        private List<Turno> turnos;
        private TipoRT tipoRT;
        private Modelo modelo;
        private CentroInvestigacion? centroInvestigacion;

        public RecursoTecnologico(int num, DateTime dat, int per, int dur, int fra, TipoRT tip, Modelo mod, CentroInvestigacion cen)
        {
            numeroRT = num;
            fechaAlta = dat;
            imagenes = new List<string>();
            periodicidadMantenimientoPrev = per;
            duracionMantenimientoPrev = dur;
            fraccionHorarioTurnos = fra;
            cambioEstadoRT = new List<CambioEstadoRT>();
            turnos = new List<Turno>();
            tipoRT = tip;
            modelo = mod;
            centroInvestigacion = cen;
            cambioEstadoRT.Add(new CambioEstadoRT(Estado.RTActivo));
        }

        public bool EsDeTipoRT(TipoRT? tipoRecTec)
        {
            if (tipoRecTec == tipoRT || tipoRecTec is null)
            {
                return true;
            }
            return false;
        } 
        public bool EsActivo()
        {
            CambioEstadoRT? actual = getEstadoActual();
            if (actual is not null && actual.enEstadoActualReservable())
            {
                return true;
            }
            return false;
        }
        public DatosRT MostrarRT()
        {
            int nro = MostrarNroInventario();
            string est = getEstadoActual().mostrarEstado();
            string cenIn = MostrarCentroInvestigacion();
            string marc = MostrarMarcaYModelo()[1];
            string mod = MostrarMarcaYModelo()[0];
            DatosRT datos = new (nro, est, cenIn, marc, mod);
            return datos;
        }
        public string MostrarCentroInvestigacion()
        {
            return centroInvestigacion.getNombre();
        }
        public List<string> MostrarMarcaYModelo()
        {
            return modelo.MostrarMarcaYModelo();
        }
        public int MostrarNroInventario()
        {
            return numeroRT;
        } 
        /*
        public bool EsDeMiCentroInvestigacion(PersonalCientifico cientifico)
        {
            return centroInvestigacion.EsTuCientificoActivo(cientifico);
        }
        */
        public CambioEstadoRT? getEstadoActual()
        {
            foreach (CambioEstadoRT cambioEstado in cambioEstadoRT)
            {
                if (cambioEstado.esActual())
                {
                    return cambioEstado;
                }
            }
            return null;
        }
        /*
        public List<Turno> MostrarTurnos()
        {
            foreach (Turno cadaTurno in turnos)
            {
                if (cadaTurno.esPosteriorAFecha())
                {
                    cadaTurno.buscarEstadoActual();
                }
            }
        }
        */
    }
}
