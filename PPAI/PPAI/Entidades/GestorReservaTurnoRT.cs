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
        PantallaReservaTurnoRT pantalla;
        public void NewReservaRT()
        {
            DataTable dt = ObtenerTipoRT();
            pantalla.PedirSeleccionTipoRT(dt);
        }
        public GestorReservaTurnoRT(PantallaReservaTurnoRT pantallaReservaTurnoRT)
        {
            pantalla = pantallaReservaTurnoRT;
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
            List<RecursoTecnologico> recursos = new List<RecursoTecnologico>();
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
