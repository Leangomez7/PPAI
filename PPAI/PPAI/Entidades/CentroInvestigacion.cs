using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class CentroInvestigacion
    {
        private string nombre;
        private string sigla;
        /*private string direccion;
        private string edificio;
        private string piso;
        private float[] coordenadas;
        private int telefono;
        private string correo;
        private int nroResolucion;
        private DateTime fechaResolucion;
        private string reglamento;
        private string caracteristicas;
        private DateTime fechaAlta;
        private DateTime fechaBaja;
        private int tiempoReserva;
        private string motivoBaja;
        private List<AsignacionDirectorCI> director;
        private List<AsignacionCientificoCI> cientificos;
        private List<RecursoTecnologico> recursosTecnologicos;       

        */

        public CentroInvestigacion(string nom, string sig)
        {
            nombre = nom;
            sigla = sig;
        }
        public string getNombre()
        {
            return nombre;
        }
        /*
        public bool EsTuCientificoActivo(PersonalCientifico cientifico)
        {
            foreach (AsignacionCientificoCI asignacionCientifico in cientificos)
            {
                if (asignacionCientifico.esCientificoActivo(cientifico))
                {
                    return true;
                }
            }
            return false;
        }
        */
    }
}
