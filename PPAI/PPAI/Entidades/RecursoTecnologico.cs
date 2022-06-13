﻿using System;
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
        private int FraccionHorarioTurnos;
        private List<CambioEstadoRT> cambioEstadoRT;
        private List<Turno> turnos;
        private TipoRT tipoRT;
        private Modelo modelo;
        private CentroInvestigacion? centroInvestigacion;
       
        public bool EsDeTipoRT(TipoRT tipoRecTec)
        {
            if (tipoRecTec == tipoRT)
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
            string marc = MostrarMarcaYModelo()[0];
            string mod = MostrarMarcaYModelo()[1];
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
        public bool EsDeMiCentroInvestigacion(PersonalCientifico cientifico)
        {
            return centroInvestigacion.EsTuCientificoActivo(cientifico);
        }
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
