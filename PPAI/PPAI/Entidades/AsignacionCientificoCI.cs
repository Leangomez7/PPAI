using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class AsignacionCientificoCI
    {
        private DateTime fechaDesde = DateTime.Now;
        private DateTime fechaHasta;
        private PersonalCientifico cientifico;

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
        public void setTurno()
        {
            //
        }
        public void misTurnos()
        {
            //
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
