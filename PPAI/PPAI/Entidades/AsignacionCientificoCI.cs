using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class AsignacionCientificoCI
    {
        public DateTime fechaDesde = DateTime.Now;
        public DateTime fechaHasta;
        public PersonalCientifico cientifico;

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
        public string obtenerCorreoCientifico()
        {
            return cientifico.correoPersonal;
        }
    }
}
