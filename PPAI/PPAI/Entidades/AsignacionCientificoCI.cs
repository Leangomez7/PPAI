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
        private DateTime? fechaHasta;
        private PersonalCientifico cientifico;
        private List<Turno> turnos;

        public AsignacionCientificoCI(PersonalCientifico cient)
        {
            cientifico = cient;
            turnos = new List<Turno>();
        }

        public bool esCientificoActivo(PersonalCientifico personalCientifico)
        {
            if (fechaHasta is null && cientifico == personalCientifico)
            {
                return true;
            }
            return false;
        }
        public void setTurno(Turno turno)
        {
            turnos.Add(turno);
        }
        public string obtenerCorreoInstitucionalCientifico()
        {
            return cientifico.tomarCorreoInstitucional();
        }
        public string obtenerCorreoPersonalCientifico()
        {
            return cientifico.tomarCorreoPersonal();
        }
    }
}
