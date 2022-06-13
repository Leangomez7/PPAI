﻿using System;
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
        private List<Marca> marcas;
        private List<Modelo> modelos;
        private Modelo mod1;
        PantallaReservaTurnoRT pantalla;

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
                investigaciones.Add(new CentroInvestigacion(nombre, campos[camp].Substring(0, 3)));
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
            for (int i = 0; i < 10000; i++)
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
                int fra = rd.Next(10, 20);
                int indtip = rd.Next(0, tiposRT.Count());
                Modelo mod = modelos[rd.Next(0, modelos.Count())];
                int cen = rd.Next(0, investigaciones.Count());
                recursos.Add(new RecursoTecnologico(nroInv, fec, per, dur, fra, tiposRT[indtip], mod, investigaciones[cen]));
            }
        }
        public void GenerarTiposRT()
        {
            string[] nombres = new string[5] {"Microscopio", "Balanza", "Resonador", "Cómputo", "emsu" };
            string[] desc = new string[5] {"Microscopio", "Balanza de Precisión", "Resonador Magnético", "Equipamiento de Cómputo Datos de Alto Rendimiento", "xd" };
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
            pantalla.PedirSeleccionTipoRT(dt);
        }
        public GestorReservaTurnoRT(PantallaReservaTurnoRT pantallaReservaTurnoRT)
        {
            pantalla = pantallaReservaTurnoRT;
            tiposRT = new List<TipoRT>();
            recursos = new List<RecursoTecnologico>();
            investigaciones = new List<CentroInvestigacion>();
            marcas = new List<Marca>();
            modelos = new List<Modelo>();
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
        public List<DatosRT> OrdenarYAgruparPorCI(List<DatosRT> datos)
        {
            datos.Sort((s1, s2) => s1.ci.CompareTo(s2.ci));
            return datos;
        }
    }
}
