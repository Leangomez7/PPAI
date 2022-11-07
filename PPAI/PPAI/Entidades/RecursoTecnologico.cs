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
        public RecursoTecnologico rt;

        public DatosRT(int nro, string est, string cenIn, string marc, string mod, RecursoTecnologico rec)
        {
            nroInventario = nro;
            estado = est;
            ci = cenIn;
            marca = marc;
            modelo = mod;
            rt = rec;
        }
    }
    public class RecursoTecnologico
    {
        private int numeroRT;
        private DateTime fechaAlta;
        private List<string> imagenes = new List<string>();
        private int periodicidadMantenimientoPrev;
        private int duracionMantenimientoPrev;
        private int fraccionHorarioTurnos;
        private List<CambioEstadoRT> cambioEstadoRT = new List<CambioEstadoRT>();
        private List<Turno> turnos = new List<Turno>();
        private TipoRT tipoRT;
        private Modelo modelo;
        private CentroInvestigacion? centroInvestigacion;
        private List<HorarioRT> horarioRT = new List<HorarioRT>();

        /// <summary>
        /// Crea un Recurso Tecnológico con todos sus datos
        /// </summary>
        /// <param name="num">Número del Recurso</param>
        /// <param name="dat">Fecha de alta del Recurso</param>
        /// <param name="per">Periodicidad de Mantenimiento Preventivo</param>
        /// <param name="dur">Duración de Mantenimiento Preventivo</param>
        /// <param name="fra">Fracción de Horario de los Turnos</param>
        /// <param name="tip">Tipo de Recurso Tecnológico</param>
        /// <param name="mod">Modelo de Recurso</param>
        /// <param name="cen">Centro de Investigación al que pertenece</param>
        public RecursoTecnologico(int num, DateTime dat, int per, int dur, int fra, TipoRT tip, Modelo mod, CentroInvestigacion cen)
        {
            numeroRT = num;
            fechaAlta = dat;
            periodicidadMantenimientoPrev = per;
            duracionMantenimientoPrev = dur;
            fraccionHorarioTurnos = fra;
            tipoRT = tip;
            modelo = mod;
            centroInvestigacion = cen;
            cambioEstadoRT.Add(new CambioEstadoRT(Estado.RTActivo));
            GenerarTurnos();
        }

        /// <summary>
        /// Reserva un turno del recurso tecnológico
        /// </summary>
        /// <param name="tur">Turno a reservar</param>
        /// <param name="res">Estado reservado</param>
        public void ReservarTurno(Turno tur, Estado? res)
        {
            tur.Reservar(res);
        }

        /// <summary>
        /// Genera los turnos para un recurso tecnológico para los próximos 30 días
        /// </summary>
        public void GenerarTurnos()
        {
            horarioRT.Add(new HorarioRT(DayOfWeek.Monday));
            horarioRT.Add(new HorarioRT(DayOfWeek.Tuesday));
            horarioRT.Add(new HorarioRT(DayOfWeek.Wednesday));
            horarioRT.Add(new HorarioRT(DayOfWeek.Thursday));
            horarioRT.Add(new HorarioRT(DayOfWeek.Friday));
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            DateOnly limit = DateOnly.FromDateTime(DateTime.Now).AddDays(30);
            for (DateOnly i = today; i < limit; i = i.AddDays(1))
            {
                DateTime idt = i.ToDateTime(new TimeOnly(0, 0));
                foreach (HorarioRT horario in horarioRT)
                {
                    // Comparar dia del horario con dia para el que se genera
                    if (horario.GetDia() == idt.DayOfWeek)
                    {
                        TimeOnly acrear = horario.GetHoraDesde();
                        TimeOnly limittime = horario.GetHoraHasta();
                        while (acrear <= limittime)
                        {
                            DateTime dtinicio = i.ToDateTime(acrear);
                            DateTime dtfin = dtinicio.AddMinutes(fraccionHorarioTurnos);
                            turnos.Add(new Turno(idt.DayOfWeek, dtinicio, dtfin));
                            if (acrear.AddMinutes(fraccionHorarioTurnos) > acrear)
                            {
                                acrear = acrear.AddMinutes(fraccionHorarioTurnos);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Comprueba si el RT es de un determinado tipo, pasado como parámetro
        /// </summary>
        /// <param name="tipoRecTec">TipoRT a comprobar</param>
        /// <returns>true si es del tipo, false si no</returns>
        public bool EsDeTipoRT(TipoRT? tipoRecTec)
        {
            if (tipoRecTec == tipoRT || tipoRecTec is null)
            {
                return true;
            }
            return false;
        } 

        /// <summary>
        /// Devuelve si el RT se encuentra activo
        /// </summary>
        /// <returns>true si es Activo, false si no</returns>
        public bool EsActivo()
        {
            CambioEstadoRT? actual = getEstadoActual();
            if (actual is not null && actual.enEstadoActualReservable())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Devuelve un struct DatosRT con los datos del Recurso
        /// </summary>
        /// <returns>Datos del Recurso</returns>
        public DatosRT MostrarRT()
        {
            int nro = MostrarNroInventario();
            string est = getEstadoActual().mostrarEstado();
            string cenIn = MostrarCentroInvestigacion();
            string marc = MostrarMarcaYModelo()[1];
            string mod = MostrarMarcaYModelo()[0];
            RecursoTecnologico rt = this;
            DatosRT datos = new (nro, est, cenIn, marc, mod, rt);
            return datos;
        }

        /// <summary>
        /// Devuelve el Centro de Investigación al que pertenece el RT
        /// </summary>
        /// <returns>string con el nombre del CI al que pertenece</returns>
        public string MostrarCentroInvestigacion()
        {
            return centroInvestigacion.getNombre();
        }
        /// <summary>
        /// Devuelve la marca y modelo del recurso como Lista de string
        /// </summary>
        /// <returns>Lista de strings, marca y modelo</returns>
        public List<string> MostrarMarcaYModelo()
        {
            return modelo.MostrarMarcaYModelo();
        }

        /// <summary>
        /// Devuelve el número de Inventario del RT
        /// </summary>
        /// <returns>ínt, Número de inventario del RT</returns>
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

        /// <summary>
        /// Devuelve el cambio de estado actual
        /// </summary>
        /// <returns>Cambio de Estado actual</returns>
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

        /// <summary>
        /// Devuelve si un PersonalCientifico pertenece al centro de investigación del RT
        /// </summary>
        /// <param name="cien">PersonalCientifico a comprobar</param>
        /// <returns>true si el Cientifico pertenece al CI, false si no</returns>
        public bool EsDeMiCentroInvestigacion(PersonalCientifico cien)
        {
            return centroInvestigacion.EsTuCientificoActivo(cien);
        }
        
        /// <summary>
        /// Devuelve una lista de Datos de Turno, de todos los turnos del RT para un día
        /// </summary>
        /// <param name="fec">Día a buscar</param>
        /// <returns>Lista de Datos de Turnos del día a buscar</returns>
        public List<DatosTurno> MostrarTurnos(DateTime fec)
        {
            List<DatosTurno> datos = new List<DatosTurno>();
            foreach (Turno cadaTurno in turnos)
            {
                if (cadaTurno.esPosteriorAFecha(fec) && cadaTurno.esReservable())
                {
                    DatosTurno tur = cadaTurno.MostrarTurno();
                    datos.Add(tur);
                    System.Diagnostics.Debug.WriteLine(cadaTurno.ToString());
                }
            }
            return datos;
        }

        public string ToString()
        {
            return this.MostrarMarcaYModelo()[1] + " " + this.MostrarMarcaYModelo()[0] + " - Inventario " + this.MostrarNroInventario();
        }
    }
}
