using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class AsignacionCientificoCI
    {
        private DateTime fechaDesde = DateTime.Now;
        private DateTime fechaHasta;
        private PersonalCientifico cientifico;
        private List<Turno> turnos;

        public PersonalCientifico mostrarPersonalCientifico()
        {
            return cientifico;
        }
        public bool esCientificoActivo()
        {
            if (fechaHasta < DateTime.Now)
            {
                return true;
            }
            return false;
        }
        public void setTurno(Turno turno)
        {
            turnos.Add(turno);
        }
        public List<Turno> misTurnos()
        {
            return turnos;
        }
        public string obtenerCorreoPersonalCientifico()
        {
            return cientifico.tomarCorreoPersonal();
        }
        public string obtenerCorreoInstitucionalCientifico()
        {
            return cientifico.tomarCorreoInstitucional();
        }
    }
}
