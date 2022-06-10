using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class CentroInvestigacion
    {
        public string nombre;
        public string sigla;
        public string direccion;
        public string edificio;
        public string piso;
        public float[] coordenadas;
        public int telefono;
        public string correo;
        public int nroResolucion;
        public DateTime fechaResolucion;
        public string reglamento;
        public string caracteristicas;
        public DateTime fechaAlta;
        public DateTime fechaBaja;
        public int tiempoReserva;
        public string motivoBaja;
        //public List<AsignacionDirectorCI> director;
        public List<AsignacionCientificoCI> cientificos;
        private List<RecursoTecnologico> recursosTecnologicos;

        /*
        public RecursoTecnologico(string nom)
        {
            nombre = nom;
            recursosTecnologicos = new List<RecursoTecnologico>();
        }
        */
        public CentroInvestigacion mostrarCI()
        {
            return this;
        }
        /*
        public PersonalCientifico miDirectorActual()
        {
            //
        }
        public List<PersonalCientifico> misDirectores()
        {
            //
        }
        */
        public bool estoyActivo()
        {
            if (fechaBaja > DateTime.Now)
            {
                return true;
            }
            return false;
        }
        public List<PersonalCientifico> misCientificosActivos()
        {
            List<PersonalCientifico> cientificosActivos = new();
            foreach (AsignacionCientificoCI cientifico in cientificos)
            {
                if (cientifico.esCientificoActivo())
                {
                    cientificosActivos.Add(cientifico.cientifico);
                }
            }
            return cientificosActivos;
            
        }
        /*
        public List<RecursoTecnologico> misRecursosActivos()
        {
            List<RecursoTecnologico> recursosActivos = new();
            foreach (RecursoTecnologico recurso in recursosTecnologicos)
            {
                if (recurso.esActivo())
                {
                    recursosActivos.Add(recurso);
                }
            }
            return recursosActivos;
        }
        public List<RecursoTecnologico> misRecursosTecnologicos()
        {
            List<RecursoTecnologico> recursosActivos = new();
            foreach (RecursoTecnologico recurso in recursosTecnologicos)
            {
                recursosActivos.Add(recurso);
            }
            return recursosActivos;
        }
        */
        public string miBaja()
        {
            return motivoBaja;
        }
        public string getNombre()
        {
            return nombre;
        }
        public bool esTuCientificoActivo(PersonalCientifico cientifico)
        {
            List<PersonalCientifico> listaCientificos = misCientificosActivos();
            return listaCientificos.Contains(cientifico);
        }
    }
}
