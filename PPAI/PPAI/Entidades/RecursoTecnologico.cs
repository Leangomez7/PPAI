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

        public void ReservarTurno(Turno tur, Estado? res)
        {
            tur.Reservar(res);

        }

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
            RecursoTecnologico rt = this;
            DatosRT datos = new (nro, est, cenIn, marc, mod, rt);
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

        public bool EsDeMiCentroInvestigacion(PersonalCientifico cien)
        {
            return centroInvestigacion.EsTuCientificoActivo(cien);
        }
        
        public List<DatosTurno> MostrarTurnos(DateTime fec)
        {
            List<DatosTurno> datos = new List<DatosTurno>();
            foreach (Turno cadaTurno in turnos)
            {
                if (cadaTurno.esPosteriorAFecha(fec) && cadaTurno.esReservable())
                {
                    DatosTurno tur = cadaTurno.MostrarTurno();
                    datos.Add(tur);
                    System.Diagnostics.Debug.WriteLine(cadaTurno.TurnoToString());
                }
            }
            return datos;
        }
    }
}
