using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.ReservaTurnoRT;
using System.Data;

namespace PPAI.Entidades
{
    internal class GestorReservaTurnoRT
    {
        private List<TipoRT> tiposRT;
        private List<RecursoTecnologico> recursos;
        private List<CentroInvestigacion> investigaciones;
        private Modelo mod1;
        PantallaReservaTurnoRT pantalla;


        public void Centros()
        {
            investigaciones.Add(new CentroInvestigacion("CentroMessi", "CEM"));
            investigaciones.Add(new CentroInvestigacion("CentroPou", "CEP"));
        }
        public void GenerarRT()
        {
            Marca marca1 = new Marca("Tomaselli");
            mod1 = new Modelo("Messi", marca1);
            for (int i = 0; i < 20; i++)
            {
                Random rd = new Random();
                int nroInv = rd.Next(1500, 2100);
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                DateTime fec = start.AddDays(rd.Next(range));
                int per = rd.Next(10, 20);
                int dur = rd.Next(10, 20);
                int fra = rd.Next(10, 20);
                int indtip = rd.Next(0, tiposRT.Count());
                Modelo mod = mod1;
                int cen = rd.Next(0, investigaciones.Count());
                recursos.Add(new RecursoTecnologico(nroInv, fec, per, dur, fra, tiposRT[indtip], mod, investigaciones[cen]));
            }
        }
        public void GenerarTiposRT()
        {
            string[] nombres = new string[5] {"messi", "pou", "farre", "papai", "emsu" };
            string[] desc = new string[5] {"xd", "aaa", "anashe", "pou", "xd" };
            for (int i = 0; i < nombres.Length; i++)
            {
                TipoRT tipoc = new TipoRT(nombres[i], desc[i]);
                tiposRT.Add(tipoc);
            }
        }

        public void NewReservaRT()
        {
            GenerarTiposRT();
            Centros();
            GenerarRT();
            DataTable dt = ObtenerTipoRT();
            pantalla.PedirSeleccionTipoRT(dt);
        }
        public GestorReservaTurnoRT(PantallaReservaTurnoRT pantallaReservaTurnoRT)
        {
            pantalla = pantallaReservaTurnoRT;
            tiposRT = new List<TipoRT>();
            recursos = new List<RecursoTecnologico>();
            investigaciones = new List<CentroInvestigacion>();
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
        public void TipoRTSeleccionado(TipoRT tipoRT)
        {
            List<DatosRT> datos = ObtenerRTActivoDeTipoRT(tipoRT);
            datos = OrdenarYAgruparPorCI(datos);
            pantalla.PedirSeleccionRT(datos);
        }
        public List<DatosRT> ObtenerRTActivoDeTipoRT(TipoRT tipoRT)
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
        public List<DatosRT> OrdenarYAgruparPorCI(List<DatosRT> datos)
        {
            datos.Sort((s1, s2) => s1.ci.CompareTo(s2.ci));
            return datos;
        }
    }
}
