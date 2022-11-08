using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class CentroInvestigacion
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string sigla { get; set; }
        public List<AsignacionCientificoCI> cientificos { get; set; } = new List<AsignacionCientificoCI>();
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

        public void AgregarCientifico(PersonalCientifico per)
        {
            cientificos.Add(new AsignacionCientificoCI(per));
        }

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
    }
}