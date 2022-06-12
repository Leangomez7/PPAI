using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class RecursoTecnologico
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
        public bool esActivo()
        {
            return true;
        }
        public RecursoTecnologico mostrarRT()
        {
            return this;
        }
        public void habilitar()
        {
        } 
        public void conocerCategoria()
        {
        } 
        public void conocerCaracteristicaRecurso()
        {
        } 
        public void MiModeloYMarca()
        {
        } 
        public void nuevoMantenimientoPreventivo()
        {
        } 
        public void misTurnosDisponibles()
        {
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
        public void mostrarMarcaYmodelo()
        {

        } 
        public List<Turno> mostrarTurnos()
        {
            return turnos;
        } 
        public void reservarTurno()
        {
        } 
    }
}
