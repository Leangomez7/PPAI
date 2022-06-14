using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.ReservaTurnoRT;
using System.Data;

namespace PPAI.Entidades
{
    public class GestorReservaTurnoRT
    {
        private List<TipoRT> tiposRT;
        private List<RecursoTecnologico> recursos;
        private List<CentroInvestigacion> investigaciones;
        private List<Marca> marcas;
        private List<Modelo> modelos;
        private Sesion actual;
        PantallaReservaTurnoRT? pantalla;
        
        public GestorReservaTurnoRT(Sesion sesion)
        {
            tiposRT = new List<TipoRT>();
            recursos = new List<RecursoTecnologico>();
            investigaciones = new List<CentroInvestigacion>();
            marcas = new List<Marca>();
            modelos = new List<Modelo>();
            actual = sesion;
        }
        public void setPantalla(PantallaReservaTurnoRT pant)
        {
            pantalla = pant;
        }
        public void GenerarCentros()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                string nombre = "Centro de ";
                string[] campos = new string[] {"Astronomía", "Computación", "Redes", "Física", "Química", "Biología" };
                string[] facultades = new string[] { "FAMAF", "FCEFYN", "FCYR", "FCN", "FCQ" };
                int camp = rnd.Next(0, campos.Count());
                nombre += campos[camp] + " - " + facultades[rnd.Next(0, facultades.Count())];
                CentroInvestigacion cen = new CentroInvestigacion(nombre, campos[camp].Substring(0, 3));
                //cen.AgregarCientifico(actual.ObtenerCientificoLoggeado());
                investigaciones.Add(cen);
            }
        }
        public void GenerarMarcas()
        {
            marcas.Add(new Marca("Shidmazu"));
            marcas.Add(new Marca("Nikon"));
            marcas.Add(new Marca("Zeis"));
            marcas.Add(new Marca("Leica"));
            marcas.Add(new Marca("Olympus"));
            marcas.Add(new Marca("Meiji Techno"));
            marcas.Add(new Marca("Motic"));
            marcas.Add(new Marca("GE"));
        }
        public void GenerarModelos()
        {
            string weas = "ABCDEFGHIJKLMNOPRSTUVWXYZ1234567890-";
            Random rnd = new Random();
            int cant = rnd.Next(30, 60);
            for (int i = 0; i < cant; i++)
            {
                string nom = "";
                int len = rnd.Next(7, 13);
                for (int j = 0; j < len; j++)
                {
                    int ind = 0;
                    if (j != 0 && j != len-1)
                    {
                        ind = rnd.Next(0, weas.Length);
                    }
                    else
                    {
                        ind = rnd.Next(0, weas.Length-1);
                    }
                    nom += weas[ind];
                }
                int indmar = rnd.Next(0, marcas.Count());
                Marca mar = marcas[indmar];
                modelos.Add(new Modelo(nom, mar));
            }
        }
        public void GenerarRT()
        {
            //TODO: volver fraccionamiento a random? Cambiar
            for (int i = 0; i < 40; i++)
            {
                Random rd = new Random();
                bool existe = true;
                int nroInv = 0;
                while (existe)
                {
                    existe = false;
                    nroInv = rd.Next(1300, 21300);
                    foreach (RecursoTecnologico rec in recursos)
                    {
                        if (rec.MostrarNroInventario() == nroInv)
                        {
                            existe = true;
                            break;
                        }
                    }
                }                
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                DateTime fec = start.AddDays(rd.Next(range));
                int per = rd.Next(10, 20);
                int dur = rd.Next(10, 20);
                int fra = 360;
                //int fra = rd.Next(10, 20);
                int indtip = rd.Next(0, tiposRT.Count());
                Modelo mod = modelos[rd.Next(0, modelos.Count())];
                int cen = rd.Next(0, investigaciones.Count());
                recursos.Add(new RecursoTecnologico(nroInv, fec, per, dur, fra, tiposRT[indtip], mod, investigaciones[cen]));
            }
        }
        public void GenerarTiposRT()
        {
            string[] nombres = new string[5] {"Microscopio", "Balanza", "Resonador", "Cómputo", "EMSU" };
            string[] desc = new string[5] {"Microscopio", "Balanza de Precisión", "Resonador Magnético", "Equipamiento de Cómputo Datos de Alto Rendimiento", "Equipamiento Motor Sintético Universal" };
            for (int i = 0; i < nombres.Length; i++)
            {
                TipoRT tipoc = new TipoRT(nombres[i], desc[i]);
                tiposRT.Add(tipoc);
            }
        }

        public void NewReservaRT()
        {
            GenerarMarcas();
            GenerarModelos();
            GenerarTiposRT();
            GenerarCentros();
            GenerarRT();
            DataTable dt = ObtenerTipoRT();
            DataRow row = dt.NewRow();
            row["TipoRT"] = null;
            row["NombreTipo"] = "Todos";
            dt.Rows.InsertAt(row, 0);
            pantalla.PedirSeleccionTipoRT(dt);
        }
        
        public DataTable ObtenerTipoRT()
        {
            DataTable dataTable = new DataTable();
            DataColumn column = new DataColumn();

            column.DataType = typeof(TipoRT);
            column.ColumnName = "TipoRT";
            dataTable.Columns.Add(column);

            column = new DataColumn();

            column.DataType = typeof(string);
            column.ColumnName = "NombreTipo";
            dataTable.Columns.Add(column);

            foreach (TipoRT tipoRT in tiposRT)
            {
                DataRow row = dataTable.NewRow();
                row["TipoRT"] = tipoRT;
                row["NombreTipo"] = tipoRT.MostrarTipoRecurso();
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        public void TipoRTSeleccionado(TipoRT? tipoRT)
        {
            List<DatosRT> datos = ObtenerRTActivoDeTipoRT(tipoRT);
            datos = OrdenarYAgruparPorCI(datos);
            pantalla.PedirSeleccionRT(datos);
        }
        public List<DatosRT> ObtenerRTActivoDeTipoRT(TipoRT? tipoRT)
        {
            List<RecursoTecnologico> recursosActivos = new List<RecursoTecnologico>();
            List<DatosRT> datos = new List<DatosRT>();
            foreach (RecursoTecnologico RT in recursos)
            {
                if (RT.EsDeTipoRT(tipoRT))
                {
                    if (RT.EsActivo())
                    {
                        recursosActivos.Add(RT);
                    }
                }
            }
            foreach (RecursoTecnologico recAc in recursosActivos)
            {
                DatosRT datosRT = recAc.MostrarRT();
                datos.Add(datosRT);
            }
            return datos;
        }

        public void TomarSeleccionRT(RecursoTecnologico rt)
        {
            bool ver = VerificarCIdeCientificoLoggeado(rt);
            List<DatosTurno> turnos = obtenerTurnosReservablesRTSeleccionado(rt);
            pantalla.PedirSeleccionDeTurno(turnos, rt.MostrarRT());
        }

        public bool VerificarCIdeCientificoLoggeado(RecursoTecnologico rt)
        {
            PersonalCientifico cientifico = actual.ObtenerCientificoLoggeado();
            bool pertenece = rt.EsDeMiCentroInvestigacion(cientifico);
            return pertenece;
        }

        public List<DatosRT> OrdenarYAgruparPorCI(List<DatosRT> datos)
        {
            datos.Sort((s1, s2) => s1.ci.CompareTo(s2.ci));
            return datos;
        }
        
        public List<DatosTurno> obtenerTurnosReservablesRTSeleccionado(RecursoTecnologico rt)
        {
            List<DatosTurno> turnos = new List<DatosTurno>();
            DateTime fecha = DateTime.Now;
            turnos = rt.MostrarTurnos(fecha);
            turnos = AgruparYOrdenarTurnosPorFecha(turnos);
            return turnos;
        }

        public List<DatosTurno> AgruparYOrdenarTurnosPorFecha(List<DatosTurno> turnos)
        {
            turnos.Sort((s1, s2) => s1.fechaHoraInicio.CompareTo(s2.fechaHoraInicio));
            return turnos;
        }

        public void ReservarTurnoRT(Turno tur, DatosRT rt)
        {
            Estado? res = ObtenerEstadoReservado();
            rt.rt.ReservarTurno(tur, res);
            PersonalCientifico loggeado = actual.ObtenerCientificoLoggeado();
            loggeado.SetTurno(tur);
            string correo = loggeado.tomarCorreoInstitucional();
        }
        public Estado? ObtenerEstadoReservado()
        {
            var est = Enum.GetValues(typeof(Estado));
            foreach (Estado estado in est)
            {
                if (estado.esAmbitoTurno() && estado.esReservado())
                {
                    return estado;
                }
            }
            return null;
        }
    }
}
