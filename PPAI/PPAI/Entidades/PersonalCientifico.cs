using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class PersonalCientifico
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private int nroDocumento;
        private string correoInstitucional;
        private string correoPersonal;
        private int telefono;
        private Usuario usuario;

        public string tomarCorreoPersonal()
        {
            return correoPersonal;
        }
        public string tomarCorreoInstitucional()
        {
            return correoInstitucional;
        }
    }
}
