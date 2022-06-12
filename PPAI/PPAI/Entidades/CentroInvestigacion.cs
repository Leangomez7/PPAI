using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class CentroInvestigacion
    {
        private string nombre;
        private string sigla;
        private string direccion;
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
        public List<PersonalCientifico> misCientificos()
        {
            List<PersonalCientifico> cientificosActivos = new();
            foreach (AsignacionCientificoCI cientifico in cientificos)
            {
                cientificosActivos.Add(cientifico.mostrarPersonalCientifico());
            }
            return cientificosActivos;

        }
        public List<PersonalCientifico> misCientificosActivos()
        {
            List<PersonalCientifico> cientificosActivos = new();
            foreach (AsignacionCientificoCI cientifico in cientificos)
            {
                if (cientifico.esCientificoActivo())
                {
                    cientificosActivos.Add(cientifico.mostrarPersonalCientifico());
                }
            }
            return cientificosActivos;
            
        }        
        public List<RecursoTecnologico> MisRecursosActivos()
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
