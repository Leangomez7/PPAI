using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.ReservaTurnoRT;
using System.Data;
using PPAI.Entidades;
using PPAI.Boundary.ReservaTurno;
using static PPAI.Program;
using System.Data.Entity;

namespace PPAI.Control
{
    public class GestorReservaTurnoRT
    {
        private List<IObserverTurno> observadores;
        private DbSet<TipoRT> tiposRT;
        private DbSet<RecursoTecnologico> recursos;
        private DbSet<CentroInvestigacion> investigaciones;
        private DbSet<Marca> marcas;
        private DbSet<Modelo> modelos;
        /*private List<TipoRT> tiposRT;
        private List<RecursoTecnologico> recursos;
        private List<CentroInvestigacion> investigaciones;
        private List<Marca> marcas;
        private List<Modelo> modelos;*/
        private Sesion actual;
        PantallaReservaTurnoRT? pantalla;
        private string rtstring;
        private string turnostring;
        private string mail;
        private string num;
        private RecursoTecnologico seleccionado;
        private Turno turno;
        private PersonalCientifico loggeado;
        private PersistenciaContext db = new PersistenciaContext();

        /// <summary>
        /// Agrega a un suscriptor a la lista de suscriptores
        /// </summary>
        /// <param name="o">observador a agregar</param>
        public void suscribir(IObserverTurno o)
        {
            foreach (IObserverTurno obs in observadores)
            {
                if (o.GetType() == obs.GetType()) return;
            }
            observadores.Add(o);
        }

        /// <summary>
        /// Elimina a un suscriptor de la lista
        /// </summary>
        /// <param name="o">suscriptor a eliminar</param>
        public void quitar(IObserverTurno o)
        {
            observadores.Remove(o);
        }

        /// <summary>
        /// Notifica a todos los sucriptores que están en la lista
        /// </summary>
        public void notificar()
        {
            foreach (IObserverTurno o in observadores)
            {
                o.notificar(this.num, this.mail, this.rtstring, this.turnostring);
            }
        }

        /// <summary>
        /// Constructor por defecto, toma una Sesion que será la sesión usada
        /// </summary>
        /// <param name="sesion">sesion a ser usada</param>
        public GestorReservaTurnoRT(Sesion sesion)
        {
            // Inicializar listas
            /*tiposRT = new List<TipoRT>();
            recursos = new List<RecursoTecnologico>();
            investigaciones = new List<CentroInvestigacion>();
            marcas = new List<Marca>();
            modelos = new List<Modelo>();
            GenerarMarcas();
            GenerarModelos();
            GenerarTiposRT();
            GenerarCentros();
            GenerarRT();*/
            observadores = new List<IObserverTurno>();
            actual = sesion;
            
            tiposRT = db.tipoRT;
            recursos = db.recursoTecnologico;
            investigaciones = db.centroInvestigacion;
            marcas = db.marca;
            modelos = db.modelo;


            /*
            var query = from b in db.recursoTecnologico select b;

            foreach (var item in query) recursos.Add(item);*/
            
            /*
            tiposRT = new List<TipoRT>(db.tipoRT);
            recursos = new List<RecursoTecnologico>(db.recursoTecnologico);
            investigaciones = new List<CentroInvestigacion>(db.centroInvestigacion);
            marcas = new List<Marca>(db.marca);
            modelos = new List<Modelo>(db.modelo);*/

            /*foreach (Marca marca in marcas) db.marca.Add(marca);
            foreach (Modelo modelo in modelos) db.modelo.Add(modelo);
            foreach (TipoRT tipo in tiposRT) db.tipoRT.Add(tipo);
            foreach (CentroInvestigacion ci in investigaciones) db.centroInvestigacion.Add(ci);
            foreach (RecursoTecnologico rt in recursos) db.recursoTecnologico.Add(rt);*/
            db.SaveChanges();
        }

        /// <summary>
        /// Pedirle a la pantalla la selección de Tipo RT 
        /// </summary>
        public void NewReservaRT()
        {
            DataTable dt = ObtenerTipoRT();
            DataRow row = dt.NewRow();
            row["TipoRT"] = null;
            row["NombreTipo"] = "Todos";
            dt.Rows.InsertAt(row, 0);
            pantalla.PedirSeleccionTipoRT(dt);
        }

        /// <summary>
        /// Guardar la pantalla en un atributo, para poder utilizar sus métodos
        /// </summary>
        /// <param name="pant"></param>
        public void setPantalla(PantallaReservaTurnoRT pant)
        {
            pantalla = pant;
        }

        /// <summary>
        /// Obtiene una tabla con todos los Tipos de RT, para usarse al mostrar en pantalla
        /// </summary>
        /// <returns>DataTable de TiposRT</returns>
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

        /// <summary>
        /// Toma selección de TipoRT, y pide selección de un recurso a la pantalla
        /// </summary>
        /// <param name="tipoRT">Tipo RT seleccionado</param>
        public void TipoRTSeleccionado(TipoRT? tipoRT)
        {
            List<DatosRT> datos = ObtenerRTActivoDeTipoRT(tipoRT);
            datos = OrdenarYAgruparPorCI(datos);
            pantalla.PedirSeleccionRT(datos);
        }

        /// <summary>
        /// Devuelve una Lista de Datos de Recurso Tecnológico de los recursos de un Tipo
        /// </summary>
        /// <param name="tipoRT">Tipo de recurso a buscar</param>
        /// <returns>Lista de DatosRT</returns>
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

        /// <summary>
        /// Toma la selección de un RT, verifica si el científico pertenece a su CI y pide la selección del turno a la pantalla
        /// </summary>
        /// <param name="rt">Recurso Tecnológico seleccionado</param>
        public void TomarSeleccionRT(RecursoTecnologico rt)
        {
            bool ver = VerificarCIdeCientificoLoggeado(rt);
            seleccionado = rt;
            List<DatosTurno> turnos = obtenerTurnosReservablesRTSeleccionado(rt);
            pantalla.PedirSeleccionDeTurno(turnos, rt.MostrarRT());
        }

        /// <summary>
        /// Verifica si el Científico loggeado pertenece al CI de un Recurso pasado como parámetro
        /// </summary>
        /// <param name="rt">Recurso a comprobar</param>
        /// <returns>true si pertenece, false si no</returns>
        public bool VerificarCIdeCientificoLoggeado(RecursoTecnologico rt)
        {
            PersonalCientifico cientifico = actual.ObtenerCientificoLoggeado();
            bool pertenece = rt.EsDeMiCentroInvestigacion(cientifico);
            return pertenece;
        }

        /// <summary>
        /// Ordena una lista de DatosRT según su Centro de Investigación
        /// </summary>
        /// <param name="datos">Lista a ordenar</param>
        /// <returns>Lista ordenada</returns>
        public List<DatosRT> OrdenarYAgruparPorCI(List<DatosRT> datos)
        {
            datos.Sort((s1, s2) => s1.ci.CompareTo(s2.ci));
            return datos;
        }

        /// <summary>
        /// Obtiene los turnos reservables de un RT seleccionado
        /// </summary>
        /// <param name="rt">RT seleccionado</param>
        /// <returns>Lista de DatosTurno de los turnos reservables</returns>
        public List<DatosTurno> obtenerTurnosReservablesRTSeleccionado(RecursoTecnologico rt)
        {
            List<DatosTurno> turnos = new List<DatosTurno>();
            DateTime fecha = DateTime.Now;
            turnos = rt.MostrarTurnos(fecha);
            turnos = AgruparYOrdenarTurnosPorFecha(turnos);
            return turnos;
        }

        /// <summary>
        /// Ordena una lista de turnos por fecha
        /// </summary>
        /// <param name="turnos">Lista a ordenar</param>
        /// <returns>Lista ordenada</returns>
        public List<DatosTurno> AgruparYOrdenarTurnosPorFecha(List<DatosTurno> turnos)
        {
            turnos.Sort((s1, s2) => s1.fechaHoraInicio.CompareTo(s2.fechaHoraInicio));
            return turnos;
        }

        /// <summary>
        /// Obtiene datos del turno para después usarlos en la notificación de reserva
        /// </summary>
        private void ObtenerDatosTurno()
        {
            rtstring = seleccionado.getNombre();
            turnostring = turno.getStringHorarios();
        }

        /// <summary>
        /// Obtiene el correo del científico loggeado al que mandar el mail
        /// </summary>
        private void ObtenerCorreoCientifico()
        {
            mail = loggeado.tomarCorreoInstitucional();
        }

        /// <summary>
        /// Obtiene el número de teléfono del científico loggeado al que mandar el mensaje
        /// </summary>
        private void ObtenerNumeroCientifico()
        {
            num = loggeado.tomarTelefono();
        }

        /// <summary>
        /// Reserva un Turno y notifica a los observadores necesarios
        /// </summary>
        /// <param name="tur">turno a reservar</param>
        /// <param name="rt">recurso tecnológico para el cual reservar</param>
        /// <param name="medios">lista de medios de notificación por los cuales notificar</param>
        public void ReservarTurnoRT(Turno tur, DatosRT rt, List<int> medios)
        {
            Estado res = ObtenerEstadoReservado();
            rt.rt.ReservarTurno(tur, res);
            loggeado = actual.ObtenerCientificoLoggeado();
            loggeado.SetTurno(tur);
            turno = tur;
            foreach (int med in medios)
            {
                IObserverTurno obs = IObserverTurno.crear((Medio)med);
                this.suscribir(obs);
            }
            ObtenerDatosTurno();
            ObtenerCorreoCientifico();
            ObtenerNumeroCientifico();
            this.notificar();
        }

        /// <summary>
        /// Obtiene el Estado Reservado para después setearlo al Turno
        /// </summary>
        /// <returns>Estado reservado</returns>
        public Estado ObtenerEstadoReservado()
        {
            return Estado.TurnoReservado;
        }
        /*
        public void GenerarCentros()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                string nombre = "Centro de ";
                string[] campos = new string[] { "Astronomía", "Computación", "Redes", "Física", "Química", "Biología" };
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
                    if (j != 0 && j != len - 1)
                    {
                        ind = rnd.Next(0, weas.Length);
                    }
                    else
                    {
                        ind = rnd.Next(0, weas.Length - 1);
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
            string[] nombres = new string[5] { "Microscopio", "Balanza", "Resonador", "Cómputo", "EMSU" };
            string[] desc = new string[5] { "Microscopio", "Balanza de Precisión", "Resonador Magnético", "Equipamiento de Cómputo Datos de Alto Rendimiento", "Equipamiento Motor Sintético Universal" };
            for (int i = 0; i < nombres.Length; i++)
            {
                TipoRT tipoc = new TipoRT(nombres[i], desc[i]);
                tiposRT.Add(tipoc);
            }
        }
        */
    }
}
